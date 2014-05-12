using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace MilbatProject.ViewModels
{
    public static class SettingsPageViewModel
    {
        public static bool IsPanoramaClickable;
        public static string UserName, eMail;
        public static int FontOffset, deltaOffset;
        private static bool ResizePossible;
        private static int dirCounter;
        public static void SettingsPageInit()
        {
            //CreateNewSettingsFile();
            //ReadIsoStream();
            
            AssignStreamToVariables();
            deltaOffset = FontOffset;
            ResizePossible = false;
        }

        public static void ApplyAndSaveChanges(string newName, string newMail, bool clickFlag)
        {
            if (UserName != newName)
                UserName = newName;
            if (eMail != newMail)
                eMail = newMail;
            IsPanoramaClickable = clickFlag;
            FontOffset = deltaOffset;
            AssignVariablesToStream();
        }
        public static void PreviewNewFont(int newOffset, Grid layout)
        {
            if (deltaOffset <= 6 && deltaOffset >= -6 && deltaOffset * newOffset >= 0)
            {
                deltaOffset += newOffset;
                ResizePossible = ResizeFont(layout, deltaOffset) && dirCounter != 4;
            }
            if (deltaOffset * newOffset < 0)
            {
                deltaOffset += newOffset;
                ResizePossible = ResizeFont(layout, newOffset) && dirCounter != 4;
            }
        }

        public static void CreateNewSettingsFile()
        {
            XDocument doc = null;
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                    using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("Settings.xml", FileMode.Create, isoStore))
                    {
                        XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
                        doc = new XDocument(dec, new XElement("settings"));

                        doc.Root.Add(new XElement("name",
                            new XAttribute("Value", "")));
                        doc.Root.Add(new XElement("email",
                            new XAttribute("Address", "")));
                        doc.Root.Add(new XElement("panorama",
                            new XAttribute("Clickable", "False")));
                        doc.Root.Add(new XElement("font",
                            new XAttribute("Offset", "0")));
                        isoStream.Position = 0;
                        doc.Save(isoStream);
                    }
            }
            
        }
        public static void AssignStreamToVariables()
        {
            XDocument doc = null;
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if(isoStore.FileExists("Settings.xml"))
                {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("Settings.xml", FileMode.Open, isoStore))
                {
                    isoStream.Position = 0;
                    doc = XDocument.Load(isoStream,LoadOptions.PreserveWhitespace);
                    isoStream.Position = 0;

                    UserName = doc.Root.Element("name").Attribute("Value").Value.ToString();
                    eMail = doc.Root.Element("email").Attribute("Address").Value.ToString();
                    IsPanoramaClickable = bool.Parse(doc.Root.Element("panorama").Attribute("Clickable").Value.ToString());
                    FontOffset = int.Parse(doc.Root.Element("font").Attribute("Offset").Value.ToString());
                }
                }
            }
            

        }



        public static void AssignVariablesToStream()
        {
            XDocument doc = null;
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("Settings.xml", FileMode.Open, isoStore))
                {
                    doc = XDocument.Load(isoStream, LoadOptions.PreserveWhitespace);
                    isoStream.Position = 0;
                }
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("Settings.xml", FileMode.Create, isoStore))
                {
                    doc.Root.Element("name").Attribute("Value").Value = UserName;
                    doc.Root.Element("email").Attribute("Address").Value = eMail;
                    doc.Root.Element("panorama").Attribute("Clickable").Value = IsPanoramaClickable.ToString();
                    doc.Root.Element("font").Attribute("Offset").Value = FontOffset.ToString();
                    doc.Save(isoStream);
                    isoStream.Position = 0;

                }
            }
            
        }






        public static bool ResizeFont(Grid layout, int ResizeValue)
        {
            // Instantiate a list of TextBlockes
            List<TextBlock> TextBlockList = new List<TextBlock>();

            // Call GetTextBlockes function, passing in the root element,
            // and the empty list of TextBlockes (LayoutRoot in this example)
            GetTextBlocks(layout, TextBlockList);

            // Now TextBlockList contains a list of all the text boxes on your page.
            // Find all the non empty TextBlockes, and put them into a list.
            var nonEmptyTextBlockList = TextBlockList.Where(txt => txt.Text != string.Empty).ToList();

            // Do something with each non empty TextBlock.
            int checkMinCap = nonEmptyTextBlockList.Where(txt => txt.FontSize + ResizeValue <= 1).ToList().Count;
            int checkMaxCap = nonEmptyTextBlockList.Where(txt => txt.FontSize + ResizeValue > 90).ToList().Count;
            if (checkMinCap == 0 && checkMaxCap == 0)
            {
                nonEmptyTextBlockList.ForEach(txt => txt.FontSize += ResizeValue);
                return true;
            }
            return false;
        }

        public static void ResizeFontPage(Grid layout, int ResizeValue)
        {
            // Instantiate a list of TextBlockes
            List<TextBlock> TextBlockList = new List<TextBlock>();

            // Call GetTextBlockes function, passing in the root element,
            // and the empty list of TextBlockes (LayoutRoot in this example)
            GetTextBlocks(layout, TextBlockList);

            // Now TextBlockList contains a list of all the text boxes on your page.
            // Find all the non empty TextBlockes, and put them into a list.
            var nonEmptyTextBlockList = TextBlockList.Where(txt => txt.Text != string.Empty).ToList();

            // Do something with each non empty TextBlock.
            int checkMinCap = nonEmptyTextBlockList.Where(txt => txt.FontSize + ResizeValue <= 1).ToList().Count;
            int checkMaxCap = nonEmptyTextBlockList.Where(txt => txt.FontSize + ResizeValue > 90).ToList().Count;
            if (checkMinCap == 0 && checkMaxCap == 0)
            {
                nonEmptyTextBlockList.ForEach(txt => txt.FontSize += ResizeValue);
            }
        }


        public static void ReadIsoStream()
        {
            using (IsolatedStorageFile isoStory = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream("Settings.xml", FileMode.Open, isoStory))
                {
                    using (XmlReader reader = XmlReader.Create(isoStream))
                    {
                        StreamReader rd = new StreamReader(isoStream);
                        isoStream.Position = 0;
                        MessageBox.Show(rd.ReadToEnd());
                        isoStream.Position = 0;
                    }
                }
            }
        }
        public static void GetTextBlocks(UIElement uiElement, List<TextBlock> TextBlockList)
        {
            TextBlock TextBlock = uiElement as TextBlock;
            if (TextBlock != null)
            {
                // If the UIElement is a TextBlock, add it to the list.
                TextBlockList.Add(TextBlock);
            }
            else
            {
                Panel panel = uiElement as Panel;
                if (panel != null)
                {
                    // If the UIElement is a panel, then loop through it's children
                    foreach (UIElement child in panel.Children)
                    {
                        GetTextBlocks(child, TextBlockList);
                    }
                }
            }
        }
    }
}
