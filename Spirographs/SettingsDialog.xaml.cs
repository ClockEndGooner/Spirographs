//////////////////////////////////////////////////////////////////////////////
//
// SettingsDialog.xaml.cs
// Implementation of settings dialog box for drawing spirographs.
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
using System.Windows.Media;

namespace Spirographs
{
    public partial class SettingsDialog : Window
    {
        public SpirographSettings Settings { get; private set; }
        private int MaxSpiroValue;

        public SettingsDialog(SpirographSettings settings,
                              int maxSpiroValue)
        {
            MaxSpiroValue = maxSpiroValue;

            InitializeComponent();

            Settings = settings;
            SetDialogChildControlValues();
        }

        private void SetDialogChildControlValues()
        {
            AIntegerUpDown.Maximum = MaxSpiroValue;
            BIntegerUpDown.Maximum = MaxSpiroValue;
            CIntegerUpDown.Maximum = MaxSpiroValue;

            AIntegerUpDown.Value = Settings.A;
            BIntegerUpDown.Value = Settings.B;
            CIntegerUpDown.Value = Settings.C;
            IterIntegerUpDown.Value = Settings.Iter;

            ForegroundColorPicker.SelectedColor = Settings.ForegroundColor;
            BackgroundColorPicker.SelectedColor = Settings.BackgroundColor;
            StrokeDecimalUpDown.Value = (decimal) Settings.StrokeThickness;
        }

        private void OnSettingsOKClick(object sender, RoutedEventArgs e)
        {
            int? a = AIntegerUpDown.Value;
            int? b = BIntegerUpDown.Value;
            int? c = CIntegerUpDown.Value;
            int? iter = IterIntegerUpDown.Value;

            Color? foregroundColor = ForegroundColorPicker.SelectedColor;
            Color? backgroundColor = BackgroundColorPicker.SelectedColor;

            double? strokeThichness = (double) StrokeDecimalUpDown.Value;

            if (a.HasValue && b.HasValue && c.HasValue && iter.HasValue &&
                foregroundColor.HasValue && backgroundColor.HasValue)
            {
                Settings = 
                new SpirographSettings(a.Value, b.Value, c.Value, iter.Value,
                                       foregroundColor.Value, backgroundColor.Value,
                                       strokeThichness.Value);

                DialogResult = true;

                Close();
            }
        }
    }
}
