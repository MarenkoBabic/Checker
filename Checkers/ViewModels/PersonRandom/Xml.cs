namespace Checkers.ViewModels.PersonRandom
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    


    public class Xml
    {
        public  List<Person> DeserializePersonList()
        {
            //der Typ der zu deserialisierenden Klasse muss übergeben werden            
            XmlSerializer deserializer = new XmlSerializer( typeof( List<Person> ) );
            FileStream fs = new FileStream( "personList.xml", FileMode.Open );
            List<Person> personList = (List<Person>)deserializer.Deserialize( fs );
            fs.Close();
            return personList;
        }

        public  void SerializePersonList( List<Person> PersonList )
        {
            XmlSerializer serializer = new XmlSerializer( typeof( List<Person> ) );
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
