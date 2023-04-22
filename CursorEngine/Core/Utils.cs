using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

namespace CursorEngine.Core
{
    public class Utils
    {
        public struct BitmapWithOffset
        {
            public Bitmap Bitmap;
            
            public int offsetX;
            public int offsetY;
        }
        
        public static BitmapWithOffset ReScaleBitmap(EasingType easingType, Image bitmap, double scaleFactor)
        {
            var image = new Bitmap(bitmap.Width * 2, bitmap.Height * 2, PixelFormat.Format32bppArgb);

            var graphics = Graphics.FromImage(image);

            var size = new Size((int) (bitmap.Width * scaleFactor),
                (int) (bitmap.Height * scaleFactor));
            
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            DebugExtensions.PushMessage($"point [width: {bitmap.Width}, height: {bitmap.Height}] " +
                                        $"-> size [{size.Width} * {size.Height}]");

            graphics.DrawImage(bitmap, new Rectangle(new Point(bitmap.Width,
                    bitmap.Height), 
                size));
            
            return new BitmapWithOffset
            {
                Bitmap = image,
                /*offsetX = ,
                offsetY = */
            };
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