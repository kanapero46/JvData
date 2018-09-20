using System;

namespace nJvUnit
{
    class iJvUnit : 
    {
        /* JRA-VAN DataLab.との通信をまとめたI/F */
        int AxJVLinkUnit(AxJVDTLabLib.AxJVLink axJv);

        int AxJvInit(String User);
        int AxJvOpen();
        int AxJvRead();
        int AxJvSkip();
        int AxJvClose();

    }
}
