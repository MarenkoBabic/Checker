namespace Checkers.ViewModels.Checker
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;



    public class XmlHelper
    {
        public ObservableCollection<Result> DeserializeResultList()
        {
            XmlSerializer deserializer = new XmlSerializer( typeof( ObservableCollection<Result> ) );
            FileStream fs = new FileStream( "resultList.xml", FileMode.Open );
            ObservableCollection<Result> resultList = (ObservableCollection<Result>)deserializer.Deserialize( fs );
            fs.Close();
            return resultList;
        }

        public void SerializeResultList( ObservableCollection<Result> ResultList )
        {
            XmlSerializer serializer = new XmlSerializer( typeof( ObservableCollection<Result> ) );
            FileStream fs = new FileStream( "resultList.xml", FileMode.Create );
            serializer.Serialize( fs, ResultList );
            fs.Close();
        }

        public void RemoveAll()
        {
            XmlDocument document = new XmlDocument();
            document.Load( "resultList.xml" );
            XmlElement root = document.DocumentElement;
            root.RemoveAll();
            document.Save( "resultList.xml" );
        }
    }
}
