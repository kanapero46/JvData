﻿using nSoftwareDef;
using nScsDef;
using System;

public class Scs : iSoftWareDef, iScsdef
{
    /* 0：デバッグ処理なし、１：デバッグ処理あり */
    public static Boolean DEBUG_DEF = false;

    /* バージョン情報 */
    private static readonly String VERSION_DEF = "00.00-03";

    /* 製品版フラグ：0：工程モード、1：製品モード */
    private static readonly Boolean MASPRO_DEF = false;

    /* Overide to iScsDef */
    String iScsdef.ShowSoftWareVersion(){ return VERSION_DEF; }

    /* Overide to iSoftWareDef */
    bool iSoftWareDef.DEBUG(){ return DEBUG_DEF; }
}
 