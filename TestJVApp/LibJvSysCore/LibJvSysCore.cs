using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibJvSysCore
{
    public class libJvSysCore
    {
        static readonly String LIB_SYSTEM_VER = "F00";
        static readonly Boolean DEBUG_DEF = true;

        public static String GetibraryVersion() { return (LIB_SYSTEM_VER); }

        public static Boolean DEBUG() { return DEBUG_DEF; }
    }
}
