using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class frmMain : FormBase
    {
        public frmMain()
        {
            InitializeComponent();

            FormCommon.SetRecvEvent(this);
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
