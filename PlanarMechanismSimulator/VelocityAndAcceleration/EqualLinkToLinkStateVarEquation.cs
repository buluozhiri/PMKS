﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMKS;

namespace PMKS.VelocityAndAcceleration
{
    /// <summary>
    /// This is for when two links are connected by a P joint. In such a case, 
    /// both links have the same angular velocity and angular acceleration.
    /// </summary>
    internal class EqualLinkToLinkStateVarEquation : EquationBase
    {
        protected readonly Link link1;
        protected int link1Index = -1;
        protected readonly Link link2;
        protected int link2Index = -1;


        internal EqualLinkToLinkStateVarEquation(Link link1, Link link2)
        {
            this.link1 = link1;
            this.link2 = link2;
        }

        internal override void CaptureUnknownIndicies(List<object> unknownObjects)
        {
            var index = 0;
            foreach (var o in unknownObjects)
            {
                if (o == link1) link1Index = index;
                else if (o == link2) link2Index = index;
                if (o is Joint) index += 2;
                else index++;
            }
        }
        internal double[] GetRowCoefficients()
        {
            var coefficients = new double[unkLength];
            for (int i = 0; i < unkLength; i++)
            {
                if (i == link1Index) coefficients[i] = -1;
                else if (i == link2Index) coefficients[i] = 1;
                else coefficients[i] = 0;
            }
            return coefficients;
        }

        internal List<int> GetRowIndices()
        {
            return new List<int> { link1Index, link2Index };
        }
    }
}