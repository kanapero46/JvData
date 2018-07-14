using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJVApp
{
    class Main
    {
        func Func = new func();


        public void showMainFunction(String JyoMei , JVDataClass.Race Racedata)
        {
            //競馬場の開催インデックスを取得する。
            int index = Func.KeibajoToNumber(JyoMei);

            //開催情報の取得
            if ((Racedata.JoyCdToIndex(JyoMei)) != -1)
            {
                //開催データあり
                MessageBox.Show("本日開催しています。");
            }
            else
            {
                //開催していない競馬場・パタメータエラー
                MessageBox.Show("開催していない競馬場です。");
                Func.errMesage(201);
            }

        }
    }
}
