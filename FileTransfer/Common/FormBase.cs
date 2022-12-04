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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            base.BackColor = Color.White;
            base.StartPosition = FormStartPosition.CenterParent;
            base.Font = new Font("맑은고딕", 10F);
        }

        public virtual void ReceiveData(string pFormName, string pMessage, object pItems)
        {

        }
    }
}
