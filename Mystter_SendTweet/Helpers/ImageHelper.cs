using ImageMagick;
using System;
using System.Diagnostics;

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
  }
}
