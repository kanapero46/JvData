using System;
using System.Collections.Generic;
using System.Text;

namespace LibJvSysCore
{
    public class libJvSysConv
    {

        /** DateTime型からString型へ形成する関数
         */
        public static String LibJvConvtDateTime2String(DateTime time)
        {
            String tmp;

            tmp = time.ToString("yyyymmdd");
            return tmp;
        }

        /** 競馬場コードから競馬場名へ形成する関数
         */
        public static String LibJvConvCourceNum2String(String CourceNum)
        {
            switch (CourceNum)
            {
                case "01":
                    return ("札幌");
                case "02":
                    return ("函館");
                case "03":
                    return ("福島");
                case "04":
                    return ("新潟");
                case "05":
                    return ("東京");
                case "06":
                    return ("中山");
                case "07":
                    return ("中京");
                case "08":
                    return ("京都");
                case "09":
                    return ("阪神");
                case "10":
                    return ("小倉");
                default:
                    return (CourceNum);
            }
        }

        /** 競馬場コードから競馬場名へ形成する関数
         *  戻り値：１～競馬場コード
         *         －１：エラー
         */
        public static int LibJvConvCourceName2CourceNum(String CourceName)
        {
            switch (CourceName)
            {
                case "札幌":
                    return (01);
                case "函館":
                    return (02);
                case "福島":
                    return (03);
                case "新潟":
                    return (04);
                case "東京":
                    return (05);
                case "中山":
                    return (06);
                case "中京":
                    return (07);
                case "京都":
                    return (08);
                case "阪神":
                    return (09);
                case "小倉":
                    return (10);
                default:
                    return (-1);
            }
        }


    }
}
