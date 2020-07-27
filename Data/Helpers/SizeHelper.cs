using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Enums
{
    public class SizeHelper
    {
        public static double _36 = 36;
        public static double _365 = 36.5;
        public static double _37 = 37;
        public static double _375 = 37.5;
        public static double _38 = 38;
        public static double _385 = 38.5;
        public static double _39 = 39;
        public static double _395 = 39.5;
        public static double _40 = 40;
        public static double _405 = 40.5;
        public static double _41 = 41;
        public static double _415 = 41.5;
        public static double _42 = 42;
        public static double _425 = 42.5;
        public static double _43 = 43;
        public static double _435 = 43.5;
        public static double _44 = 44;
        public static double _445 = 44.5;

        public double Size { get; set; }
        public SizeHelper()
        {}

        public string getSizeDb(List<SizeHelper> sizeHelpers)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var size in sizeHelpers)
            {
                stringBuilder.Append(size.Size);
            }
            return stringBuilder.ToString();
        }
    }
}
