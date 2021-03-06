﻿/*************************************************************************
 *     This file & class is part of the StarMath Project
 *     Copyright 2010, 2011 Matthew Ira Campbell, PhD.
 *
 *     StarMath is free software: you can redistribute it and/or modify
 *     it under the terms of the GNU General internal License as published by
 *     the Free Software Foundation, either version 3 of the License, or
 *     (at your option) any later version.
 *  
 *     StarMath is distributed in the hope that it will be useful,
 *     but WITHOUT ANY WARRANTY; without even the implied warranty of
 *     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *     GNU General internal License for more details.
 *  
 *     You should have received a copy of the GNU General internal License
 *     along with StarMath.  If not, see <http://www.gnu.org/licenses/>.
 *     
 *     Please find further details and contact information on StarMath
 *     at http://starmath.codeplex.com/.
 *************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarMathLib
{
    internal static partial class StarMath
    {
        #region Norm Functions
        #region 1-norm (Manhattan Distance)
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the vector, x.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static double norm1(IEnumerable<double> x)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return x.Sum(a => Math.Abs(a));
        }
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the vector, x.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static int norm1(IEnumerable<int> x)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return x.Sum(a => Math.Abs(a));
        }

        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <param name = "y">The vector, y.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static double norm1(IList<double> x, IList<double> y)
        {
            var xlength = x.Count();
            if (x == null) throw new Exception("The vector, x, is null.");
            if (y == null) throw new Exception("The vector, y, is null.");
            if (xlength != y.Count()) throw new Exception("The vectors are not the same size.");
            return norm1(x, y, xlength);
        }
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="y">The vector, y.</param>
        /// <param name="length">The length of the vector.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static double norm1(IList<double> x, IList<double> y, int length)
        {
            var norm = 0.0;
            for (var i = 0; i != length; i++)
                norm += Math.Abs(x[i] - y[i]);
            return norm;
        }

        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <param name = "y">The vector, y.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static int norm1(IList<int> x, IList<int> y)
        {
            var xlength = x.Count();
            if (x == null) throw new Exception("The vector, x, is null.");
            if (y == null) throw new Exception("The vector, y, is null.");
            if (xlength != y.Count()) throw new Exception("The vectors are not the same size.");
            return norm1(x, y, xlength);
        }
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <param name = "y">The vector, y.</param>
        /// <param name="length">The length of the vector.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static int norm1(IList<int> x, IList<int> y, int length)
        {
            var norm = 0;
            for (var i = 0; i != length; i++)
                norm += Math.Abs(x[i] - y[i]);
            return norm;
        }

        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name = "A">The matrix, A.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static double norm1(double[,] A)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return norm1(A, A.GetLength(0), A.GetLength(1));
        }
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name = "A">The matrix, A.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static double norm1(double[,] A, int numRows, int numCols)
        {
            var norm = 0.0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += Math.Abs(A[i, j]);
            return norm;
        }


        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name = "A">The matrix, A.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static int norm1(int[,] A)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return norm1(A, A.GetLength(0), A.GetLength(1));
        }
        /// <summary>
        /// Returns to 1-norm (sum of absolute values of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <returns>Scalar value of 1-norm.</returns>
        internal static int norm1(int[,] A, int numRows, int numCols)
        {
            var norm = 0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += Math.Abs(A[i, j]);
            return norm;
        }

        #endregion

        #region 2-norm (Euclidian Distance)
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="y">The vector, y.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IList<double> x, IList<double> y, Boolean dontDoSqrt = false)
        {
            var xlength = x.Count();
            if (x == null) throw new Exception("The vector, x, is null.");
            if (y == null) throw new Exception("The vector, y, is null.");
            if (xlength != y.Count()) throw new Exception("The vectors are not the same size.");
            return norm2(x, y, xlength, dontDoSqrt);
        }
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="y">The vector, y.</param>
        /// <param name="length">The length of the vectors.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IList<double> x, IList<double> y, int length, Boolean dontDoSqrt = false)
        {
            var norm = 0.0;
            for (var i = 0; i != length; i++)
                norm += (x[i] - y[i]) * (x[i] - y[i]);
            return dontDoSqrt ? norm : Math.Sqrt(norm);
        }


        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="y">The vector, y.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IList<int> x, IList<int> y, Boolean dontDoSqrt = false)
        {
            var xlength = x.Count();
            if (x == null) throw new Exception("The vector, x, is null.");
            if (y == null) throw new Exception("The vector, y, is null.");
            if (xlength != y.Count()) throw new Exception("The vectors are not the same size.");
            return norm2(x, y, xlength, dontDoSqrt);
        }
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the difference between x and y.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="y">The vector, y.</param>
        /// <param name="length">The length of the vectors.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IList<int> x, IList<int> y, int length, Boolean dontDoSqrt = false)
        {
            var norm = 0.0;
            for (var i = 0; i != length; i++)
                norm += (x[i] - y[i]) * (x[i] - y[i]);
            return dontDoSqrt ? norm : Math.Sqrt(norm);
        }

        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the vector, x.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IEnumerable<double> x, Boolean dontDoSqrt = false)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return dontDoSqrt ? x.Sum(a => a * a) : Math.Sqrt(x.Sum(a => a * a));
        }

        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the vector, x.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(IEnumerable<int> x, Boolean dontDoSqrt = false)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return dontDoSqrt ? x.Sum(a => a * a) : Math.Sqrt(x.Sum(a => a * a));
        }


        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(double[,] A, Boolean dontDoSqrt = false)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return norm2(A, A.GetLength(0), A.GetLength(1), dontDoSqrt);
        }
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(double[,] A, int numRows, int numCols, Boolean dontDoSqrt = false)
        {
            var norm = 0.0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += (A[i, j] * A[i, j]);
            return dontDoSqrt ? norm : Math.Sqrt(norm);
        }

        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(int[,] A, Boolean dontDoSqrt = false)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return norm2(A, A.GetLength(0), A.GetLength(1), dontDoSqrt);
        }
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <param name="dontDoSqrt">if set to <c>true</c> [don't take the square root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double norm2(int[,] A, int numRows, int numCols, Boolean dontDoSqrt = false)
        {
            var norm = 0.0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += (A[i, j] * A[i, j]);
            return dontDoSqrt ? norm : Math.Sqrt(norm);
        }
        #endregion

        #region P-norm
        /// <summary>
        /// Returns to p-norm (p-root of the sum of each term raised to the p power)
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of P-norm.</returns>
        internal static double normP(IEnumerable<double> x, double p, Boolean dontDoPRoot = false)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return dontDoPRoot ? x.Sum(a => Math.Pow(a, p)) : Math.Pow(x.Sum(a => a * a), 1 / p);
        }

        /// <summary>
        /// Returns to p-norm (p-root of the sum of each term raised to the p power)
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of P-norm.</returns>
        internal static double normP(IEnumerable<int> x, double p, Boolean dontDoPRoot = false)
        {
            if (x == null) throw new Exception("The vector, x, is null.");
            return dontDoPRoot ? x.Sum(a => Math.Pow(a, p)) : Math.Pow(x.Sum(a => a * a), 1 / p);
        }


        /// <summary>
        /// Returns to p-norm (p-root of the sum of each term raised to the p power)
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of P-norm.</returns>
        internal static double normP(double[,] A, double p, Boolean dontDoPRoot = false)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return normP(A, p, A.GetLength(0), A.GetLength(1), dontDoPRoot);
        }
        /// <summary>
        /// Returns to p-norm (p-root of the sum of each term raised to the p power)
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of P-norm.</returns>
        internal static double normP(double[,] A, double p, int numRows, int numCols, Boolean dontDoPRoot = false)
        {
            var norm = 0.0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += Math.Pow(A[i, j], p);
            return dontDoPRoot ? norm : Math.Pow(norm, 1 / p);
        }

        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double normP(int[,] A, double p, Boolean dontDoPRoot = false)
        {
            if (A == null) throw new Exception("The matrix, A, is null.");
            return normP(A, p, A.GetLength(0), A.GetLength(1), dontDoPRoot);
        }
        /// <summary>
        /// Returns to 2-norm (square root of the sum of squares of all terms)
        /// of the matrix, A.
        /// </summary>
        /// <param name="A">The matrix, A.</param>
        /// <param name="p">The power, p.</param>
        /// <param name="numRows">The number of rows.</param>
        /// <param name="numCols">The number of columns.</param>
        /// <param name="dontDoPRoot">if set to <c>true</c> [don't take the P-root].</param>
        /// <returns>Scalar value of 2-norm.</returns>
        internal static double normP(int[,] A, double p, int numRows, int numCols, Boolean dontDoPRoot = false)
        {
            var norm = 0.0;
            for (var i = 0; i != numRows; i++)
                for (var j = 0; j != numCols; j++)
                    norm += Math.Pow(A[i, j], p);
            return dontDoPRoot ? norm : Math.Pow(norm, 1 / p);
        }
        #endregion

        #endregion

        #region Normalize

        /// <summary>
        /// Returns to normalized vector (has lenght or 2-norm of 1))
        /// of the vector, x.
        /// </summary>
        /// <param name = "x">The vector, x.</param>
        /// <returns>unit vector.</returns>
        internal static double[] normalize(IList<double> x)
        {
            return normalize(x, x.Count());
        }

        /// <summary>
        /// Returns to normalized vector (has lenght or 2-norm of 1))
        /// of the vector, x.
        /// </summary>
        /// <param name="x">The vector, x.</param>
        /// <param name="length">The length of the vector.</param>
        /// <returns>unit vector.</returns>
        internal static double[] normalize(IList<double> x, int length)
        {
            return divide(x, norm2(x), length);
        }

        #endregion

        #region Sum

        /// <summary>
        /// Sum up all the elements of a given matrix
        /// </summary>
        /// <param name = "B">Matrix (1D double) whose parameters need to be summed up</param>
        /// <returns>Returns the total (double) </returns>
        internal static double sum(IEnumerable<double> B)
        {
            return B.Sum();
        }

        /// <summary>
        /// Sum up all the elements of a given matrix
        /// </summary>
        /// <param name = "B">Matrix (1D int) whose parameters need to be summed up</param>
        /// <returns>Returns the total (int) </returns>
        internal static double sum(IEnumerable<int> B)
        {
            return B.Sum();
        }

        /// <summary>
        /// Sum up all the elements of a given matrix
        /// </summary>
        /// <param name = "B">Matrix (2D double) whose parameters need to be summed up</param>
        /// <returns>Returns the total (double) </returns>
        internal static double sum(double[,] B)
        {
            return JoinMatrixColumnsIntoVector(B).Sum();
        }

        /// <summary>
        /// Sum up all the elements of a given matrix
        /// </summary>
        /// <param name = "B">Matrix (2D double) whose parameters need to be summed up</param>
        /// <returns>Returns the total (int) </returns>
        internal static double sum(int[,] B)
        {
            return JoinMatrixColumnsIntoVector(B).Sum();
        }
        #endregion

        #region Standard Deviation
        /// <summary>
        /// Calculates the standard deviation assuming the whole population is provided (not sample st. dev.).
        /// </summary>
        /// <param name="A">An vector of integers, A.</param>
        /// <returns></returns>
        internal static double standardDeviation(IList<int> A)
        {
            var mean = A.Average();
            var variance = A.Sum(a => (a - mean) * (a - mean));
            return Math.Sqrt(variance / A.Count);
        }
        /// <summary>
        /// Calculates the standard deviation assuming the whole population is provided (not sample st. dev.).
        /// </summary>
        /// <param name="A">An vector of doubles, A.</param>
        /// <returns></returns>
        internal static double standardDeviation(IList<double> A)
        {
            var mean = A.Average();
            var variance = A.Sum(a => (a - mean) * (a - mean));
            return Math.Sqrt(variance / A.Count);
        }

        /// <summary>
        /// Calculates the standard deviation assuming the whole population is provided (not sample st. dev.).
        /// </summary>
        /// <param name="A">A matrix in integers, A.</param>
        /// <returns></returns>
        internal static double standardDeviation(int[,] A)
        { return standardDeviation(JoinMatrixColumnsIntoVector(A)); }
        /// <summary>
        /// Calculates the standard deviation assuming the whole population is provided (not sample st. dev.).
        /// </summary>
        /// <param name="A">A matrix in doubles, A.</param>
        /// <returns></returns>
        internal static double standardDeviation(double[,] A)
        { return standardDeviation(JoinMatrixColumnsIntoVector(A)); }

        #endregion
    }
}