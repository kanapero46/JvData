using AxJVDTLabLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibJvSysCore;

namespace TestJVApp
{  

    struct CONNER
    {
        public int conner1;
        public int conner2;
        public int conner3;
        public int conner4;
    }
    struct KaisaiInfoStructures
    {
        public int idx;             //Dummyのインデックス
        public int[] index;         //配列インデックス
        public String[] Jomei;      //場名
        public int[] DayRaceMaxCounter; //各場の１日レース最大数
        public int MaxRaceCounter;  //レース最大数
    }

    struct JvDataStructures
    {
        public String Date;            /* 日付 */
        public int Kai;             /* 回 */
        public int Nichi;           /* 日目 */
        public String RaceCourse;      /* 場名 */
        public int RaceNumber;         /* レース番号 */
        public String RaceName;        /* レース名 */
        public String TD;          /* 芝・ダート */
        public int Distance;           /* 距離(mつけない) */
    }

    struct JvRaceDataBasicStructures
    {
        public int Waku;            /* 枠番 RACE */
        public int Umaban;          /* 馬番 RACE*/
        public String Bamei;        /* 馬名 Race */
        public String Jokkey;       /* 騎手 RACE */
        public Double Omosa;        /* 斤量 RACE */
    }

    struct BloodData
    {
        public String fHorse;       /* 父 MASTER */
        public String mHours;       /* 母 MASTER */
        public String BMS;          /* 母父 MASTER */
        public String BMS1;         /* 母母父 MASTER */
    }

    struct JvRaceDataStructures     /* レース情報基本データ構造体 */
    {
        public JvRaceDataBasicStructures id;    /* 基本情報 */
        public BloodData Blood;     /* 血統情報 */
        public String Kyakushitu;   /* 脚質 RACE */
        public String sex;          /* 性別 RACE */
        public int Year;            /* 年齢 RACE */
    }
    
    struct JvRaceDataMasterStructures   /* レース情報過去データ構造体 */
    {
        public int ID;                /* レース情報ヘッダ */
        public JvRaceDataBasicStructures Common;    /* レース情報共通情報(馬名など) */
        public BloodData Blood;
        public String BabaJotai;     /* 馬場状態 */
        public String Rank;          /* 着順 （取消などが入るためString型で保持 */
        public String Time;          /* 走破タイム */
        public int SyusouTosu;       /* 頭数 */
        public String Bataiju;          /* 馬体重 */
        public String Zougen;        /* 馬体重増減 */
        public String BataijuDiff;      /* 増減差 */
        public CONNER Conner;        /* コーナー順位 */
        public String final3F;       /* 上がり3F */
        public String AiteUma;       /* 相手馬 */
        public String DiffTime;      /* タイム差 */
    }

    //JVとのやり取りやデータはこの関数で保持。
    //他のクラスやフォームはデータのゲットをする設計を考える。
    //エラーコードチェックは呼び出し元で行うこと。
    class Main
    {
        /* クラス */
        func Func = new func();
        JVData_Struct axJvObject = new JVData_Struct();
        JVData_Struct JvData = new JVData_Struct();
        JVData_Struct.JV_RA_RACE RaceData = new JVData_Struct.JV_RA_RACE();
        JVData_Struct.JV_SE_RACE_UMA RaceUmaData = new JVData_Struct.JV_SE_RACE_UMA();
        Form2 JvMain = new Form2();
        Form1 f1 = new Form1();

        /* 各種データ：定数・変数 */
        private int JRAKeibajo = 10;        //JRAの競馬場最大値
        static int MaxRaceCount = 36;      //一日の最大レース数 → ３の倍数にすること

        const int RESULT_OK = 1;
        const int RESULT_NG = 0;
        const int RESULT_PARAM_ERROR = -1;

        //String[] Jomei = new String[MaxRaceCount / 12];
        String[] RaceName = new String[MaxRaceCount];
       // String[,] TrackDist = new String[MaxRaceCount,2];
        
        //  String[] RaceNum = new String[MaxRaceCount];

        /* 配列 */
        List<String> RaceNum = new List<String>();
        List<String> HName = new List<string>();
        List<int> RaceCount = new List<int>();
        List<String> Track = new List<String>();
        List<String> Distance = new List<String>();
        List<String> KaisaiDate = new List<String>();

