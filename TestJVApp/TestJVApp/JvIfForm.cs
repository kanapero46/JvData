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
    public partial class JvIfForm : Form
    {
        public JvIfForm()
        {
            InitializeComponent();
        }

        public int InitJv()
        {
            return (JvIf1.JVInit("UNKNOWN"));
        }

        public int ReadJv(out String buff, out int buffSize, out String fName)
        {
            return (JvIf1.JVRead(out buff, out buffSize, out fName));
        }

        public int OpenJv(String Data, String Time, int opKind, ref int ReadCount, ref int DownloadCount, out String LastTime)
        {
            return (JvIf1.JVOpen(Data, Time, opKind, ref ReadCount, ref DownloadCount, out LastTime));
        }

        public void SkipJv()
        {
            JvIf1.JVSkip();
        }

        public void CloseJv()
        {
            JvIf1.JVClose();
        }

        public int RTJvOpen(String spec, String key)
        {
            return (JvIf1.JVRTOpen(spec, key));
        }

        private void JvIfForm_Load(object sender, EventArgs e)
        {

        }
    }
}
