using System;

namespace iJvUnit
{
    interface iJvUnit
    {
        /* JRA-VAN DataLab.との通信をまとめたI/F */
        public int axJVLinkUnit(AxJVDTLabLib.AxJVLink axJv);

        public int axJvInit(String User);
    }
}