        List<JvDataStructures> tmp = new List<JvDataStructures>();
        static JvDataStructures DefData = new JvDataStructures();
        static List<JvDataStructures> ArrayDefData = new List<JvDataStructures>();

        static List<JvRaceDataStructures> ArrayRaceData = new List<JvRaceDataStructures>();
        static JvRaceDataStructures tmpRaceData = new JvRaceDataStructures();

        static KaisaiInfoStructures KaisaiInfo = new KaisaiInfoStructures();

        String JyoMei;
        String Speckind;
        String F3func;                      //Form3で表示する開催競馬場
        Boolean jFlag = false;

        String[] Horsename = new String[MaxRaceCount];

        /* 過去走用 */
        JvRaceDataMasterStructures[,] FormParfomance = new JvRaceDataMasterStructures[3,18]; /* 左　0：前走・・・　右：1頭目 */
        List<JvRaceDataMasterStructures> tmpFormPerfomance = new List<JvRaceDataMasterStructures>();
        List<JvRaceDataMasterStructures> tmpFormPerfomanceSE = new List<JvRaceDataMasterStructures>();
        List<JvRaceDataMasterStructures> tmpFormPerfomanceRA = new List<JvRaceDataMasterStructures>();

        int[] RaceCounter = new int[MaxRaceCount / 12];
        int j = 0;
        int gCacheJoMeiIndex = 0;
        
        //出走馬データ
        String[,] Bamei = new string[3, 18];

        public int JvOpenFunction(String Data, String Time, int opKind, ref int ReadCount, ref int DownloadCount, out String LastTime)
        {
            int ret;
            ret = JvMain.OpenJv(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime);
            //f1.CloseJv();
            //ret = f1.RTJvOpen("0B15", "20180623");

            return (ret);

        }

        public int ExtJvOpenEntrance(int RaceNum, String date)
        {
            int ret = 0;

            InitFunction();

            /* JvDataの初期化 */
            ret = JvMain.InitJv();
            CheckErrorCode(ret);

            /* 今年日付を入れる */
            DateTime dt = DateTime.Now;
            if (date.Length == 3)
            {
                date = dt.Year.ToString() + "0" + date;
            }
            else
            {
                date = dt.Year.ToString() + date;
            }

            ret = prJvOpenFunc("20180719" + "000000", "RCOV");
            CheckErrorCode(ret);

            ret = JvReadFuncToRCOVData();
            CheckErrorCode(ret);

            return (ret);
        }

