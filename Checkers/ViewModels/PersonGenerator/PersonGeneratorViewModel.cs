
namespace Checkers.ViewModels
{
    using System;
    using System.Text.RegularExpressions;
    using Checkers.ViewModels.PersonGenerator;

    public class PersonGeneratorViewModel : ViewModelBase, IShell
    {
        PersonelManagement pm = new PersonelManagement();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string HairColor { get; set; }
        public string Input
        {
            get
            {
                return input;
            }
            set
            {
                input = value;
            }
        }
        public string PersonList
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
        public string FilterList
        {
            get
            {
                return filterList;
            }
            set
            {
                filterList = value;
                OnPropertyChanged( "FilterList" );
            }
        }

        public void Generator()
        {
            pm.ListPerson.Clear();
            Regex reg = new Regex( "^[0-9]+$" );
            //Prüfe ob eingabe Null oder Zahlen sind
            if( !string.IsNullOrEmpty( input ) && reg.IsMatch( input) )
            {
                bool result = int.TryParse( input, out int number );
                if( number != 0 && number < 10000 )
                {
                    PersonList = null;
                    pm.PersonGenerator( number );
                    foreach( Person item in pm.ListPerson )
                    {
                        PersonList += item;
                    }
                }
                else
                {
                    PersonList = "Max Zahl 9999";
                }
            }
            else
            {
                PersonList = "Zahl eingeben";
            }
        }

        public void Filter()
        {
            FilterList = null;
            pm.ListFilterPerson.Clear();
            if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay == null && string.IsNullOrEmpty( HairColor ) )
            {
                pm.SearchPerson( FirstName, LastName );
            }
            else if( (string.IsNullOrEmpty( FirstName ) && string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                pm.SearchDate( BirthDay );
            }
            else if( (string.IsNullOrEmpty( FirstName ) && string.IsNullOrEmpty( LastName )) && BirthDay == null && !string.IsNullOrEmpty( HairColor ) )
            {
                pm.searchHairColor( HairColor );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                pm.SearchPersonWithNameAndBirthDay( FirstName, LastName, BirthDay );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay == null && !string.IsNullOrEmpty( HairColor ) )
            {
                pm.SearchPersonWithNameAndHairColor( FirstName, LastName, HairColor );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                pm.SearchPersonWithAllInput( FirstName, LastName, BirthDay, HairColor );
            }
            if( pm.ListFilterPerson.Count > 0 )
            {
                foreach( Person item in pm.ListFilterPerson )
                {
                    FilterList += item;
                }
            }
            else
            {
                FilterList = "Nicht vorhanden";
            }
        }

        private string filterList;
        private string personList;
        private string input;

    }
}
