using System;
using UIKit;

namespace NotifyMe.iOS.PlatformSpecific
{
    public static class SharedColors
    {
        static SharedColors()
        {
            Primary = FromHexString("#FFBF65");
            SecondPrimary = FromHexString("#FF9705");
            Background = FromHexString("#003338");
            LighterBackground = FromHexString("#486669");
        }

        public static UIColor Primary { get; set; }

        public static UIColor SecondPrimary { get; set; }

        public static UIColor Background { get; set; }

        public static UIColor LighterBackground { get; set; }

        public static UIColor FromHexString(string hexValue)
        {
            hexValue = hexValue.TrimStart('#');

            int parts = hexValue.Length / 2;
            byte[] bytes = new byte[parts];
            for (int i = 0; i < hexValue.Length / 2; i++)
            {
                string part = hexValue.Substring(i * 2, 2);
                bytes[i] = Convert.ToByte(part, 16);
            }

            if (parts == 4)
            {
                return UIColor.FromRGBA(bytes[1], bytes[2], bytes[3], bytes[0]);
            }
            else
            {
                return UIColor.FromRGB(bytes[0], bytes[1], bytes[2]);
            }
        }
    }
}