        private int JvReadFuncToRCOVData()
        {
            String buff = null;
            int buffsize = 2000;
            String fName = null;
            int skipCount = 0;
            int boolStatus = 0;
            Boolean eof = false;
            
            do
            {
                int ret = JvMain.ReadJv(out buff, out buffsize, out fName);

                if (ret == -1)
                {
                    /* ファイルの切り替え */
                    if (eof == true)
                    {
                       break;
                    } //２日分の開催データ取得完了

                    JvMain.SkipJv();
                }
                else if (buff == null)
                {
                    break;  //エラー
                }
                else if (ret == 0)
                {
                    if (eof == true)
                    {
                        /* ファイル読み込みの終了 */
                        break;
                    }
                    else
                    {
                        skipCount++;        //３回以上スキップしたら終了する。
                        JvMain.SkipJv();
                        continue;
                    }

                }
                if(buff == null){
                    JvMain.SkipJv();
                    continue;
                }
                
                JvRaceDataMasterStructures MasterDataSe = new JvRaceDataMasterStructures();
                switch (buff.Substring(0, 2))
                {
                    case "SE":
                        /* 相手馬 */
                        JVData_Struct.JV_SE_RACE_UMA Se = new JVData_Struct.JV_SE_RACE_UMA();
                        
                        Se.SetDataB(ref buff);
                        MasterDataSe.Common.Waku = Int32.Parse(Se.Wakuban);
                        MasterDataSe.Common.Umaban = Int32.Parse(Se.Umaban);
                        MasterDataSe.Common.Bamei = Se.Bamei;
                        MasterDataSe.Common.Jokkey = Se.KisyuRyakusyo;
                        MasterDataSe.Common.Omosa = Int32.Parse(Se.Futan);
                        MasterDataSe.Rank = Se.KakuteiJyuni;
                        if (Se.KakuteiJyuni.Equals("01"))
                        {
                            MasterDataSe.AiteUma = "(" + Se.ChakuUmaInfo[0].Bamei + ")";
                        }
                        else
                        {
                            MasterDataSe.AiteUma = Se.ChakuUmaInfo[0].Bamei;
                        }
                        MasterDataSe.Bataiju = Se.BaTaijyu;
                        MasterDataSe.Zougen = Se.ZogenFugo;             /* + - */
                        MasterDataSe.BataijuDiff = Se.ZogenSa;

                        MasterDataSe.final3F = Se.HaronTimeL3;
                        MasterDataSe.DiffTime = Se.TimeDiff;
                        MasterDataSe.Conner.conner1 = Int32.Parse(Se.Jyuni1c);
                        MasterDataSe.Conner.conner2 = Int32.Parse(Se.Jyuni2c);
                        MasterDataSe.Conner.conner3 = Int32.Parse(Se.Jyuni3c);
                        MasterDataSe.Conner.conner4 = Int32.Parse(Se.Jyuni4c);
                        MasterDataSe.Time = Se.Time;
                        
                        
                        tmpFormPerfomanceSE.Add(MasterDataSe);
                        break;
                    case "RA":
                        /* 頭数・馬場状態 */
                        JVData_Struct.JV_RA_RACE Race = new JVData_Struct.JV_RA_RACE();
                        Race.SetDataB(ref buff);
                        String TrackCD = Race.TenkoBaba.SibaBabaCD + Race.TenkoBaba.DirtBabaCD;
                        MasterDataSe.SyusouTosu = Int32.Parse(Race.SyussoTosu);
                        MasterDataSe.BabaJotai = TrackCD;
                        
                        tmpFormPerfomanceRA.Add(MasterDataSe);
                        break;
                    case "UM":
                        JVData_Struct.JV_UM_UMA Uma = new JVData_Struct.JV_UM_UMA();
                        JvRaceDataMasterStructures MasterData = new JvRaceDataMasterStructures();
                        Uma.SetDataB(ref buff);
                        MasterDataSe.Common.Bamei = Uma.Bamei;
                        MasterDataSe.Blood.fHorse = Uma.Ketto3Info[0].Bamei;
                        MasterDataSe.Blood.mHours = Uma.Ketto3Info[1].Bamei;
                        MasterDataSe.Blood.BMS = Uma.Ketto3Info[4].Bamei;
                        MasterDataSe.Blood.BMS1 = Uma.Ketto3Info[12].Bamei;
                        tmpFormPerfomance.Add(MasterDataSe);
                        break;
                }
            }while (boolStatus == 0 && skipCount < 10);

            /* 結合処理を加える */
          //  JointmpFormPerfomanceData();
            return (0);
        }

        void JointmpFormPerfomanceData()
        {
            int one = tmpFormPerfomance.Count();
            int two = tmpFormPerfomanceSE.Count();
            int three = tmpFormPerfomanceRA.Count();

            if (one == 0 || two == 0 || three == 0)
            {
                return;
            }
            
        }

        private int prJvOpenFunc(String date,String Data)
        {
            int ret;
            //String Data = Data;
            String Time = date;
            int opKind = 2;
            int ReadCount = 0;
            int DownloadCount = 0;
            String LastTime;

            Speckind = Data;
            ret = JvOpenFunction(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime);

            return (ret);

        }

        /** JvReadのI/F関数：呼び出し元でエラーチェックを行う
         * 引数などを指定する場合は別の関数を呼ぶこと
         * */
        public int JvReadFunc()
        {
            String buff = null;
            int buffsize = 2000;
            String fName = null;

            int ret = RunJvReadFunc(out buff, out buffsize, out fName, 0);

            return (ret);

        }

        /** JvReadのI/F関数：呼び出し元でエラーチェックを行う
         * 呼び出しに引数で指定したデータを返すことのできる関数
         * */
        public int ExtJvReadFunc(ref String buff, ref int buffsize, ref String fName)
        {
            return (RunJvReadFunc(out buff, out buffsize, out fName,0));
        }

