using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    public static class YdConverter {

        //定数
        private const double ratio = 0.9144;

        //メートルからヤードを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }
        //ヤードからメートルを求める
        public static double ToMeter(double yard) {
            return yard * ratio;
        }
    }
}
