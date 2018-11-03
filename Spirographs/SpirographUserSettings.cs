//////////////////////////////////////////////////////////////////////////////
//
// SpirographUserSettings.cs 
// User settings and default values for rendering a Spirograph.
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
using System.Configuration;
using System.Windows.Media;

namespace Spirographs
{
    public class SpirographUserSettings : ApplicationSettingsBase
    {
        #region SpirographUserSettings Properties

        [UserScopedSetting()]
        [DefaultSettingValue("10")]
        public double Left
        {
            get
            {
                return Convert.ToDouble(this["Left"]);
            }

            set
            {
                this["Left"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("10")]
        public double Top
        {
            get
            {
                return Convert.ToDouble(this["Top"]);
            }

            set
            {
                this["Top"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("450")]
        public double Width
        {
            get
            {
                return Convert.ToDouble(this["Width"]);
            }

            set
            {
                this["Width"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("450")]
        public double Height
        {
            get
            {
                return Convert.ToDouble(this["Height"]);
            }

            set
            {
                this["Height"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("120")]
        public int A
        {
            get
            {
                return Convert.ToInt32(this["A"]);
            }

            set
            {
                this["A"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("32")]
        public int B
        {
            get
            {
                return Convert.ToInt32(this["B"]);
            }

            set
            {
                this["B"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("100")]
        public int C
        {
            get
            {
                return Convert.ToInt32(this["C"]);
            }

            set
            {
                this["C"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("200")]
        public int Iterations
        {
            get
            {
                return Convert.ToInt32(this["Iterations"]);
            }

            set
            {
                this["Iterations"] = value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("White")]
        public Color ForegroundColor
        {
            get
            {
                return ((Color) this["ForegroundColor"]);
            }

            set
            {
                this["ForegroundColor"] = (Color)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("DodgerBlue")]
        public Color BackgroundColor
        {
            get
            {
                return ((Color)this["BackgroundColor"]);
            }

            set
            {
                this["BackgroundColor"] = (Color)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("1.25")]
        public double BrushThickness
        {
            get
            {
                return Convert.ToDouble(this["BrushThickness"]);
            }

            set
            {
                this["BrushThickness"] = value;
            }
        }

        #endregion SpirographUserSettings Properties
    }
}
