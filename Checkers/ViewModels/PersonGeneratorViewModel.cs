
namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    enum Haarfarbe { Rot, Blau, Grün, Blond, Schwarz, Weiß }
    class PersonGeneratorViewModel : ViewModelBase,IShell
    {
        #region propertys

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

        public string InputFilter
        {
            get
            {
                return inputFilter;
            }
            set
            {
                inputFilter = value;
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

        public string PersonFilter
        {
            get
            {
                return personFilter;
            }
            set
            {
                personFilter = value;
                OnPropertyChanged( "PersonFilter" );
            }

        }

        public IEnumerable<string> PersonFilterList { get; set; }


        #endregion
        RandomPerson rn = new RandomPerson();

        public void Generator()
        {
            rn.PersonGenerator( Input );
            foreach( string person in rn.PersonList )
            {
                PersonList += person + "\n";
            }
        }

        public void Filter()
        {
            PersonFilterList = rn.PersonList.Where( x => x.Contains( InputFilter ) );

            foreach( string item in PersonFilterList )
            {
                PersonFilter += item + "\n";
            }
        }



        private string personFilter;
        private string personList;
        private string input;
        private string inputFilter;
    }
}
