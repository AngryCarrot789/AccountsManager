using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AccountsManager.Account.IO
{
    public static class AccountHelper
    {
        public const string AccNameName = "accName.txt";
        public const string EmailllName = "email.txt";
        public const string UsernamName = "usrName.txt";
        public const string PasswrdName = "pssWrd.txt";
        public const string DofBrthName = "DtoBrth.txt";
        public const string ScrtyInName = "ScrtyInfo.txt";
        public const string ExtrIn1Name = "ExtInf1.txt";
        public const string ExtrIn2Name = "ExtInf2.txt";
        public const string ExtrIn3Name = "ExtInf3.txt";
        public const string ExtrIn4Name = "ExtInf4.txt";
        public const string ExtrIn5Name = "ExtInf5.txt";

        //public static string UnsecureConvertAccountToXML(this UnsecureAccountModel account)
        //{
        //    using (MemoryStream sw = new MemoryStream())
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(UnsecureAccountModel));
        //        xmlSerializer.Serialize(sw, account);
        //        sw.Position = 0;
        //        using (StreamReader reader = new StreamReader(sw, Encoding.UTF8))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        //public static UnsecureAccountModel UnsecureConvertXMLToAccount(this string xml)
        //{
        //    using (MemoryStream sw = new MemoryStream(Encoding.ASCII.GetBytes(xml)))
        //    {
        //        sw.Position = 0;
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(UnsecureAccountModel));
        //        return xmlSerializer.Deserialize(sw) as UnsecureAccountModel;
        //    }
        //}
    }
}
