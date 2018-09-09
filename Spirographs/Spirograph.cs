//////////////////////////////////////////////////////////////////////////////
//
// Spirograph.cs
// The spirograph or hypotrochoid shape implementation.
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
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spirographs
{
    public sealed class Spirograph
    {
        #region Spirograph Class Constant Definitions

        private readonly double DefaultDPIX = 96d;
        private readonly double DefaultDPIY = 96d;

        #endregion Spirograph Class Constant Definitions

        #region Spirograph Class Data Members

        private int A;
        private int B;
        private int C;
        private int Iterations;
        private double StrokeThickness;

        #endregion Spirograph Class Data Members

        #region Spirograph Class Constructor

        public Spirograph(int a, int b, int c, int iter,
                          double strokeThickness)
        {
            A = a;
            B = b;
            C = c;
            Iterations = iter;
            StrokeThickness = strokeThickness;

            return;
        }

        #endregion Spirograph Class Constructor

        #region Spirograph Class Implementation

        public void Draw(Canvas canvas, 
                         Color lineColor, 
                         Color backgroundColor)
        {
            canvas.Children.Clear();
            canvas.SnapsToDevicePixels = true;

            List<Point> points = CalculatePoints(canvas);

            Polygon polygon = new Polygon();
            polygon.Stroke = new SolidColorBrush(lineColor);
            polygon.StrokeThickness = StrokeThickness;
            polygon.HorizontalAlignment = HorizontalAlignment.Center;
            polygon.VerticalAlignment = VerticalAlignment.Center;
            polygon.Points = new PointCollection(points);

            canvas.Children.Add(polygon);

            canvas.Background = new SolidColorBrush(backgroundColor);

            return;
        }

        private double X(double t, double a, double b, double c)
        {
            return
            (a - b) * Math.Cos(t) + c * Math.Cos((a - b) / b * t);
        }

        private double Y(double t, double a, double b, double c)
        {
            return
            (a - b) * Math.Sin(t) - c * Math.Sin((a - b) / b * t);
        }

        private List<Point> CalculatePoints(Canvas canvas)
        {
            int width = Convert.ToInt32(canvas.Width) - 10;
            int height = Convert.ToInt32(canvas.Height) - 10;

            int cx = width / 2;
            int cy = height / 2;

            double t = 0;
            double dt = Math.PI / Iterations;
            double maxT = 2 * Math.PI * B / CommonMathUtils.GCD(A, B);

            double x1 = cx + X(t, A, B, C);
            double y1 = cy + Y(t, A, B, C);

            List<Point> points = new List<Point>();
            points.Add(new Point(x1, y1));

            while (t <= maxT)
            {
                t += dt;

                x1 = cx + X(t, A, B, C);
                y1 = cy + Y(t, A, B, C);

                points.Add(new Point(x1, y1));
            }

            return points;
        }

        public bool Save(Canvas spiroCanvas, BitmapEncoder bitmapEncoder,
                         string spiroFileName)
        {
            Rect canvasRect = VisualTreeHelper.GetDescendantBounds(spiroCanvas);

            RenderTargetBitmap renderBitmap =
            new RenderTargetBitmap((int) canvasRect.Width, 
                                   (int) canvasRect.Height,
                                   DefaultDPIX, DefaultDPIY, 
                                   PixelFormats.Default);

            DrawingVisual drawingVisual = new DrawingVisual();

            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                VisualBrush visualBrush =
                new VisualBrush(spiroCanvas);

                drawingContext.DrawRectangle(visualBrush, null,
                               new Rect(new Point(), canvasRect.Size));

            }

            renderBitmap.Render(drawingVisual);
            bitmapEncoder.Frames.Add(BitmapFrame.Create(renderBitmap));

            using (MemoryStream bitmapStream = new MemoryStream())
            {
                bitmapEncoder.Save(bitmapStream);
                bitmapStream.Close();

                File.WriteAllBytes(spiroFileName, bitmapStream.ToArray());
            }

            return File.Exists(spiroFileName);
        }

        #endregion Spirograph Class Implementation
    }
}

