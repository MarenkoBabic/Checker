namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;

    public class PersonRandomViewModel : ViewModelBase, IShell
    {
        PersonalManagement personalManager = new PersonalManagement();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public HairColor HairColor { get; set; }
        public List<Person> DataGridPersonList
        {
            get
            {
                return dataGridPersonList;
            }
            set
            {
                dataGridPersonList = value;
                OnPropertyChanged( nameof( DataGridPersonList ) );
            }
        }

        public IEnumerable<Person> DataGridListFilter
        {
            get
            {
                return dataGridListFilter;
            }
            set
            {
                dataGridListFilter = value;
                OnPropertyChanged( nameof( DataGridListFilter ) );
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

        public PersonRandomViewModel()
        {
        }
        public void GeneratorRandomPerson()
        {
            bool result = int.TryParse( CountPerson, out int number );
            this.DataGridPersonList = personalManager.CreateRandomPerson( number );
        }

        public void Filter()
        {
            this.DataGridListFilter = personalManager.SearchPerson( FirstName, LastName, BirthDay,HairColor.keineAngabe, DataGridPersonList );
        }
        private string countPerson;
        private List<Person> dataGridPersonList;
        private IEnumerable<Person> dataGridListFilter;

    }
}
