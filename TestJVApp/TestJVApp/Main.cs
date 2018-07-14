using AxJVDTLabLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJVApp
{

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

    //JVとのやり取りやデータはこの関数で保持。
    //他のクラスやフォームはデータのゲットをする設計を考える。
    //エラーコードチェックは呼び出し元で行うこと。
    class Main
    {
        func Func = new func();
        JVData_Struct axJvObject = new JVData_Struct();
        JVData_Struct JvData = new JVData_Struct();
        JVData_Struct.JV_RA_RACE RaceData = new JVData_Struct.JV_RA_RACE();
        Form2 f1 = new Form2();

        //各種データ
        private int JRAKeibajo = 10;        //JRAの競馬場最大値
        static int MaxRaceCount = 36;      //一日の最大レース数 → ３の倍数にすること
        //String[] Jomei = new String[MaxRaceCount / 12];
        String[] RaceName = new String[MaxRaceCount];
       // String[,] TrackDist = new String[MaxRaceCount,2];
        
        //  String[] RaceNum = new String[MaxRaceCount];

        List<String> RaceNum = new List<String>();
        List<String> HName = new List<string>();
        List<int> RaceCount = new List<int>();
        List<String> Track = new List<String>();
        List<String> Distance = new List<String>();
        List<String> KaisaiDate = new List<String>();

        List<JvDataStructures> tmp = new List<JvDataStructures>();
        static JvDataStructures DefData = new JvDataStructures();
        static List<JvDataStructures> ArrayDefData = new List<JvDataStructures>();
        static KaisaiInfoStructures KaisaiInfo = new KaisaiInfoStructures();

        String JyoMei;

        String F3func;                      //Form3で表示する開催競馬場

        String[] Horsename = new String[MaxRaceCount];

        int[] RaceCounter = new int[MaxRaceCount / 12];
        int j = 0;
        int jidx = 0;

        //出走馬データ
        String[,] Bamei = new string[3, 18];

        /* イニシャライズ処理 */
        private void InitMainFunction()
        {


        }

        public int JvOpenFunction(String Data, String Time, int opKind, ref int ReadCount, ref int DownloadCount, out String LastTime)
        {
            int ret;
            ret = f1.OpenJv(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime);
            //f1.CloseJv();
            //ret = f1.RTJvOpen("0B15", "20180623");

            return (ret);

        }

        private int prJvOpenFunc(String date)
        {
            int ret;
            String Data = "RACE";
            String Time = date;
            int opKind = 2;
            int ReadCount = 0;
            int DownloadCount = 0;
            String LastTime;

            ret = JvOpenFunction(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime);

            return (ret);

        }

        /** JvReadのI/F関数：呼び出し元でエラーチェックを行う
         * 引数などを指定する場合は別の関数を呼ぶこと
         * */
        public int JvReadFunc()
        {
            String buff = null;
            int buffsize = 1500;
            String fName = null;

            int ret = RunJvReadFunc(out buff, out buffsize, out fName);

            return (ret);

        }

        /** JvReadのI/F関数：呼び出し元でエラーチェックを行う
         * 呼び出しに引数で指定したデータを返すことのできる関数
         * */
        public int ExtJvReadFunc(ref String buff, ref int buffsize, ref String fName)
        {
            return (RunJvReadFunc(out buff, out buffsize, out fName));
        }

        /* JvReadのラッパー関数 */
        private int RunJvReadFunc(out String buff, out int buffSize, out String fName)
        {

            int ret;
            int boolStatus = 0;
            Boolean eof = false;
            int racecnt = 0;
            int skipCount = 0;
            Boolean jFlag = false;

            do {
                ret = f1.ReadJv(out buff, out buffSize, out fName);
                
                if (ret == -1)
                {
                    /* ファイルの切り替え */
                    if (eof == true) {
                        skipCount++;
                        break;
                    } //２日分の開催データ取得完了

                    eof = true;
                    f1.SkipJv();
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
                        f1.SkipJv();
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

                            //開催日データ・セット
                            setkaisaiDate(RaceData.id.MonthDay);

                            RaceNum.Add(Func.ChgJyoCDtoString(RaceData.id.JyoCD + RaceData.id.RaceNum + "Ｒ"));  //場名+レース番号＋R
                            String Old = Func.ChgYearOldString(RaceData.JyokenInfo.SyubetuCD, 1);      //３歳以上
                            String Joken = Func.CngRaceCla(RaceData.JyokenInfo.JyokenCD);           //５００万下
                            String TD = Func.CngTrackCdtoString(1,RaceData.TrackCD);                //芝・ダート

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
                                    HName.Add(Name + "（" + Old + Joken + "）" );
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
                            try
                            {
                                if (KaisaiInfo.Jomei[jidx].Equals(JyoMei))
                                {
                                    ArrayDefData.Add(DefData);
                                    KaisaiInfo.Jomei[jidx] = DefData.RaceCourse;
                                    KaisaiInfo.DayRaceMaxCounter[jidx]++;
                                    jFlag = false;
                                    
                                }
                                else
                                {
                                    jidx++;
                                    KaisaiInfo.Jomei[jidx] = DefData.RaceCourse;
                                    KaisaiInfo.idx++;
                                    ArrayDefData.Add(DefData);
                                    KaisaiInfo.DayRaceMaxCounter[jidx]++;
                                }
                            }catch(NullReferenceException ex)
                            {
                                if (jFlag == true)
                                {
                                    break;
                                }

                                jFlag = true;
                                KaisaiInfo.Jomei[jidx] = DefData.RaceCourse;
                                KaisaiInfo.idx++;
                                ArrayDefData.Add(DefData);
                                KaisaiInfo.DayRaceMaxCounter[jidx]++;
                                
                            }
                            
                            //  MessageBox.Show(RaceData.RaceInfo.Hondai);

                            break;
                        case "SE":
                            /* 馬毎レース情報 */ 

                            break;
                        default:
                            f1.SkipJv();
                            break;
                    }
                    
                }
            }while (boolStatus == 0 && skipCount < 3);

            if (boolStatus == -1)
            {
                CheckErrorCode(ret);
            }

            return (ret);
        }

        public Boolean runManinFunction(String date)
        {
            int ret = 0;

            InitFunction();

            /* JvDataの初期化 */
            ret = f1.InitJv();
            CheckErrorCode(ret);


            /* JvDataをOpen */
            ret = prJvOpenFunc(date);
            //ret = f1.RTJvOpen("0B15","20180623");
            if (ret != 0)CheckErrorCode(ret);

            /* JvDateの読み込み */
            ret = JvReadFunc();
            if(ret <= -3)CheckErrorCode(ret);

            
            f1.CloseJv();
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
            Form1 f1 = new Form1();
            if (ret < 0)
            {
                MessageBox.Show("エラーにより終了します。" + ret);
                this.f1.CloseJv();
                f1.ThisClose();
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

            Form3 f3 = new Form3(RC, ArrayDefData, KaisaiInfo);
            f3.Show();
        }

        public JvDataStructures getHNameFunction()
        {
            return (DefData);
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
    }
}
