using AccountsManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace AccountsManager.Account.IO
{
    public static class AccountSaver
    {

        public static void SaveFiles(List<UnsecureAccountModel> accounts)
        {
            string path = Settings.Default.accountsPath;

            if (Directory.Exists(path))
            {
                SaveFiles(accounts, path);
            }
        }

        public static void SaveFiles(List<UnsecureAccountModel> accounts, string directoryLocation)
        {
            List<string> NEWaccname = new List<string>();
            List<string> NEWemailss = new List<string>();
            List<string> NEWusernam = new List<string>();
            List<string> NEWpasswrd = new List<string>();
            List<string> NEWdofbrth = new List<string>();
            List<string> NEWscrtyin = new List<string>();
            List<string> NEWextinf1 = new List<string>();
            List<string> NEWextinf2 = new List<string>();
            List<string> NEWextinf3 = new List<string>();
            List<string> NEWextinf4 = new List<string>();
            List<string> NEWextinf5 = new List<string>();

            for (int i = 0; i < accounts.Count; i++)
            {
                NEWaccname.Add(accounts[i].AccountName);
                NEWemailss.Add(accounts[i].Email);
                NEWusernam.Add(accounts[i].Username);
                NEWpasswrd.Add(accounts[i].Password);
                NEWdofbrth.Add(accounts[i].DateOfBirth);
                NEWscrtyin.Add(accounts[i].SecurityInfo);
                NEWextinf1.Add(accounts[i].ExtraInfo1);
                NEWextinf2.Add(accounts[i].ExtraInfo2);
                NEWextinf3.Add(accounts[i].ExtraInfo3);
                NEWextinf4.Add(accounts[i].ExtraInfo4);
                NEWextinf5.Add(accounts[i].ExtraInfo5);
            }

            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.AccNameName), NEWaccname);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.EmailllName), NEWemailss);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.UsernamName), NEWusernam);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.PasswrdName), NEWpasswrd);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.DofBrthName), NEWdofbrth);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ScrtyInName), NEWscrtyin);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ExtrIn1Name), NEWextinf1);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ExtrIn2Name), NEWextinf2);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ExtrIn3Name), NEWextinf3);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ExtrIn4Name), NEWextinf4);
            File.WriteAllLines(Path.Combine(directoryLocation, AccountHelper.ExtrIn5Name), NEWextinf5);
        }
    }
}
