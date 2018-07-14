using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJVApp
{
    class func
    {
        public String ConvertDate(DateTime time)
        {
            String tmp;

            tmp = time.ToString("yyyymmdd");
            return "0";
        }


        //場名変換関数
        public string ChgJyoCDtoString(string JyoCD)
        {
            switch (JyoCD)
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
                    return (JyoCD);
            }
        }

        //場名変換関数
        public int KeibajoToNumber(string Jyomei)
        {
            switch (Jyomei)
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


        public string CngJyoNum(string JyoCD, string RaceNum)
        {

            String RC;
            switch (JyoCD)
            {
                case "01": RC = "札幌"; break;
                case "02": RC = "函館"; break;
                case "03": RC = "福島"; break;
                case "04": RC = "新潟"; break;
                case "05": RC = "東京"; break;
                case "06": RC = "中山"; break;
                case "07": RC = "中京"; break;
                case "08": RC = "京都"; break;
                case "09": RC = "阪神"; break;
                case "10": RC = "小倉"; break;
                case "30": RC = "門別"; break;
                case "31": RC = "北見"; break;
                case "32": RC = "岩見沢"; break;
                case "33": RC = "帯広"; break;
                case "34": RC = "旭川"; break;
                case "35": RC = "盛岡"; break;
                case "36": RC = "水沢"; break;
                case "37": RC = "上山"; break;
                case "38": RC = "三条"; break;
                case "39": RC = "足利"; break;
                case "40": RC = "宇都宮"; break;
                case "41": RC = "高崎"; break;
                case "42": RC = "浦和"; break;
                case "43": RC = "船橋"; break;
                case "44": RC = "大井"; break;
                case "45": RC = "川崎"; break;
                case "46": RC = "金沢"; break;
                case "47": RC = "笠松"; break;
                case "48": RC = "名古屋"; break;
                case "49": RC = "紀三寺"; break;
                case "50": RC = "園田"; break;
                case "51": RC = "姫路"; break;
                case "52": RC = "益田"; break;
                case "53": RC = "福山"; break;
                case "54": RC = "高知"; break;
                case "55": RC = "佐賀"; break;
                case "56": RC = "荒尾"; break;
                case "57": RC = "中津"; break;
                case "58": RC = "札幌"; break;
                case "59": RC = "函館"; break;
                case "60": RC = "新潟"; break;
                case "61": RC = "中京"; break;
                case "A0": RC = "他外国"; break;
                case "A2": RC = "日本"; break;
                case "A4": RC = "アメリ"; break;
                case "A6": RC = "イギリ"; break;
                case "A8": RC = "フラン"; break;
                case "B0": RC = "インド"; break;
                case "B2": RC = "アイル"; break;
                case "B4": RC = "ニュー"; break;
                case "B6": RC = "オース"; break;
                case "B8": RC = "カナダ"; break;
                case "C0": RC = "イタリ"; break;
                case "C2": RC = "ドイツ"; break;
                case "C5": RC = "オマー"; break;
                case "C6": RC = "イラク"; break;
                case "C7": RC = "アラブ"; break;
                case "C8": RC = "シリア"; break;
                case "D0": RC = "スウェ"; break;
                case "D2": RC = "ハンガ"; break;
                case "D4": RC = "ポルト"; break;
                case "D6": RC = "ロシア"; break;
                case "D8": RC = "ウルグ"; break;
                case "E0": RC = "ペルー"; break;
                case "E2": RC = "アルゼ"; break;
                case "E4": RC = "ブラジ"; break;
                case "E6": RC = "ベルギ"; break;
                case "E8": RC = "トルコ"; break;
                case "F0": RC = "韓国"; break;
                case "F1": RC = "中国"; break;
                case "F2": RC = "チリ"; break;
                case "F4": RC = ""; break;
                case "F6": RC = ""; break;
                case "F8": RC = "パナマ"; break;
                case "G0": RC = "香港"; break;
                case "G2": RC = "スペイ"; break;
                case "G4": RC = ""; break;
                case "G6": RC = ""; break;
                case "G8": RC = ""; break;
                case "H0": RC = "西独"; break;
                case "H2": RC = "南アフ"; break;
                case "H4": RC = "スイス"; break;
                case "H6": RC = "モナコ"; break;
                case "H8": RC = "フィリ"; break;
                case "I0": RC = "プエル"; break;
                case "I2": RC = "コロン"; break;
                case "I4": RC = "チェコ"; break;
                case "I6": RC = "チェコ"; break;
                case "I8": RC = "スロバ"; break;
                case "J0": RC = "エクア"; break;
                case "J2": RC = "ギリシ"; break;
                case "J4": RC = "マレー"; break;
                case "J6": RC = "メキシ"; break;
                case "J8": RC = "モロッ"; break;
                case "K0": RC = "パキス"; break;
                case "K2": RC = "ポーラ"; break;
                case "K4": RC = "パラグ"; break;
                case "K6": RC = "サウジ"; break;
                case "K8": RC = "キプロ"; break;
                case "L0": RC = "タイ"; break;
                case "L2": RC = "ウクラ"; break;
                case "L4": RC = "ベネゼ"; break;
                case "L6": RC = "ユーゴ"; break;
                case "L8": RC = "デンマ"; break;
                case "M0": RC = "シンガ"; break;
                case "M2": RC = "マカオ"; break;
                case "M4": RC = "墺国"; break;
                case "M6": RC = "ヨルダ"; break;
                case "M8": RC = "カタル"; break;
                default:
                    return ("場名？");
            }

            String num;

            if (string.Equals("-", RaceNum.Substring(0, 1)))
            {
                //エラー（マイナス値）
                num = "0";
            }
            else if (string.Equals("0", RaceNum.Substring(0, 1)))
            {
                //01～09の場合
                num = RaceNum.Substring(1, 1);
            }
            else
            {
                //10～
                num = RaceNum;
            }


            return (RC + num + "R");
        }//end

        public string CngRaceCla(string[] raceclass)
        {
            for (int idx=0; idx < raceclass.Length; idx++)
            {
                if(raceclass[idx] == null)
                {
                    //競争条件がなし
                    continue;
                }

                switch (raceclass[idx])
                {
                    case "001": return ("１００万円以下");
                    case "002": return ("２００万円以下");
                    case "003": return ("３００万円以下");
                    case "005": return ("５００万円以下");
                    case "010": return ("１０００万円以下");
                    case "016": return ("１６００万円以下");
                    case "099": return ("９９００万円以下 ");
                    case "100": return ("１億円以下");
                    case "701": return ("新馬");
                    case "702": return ("未出走 ");
                    case "703": return ("未勝利");
                    case "999": return ("オープン");
                }
            }
            return("条件");

        }//end toClass  

        public void errMesage(int errCode)
        {
            /* エラー発生コードはここに定義する 
             * 
             * 200:場名の設定に失敗。
             * 201:場名の取得に失敗。
             * 
             * */
            MessageBox.Show("エラーが発生しました。プログラムを終了します。" + errCode);
            Form1 form = new Form1();
            form.Close();
        }

        /**
         * 内部エラーコードをStringで戻す関数
         * 内部エラーではないときにはメッセージを出す。
         * */
        public String ErrCodetoString(int errno)
        {
            switch (errno)
            {
                case -1:
                    MessageBox.Show("該当のデータがありません。");
                    return ("-1");
                case -2:
                    return ("-2");
                case -111:
                    return ("-111");
                case -112:
                    return ("-112");
                case -114:
                    return ("-114");
                case -115:
                    return ("-115");
                case -116:
                    return ("-116");
                case -201:
                    return ("-201");
                case -202:
                    return ("-202");
                case -203:
                    return ("-203");
                case -211:
                    return ("-211");
                case -301:
                    MessageBox.Show("認証に失敗しました。");
                    return ("-301");
                case -302:
                    MessageBox.Show("DataLab.サービスの利用有効期限が切れています。");
                    return ("-302");
                case -303:
                    return ("-303");
                case -604:
                    MessageBox.Show("サーバーがメンテナンス中です。");
                    return ("-604");
            }
            return (errno.ToString());
        }

        public String ChgYearOldString(String CD, int function)
        {
            if (function == 0)
            {
                switch (CD)
                {
                    case "00": return ("");
                    case "11": return ("サラ系２歳");
                    case "12": return ("サラ系３歳");
                    case "13": return ("サラ系３歳以上");
                    case "14": return ("サラ系４歳以上");
                    case "18": return ("サラ障害３歳以上");
                    case "19": return ("サラ障害４歳以上");
                    default: return ("");

                }
            }

            if(function == 1)
            {
                switch (CD)
                {
                    case "00": return ("");
                    case "11": return ("２歳");
                    case "12": return ("３歳");
                    case "13": return ("３歳以上");
                    case "14": return ("４歳以上");
                    case "18": return ("３歳以上障害");
                    case "19": return ("４歳以上障害");
                    default: return ("");

                }

            }
            return ("");
        }

        /** グレードコード変換関数
         * */
        public String ChgGradeCdToString(String GradeCd)
        {
            switch (GradeCd)
            {
                case "A":
                    return ("ＧⅠ");
                case "B":
                    return ("ＧⅡ");
                case "C":
                    return ("ＧⅢ");
                case "D":
                    return ("重賞");
                case "E":
                    return ("特別競走");
                case "F":
                    return ("Ｊ・ＧⅠ");
                case "G":
                    return ("Ｊ・ＧⅡ");
                case "H":
                    return ("Ｊ・ＧⅢ");
                default:
                    return ("");
            }
        }

        //SelectData→芝・ダートなど短縮形
        public String CngTrackCdtoString(int SelectData, String TrackCD)
        {
            if (SelectData == 1)
            {
                switch (TrackCD)
                {
                    case "10": return ("芝");
                    case "11": return ("芝");
                    case "12": return ("芝");
                    case "13": return ("芝");
                    case "14": return ("芝");
                    case "15": return ("芝");
                    case "16": return ("芝");
                    case "17": return ("芝");
                    case "18": return ("芝");
                    case "19": return ("芝");
                    case "20": return ("芝");
                    case "21": return ("芝");
                    case "22": return ("芝");
                    case "23": return ("ダート");
                    case "24": return ("ダート");
                    case "25": return ("ダート");
                    case "26": return ("ダート");
                    case "27": return ("サンド");
                    case "28": return ("サンド");
                    case "29": return ("ダート");
                    case "51": return ("芝");
                    case "52": return ("芝→ダート");
                    case "53": return ("芝");
                    case "54": return ("芝");
                    case "55": return ("芝");
                    case "56": return ("芝");
                    case "57": return ("芝");
                    case "58": return ("芝");
                    case "59": return ("芝");
                }
            }else if(SelectData == 2)
            {
                switch (TrackCD)
                {
                    case "10": return ("芝・直");
                    case "11": return ("芝・左");
                    case "12": return ("芝・左外");
                    case "13": return ("芝・左内→外");
                    case "14": return ("芝・左外→内");
                    case "15": return ("芝・左内２周");
                    case "16": return ("芝・左外２周");
                    case "17": return ("芝・右");
                    case "18": return ("芝・右外");
                    case "19": return ("芝・右内→外");
                    case "20": return ("芝・右外→内");
                    case "21": return ("芝・右内２周");
                    case "22": return ("芝・右外２周");
                    case "23": return ("ダート・左");
                    case "24": return ("ダート・右");
                    case "25": return ("ダート・左内");
                    case "26": return ("ダート・右外");
                    case "27": return ("サンド・左");
                    case "28": return ("サンド・右");
                    case "29": return ("ダート・直");
                    case "51": return ("芝・襷");
                    case "52": return ("芝→ダート");
                    case "53": return ("芝・左");
                    case "54": return ("芝");
                    case "55": return ("芝・外");
                    case "56": return ("芝・外→内");
                    case "57": return ("芝・内→外");
                    case "58": return ("芝・内２周");
                    case "59": return ("芝・外２周");
                }
            }
            return ("");
        }

    }
}

