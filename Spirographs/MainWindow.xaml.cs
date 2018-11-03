//////////////////////////////////////////////////////////////////////////////
//
// MainWindow.xaml.cs
// Spirographs main application window.
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
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

using Microsoft.Win32;

using static System.Windows.SystemParameters;

namespace Spirographs
{
    public partial class MainWindow : Window
    {
        #region MainWindow Class Data Members

        private readonly string DefaultImageFileName = "Spirograph";
        private readonly int PNGDefaultFileFiler = 4;

        public SpirographSettings SpirographSettings { get; private set; }
        private SpirographSettings PreviousSettings { get; set; }

        private Spirograph theSpirograph;

        #endregion MainWindow Class Data Members

        #region MainWindow Class Constructor

        public MainWindow(SpirographSettings settings)
        {
            InitializeComponent();

            SpirographSettings = settings;
            PreviousSettings = new SpirographSettings(SpirographSettings);
        }

        #endregion MainWindow Class Constructor

        #region MainWindow Class & Child Control Event Handlers

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = sender as Button;

            if (buttonClicked.Name == "SettingsButton")
            {
                UpdateSpirographSettings();
            }

            else if (buttonClicked.Name == "SaveButton")
            {
                SaveSpirographImage();
            }

            else
            {
                ShowAboutDialogBox();
            }
        }

        private void OnMainWindowLoading(object sender, RoutedEventArgs loadEvent)
        {
            if (SpirographSettings != null)
            {
                DrawSpirograph();
            }
        }

        private void OnMainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var trace =
            $"Width: {Width.ToString()}  Height: {Height.ToString()}  Top: {Top.ToString()}  Left: {Left.ToString()}  ";

            Debug.Write(trace);

            trace =
            $"SpiroCanvas.Width: {SpiroCanvas.Width.ToString()}  Height: {SpiroCanvas.Height.ToString()}";

            Debug.WriteLine(trace);
        }

        private void OnRightMouseButtonClicked(object sender, MouseButtonEventArgs e)
        {
            UIElement mouseClickTarget = sender as UIElement;

            ShowSpirograpContextMenu(mouseClickTarget);
        }

        #endregion MainWindow Class & Child Control Event Handlers

        #region MainWindow Class Implementation

        private void UpdateSpirographSettings()
        {
            var maxValue = 
            Convert.ToInt32(Math.Max(ActualWidth, ActualHeight));

            var settingsDialog = new SettingsDialog(SpirographSettings, maxValue)
            {
                Owner = this
            };
        
            bool? settingsChanaged = settingsDialog.ShowDialog();

            if (settingsChanaged.HasValue && settingsChanaged.Value == true)
            {
                SpirographSettings = settingsDialog.Settings;
                DrawSpirograph();
            }
        }

        private void SetCanvasSize()
        {
            var canvasSize = Math.Min(PrimaryScreenWidth, PrimaryScreenHeight);

            SpiroCanvas.Width = canvasSize;
            SpiroCanvas.Height = canvasSize;
        }    

        private void DrawSpirograph()
        {
            SetCanvasSize();

            var halfCanvasWidth = SpiroCanvas.Width / 2;

            if (SpirographSettings.IsSpirographRadiusLarger(halfCanvasWidth))
            {
                var warningDialog = new WarningDialog
                {
                    Owner = this
                };

                //
                // dialogResult is true when either the Previous or Draw button have been
                // clicked. False is returned if the user clicked on the close dialog 
                // button.
                //
                var dialogResult = warningDialog.ShowDialog();

                if (dialogResult.HasValue && dialogResult.Value == true)
                {
                    if (warningDialog.Response == WarningResponse.UsePreviousSettings)
                    {
                        SpirographSettings = PreviousSettings;
                    }
                }
            }

            SpiroCanvas.Children.Clear();

            theSpirograph = new Spirograph(SpirographSettings);
            theSpirograph.Draw(SpiroCanvas);

            if (!SpirographSettings.IsSpirographRadiusLarger(halfCanvasWidth))
            {
                PreviousSettings = new SpirographSettings(SpirographSettings);
            }            
        }

        private void SaveSpirographImage()
        {
            BitmapFileSettings bitmapSettings = GetBitmapFileSettings();

            if (theSpirograph != null)
            {
                if (bitmapSettings != null)
                {
                    theSpirograph.Save(SpiroCanvas,
                                       bitmapSettings.Encoder,
                                       bitmapSettings.BitmapFileName);
                }
            }
        }

        private BitmapFileSettings GetBitmapFileSettings()
        {
            BitmapFileSettings bitmapSettings = null;

            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save Spirograph Image File",
                FileName = DefaultImageFileName,
                Filter = BitmapFileSettings.FileFilters,
                FilterIndex = PNGDefaultFileFiler,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                AddExtension = true,
                OverwritePrompt = true,
                ValidateNames = true,
            };

            bool? dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value == true)
            {
                var encoding = (BitmapEncoding) (saveFileDialog.FilterIndex - 1);
                var imageFileName = saveFileDialog.FileName;

                bitmapSettings = new BitmapFileSettings(encoding, imageFileName);
            }

            return bitmapSettings;
        }

        private void ShowSpirograpContextMenu(UIElement contextMenuTarget)
        {
            var spiroContextMenu = (ContextMenu) FindResource("SpiroContextMenu");

            if (spiroContextMenu != null)
            {
                spiroContextMenu.PlacementTarget = contextMenuTarget;
                spiroContextMenu.IsOpen = true;
            }
        }

        private void OnContextMenuItemClicked(object sender, RoutedEventArgs menuItemClickEvent)
        {
            MenuItem selectedMenuItem = sender as MenuItem;

            if (selectedMenuItem.Name == "SettingsMenuItem")
            {
                UpdateSpirographSettings();
            }

            else if (selectedMenuItem.Name == "SaveMenuItem")
            {
                SaveSpirographImage();
            }

            else
            {
                Debug.Assert("AboutMenuItem" == selectedMenuItem.Name);

                ShowAboutDialogBox();
            }
        }

        private void ShowAboutDialogBox()
        {
            var aboutDialog = new AboutSpirographsDialog
            {
                Owner = this
            };

            aboutDialog.ShowDialog();
        }

#endregion MainWindow Class Implementation
    }
}

