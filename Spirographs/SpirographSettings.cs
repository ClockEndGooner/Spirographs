
using System;
using System.Text;
using System.Windows.Media;

namespace Spirographs
{
    public sealed class SpirographSettings
    {
        #region SpirographSettings Data Members & Auto Properties

        public int A { get; private set; }

        public int B { get; private set; }

        public int C { get; private set; }

        public int Iter { get; private set; }

        public Color ForegroundColor { get; private set; }

        public Color BackgroundColor { get; private set; }

        public Double StrokeThickness { get; private set; }

        #endregion SpirographSettings Data Members & Auto Properties

        #region SpirographSettings Class Constructor

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

            return;
        }

        #endregion SpirographSettings Class Constructor
    }
}
