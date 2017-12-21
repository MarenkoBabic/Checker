namespace Checkers.ViewModels.PersonRandom
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using Microsoft.Win32;

    public class XmlHelper
    {
        /// <summary>
        /// Ladet eine Xml-Datei und fügt sie zur einer Liste hinzu
        /// </summary>
        /// <returns>List</returns>
        public List<Person> LoadXmlFile( string path )
        {
            var list = new List<Person>();
            if( path == null )
            {
                return list;
            }
            using( FileStream fs = File.Open( path, FileMode.Open ) )
            {
                XmlSerializer deserializer = new XmlSerializer( typeof( List<Person> ) );
                return (List<Person>)deserializer.Deserialize( fs );
            }
        }

        /// <summary>
        /// Speichert eine Liste als Xml -File
        /// </summary>
        /// <param name="list"></param>
        public void SaveXmlFile( ObservableCollection<Person> list )
        {
            string filename = SaveFileDialog();
            if( !string.IsNullOrEmpty( filename ) )
            {
                using( FileStream fs = File.Open( filename, FileMode.Create ) )
                {
                    XmlSerializer serializer = new XmlSerializer( typeof( ObservableCollection<Person> ) );
                    serializer.Serialize( fs, list );
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// Öffnet den AuswahlDialog
        /// </summary>
        /// <returns>Pfad von der Xml Datei oder null</returns>
        public string OpenFileDialog()
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

        /// <summary>
        /// Öffnet den Speicherdialog
        /// </summary>
        /// <returns>Pfad von der Xml-Datei oder null</returns>
        private string SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "";
            saveFileDialog.Filter = "Xml Files(.xml)|*.xml";
            saveFileDialog.DefaultExt = ".xml";

            Nullable<bool> result = saveFileDialog.ShowDialog();

            if( result == true )
            {
                string filename = saveFileDialog.FileName;
                return filename;
            }
            return null;
        }
    }
}
