using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public class MsgBox
    {
        public static DialogResult Information(string pContext, string pTitle, MessageBoxButtons pBtn = MessageBoxButtons.OK, MessageBoxIcon pIcon = MessageBoxIcon.Asterisk, MessageBoxDefaultButton pDefBtn = MessageBoxDefaultButton.Button1, MessageBoxOptions pOpt = MessageBoxOptions.ServiceNotification)
        {
            return MessageBox.Show(pContext, pTitle, pBtn, pIcon, pDefBtn, pOpt);
        }

        public static DialogResult Warning(string pContext, string pTitle, MessageBoxButtons pBtn = MessageBoxButtons.OK, MessageBoxIcon pIcon = MessageBoxIcon.Warning, MessageBoxDefaultButton pDefBtn = MessageBoxDefaultButton.Button1, MessageBoxOptions pOpt = MessageBoxOptions.ServiceNotification)
        {
            return MessageBox.Show(pContext, pTitle, pBtn, pIcon, pDefBtn, pOpt);
        }

        public static DialogResult Error(string pContext, string pTitle, MessageBoxButtons pBtn = MessageBoxButtons.OK, MessageBoxIcon pIcon = MessageBoxIcon.Error, MessageBoxDefaultButton pDefBtn = MessageBoxDefaultButton.Button1, MessageBoxOptions pOpt = MessageBoxOptions.ServiceNotification)
        {
            return MessageBox.Show(pContext, pTitle, pBtn, pIcon, pDefBtn, pOpt);
        }

        public static DialogResult Question(string pContext, string pTitle, MessageBoxButtons pBtn = MessageBoxButtons.YesNoCancel, MessageBoxIcon pIcon = MessageBoxIcon.Question, MessageBoxDefaultButton pDefBtn = MessageBoxDefaultButton.Button1, MessageBoxOptions pOpt = MessageBoxOptions.ServiceNotification)
        {
            return MessageBox.Show(pContext, pTitle, pBtn, pIcon, pDefBtn, pOpt);
        }
    }
}
