using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTHPT.App_Start
{
    public class CreateID
    {
        public static string CreateID_ByteText()
        {
            string IDstring = DateTime.Now.ToString("MMddHHmmss");
            return IDstring;
        }
    }
}