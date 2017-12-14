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
        public ObservableCollection<Person> PersonList { get; set; }

        public PersonRandomViewModel()
        {
            PersonList = new ObservableCollection<Person>();
            PersonList = xml.DeserializePersonList();
        }

        public void GenerateRandomPerson()
        {
            var list = new List<Person>();
            bool result = int.TryParse( CountPerson, out int number );

            list = personalManager.CreateRandomPerson( number );
            list.ForEach( PersonList.Add );

            xml.SerializePersonListOrSaveList( PersonList );
        }

        public void Filter()
        {
            if( !string.IsNullOrEmpty( BirthDay ) )
            {
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, DateTime.Parse( BirthDay ), HairColor, PersonList );
            }
            else
            {
                DateTime? birthDayNull = null;
                this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, birthDayNull, HairColor, PersonList );
            }
        }

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
            xml.SerializePersonListOrSaveList( PersonList );
        }

        public void DeletePersonList()
        {
            xml.RemoveAll();
            PersonList.Clear();
        }

        public void SaveChangedList()
        {
            xml.SerializePersonListOrSaveList( PersonList);
        }

        private string countPerson;
        private IEnumerable<Person> listPersonFiltered;
        private HairColor hairColor;
    }
}
