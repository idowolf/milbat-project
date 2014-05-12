using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.IO.IsolatedStorage;
using System.IO;

namespace MilbatProject.ViewModels
{
    public static class DisclaimerPageViewModel
    {
        public static void SignDisclaimer()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("DisclaimerSigned.xml", FileMode.Create, isoStore))
                {
                }
            }
        }

        public static bool IsDisclaimerSigned()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                return isoStore.FileExists("DisclaimerSigned.xml");
            }
        }
        public static void ForceDisclaimerRemoval()
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStore.DeleteFile("DisclaimerSigned.xml");
            }
        }
    }
}