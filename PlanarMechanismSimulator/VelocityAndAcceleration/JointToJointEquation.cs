﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PMKS;

namespace PMKS.VelocityAndAcceleration
{
    internal abstract class JointToJointEquation : EquationBase
    {
        protected readonly Joint joint1;
        protected int joint1XIndex = -1;
        protected int joint1YIndex = -1;
        protected readonly Joint joint2;
        protected int joint2XIndex = -1;
        protected int joint2YIndex = -1;
        internal readonly Link link;
        protected int linkIndex = -1;
        protected readonly bool joint1IsKnown;
        protected readonly bool joint2IsKnown;

        protected JointToJointEquation(Joint joint1, Joint joint2, Link link, bool Joint1IsKnown, bool Joint2IsKnown)
        {
            this.joint1 = joint1;
            this.joint2 = joint2;
            this.link = link;
            this.joint1IsKnown = Joint1IsKnown;
            this.joint2IsKnown = Joint2IsKnown;
        }


        internal override void CaptureUnknownIndicies(List<object> unknownObjects)
        {
            var index = 0;
            foreach (var o in unknownObjects)
            {
                if (!joint1IsKnown && o == joint1)
                {
                    joint1XIndex = index;
                    joint1YIndex = index + 1;
                }
                else if (!joint2IsKnown && o == joint2)
                {
                    joint2XIndex = index;
                    joint2YIndex = index + 1;
                }
                else if (o == link) linkIndex = index;
                if (o is Joint) index += 2;
                else index++;
            }
        }

        internal abstract double[] GetRow1Coefficients();
        internal abstract double[] GetRow2Coefficients();
        internal abstract double GetRow1Constant();
        internal abstract double GetRow2Constant();

        internal virtual List<int> GetRow1Indices()
        {
            var indices = new List<int> {joint1XIndex, joint2XIndex, linkIndex};
            indices.RemoveAll(i => i == -1);
           return indices;
        }


        internal virtual List<int> GetRow2Indices()
        {
            var indices = new List<int> { joint1YIndex, joint2YIndex, linkIndex };
            indices.RemoveAll(i => i == -1);
            return indices;
        }

    }

    internal abstract class VelocityJointToJoint : JointToJointEquation
    {
        internal bool linkIsKnown;
        protected VelocityJointToJoint(Joint joint1, Joint joint2, Link link, bool Joint1IsKnown, bool Joint2IsKnown, bool linkIsKnown)
            : base(joint1, joint2, link, Joint1IsKnown, Joint2IsKnown)
        {
            this.linkIsKnown = linkIsKnown;
        }

        internal override double GetRow1Constant()
        {
            var value = 0.0;
            if (joint1IsKnown) value += joint1.vx;
            if (joint2IsKnown) value -= joint2.vx;
            if (linkIsKnown) value -= link.Velocity * (joint2.y - joint1.y);
            return value;
        }
        internal override double GetRow2Constant()
        {
            var value = 0.0;
            if (joint1IsKnown) value += joint1.vy;
            if (joint2IsKnown) value -= joint2.vy;      
            if (linkIsKnown) value -= link.Velocity * (joint1.x - joint2.x);
            return value;
        }
    }
    internal abstract class AccelerationJointToJoint : JointToJointEquation
    {
        protected AccelerationJointToJoint(Joint joint1, Joint joint2, Link link, bool Joint1IsKnown, bool Joint2IsKnown)
            : base(joint1, joint2, link, Joint1IsKnown, Joint2IsKnown) { }

        internal override double GetRow1Constant()
        {
            var value = link.Velocity * link.Velocity * (joint1.x - joint2.x);
            if (joint1IsKnown) value += joint1.ax;
            if (joint2IsKnown) value -= joint2.ax;
            return value;
        }
        internal override double GetRow2Constant()
        {
            var value = link.Velocity * link.Velocity * (joint1.y - joint2.y);
            if (joint1IsKnown) value += joint1.ay;
            if (joint2IsKnown) value -= joint2.ay;
            return value;
        }
    }

}