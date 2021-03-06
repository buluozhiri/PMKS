﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMKS.VelocityAndAcceleration
{
    internal abstract class EquationBase
    {
        internal int unkLength { get; set; }


        /// <summary>
        /// Captures the unknown indicies.
        /// </summary>
        /// <param name="unknownObjects">The unknown objects.</param>
        internal abstract void CaptureUnknownIndicies(List<object> unknownObjects);
    }
}