//////////////////////////////////////////////////////////////////////////////
//
// WarningDialog.xaml.cs
// A Draw Sprigraph Warning dialog box class implementation.
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

using System.Windows;
using System.Windows.Input;

namespace Spirographs
{
    public enum WarningResponse
    {
        UseCurrentSettings = 0,
        UsePreviousSettings = 1
    }

    public partial class WarningDialog : Window
    {
        #region WarningDialog Class Properties

        public WarningResponse Response { get; private set; }

        #endregion WarningDialog Class Properties

        #region WarningDialog Class Constructor

        public WarningDialog()
        {
            InitializeComponent();
        }

        #endregion WarningDialog Class Constructor

        #region WarningDialog Class Implementation

        private void OnDrawButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Response = WarningResponse.UseCurrentSettings;

            this.Close();
        }

        private void OnPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Response = WarningResponse.UsePreviousSettings;

            this.Close();        
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DialogResult = false;

                this.Close();
            }
        }

        #endregion WarningDialog Class Implementation
    }
}
