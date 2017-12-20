namespace Checkers.ViewModels.PersonRandom
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Microsoft.Win32;
    using Personalmanagement.Dto;

    public class XmlHelper
    {
      /// <summary>
      /// Löscht alle Daten aus dem Dokument
      /// </summary>
      /// <param name="doc"></param>
      /// <returns>Leeres XmlDocument</returns>
        public XmlDocument RemoveAllNotes(XmlDocument doc)
        {
            XmlElement root = doc.DocumentElement;
            root.RemoveAll();
            return doc;
        }

        /// <summary>
        /// Ladet eine Xml-Datei und fügt sie zur einer Liste hinzu
        /// </summary>
        /// <returns>List</returns>
        public List<Person> LoadXmlFile()
        {
            var list = new List<Person>();
            XmlSerializer deserializer = new XmlSerializer( typeof( List<Person> ) );
            FileStream fs = new FileStream( OpenXmlFile(), FileMode.Open );
            list = (List<Person>)deserializer.Deserialize( fs );
            fs.Close();
            return list;
        }
        /// <summary>
        /// Speichert eine Liste als Xml -File
        /// </summary>
        /// <param name="list"></param>
        public void SaveXmlFile( ObservableCollection<Person> list )
        {
            string filename;
            XDocument doc = new XDocument();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "Xml Files(.xml)|*.xml";
            saveFileDialog.DefaultExt = ".xml";

            Nullable<bool> result = saveFileDialog.ShowDialog();

            if( result == true )
            {
                filename = saveFileDialog.FileName;
                XmlSerializer serializer = new XmlSerializer( typeof( ObservableCollection<Person> ) );
                FileStream fs = new FileStream( filename, FileMode.Create );
                serializer.Serialize( fs, list );
                fs.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void loadandsaveXMl()
        {
            string filename = OpenXmlFile();
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            RemoveAllNotes( document );
            document.Save( filename );
        }
        /// <summary>
        /// Öffnet eine Xml datei 
        /// </summary>
        /// <returns>Path von der Xml Datei</returns>
        private string OpenXmlFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Xml Files(.xml)|*.xml";
            openFileDialog.DefaultExt = ".xml";

            Nullable<bool> result = openFileDialog.ShowDialog();

            if( result == true )
            {
                string filename = openFileDialog.FileName;
                return filename;
            }
            return null;
        }

        
    }
}
