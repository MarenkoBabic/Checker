
namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using Checkers.ViewModels.PersonGenerator;

    class PersonGeneratorViewModel : ViewModelBase, IShell
    {
        #region propertys
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

        #endregion
        RandomPerson rn = new RandomPerson();

        public void Generator()
        {
            rn.ListPerson.Clear();
            Regex reg = new Regex( "^[0-9]+$" );
            if( !string.IsNullOrEmpty( input ) )
            {
                if( reg.IsMatch( input.TrimStart() ) )
                {
                    bool result = int.TryParse( input, out int number );
                    if( number != 0 )
                    {
                        PersonList = null;
                        if( true )
                        {

                        }
                        rn.PersonGenerator( number );
                        foreach( Person item in rn.ListPerson )
                        {
                            PersonList += item;
                        }
                    }
                    else
                    {
                        PersonList = "Max Zahl 2.147.483.647";
                    }
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
            rn.ListFilterPerson.Clear();
            if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay == null && string.IsNullOrEmpty( HairColor ) )
            {
                rn.SerachPerson( FirstName, LastName );
            }
            else if( (string.IsNullOrEmpty( FirstName ) && string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                rn.SearchDate( BirthDay );
            }
            else if( (string.IsNullOrEmpty( FirstName ) && string.IsNullOrEmpty( LastName )) && BirthDay == null && !string.IsNullOrEmpty( HairColor ) )
            {
                rn.searchHairColor( HairColor );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                rn.SearchPersonWithNameAndBirthDay( FirstName, LastName, BirthDay );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay == null && !string.IsNullOrEmpty( HairColor ) )
            {
                rn.SearchPersonWithNameAndHairColor( FirstName, LastName, HairColor );
            }
            else if( (!string.IsNullOrEmpty( FirstName ) || !string.IsNullOrEmpty( LastName )) && BirthDay != null && string.IsNullOrEmpty( HairColor ) )
            {
                rn.SearchPersonWithAllInput( FirstName, LastName, BirthDay, HairColor );
            }

            if( rn.ListFilterPerson != null )
            {
                foreach( Person item in rn.ListFilterPerson )
                {
                    FilterList += item + "\n";
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
