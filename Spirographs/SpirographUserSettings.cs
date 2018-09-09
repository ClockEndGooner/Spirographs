
using System;
using System.Configuration;
using System.Windows.Media;

namespace Spirographs
{
    public class SpirographUserSettings : ApplicationSettingsBase
    {
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
    }
}
