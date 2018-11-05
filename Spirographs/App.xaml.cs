//////////////////////////////////////////////////////////////////////////////
//
// App.xaml.cs 
// Spirographs application implementation.
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
using System.Windows;

namespace Spirographs
{
    public partial class App : Application
    {
        #region Spirographs App Data Properties 

        private SpirographUserSettings theUserSettings;
        private MainWindow theMainWindow;

        #endregion Spirographs App Data Properties 

        #region Spirographs App Class Constructor

        public App()
        {

        }

        #endregion Spirographs App Class Constructor

        #region Spirographs App Class Event Handlers

        public void OnApplicationStartup(object sender, StartupEventArgs startupEvent)
        {
            if (LoadSpirographUserSettings(out var windowLocation, out var windowSize,
                                           out var spirographSettings))
            {                
                var maxSize = Math.Max(windowSize.X, windowSize.Y);

                if (spirographSettings.IsSpirographRadiusLarger(maxSize))
                {
                    spirographSettings = SpirographSettings.DefaultSettings;
                }

                theMainWindow = new MainWindow(spirographSettings)
                {
                    Left = windowLocation.X,
                    Top = windowLocation.Y,
                    Width = windowSize.X,
                    Height = windowSize.Y
                };

                theMainWindow.Show();
            }
        }

        private void OnApplicationExit(object sender, ExitEventArgs exitEvent)
        {
            if (theMainWindow != null)
            {
                if (UpdateSpirographUserSettings())
                {
                    theUserSettings.Save();
                }
            }
        }

        #endregion Spirographs App Class Event Handlers

        #region Spirographs App Class Supporting Methods

        private bool LoadSpirographUserSettings(out Point windowLocation, 
                                                out Point windowSize,
                                                out SpirographSettings spirographSettings)
        {
            theUserSettings = new SpirographUserSettings();

            windowLocation = new Point(theUserSettings.Left, theUserSettings.Top);
            windowSize = new Point(theUserSettings.Width, theUserSettings.Height);

            spirographSettings = 
            new SpirographSettings(theUserSettings.A,
                                   theUserSettings.B,
                                   theUserSettings.C,
                                   theUserSettings.Iterations,
                                   theUserSettings.ForegroundColor,
                                   theUserSettings.BackgroundColor,
                                   theUserSettings.BrushThickness);

            return (windowLocation != null && windowSize != null &&
                    spirographSettings != null);
        }

        private bool UpdateSpirographUserSettings()
        {
            bool updatedSettings = false;

            if (theMainWindow != null && 
                theMainWindow.SpirographSettings != null)
            {
                theUserSettings.Top = theMainWindow.Top;
                theUserSettings.Left = theMainWindow.Left;
                theUserSettings.Width = theMainWindow.Width;
                theUserSettings.Height = theMainWindow.Height;

                theUserSettings.A = theMainWindow.SpirographSettings.A;
                theUserSettings.B = theMainWindow.SpirographSettings.B;
                theUserSettings.C = theMainWindow.SpirographSettings.C;

                theUserSettings.Iterations = 
                theMainWindow.SpirographSettings.Iter;

                theUserSettings.ForegroundColor =
                theMainWindow.SpirographSettings.ForegroundColor;

                theUserSettings.BackgroundColor =
                theMainWindow.SpirographSettings.BackgroundColor;

                theUserSettings.BrushThickness =
                theMainWindow.SpirographSettings.StrokeThickness;

                updatedSettings = true;
            }

            return updatedSettings;
        }

        #endregion Spirographs App Class Supporting Methods
    }
}
