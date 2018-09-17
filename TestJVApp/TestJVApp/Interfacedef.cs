using System;
using iJvUnit;

namespace InterfaceDef
{
    interface Interfacedef : iJvUnit, iScsdef
    {
        /* すべてのインターフェイスをこのファイルでインクルードする               */
        /* 処理ではこのファイルをインクルードすることで、すべての処理を動作させる　*/
    }
}
