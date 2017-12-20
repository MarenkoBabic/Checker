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
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string BirthDay
        {
            get;
            set;
        }
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
        public IEnumerable<Person> ListPersonFiltered
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
        public IEnumerable<HairColor> HairColorList
        {
            get
            {
                return Enum.GetValues( typeof( HairColor ) ).Cast<HairColor>();
            }
        }
        public string CountPerson { get; set; }
        public ObservableCollection<Person> PersonList { get; set; }

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
            //Prüft ob string leer ist
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
        /// Fügt eine Xml Datei der Liste hinzu
        /// </summary>
        public void AddXmlFile()
        {
            List<Person> list = new List<Person>();
            list = xml.LoadXmlFile();
            list.ForEach( PersonList.Add );
        }

        /// <summary>
        /// Leert die Liste
        /// </summary>
        public void DeleteList()
        {
            //xml.RemoveAllNotes();
            PersonList.Clear();
        }

        /// <summary>
        /// Speichert die Liste als Xml-File
        /// </summary>
        public void SaveListToXmlFile()
        {
            xml.SaveXmlFile( PersonList );
        }

        private IEnumerable<Person> listPersonFiltered;
        private HairColor hairColor;
    }
}
