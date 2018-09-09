//////////////////////////////////////////////////////////////////////////////
//
// BitmapFileSettings.cs 
// Wrapper class for BitmapEncoding a Spirograph.
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

using System.Windows.Media.Imaging;

namespace Spirographs
{
    public enum BitmapEncoding
    {
        BMP,
        GIF,
        JPEG,
        PNG,
        TIFF,
        WMP
    };

    public sealed class BitmapFileSettings
    {
        #region BitmapFileSettings Class Constant Definitions

        public static readonly string FileFilters =
        "Bitmap Image File (*.bmp)|*.bmp|Graphics Interchange Format (*.gif)|*.gif|JPEG - Joint Photographic Experts Group Image (*.jpg)|*.jpg|PNG - Portable Network Graphic Bitmap (*.png)|*.png|TIFF Raster Image Format(*.tif)|*.tif|Microsoft Windows Media Photo Image (*.wmp)|*.wmp";

        #endregion BitmapFileSettings Class Constant Definitions

        #region BitmapFileSettings Class Auto-Properties 

        public BitmapEncoding EncodingFormat { get; private set; }
        public BitmapEncoder Encoder { get; private set; }
        public string BitmapFileName { get; private set; }
        public bool OverwriteExistingBitmap { get; private set; }

        #endregion BitmapFileSettings Class Auto-Properties 

        #region BitmapFileSettings Class Constructor

        public BitmapFileSettings(BitmapEncoding encoding,
                                  string fileName,
                                  bool overwriteExistingFile = false)
        {
            EncodingFormat = encoding;
            BitmapFileName = fileName;
            OverwriteExistingBitmap = overwriteExistingFile;

            InitializeBitmapEncoder();

            return;
        }

        #endregion BitmapFileSettings Class Constructor    

        #region BitmapFileSettings Class Implementation

        private void InitializeBitmapEncoder()
        {
            switch (EncodingFormat)
            {
                case BitmapEncoding.BMP:
                    Encoder = new BmpBitmapEncoder();
                    break;

                case BitmapEncoding.GIF:
                    Encoder = new GifBitmapEncoder();
                    break;

                case BitmapEncoding.JPEG:
                    Encoder = new JpegBitmapEncoder();
                    break;

                case BitmapEncoding.PNG:
                    Encoder = new PngBitmapEncoder();
                    break;

                case BitmapEncoding.TIFF:
                    Encoder = new TiffBitmapEncoder();
                    break;

                case BitmapEncoding.WMP:
                    Encoder = new WmpBitmapEncoder();
                    break;
            }

            return;
        }

        #endregion BitmapFileSettings Class Implementation    
    }
}
