using AxJVDTLabLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JVDTLabLib;

namespace TestJVApp
{ 

    public partial class Form1 : Form
    {
        //デバッグ処理の有効・無効
        Boolean DebugFlag = true;
        func toStr = new func();    //共通変換クラス
        Main main = new Main();     //メインクラスのオブジェクト宣言
        JVDataClass.Race SyncData = new JVDataClass.Race();
        DateTime dtToday = DateTime.Now;        //今日の日付
        String[,] bamei = new String[18, 2];
        public JVData_Struct.JV_RA_RACE JvRaRace = new JVData_Struct.JV_RA_RACE(); //競走馬データ

        public static JVData_Struct.JV_SE_RACE_UMA JvRaData { get; private set; }

        public Form1()
        {
            InitializeComponent();
            DayOfWeek uWeekday = dtToday.DayOfWeek; //今日の曜日
            if (uWeekday == DayOfWeek.Saturday)
            {
                //日付に指定できるのは日曜+1までにする。
                dateTimePicker1.MaxDate = dtToday.AddDays(1);
            }
            else
            {
                dateTimePicker1.MaxDate = dtToday;
            }

        }

        public int CheckReturnCode(int ret)
        {

            switch (ret){
                case 0:
                    break;
                defalut:
                    MessageBox.Show("エラーが発生しました。");
                    break;
            }

            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ret = 0;

            ret = axJVLink1.JVInit("UNKNOWN");

            if (ret != 0)
            {
                //0以外はエラーとなる
                MessageBox.Show("初期化に失敗しました。\nReturnCode=" + ret);
                this.Close();
            }


            String Data = "RACE";
            String Time = dateTimePicker1.Value.ToString("yyyyMMdd000000");
            int opKind = 1;
            int ReadCount = 0;
            int DownloadCount = 0;
            String LastTime = null;
            int Status = 0;
           

            ret = axJVLink1.JVOpen(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime);
#if (DebugFlag == true)
            Consoal.WriteLine(ret);
#endif
            if (ret != 0)
            {
                //エラー
                    toStr.ErrCodetoString(ret);
                    Status = -1;
            }

            String buff;
            int buffSize = 3000;
            String fName = null;

            //すでにボタンが押せる状態なら一旦Disbleに
            DisbleButtonFunction();
            returncode.Text = "";

            do {

                if(Status == -1)
                {
                    //JVOpenエラー
                    break;
                }

                ret = axJVLink1.JVRead(out buff, out buffSize, out fName);

                if (ret == 0)
                {
                    //ファイル取得の終了(EOF)
                    Status = -1;
                    info1.Text = "";
                    break;
                }

                if(ret == -1 && buff == null)
                {
                    //1日分のデータ取得完了
                    continue;
                }else if(ret <= -2 && buff == null)
                {
                    toStr.ErrCodetoString(ret);
                    Status = -1;
                    break;
                }
      

                JVData_Struct.RECORD_ID SpecId = new JVData_Struct.RECORD_ID();

                SpecId.RecordSpec = buff.Substring(0, 2);
                String RID = SpecId.RecordSpec;

                switch (RID)
                {
                    case "RA":
                        RunRADataFunction(buff);
                        break;
                    case "SE":
                        //RunSEDataFunction(buff);
                        break;
                    default:
                        axJVLink1.JVSkip();
                        break;
                }

   
            } while (Status == 0 || Status == 1);

            if (ret != 0)
            {
                //エラーコードを画面上に出す。
                returncode.Text = toStr.ErrCodetoString(ret);
            }
            
            //ボタンの有効化
            for(int idx = 0; idx <= 2; idx++)
            {
                EnableButtonFunction(SyncData.getJomei(idx));
            }
            axJVLink1.JVClose();
        }

        //レース情報処理
        public void RunRADataFunction(String buff)
        {
            //JvRaRace.Initialize(); SetDataBでInitializeが走るため不要
            JvRaRace.SetDataB(ref buff);

            for (int idx = 0; idx < 2; idx++)
            {
                //場名をセット
                SyncData.setJomei(idx, toStr.JyoCDtoString(JvRaRace.id.JyoCD));
            }

            textBox1.AppendText(toStr.CngJyoNum(JvRaRace.id.JyoCD, JvRaRace.id.RaceNum) +
                                                ":" +
                                                JvRaRace.RaceInfo.Hondai.TrimEnd() +
                                                "(" +
                                                toStr.CngRaceCla(JvRaRace.JyokenInfo.JyokenCD[1]) +
                                                ")\n");
        }

        public void RunSEDataFunction(String buff)
        {

        }

        //メイン画像のボタン有効化
        public void EnableButtonFunction(String Location)
        {
            switch (Location)
            {
                case "札幌":
                    sapporo.Enabled = true;
                    break;
                case "函館":
                    hakodate.Enabled = true;
                    break;
                case "福島":
                    fukushima.Enabled = true;
                    break;
                case "新潟":
                    niigata.Enabled = true;
                    break;
                case "東京":
                    tokyo.Enabled = true;
                    break;
                case "中山":
                    nakayama.Enabled = true;
                    break;
                case "中京":
                    chukyo.Enabled = true;
                    break;
                case "京都":
                    kyoto.Enabled = true;
                    break;
                case "阪神":
                    hanshin.Enabled = true;
                    break;
                case "小倉":
                    kokura.Enabled = true;
                    break;
            }
        }

        public void DisbleButtonFunction()
        {
            sapporo.Enabled = false;
                    hakodate.Enabled = false;

                    fukushima.Enabled = false;

                    niigata.Enabled = false;
    
                    tokyo.Enabled = false;

                    nakayama.Enabled = false;

                    chukyo.Enabled = false;
  
                    kyoto.Enabled = false;
    
                    hanshin.Enabled = false;
   
                    kokura.Enabled = false;
        }



        //開催競馬場ボタンのクリック処理
        private void sapporo_Click(object sender, EventArgs e)
        {
            main.showMainFunction("札幌", SyncData);
        }

        private void hakodate_Click(object sender, EventArgs e)
        {
            main.showMainFunction("函館", SyncData);

        }

        private void fukushima_Click(object sender, EventArgs e)
        {
            main.showMainFunction("福島", SyncData);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            main.showMainFunction("東京", SyncData);

        }

        private void nakayama_Click(object sender, EventArgs e)
        {
            main.showMainFunction("中山", SyncData);

        }

        private void tokyo_Click(object sender, EventArgs e)
        {
            
            main.showMainFunction("東京", SyncData);
        }

        private void chukyo_Click(object sender, EventArgs e)
        {
            main.showMainFunction("中京", SyncData);


        }

        private void kyoto_Click(object sender, EventArgs e)
        {
            main.showMainFunction("京都", SyncData);

        }

        private void hanshin_Click(object sender, EventArgs e)
        {
            main.showMainFunction("阪神", SyncData);

        }

        private void kokura_Click(object sender, EventArgs e)
        {
            main.showMainFunction("小倉", SyncData);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }//class end
}


