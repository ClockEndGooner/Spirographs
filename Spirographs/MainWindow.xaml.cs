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

namespace Spirographs
{
    public partial class MainWindow : Window
    {
        #region MainWindow Class Data Members

        private readonly string DefaultImageFileName = "Spirograph";
        private readonly int PNGDefaultFileFiler = 4;

        public SpirographSettings SpirographSettings { get; private set ; }
        private Spirograph theSpirograph;

        #endregion MainWindow Class Data Members

        #region MainWindow Class Constructor

        public MainWindow(SpirographSettings settings)
        {
            InitializeComponent();

            SpirographSettings = settings;         

            return;
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

            return;
        }

        private void OnMainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var trace =
            $"Width: {Width.ToString()}  Height: {Height.ToString()}  Top: {Top.ToString()}  Left: {Left.ToString()}  ";

            Debug.Write(trace);

            trace =
            $"SpiroCanvas.Width: {SpiroCanvas.Width.ToString()}  Height: {SpiroCanvas.Height.ToString()}";

            Debug.WriteLine(trace);

            return;
        }

        private void OnRightMouseButtonClicked(object sender, MouseButtonEventArgs e)
        {
            UIElement mouseClickTarget = sender as UIElement;

            ShowSpirograpContextMenu(mouseClickTarget);

            return;
        }

        #endregion MainWindow Class & Child Control Event Handlers

        #region MainWindow Class Implementation
        private void UpdateSpirographSettings()
        {
            int maxValue = 
            Convert.ToInt32(Math.Max(ActualWidth, ActualHeight));
        
            SettingsDialog settingsDialog =
            new SettingsDialog(SpirographSettings, maxValue);

            settingsDialog.Owner = this;

            bool? settingsChanaged = settingsDialog.ShowDialog();

            if (settingsChanaged.HasValue && settingsChanaged.Value == true)
            {
                SpirographSettings = settingsDialog.Settings;
                DrawSpirograph();
            }

            return;
        }

        private void SetCanvasSize()
        {
            double canvasSize =
            Math.Min(SystemParameters.PrimaryScreenWidth,
                     SystemParameters.PrimaryScreenHeight);

            SpiroCanvas.Width = canvasSize;
            SpiroCanvas.Height = canvasSize;

            return;
        }

        private void DrawSpirograph()
        {
            SetCanvasSize();

            SpiroCanvas.Children.Clear();

            theSpirograph = new Spirograph(SpirographSettings.A,
                                           SpirographSettings.B,
                                           SpirographSettings.C,
                                           SpirographSettings.Iter,
                                           SpirographSettings.StrokeThickness);

            theSpirograph.Draw(SpiroCanvas,
                               SpirographSettings.ForegroundColor,
                               SpirographSettings.BackgroundColor);

            return;
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

            return;
        }

        private BitmapFileSettings GetBitmapFileSettings()
        {
            BitmapFileSettings bitmapSettings = null;

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Title = "Save Spirograph Image File";
            fileDialog.FileName = DefaultImageFileName;
            fileDialog.Filter = BitmapFileSettings.FileFilters;
            fileDialog.FilterIndex = PNGDefaultFileFiler;
            fileDialog.InitialDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.AddExtension = true;
            fileDialog.OverwritePrompt = true;
            fileDialog.ValidateNames = true;

            bool? dialogResult = fileDialog.ShowDialog();

            if (dialogResult.HasValue && dialogResult.Value == true)
            {
                BitmapEncoding encoding = 
                (BitmapEncoding) (fileDialog.FilterIndex - 1);
                string imageFileName = fileDialog.FileName;

                bitmapSettings =
                new BitmapFileSettings(encoding, imageFileName);
            }

            return bitmapSettings;
        }

        private void ShowSpirograpContextMenu(UIElement contextMenuTarget)
        {
            ContextMenu spiroContextMenu = 
            FindResource("SpiroContextMenu") as ContextMenu;

            if (spiroContextMenu != null)
            {
                spiroContextMenu.PlacementTarget = contextMenuTarget;
                spiroContextMenu.IsOpen = true;
            }

            return;
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

            return;
        }

        private void ShowAboutDialogBox()
        {
            AboutSpirographsDialog aboutDialog = new AboutSpirographsDialog();

            aboutDialog.Owner = this;
            aboutDialog.ShowDialog();

            return;
        }

        #endregion MainWindow Class Implementation
    }
}

