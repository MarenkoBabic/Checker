namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Xml.Serialization;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;

    public class PersonRandomViewModel : ViewModelBase, IShell
    {
        XmlHelper xml = new XmlHelper();
        PersonalManagement personalManager = new PersonalManagement();

        #region Property

        /// <summary>
        /// Eingabe für Vorname
        /// </summary>
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// Eingabe für Nachname
        /// </summary>
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// Eingabe für Geburtsdatum
        /// </summary>
        public string BirthDay
        {
            get;
            set;
        }

        /// <summary>
        /// Auswahl Haarfarbe
        /// </summary>
        public HairColor HairColor
        {
            get
            {
                return hairColor;
            }
            set
            {
                hairColor = value;
            }
        }

        /// <summary>
        /// Personenliste gefiltert
        /// </summary>
        public ObservableCollection<Person> ListPersonFiltered
        {
            get
            {
                return listPersonFiltered;
            }
            set
            {
                listPersonFiltered = value;
                OnPropertyChanged( nameof( ListPersonFiltered ) );
            }
        }

        /// <summary>
        /// Liste für Auswahl Haarfarbe in der Combobox
        /// </summary>
        public IEnumerable<HairColor> HairColorList
        {
            get
            {
                return Enum.GetValues( typeof( HairColor ) ).Cast<HairColor>();
            }
        }

        /// <summary>
        /// Zahleingabe für generieren von Personen
        /// </summary>
        public string CountPerson { get; set; }

        /// <summary>
        /// Collection von Personenliste
        /// </summary>
        public ObservableCollection<Person> PersonList { get; set; }

        /// <summary>
        /// Speichert den Path von der zuletzt geöffnetet Xml
        /// </summary>
        public string XmlPath
        {
            get
            {
                return xmlPath;
            }
            set
            {
                xmlPath = value;
                OnPropertyChanged( "XmlPath" );
            }
        }

        #endregion

        public PersonRandomViewModel()
        {
            PersonList = new ObservableCollection<Person>();
        }

        /// <summary>
        /// Erzeugt eine Liste an Personen per Zufall
        /// </summary>
        public void GenerateRandomPerson()
        {
            var list = new List<Person>();
            bool result = int.TryParse( CountPerson, out int number );
            list = personalManager.CreateRandomPerson( number );
            list.ForEach( PersonList.Add );
        }

        /// <summary>
        /// Filtert die Personenliste
        /// </summary>
        public void Filter()
        {
            if( !string.IsNullOrEmpty( BirthDay ) )
            {
                bool result = DateTime.TryParse( BirthDay, out DateTime birthDay );
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, birthDay, HairColor, PersonList );
            }
            else
            {
                DateTime? birthDayNull = null;
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, birthDayNull, HairColor, PersonList );
            }
        }

        /// <summary>
        /// Erzeugt eine einzelne Person
        /// </summary>
        public void CreateNewPerson()
        {
            if( !string.IsNullOrEmpty( BirthDay ) )
            {
                PersonList.Add( personalManager.CreateNewPerson( FirstName, LastName, DateTime.Parse( BirthDay ), HairColor ) );
            }
            else
            {
                DateTime? birthDayNull = null;
                PersonList.Add( personalManager.CreateNewPerson( FirstName, LastName, birthDayNull, HairColor ) );
            }
        }

        /// <summary>
        /// Der Personenliste eine Xml-Datein hinzufügen
        /// </summary>
        public void AddXmlFile()
        {
            XmlPath = xml.OpenFileDialog();
            List<Person> list = new List<Person>();
            list = xml.LoadXmlFile( XmlPath );
            list.ForEach( PersonList.Add );
        }
        /// <summary>
        /// Der gefilterten Liste eine Xml-Datein hinzufügen
        /// </summary>
        public void AddFilterList()
        {
            XmlPath = xml.OpenFileDialog();
            List<Person> list = new List<Person>();
            list = xml.LoadXmlFile( XmlPath );
            list.ForEach( ListPersonFiltered.Add );
        }

        /// <summary>
        /// Leert die Liste
        /// </summary>
        public void DeleteList()
        {
            PersonList.Clear();
        }

        /// <summary>
        /// Leert die gefilterete Liste
        /// </summary>
        public void DeleteFilterList()
        {
            ListPersonFiltered.Clear();
        }

        /// <summary>
        /// Speichert die Personenliste als Xml-File
        /// </summary>
        public void SaveListAsXmlFile()
        {
            xml.SaveXmlFile( PersonList );
        }

        /// <summary>
        /// Speichert die gefilterete Liste als Xml-File
        /// </summary>
        public void SaveFilterListAsXmlFile()
        {
            xml.SaveXmlFile( ListPersonFiltered );
        }

        private ObservableCollection<Person> listPersonFiltered;
        private HairColor hairColor;
        private string xmlPath;

    }
}
