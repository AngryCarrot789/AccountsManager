using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AccountsManager.CClipboard
{
    public static class CustomClipboard
    {
        public static void SetTextObject(string obj)
        {
            try
            {
                Clipboard.SetData(DataFormats.Text, obj);
            }
            catch (Exception e)
            {
                //MessageBox.Show($"Failed to set clipboard: {e.Message}", "Clipboard");
            }
        }

        public static object GetTextObject()
        {
            try
            {
                return Clipboard.GetDataObject()?.GetData(typeof(string));
            }
            catch (Exception e)
            {
                //MessageBox.Show($"Failed to set clipboard: {e.Message}", "Clipboard");
                return null;
            }
        }
    }
}
