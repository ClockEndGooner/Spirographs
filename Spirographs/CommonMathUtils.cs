//////////////////////////////////////////////////////////////////////////////
//
// CommonMathUtils.cs 
// Math utility functions for GCD and LCM.
// Copyright (C) 2016 - W. Wonneberger
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//////////////////////////////////////////////////////////////////////////////

using System;

namespace Spirographs
{
    public static class CommonMathUtils
    {
        #region CommonMathUtils Method Implementations 

        //
        // Euclidean algorithm to calculate the greatest 
        // common divisor (GCD) of two number.
        //
        public static long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            bool finished = false;

            while (!finished)
            {
                long remainder = a % b;

                if (remainder == 0)
                {
                    finished = true;
                    continue;
                }

                a = b;
                b = remainder;
            }

            return b;
        }

        //
        // Return the Least Common Multiple (LCM) of two numbers.
        //
        public static long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        #endregion CommonMathUtils Method Implementations 
    }
}