        /* JvReadのラッパー関数 */
        private int RunJvReadFunc(out String buff, out int buffSize, out String fName, int funcNumber)
        {

            int ret;
            int boolStatus = 0;
            Boolean eof = false;
            int racecnt = 0;
            int skipCount = 0;
            

            do {
                ret = JvMain.ReadJv(out buff, out buffSize, out fName);
                
                if (ret == -1)
                {
                    /* ファイルの切り替え */
                    if (eof == true) {
                        skipCount++;
                        break;
                    } //２日分の開催データ取得完了

                    eof = true;
                    JvMain.SkipJv();
                }
                else if (buff == null)
                {
                    break;  //エラー
                }
                else if (ret == 0)
                {
                    if (eof == true)
                    {
                        /* ファイル読み込みの終了 */
                        break;
                    }
                    else
                    {
                        skipCount++;        //３回以上スキップしたら終了する。
                        JvMain.SkipJv();
                    }
                    
                }
                else if (ret < 0)
                {
                    /* -2以下の場合はエラー*/
                    boolStatus = -1;
                }
                else
                {
                    /* 正常のデータ */
                    eof = false;
                    JVData_Struct.RECORD_ID rec = new JVData_Struct.RECORD_ID();
                    String RecordSpec = buff.Substring(0, 2);


                    switch (RecordSpec)
                    {
                        case "RA":

                            /* レース情報詳細 */
                            /*JVData_Struct.JV_RA_RACE RaceData = new JVData_Struct.JV_RA_RACE();*/
                            RaceData.SetDataB(ref buff);

                            RunJvReadFuncToRAData(RaceData,funcNumber);
                            //  MessageBox.Show(RaceData.RaceInfo.Hondai);

                            break;
                        case "SE":
                            /* 馬毎レース情報 */
                            RaceUmaData.SetDataB(ref buff);
                            
                            tmpRaceData.id.Waku = Int32.Parse(RaceUmaData.Wakuban);
                            tmpRaceData.id.Umaban = Int32.Parse(RaceUmaData.Umaban);
                            tmpRaceData.id.Bamei = RaceUmaData.Bamei;
                            tmpRaceData.id.Jokkey = RaceUmaData.KisyuRyakusyo;
                            tmpRaceData.id.Omosa = Double.Parse(RaceUmaData.Futan);
                            tmpRaceData.Kyakushitu = RaceUmaData.KyakusituKubun;
                            tmpRaceData.sex = Func.ChgSexCdToString(RaceUmaData.SexCD);
                            tmpRaceData.Year = Int32.Parse(RaceUmaData.Barei);

                            ArrayRaceData.Add(tmpRaceData);

                            break;
                        /* 競走馬マスタ取得　→　dataspecをRCOVで指定するときに処理される */
                        case "UM":
                            JVData_Struct.JV_UM_UMA UmaMaster = new JVData_Struct.JV_UM_UMA();
                            UmaMaster.SetDataB(ref buff);

                            RunJvReadMasterFunc(UmaMaster);
                            
                            break;
                        default:
                            JvMain.SkipJv();
                            break;
                    }
                    
                }
            } while (boolStatus == 0 && skipCount < 3);

            if (boolStatus == -1)
            {
                CheckErrorCode(ret);
            }

            return (ret);
        }

        private int RunJvReadMasterFunc(JVData_Struct.JV_UM_UMA UmaMaster)
        {

            JvRaceDataMasterStructures tmp = new JvRaceDataMasterStructures();
            
            if (tmpRaceData.id.Bamei == null || UmaMaster.head.RecordSpec == null)
            {
                return (RESULT_NG);
            }
            else if (tmpRaceData.id.Bamei.Equals(UmaMaster.Bamei))
            {
                tmpRaceData.Blood.fHorse = UmaMaster.Ketto3Info[0].Bamei;
                tmpRaceData.Blood.mHours = UmaMaster.Ketto3Info[1].Bamei;
                tmpRaceData.Blood.BMS = UmaMaster.Ketto3Info[4].Bamei;
                tmpRaceData.Blood.BMS1 = UmaMaster.Ketto3Info[12].Bamei;
                return (RESULT_OK);
            }

            return (RESULT_NG);
        }

