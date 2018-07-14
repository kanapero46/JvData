using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestJVApp;

namespace JVDataClass
{


    class Race
    {
        private int JRAKeibajo = 10;        //JRAの競馬場最大値
        static int MaxRaceCount = 36;      //一日の最大レース数 → ３の倍数にすること
        String[] Jomei = new String[MaxRaceCount/3];
        String[] RaceName = new String[MaxRaceCount];
        String[] RaceNum = new String[MaxRaceCount];
        func Func = new func();

        //場名のセッター
        public void setJomei(int index, string Jyomei)
        {
            int idx = chkJomei(Jyomei);
            if (idx != -1)
            {
                this.Jomei[idx] = Jyomei;
            }
        }//setJomei

        private int chkJomei(string inJomei)
        {
            for (int idx = 0; idx <= 2; idx++)
            {
                if (Jomei[idx] != null && Jomei[idx].Equals(inJomei))
                {
                    //その場名は登録済み
                    return (-1);
                }
                else if (Jomei[idx] != null)
                {
                    //その場名は未登録
                    continue;
                }                 
                else
                { 
                    //idx目の配列に場名を入れる
                    return (idx);
                }
            }
            return (-1);
        }

        public string getJomei(int index)
        {
            func toStr = new func();    //共通変換クラス
            if (index < Jomei.Length)
            {
                return (Jomei[index]);
            }
            toStr.errMesage(200);
            return ("");
        }

        /** 開催しているかのデータ取得
         * 
         * @return：開催コード（東から0,1,2)
         * 例：東京・阪神・函館の開催の場合は、函館→東京→阪神の順で0,1,2で返す。
         * 開催していない場合は-1で返す。
         * */
        public int JoyCdToIndex(String JyoMei)
        {

            for (int idx = 0; idx<(JRAKeibajo-1); idx++)
            {
                
                if (Jomei[idx] !=null && Jomei[idx].Equals(JyoMei))
                {
                    return (idx);
                }
                else
                {
                    continue;
                }
            }
            return (-1);

        }
    }
}
