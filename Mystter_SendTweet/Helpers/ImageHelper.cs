using ImageMagick;
using Manina.Windows.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Mystter_SendTweet.Helpers {
  public static class ImageHelper {
    public static bool IsSupported(string path) {
      try {
        // I don't know the difference between Jpg and Jpeg.
        // A lot of .jpg extention files are recognized as Jpeg.
        MagickFormat format = new MagickImageInfo(path).Format;
        if (format == MagickFormat.Jpg || format == MagickFormat.Jpeg || format == MagickFormat.Png || format == MagickFormat.Gif || format == MagickFormat.WebP) {
          return true;
        } else {
          Debug.WriteLine("[Incompatible image] Format: {0}, Path: {1}", format, path);
          return false;
        }
      } catch (Exception ex) {
        Debug.WriteLine("[Exception on creating MagickImageInfo instance] Message: {0}, Path: {1}", ex.Message, path);
        return false;
      }
    }

    public static bool IsSupported(Image image) {
      ImageFormat format = image.RawFormat;
      if (format == ImageFormat.Jpeg || format == ImageFormat.Png || format == ImageFormat.Gif) {
        return true;
      } else {
        Debug.WriteLine("[Incompatible image] Format: {0}", format);
        return false;
      }
    }

    public static FileInfo GetFileInfo(ImageListViewItem item) {
      return new FileInfo(GetFullPath(item));
    }

    public static string GetFullPath(ImageListViewItem item) {
      return Path.Combine(item.FilePath, item.FileName);
    }
  }
}
