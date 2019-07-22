using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpZip
{
    public partial class Extract : Form
    {
        public Extract()
        {
            InitializeComponent();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        //var filesList = Form1.filesList;

        /*using (Stream s = zf.GetInputStream(ze))
                        {
                            byte[] buf = new byte[4096];
                            // Analyze file in memory using MemoryStream.
                            using (MemoryStream ms = new MemoryStream())
                            {
                                StreamUtils.Copy(s, ms, buf);
                            }
                            // Uncomment the following lines to store the file
                            // on disk.
                            /*using (FileStream fs = File.Create(@"c:\temp\uncompress_" + ze.Name))
                            {
                              StreamUtils.Copy(s, fs, buf);
                            }
                        }*/

    }
}
