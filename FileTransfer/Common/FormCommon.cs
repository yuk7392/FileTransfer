using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace FileTransfer
{
    public delegate void FormCommunication(string pFormName, string pMessage, object pItems);

    public class FormCommon
    {
        private static event FormCommunication globalFormCommunication = null;

        private static object GetFormInstance(string pFormName)
        {
            object formObject = null;

            try
            {
                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                foreach (Type type in currentAssembly.GetTypes())
                {
                    if (type.Name.Equals(pFormName) && type.IsSubclassOf(typeof(FormBase)))
                    {
                        formObject = Activator.CreateInstance(type);
                    }
                }

                return formObject;

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                return formObject;
            }
        }

        public static FormBase GetForm(string pFormName, bool pAddRecvEvent = true)
        {
            try
            {
                object formObj = GetFormInstance(pFormName);

                if (formObj == null)
                    return null;

                FormBase form = formObj as FormBase;

                if (pAddRecvEvent)
                    globalFormCommunication += form.ReceiveData;

                return form;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
                return null;
            }
        }

        public static void SendDataToAll(string pFormName, string pMessage, object pItems)
        {
            try
            {
                if (globalFormCommunication != null)
                    globalFormCommunication(pFormName, pMessage, pItems);
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
            }
        }

        public static void SetRecvEvent(FormBase pForm)
        {
            try
            {
                globalFormCommunication += pForm.ReceiveData;
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(ex);
            }
        }
    }
}
