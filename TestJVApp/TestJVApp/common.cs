using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJVApp
{
    class common
    {
        static int MaxHorse = 18;
        String[,] Bamei = new string[MaxHorse, 2];    //馬番,馬名

        public void setBamei(int num , String bamei)
        {
            this.Bamei[num,1] = bamei;
        }

        public String getUmabanToBamei(int num)
        {
            return (Bamei[num, 1]);
        }

        public int getBameiToUmaban(string bamei)
        {
            int ret;
            for(int idx = 0; idx < MaxHorse; idx++)
            {
                if (Bamei[idx, 1].Equals(bamei))
                {
                    //馬名の一致
                    return (idx);
                }
            }
            return (-1);

        }

    }
}
