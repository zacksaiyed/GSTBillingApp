using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL.BillingCommon
{
    public class ApplicationCommon
    {
        public static void WriteLog(object txt)
        {

            try
            {

                string path = HttpContext.Current.Server.MapPath("~/CodeLogs");

                File.AppendAllLines(path + "/" + DateTime.Now.ToString("dd_MMM_yyyy") + ".txt", new List<string> { DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + "\t" + txt });

            }
            catch (Exception)
            {

            }

        }

    }
}
