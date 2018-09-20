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
using LibJvSysCore;

namespace TestJVApp
{ 

    public partial class Form1 : Form
    {
        //デバッグ処理の有効・無効
        Boolean DebugFlag = true;
        Boolean statusData = false;
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
                dateTimePicker1.MaxDate = dtToday.AddDays(2);
            }
            statusData = false;
            statusBar1.Text = "開催情報を取得してください。";

        }

        public int CheckReturnCode(int ret)
        {

            switch (ret){
                case 0:
                    break;
                default:
                    MessageBox.Show("エラーが発生しました。");
                    break;
            }
            return 1;
        }

        public void ThisClose(String ErrMessage)
        {
            MessageBox.Show(ErrMessage);
            axJVLink1.JVClose();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String date = dateTimePicker1.Value.ToString("yyyyMMdd") + "000000";
            statusBar1.Text = "開催情報取得中(DataLab.接続中...)";

            /* インプットデータから */
            statusData = main.runManinFunction(date);
                        
            //ボタンの有効化
            for(int idx = 0; idx <= 2; idx++)
            {
                EnableButtonFunction(main.getJomei(idx));
            }

            /* ステータスバーの文字修正 */
            if (statusData == true)
            {
                statusBar1.Text = "競馬場名をクリックすると、開催情報を取得することが出来ます。";
            }
            else
            {
                statusBar1.Text = "開催情報の取得に失敗しました。";
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
                SyncData.setJomei(idx, toStr.ChgJyoCDtoString(JvRaRace.id.JyoCD));
            }

            textBox1.AppendText(toStr.CngJyoNum(JvRaRace.id.JyoCD, JvRaRace.id.RaceNum) +
                                                ":" +
                                                JvRaRace.RaceInfo.Hondai.TrimEnd() +
                                                "(" +
                                                
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
            main.ShowMainFunction("札幌");
        }

        private void hakodate_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("函館");

        }

        private void fukushima_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("福島");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("東京");

        }

        private void nakayama_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("中山");

        }

        private void tokyo_Click(object sender, EventArgs e)
        {
            
            main.ShowMainFunction("東京");
        }

        private void chukyo_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("中京");


        }

        private void kyoto_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("京都");

        }

        private void hanshin_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("阪神");

        }

        private void kokura_Click(object sender, EventArgs e)
        {
            main.ShowMainFunction("小倉");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            libJvSysCore.GetibraryVersion(); 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusBar1_PanelClick(object sender, StatusBarPanelClickEventArgs e)
        {

        }
    }//class end
}


