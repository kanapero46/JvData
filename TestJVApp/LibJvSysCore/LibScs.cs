using System;
using System.Collections.Generic;
using System.Text;

namespace LibJvSysCore
{
    public class LibScs
    {
        /** エラーコード判別関数
         * @return TRUE：エラーなし
         * 　　　　 FALSE：エラー
         */
        public static Boolean LibScsCheckErrorCode(int ErrCode , ref String ErrMessage)
        {
            Boolean Debug = libJvSysCore.DEBUG();
            String DefMessage = "ソフトエラーです。 SE991-0";

            if(ErrCode == 0)
            {
                //エラーコードが0の場合は問題なし。
                return (true);
            }

            switch(ErrCode)
            {
                case -101:
                    if (!Debug){ ErrMessage = DefMessage; }
                    else { ErrMessage = "sidがセットされていません。"; }
                    return (false);
                case -102:
                    if (!Debug) { ErrMessage = DefMessage; }
                    else { ErrMessage = "sidが64bitを超えています。"; }
                    return (false);
            }
            return (true);
        }
    }
}
