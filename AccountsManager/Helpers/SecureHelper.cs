using System;
using System.Runtime.InteropServices;
using System.Security;

namespace AccountsManager.Helpers
{
    public static class SecureHelper
    {
        public static string GetUnsecure(this SecureString secure)
        {
            if (secure == null)
                return "";
            IntPtr unmanaged = IntPtr.Zero;
            try
            {
                unmanaged = Marshal.SecureStringToGlobalAllocUnicode(secure);
                return Marshal.PtrToStringUni(unmanaged);
            }
            catch { return ""; }
            finally { Marshal.ZeroFreeGlobalAllocUnicode(unmanaged); }
        }

        public static SecureString CreateSecure(this string unsecure)
        {
            SecureString s = new SecureString();

            for (int i = 0; i < unsecure.Length; i++)
                s.AppendChar(unsecure[i]);

            return s;
        }
    }
}
