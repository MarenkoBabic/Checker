namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;

    public class PersonRandomViewModel : ViewModelBase, IShell
    {
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
        public DateTime? BirthDay
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
                OnPropertyChanged(nameof(PersonList));
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

        public void GeneratorRandomPerson()
        {
            bool result = int.TryParse( CountPerson, out int number );
            PersonList = new List<Person>( personalManager.CreateRandomPerson( number ) );
        }
        public void Filter()
        {
            this.ListPersonFiltered = personalManager.SearchPerson( FirstName, LastName, BirthDay, HairColor, PersonList );
        }
        public void CreatePerson()
        {
            this.PersonList =new List<Person>( personalManager.CreateNewPerson( FirstName, LastName, null, HairColor ));
        }
        private string countPerson;
        private List<Person> personList;
        private IEnumerable<Person> listPersonFiltered;
        private HairColor hairColor;
    }
}
