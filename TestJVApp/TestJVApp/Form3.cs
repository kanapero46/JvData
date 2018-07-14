using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJVApp
{

    struct LabelTable
    {
        Label Johmei;
        Label RaceName;
        Label Cource;
        Label Distance;
    }

    public partial class Form3 : Form
    {

        private JVData_Struct.JV_RA_RACE pJvDate = new JVData_Struct.JV_RA_RACE();


        //ここに宣言する。
        Main main = new Main();     //commonクラス
        func Func = new func();     //データConvクラス
        String Course;
        List<String> race = new List<string>();
        int[] RaceCounter = new int[3];
        int RCidx;
        int min,max;
        String[,] Info = new string[36, 3];
        List<String> date = new List<String>();

        internal Form3(String RC, List<JvDataStructures> JvDataStr, KaisaiInfoStructures KaisaiInfo, List<String> KaisaiDate)
        {
            InitializeComponent();
            //開催競馬場情報のセット
            Course = RC;
            int tmp = 0;

            for (int i = 0; i < KaisaiInfo.idx; i++)
            {
                if (KaisaiInfo.Jomei[i].Equals(Course))
                {
                    max = KaisaiInfo.DayRaceMaxCounter[i];
                    date = KaisaiDate;

                    for (int j = 0; j<KaisaiInfo.DayRaceMaxCounter[i]; j++, tmp++)
                    {
                        Info[j, 0] = JvDataStr[tmp].RaceName;
                        Info[j, 1] = JvDataStr[tmp].TD;
                        Info[j, 2] = JvDataStr[tmp].Distance.ToString();
                        
                    }
                    break;

                }
                else
                {
                    tmp += KaisaiInfo.DayRaceMaxCounter[i];
                }
            }

            //競馬場の配列インデックスを取得
            InitForm();
        }


        /** private
         * */
        private void InitForm()
        {
            /*
            switch (RCidx)
            {
                case 0:
                    min = 0;
                    max = min + (RaceCounter[0]);     //RaceCounterは１～１２で入っているため-1が必要
                    break;
                case 1:
                    min = 12;
                    max = min + (RaceCounter[1]);
                    break;
                case 2:
                    min = 24;
                    max = min + (RaceCounter[2]);
                    break;
            }
            */
            for (int i = 0, j = 1; i < this.max; i++, j++)
            {
                try
                {
                    if (Info[i, 0] == null)
                    {
                        writeLabelFunction(j, null, i, Info[i, 1], Info[i, 2]); break;    //12レース目がないときになる
                    }

                    writeLabelFunction(j, Info[i,0], i, Info[i, 1], Info[i, 2]);


                }
                catch (NullReferenceException ex)
                {
                    Console.Write(ex);
                    continue;
                }
            }
           ShowDateButtonEnable();
            
        }

        public void writeLabelFunction(int Cnt,String RaceName,int i,String TD, String Dist)
        {
            switch (Cnt)
            {
                case 1:
                    if (RaceName == null)
                    {
                        label3.Text = "";
                        label26.Text = ""; break;
                    }
                    label3.Text = Course + Cnt + "Ｒ";
                    label26.Text = RaceName;
                    c1.Text = TD;
                    d1.Text = Dist + "m";
                    LabelToCourseColor(c1, TD);
                    break;
                case 2:
                    if (RaceName == null)
                    {
                        label4.Text = "";
                        label25.Text = ""; break;
                    }
                    label4.Text = Course + Cnt + "Ｒ";
                    label25.Text = RaceName;
                    c2.Text = TD;
                    d2.Text = Dist + "m";
                    LabelToCourseColor(c2, TD);
                    break;
                case 3:
                    if (RaceName == null)
                    {
                        label5.Text ="";
                        label24.Text = ""; break;
                    }
                    label5.Text = Course + Cnt + "Ｒ";
                    label24.Text = RaceName;
                    c3.Text = TD;
                    d3.Text = Dist + "m";
                    LabelToCourseColor(c3, TD);
                    break;
                case 4:
                    if (RaceName == null)
                    {
                        label6.Text = "";
                        label21.Text = "";
                    }
                    label6.Text = Course + Cnt + "Ｒ";
                    label21.Text = RaceName;
                    c4.Text = TD;
                    d4.Text = Dist + "m";
                    LabelToCourseColor(c4, TD);
                    break;
                case 5:
                    if (RaceName == null)
                    {
                        label7.Text = "";
                        label22.Text = ""; break;
                    }
                    label7.Text = Course + Cnt + "Ｒ";
                    label22.Text = RaceName;
                    c5.Text = TD;
                    d5.Text = Dist + "m";
                    LabelToCourseColor(c5, TD);
                    break;
                case 6:
                    if (RaceName == null)
                    {
                        label8.Text = "";
                        label23.Text = ""; break;
                    }
                    label8.Text = Course + Cnt + "Ｒ";
                    label23.Text = RaceName;
                    c6.Text = TD;
                    d6.Text = Dist + "m";
                    LabelToCourseColor(c6, TD);
                    break;
                case 7:
                    if (RaceName == null)
                    {
                        label9.Text = "";
                        label15.Text = ""; break;
                    }
                    label9.Text = Course + Cnt + "Ｒ";
                    label15.Text = RaceName;
                    c7.Text = TD;
                    d7.Text = Dist + "m";
                    LabelToCourseColor(c7, TD);
                    break;
                case 8:
                    if (RaceName == null)
                    {
                        label10.Text = "";
                        label16.Text = ""; break;
                    }
                    label10.Text = Course + Cnt + "Ｒ";
                    label16.Text = RaceName;
                    c8.Text = TD;
                    d8.Text = Dist + "m";
                    LabelToCourseColor(c8, TD);
                    break;
                case 9:
                    if (RaceName == null)
                    {
                        label11.Text = "";
                        label17.Text = ""; break;
                    }
                    label11.Text = Course + Cnt + "Ｒ";
                    label17.Text = RaceName;
                    c9.Text = TD;
                    d9.Text = Dist + "m";
                    LabelToCourseColor(c9, TD);
                    break;
                case 10:
                    if (RaceName == null)
                    {
                        label12.Text = "";
                        label18.Text = ""; break;
                    }
                    label12.Text = Course + Cnt + "Ｒ";
                    label18.Text = RaceName;
                    c10.Text = TD;
                    d10.Text = Dist + "m";
                    LabelToCourseColor(c10, TD);
                    break;
                case 11:
                    if (RaceName == null)
                    {
                        label13.Text = "";
                        label19.Text = ""; break;
                    }
                    label13.Text = Course + Cnt + "Ｒ";
                    label19.Text = RaceName;
                    c11.Text = TD;
                    d11.Text = Dist + "m";
                    LabelToCourseColor(c11, TD);
                    break;
                case 12:
                    if (RaceName == null)
                    {
                        label14.Text = "";
                        label20.Text = ""; break;
                    }
                    label14.Text = Course + Cnt + "Ｒ";
                    label20.Text = RaceName;
                    c12.Text = TD;
                    d12.Text = Dist + "m";
                    LabelToCourseColor(c12, TD);
                    break;
            }

        }

        private void writeLabelCourseFunction(int Cnt,String RaceName,int i)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
         {
                // Course = main.getRCFunction();
                label2.Text = Course;

                for (int i = min; i < max; i++)
                {

                }


          }

        private void date2_Click(object sender, EventArgs e)
        {
            if (main.JvReadFunc() != 0)
            {
                /* エラー */
            }


        }

        private void c2_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void ShowDateButtonEnable()
        {
            Boolean ZeroFlag = false;
            String tmpDate = "";
            String[] kaisai = new String[4];

            for(int i = 0; i < date.Count; i++)
            {
                if (date[i].Substring(0, 1).Equals("0"))
                {
                    ZeroFlag = true;
                    tmpDate = date[i].Substring(1, 3);

                }
                else
                {
                    tmpDate = date[i];
                }

                switch (i)
                {
                    case 0:
                        date1.Visible = true;
                        date1.Text = tmpDate;
                        break;
                    case 1:
                        date2.Visible = true;
                        date2.Text = tmpDate;
                        break;
                    case 2:
                        date3.Visible = true;
                        date3.Text = tmpDate;
                        break;
                    case 3:
                        date4.Visible = true;
                        date4.Text = tmpDate;
                        break;
                }
            }
        }

        private void date3_Click(object sender, EventArgs e)
        {

        }

        private void LabelToCourseColor(Label label, String TD)
        {
            if(TD == null)
            {
                return;
            }

            label.ForeColor = Color.White;

            if (TD.Equals("ダート"))
            {
                label.BackColor = Color.Brown;
            }else 
            {
                label.BackColor = Color.DarkGreen;
            }
            
        }
        
    }

    class Form3Main
    {
        public void FunctionMain(JVData_Struct.JV_RA_RACE JvDate)
        {
            

        }

        private void setDate(JVData_Struct.JV_RA_RACE JvDate)
        {
            
        }
    }

}