        private void RunJvReadFuncToRAData(JVData_Struct.JV_RA_RACE buff, int funcNumber)
        {
            JvRaceDataMasterStructures RaceMaster = new JvRaceDataMasterStructures();

            if (funcNumber == 0)
            {
                //開催日データ・セット
                setkaisaiDate(RaceData.id.MonthDay);

                RaceNum.Add(LibJvSysCore.libJvSysCore.(RaceData.id.JyoCD + RaceData.id.RaceNum + "Ｒ"));  //場名+レース番号＋R
                String Old = Func.ChgYearOldString(RaceData.JyokenInfo.SyubetuCD, 1);      //３歳以上
                String Joken = Func.CngRaceCla(RaceData.JyokenInfo.JyokenCD);           //５００万下
                String TD = Func.CngTrackCdtoString(1, RaceData.TrackCD);                //芝・ダート

                DefData.Date = RaceData.id.MonthDay;
                DefData.Kai = Int32.Parse(RaceData.id.Kaiji);
                DefData.Nichi = Int32.Parse(RaceData.id.Nichiji);
                DefData.RaceCourse = Func.ChgJyoCDtoString(RaceData.id.JyoCD);            //場名
                DefData.RaceNumber = Int32.Parse(RaceData.id.RaceNum);                    //レース番号
                DefData.TD = Func.CngTrackCdtoString(1, RaceData.TrackCD);                //芝・ダート
                DefData.Distance = Int32.Parse(RaceData.Kyori);                           //距離

                //コース・距離
                Track.Add(TD);
                Distance.Add(RaceData.Kyori);


                if (RaceData.RaceInfo.Hondai.TrimEnd().Equals(""))
                {
                    //条件レース
                    DefData.RaceName = Old + Joken;
                    HName.Add(Old + Joken);
                }
                else
                {
                    String Name = RaceData.RaceInfo.Hondai.TrimEnd();
                    if (RaceData.GradeCD.Equals(" ") || RaceData.GradeCD.Equals("E"))
                    {
                        /* 重賞レース以外　→　条件入れる */
                        HName.Add(Name + "（" + Old + Joken + "）");
                        DefData.RaceName = Name;
                    }
                    else
                    {
                        //重賞レース　→　グレード入れる
                        HName.Add(Name + "（" + Func.ChgGradeCdToString(RaceData.GradeCD) + "）");
                        DefData.RaceName = Name + "(" + Func.ChgGradeCdToString(RaceData.GradeCD) + "）";
                    }
                }

                JyoMei = Func.ChgJyoCDtoString(RaceData.id.JyoCD);
                tmp.Add(DefData);
                KaisaiInfo.MaxRaceCounter++;    //最大レース数

                /* 開催情報 */
                FunctionKaisaiDateInfo(JyoMei);

                ArrayDefData.Add(DefData);
            }
            else if(funcNumber == 1)
            {
                /* 過去のデータ */
                return;
            }
            
        }

        /** Form1から呼び出し
         * 開催競馬場の取得
         */
        public Boolean runManinFunction(String date)
        {
            int ret = 0;
            String ErrMessage = "";  //v00.03-00 ライブラリ対応
            InitFunction();

            /* JvDataの初期化 */
            ret = JvMain.InitJv();
            CheckErrorCode(ret);    //エラーチェック
            if (LibScs.LibScsCheckErrorCode(ret,ref ErrMessage) == false) { f1.ThisClose(ErrMessage); }

            /* JvDataをOpen */
            String Data = "RACE";
            ret = prJvOpenFunc(date,Data);
            //ret = f1.RTJvOpen("0B15","20180623");
            if (ret != 0)CheckErrorCode(ret);

            /* JvDateの読み込み */
            ret = JvReadFunc();
            if(ret <= -3)CheckErrorCode(ret);
            
            JvMain.CloseJv();
            return (true);
        }

