using InterfaceDef;
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
    public partial class Form2 : Form, Interfacedef
    {
        public Form2()  
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public int InitJv()
        {
            return (axJVLink1.JVInit("UNKNOWN"));
        }

        public int ReadJv(out String buff, out int buffSize, out String fName)
        {
            return (axJVLink1.JVRead(out buff, out buffSize, out fName));
        }

        public int OpenJv(String Data, String Time, int opKind, ref int ReadCount, ref int DownloadCount, out String LastTime)
        {
            return (axJVLink1.JVOpen(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime));
        }

        public void SkipJv()
        {
            axJVLink1.JVSkip();
        }

        public void CloseJv()
        {
            axJVLink1.JVClose();
        }

        public int RTJvOpen(String spec, String key)
        {
            return(axJVLink1.JVRTOpen(spec, key));
        }




    }



}
