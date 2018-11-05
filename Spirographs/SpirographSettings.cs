//////////////////////////////////////////////////////////////////////////////
//
// SpirographSettings.cs
// The set of values used to draw a spriograph.
// Copyright (C) 2016 - W.Wonneberger
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
using System.Windows.Media;

namespace Spirographs
{
    public sealed class SpirographSettings
    {
        #region SpirographSettings Class Constant Definitions

        private static readonly int DefaultA = 120;
        private static readonly int DefaultB = 32;
        private static readonly int DefaultC = 100;
        private static readonly int DefaultIterations = 200;
        private static readonly Color DefaultForegroundColor = Colors.White;
        private static readonly Color DefaultBackgroundColor = Colors.DodgerBlue;
        private static readonly double DefaultLineWidth = 1.25D;

        #endregion SpirographSettings Class Constant Definitions

        #region SpirographSettings Data Members & Auto Properties

        public int A { get; private set; }

        public int B { get; private set; }

        public int C { get; private set; }

        public int Iter { get; private set; }

        public Color ForegroundColor { get; private set; }

        public Color BackgroundColor { get; private set; }

        public Double StrokeThickness { get; private set; }

        #endregion SpirographSettings Data Members & Auto Properties

        #region SpirographSettings Class Constructors

        public SpirographSettings(int a, int b, int c, int iter, 
                                  Color foregroundColor, Color backgroundColor,
                                  double strokeThickness)
        {
            A = a;
            B = b;
            C = c;
            Iter = iter;

            ForegroundColor = foregroundColor;
            BackgroundColor = backgroundColor;
            StrokeThickness = strokeThickness;
        }

        public SpirographSettings(SpirographSettings previousSettings) :
               this(previousSettings.A, previousSettings.B, previousSettings.C,
                    previousSettings.Iter, previousSettings.ForegroundColor,
                    previousSettings.BackgroundColor, previousSettings.StrokeThickness)
        {

        }

        #endregion SpirographSettings Class Constructor

        #region SpirographSettings Class Implemenetation

        public int Radius
        {
            get
            {
                return A + C - B;
            }
        }

        public bool  IsSpirographRadiusLarger(double width)
        {
            return (Convert.ToDouble(Radius) > width);
        }

        internal static SpirographSettings DefaultSettings
        {
            get
            {
                return new SpirographSettings(DefaultA, DefaultB, DefaultC, DefaultIterations,
                                              DefaultForegroundColor, DefaultBackgroundColor,
                                              DefaultLineWidth);
            }
        }

        #endregion SpirographSettings Class Implemenetation
    }
}