        /* 初期化(Initialize) */
        private void InitFunction()
        {
               
            KaisaiDate.Clear();
            RaceNum.Clear();
            HName.Clear();

            //36レース/6　= 6つ（1日3場×２）
            KaisaiInfo.Jomei = new string[MaxRaceCount/6];
            KaisaiInfo.index = new int[MaxRaceCount / 6];
            KaisaiInfo.DayRaceMaxCounter = new int[MaxRaceCount / 6];

            ArrayDefData.Clear();
            KaisaiInfo.MaxRaceCounter = 0;
            KaisaiInfo.idx = 0;
            Array.Clear(KaisaiInfo.index, 0, KaisaiInfo.index.Length);
            Array.Clear(KaisaiInfo.DayRaceMaxCounter, 0, KaisaiInfo.DayRaceMaxCounter.Length);
            if(KaisaiInfo.Jomei[0] != null)Array.Clear(KaisaiInfo.Jomei, 0, KaisaiInfo.Jomei.Length);

            for (int i = 0; i<RaceCounter.Length; i++)
            {
                RaceCounter[i] = 0;
            }
        }

        public void CheckErrorCode(int ret)
        {
           
            if (ret < 0)
            {
                MessageBox.Show("" + ret);
                this.JvMain.CloseJv();
                f1.ThisClose("エラーにより終了します。" );
            }
        }

        public int getJomeiIndex(String RC)
        {
            for (int idx = 0; idx < KaisaiInfo.Jomei.Length; idx++)
            {
                if (KaisaiInfo.Jomei[idx].Equals(RC))
                {
                    return (idx);
                }
            }

            return (-1);
           
        }

        public string getJomei(int idx)
        {
            if(this.JyoMei == null)
            {
                return ("");
            }
            if (idx > this.JyoMei.Length)
            {
                CheckErrorCode(-998); return ("");
            }
            else
            {
                return (KaisaiInfo.Jomei[idx]);
            }
        }

        /** Form1からForm3を表示する
         * 　競馬場の指定をここでする
         * */
        public void ShowMainFunction(String RC)
        {
            String[,] TD = new String[MaxRaceCount,2];
            for (int i = 0; i<MaxRaceCount; i++)
            {
                TD[i, 0] = this.Track[i];
                TD[i,1] = this.Distance[i];
            }


            this.F3func = RC;         //Form3で表示する競馬場名

            Form3 f3 = new Form3(RC, ArrayDefData, KaisaiInfo, KaisaiDate);
            f3.Show();
        }
        

        /** Form3で表示する競馬場名を取得
        * 　競馬場の指定をここでする
        *  */
        public string getRCFunction()
        {
            return (this.F3func);
        }

        public int getMaxRaceCount()
        {
            return (MaxRaceCount);
        }

        private void setkaisaiDate(String date)
        {
            int i = 0;
            Boolean ret = false;
            /* nullチェック */
            if (KaisaiDate == null || date == null)
            {
                return;
            }

            try
            {
                if (KaisaiDate.Count == 0)
                {
                    KaisaiDate.Add(date);
                    return;
                }

                do
                {
                    for(int j = 0; j < KaisaiDate.Count; j++)
                    {
                        if (KaisaiDate[j].Equals(date)) ret = true; 
                    }

                    if(ret == false)
                    {
                        //開催日を配列に代入
                        KaisaiDate.Add(date);
                    }

                    i++;
                }while(i < KaisaiDate.Count || ret == false);

            }
            catch (OutOfMemoryException e) 
            {
                Console.Write(e);
                KaisaiDate.Add(date);
            }

            return;
        }

        public void FunctionKaisaiDateInfo(String JoMei)
        {
            int ArrayCnt = KaisaiInfo.Jomei.Length;

            for (int i = gCacheJoMeiIndex; i < ArrayCnt; i++,gCacheJoMeiIndex++)
            {

                if (KaisaiInfo.Jomei[i] == null)
                {
                    /* 場名に入れていない競馬場 */
                    KaisaiInfo.Jomei[i] = JoMei;            /* 場名を入れる */
                    KaisaiInfo.DayRaceMaxCounter[i] = 1;    /* 最初の１レース目を入れる */
                    KaisaiInfo.idx++;
                    return;
                }
                else if (KaisaiInfo.Jomei[i].Equals(JoMei))
                {
                    /* 場名にすでに入っている競馬場 */
                    KaisaiInfo.idx++;                       /* ダミーカウント       */
                    KaisaiInfo.DayRaceMaxCounter[i]++;      /* 各場１日最大レース数  */
                    return;
                }
                else
                {
                    continue;
                }
            }

            KaisaiInfo.Jomei[ArrayCnt] = JoMei;

        }
    }
}
