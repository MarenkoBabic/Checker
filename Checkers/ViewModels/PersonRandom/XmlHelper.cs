namespace Checkers.ViewModels.PersonRandom
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;



    public class XmlHelper
    {
        public ObservableCollection<Person> DeserializePersonList()
        {
            //der Typ der zu deserialisierenden Klasse muss übergeben werden            
            XmlSerializer deserializer = new XmlSerializer( typeof( ObservableCollection<Person> ) );
            FileStream fs = new FileStream( "personList.xml", FileMode.Open );
            ObservableCollection<Person> personList = (ObservableCollection<Person>)deserializer.Deserialize( fs );
            fs.Close();
            return personList;
        }

        public void SerializePersonListOrSaveList( ObservableCollection<Person> PersonList )
        {
            XmlSerializer serializer = new XmlSerializer( typeof( ObservableCollection<Person> ) );
            FileStream fs = new FileStream( "personList.xml", FileMode.Create );
            serializer.Serialize( fs, PersonList );
            fs.Close();
        }

        public void RemoveAll()
        {
            XmlDocument document = new XmlDocument();
            document.Load( "personList.xml" );
            XmlElement root = document.DocumentElement;
            root.RemoveAll();
            document.Save( "personList.xml" );
        }
    }
}
