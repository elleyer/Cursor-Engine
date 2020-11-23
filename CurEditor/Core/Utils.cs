using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

namespace CurEditor.Core
{
    public class Utils
    {
        private static float _value;
        
        public static Bitmap ReScaleBitmap(EasingType easingType, Image bitmap, float scaleFactor)
        {
            var destRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var destImage = new Bitmap(bitmap.Width, bitmap.Height);

            destImage.SetResolution(bitmap.HorizontalResolution, bitmap.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    graphics.DrawImage(destImage, destRect, 0, 0, bitmap.Width, bitmap.Height, 
                        GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap GetSystemCursorBitmap(System.Windows.Forms.Cursor cursor)
        {
            var bitmap = new Bitmap(
                cursor.Size.Width, cursor.Size.Height);

            var graphics = Graphics.FromImage(bitmap);

            cursor.Draw(graphics,
                new Rectangle(new Point(0, 0), cursor.Size));

            return bitmap;
        }
        
        public static uint GetCursorResourceId(System.Windows.Forms.Cursor cursor)
        {
            var fi = typeof(System.Windows.Forms.Cursor).GetField(
                "resourceId", BindingFlags.NonPublic | BindingFlags.Instance);

            if (fi == null) return 0;
            
            var obj = fi.GetValue(cursor);
            return Convert.ToUInt32((int) obj);
        }
        
        public static Image RotateCursorBitmap(Image bitmap, float angle)
        {
            var returnBitmap = new Bitmap(bitmap.Height, bitmap.Width);

            var gfx = Graphics.FromImage(returnBitmap);

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            gfx.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
            gfx.RotateTransform(angle);
            
            gfx.TranslateTransform(-(float)bitmap.Height / 2, -(float)bitmap.Width / 2);
            gfx.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);

            return returnBitmap;
        }
        
        public static float GetAngleByPoints(float x, float y)
        {
            return 45;
        }
    }
}