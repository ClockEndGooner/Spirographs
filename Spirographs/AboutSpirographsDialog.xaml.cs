//////////////////////////////////////////////////////////////////////////////
//
// AboutSpirographDialog.xaml.cs 
// About Spirographs application dialog box.
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
using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Spirographs
{
    public partial class AboutSpirographsDialog : Window
    {
        #region AboutSpirographsDialog Class Constructor 

        public AboutSpirographsDialog()
        {
            InitializeComponent();
        }

        #endregion AboutSpirographsDialog Class Constructor

        #region AboutSpirographsDialog Property Accessors 

        private string ApplicationName
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        private string ApplicationVersion
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;

                string appVersion =
                String.Format("{0}.{1}.{2}.{3}",
                              version.Major.ToString(),
                              version.Minor.ToString(),
                              version.Build.ToString(),
                              version.Revision.ToString());

                return appVersion;
            }
        }

        #endregion AboutSpirographsDialog Property Accessors 

        #region AboutSpirographsDialog Dialog & Child Control Event Handlers

        private void OnDialogLoad(object sender, RoutedEventArgs e)
        {
            AppVersionRun.Text = ApplicationVersion;
            AppNameRun.Text = ApplicationName;
        }

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            if (sender is Hyperlink clickedLink)
            {
                string targetURI = clickedLink.NavigateUri.OriginalString;
                Debug.WriteLine(targetURI);
                Process.Start(targetURI);
            }
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
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

        #endregion AboutSpirographsDialog Dialog & Child Control Event Handlers
    }
}
