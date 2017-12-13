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
        Xml xml = new Xml();
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
        public List<Person> PersonList
        {
            get
            {
                return personList;
            }
            set
            {
                personList = value;
                OnPropertyChanged( "PersonList" );
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
        public string CountPerson
        {
            get
            {
                return countPerson;
            }
            set
            {
                countPerson = value;
            }
        }
        public ObservableCollection<Person> collection { get; set; }

        public PersonRandomViewModel()
        {
            collection = new ObservableCollection<Person>();
            PersonList = xml.DeserializePersonList();
        }

        public void GeneratorRandomPerson()
        {
            var list = new List<Person>();
            bool result = int.TryParse( CountPerson, out int number );
            list = personalManager.CreateRandomPerson( number );
            list.ForEach( collection.Add );
            xml.SerializePersonList( collection.ToList() );
            PersonList = collection.ToList();
        }

        public void Filter()
        {
            if( !string.IsNullOrEmpty( BirthDay ) )
            {
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, DateTime.Parse(BirthDay), HairColor, PersonList );
            }
            else
            {
                DateTime? birthDayNull = null;
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, birthDayNull, HairColor, PersonList );
            }
        }

        public void CreatePerson()
        {
            if( !string.IsNullOrEmpty( BirthDay ) )
            {
                collection.Add( personalManager.CreateNewPerson( FirstName, LastName, DateTime.Parse( BirthDay ), HairColor ) );
            }
            else
            {
                DateTime? birthDayNull = null;
                collection.Add( personalManager.CreateNewPerson( FirstName, LastName,birthDayNull, HairColor ) );
            }
            xml.SerializePersonList( collection.ToList() );
            PersonList = collection.ToList();
        }

        public void DeletePersonList()
        {
            xml.RemoveAll();
            PersonList = null;
        }

        private string countPerson;
        private List<Person> personList;
        private IEnumerable<Person> listPersonFiltered;
        private HairColor hairColor;
    }
}
