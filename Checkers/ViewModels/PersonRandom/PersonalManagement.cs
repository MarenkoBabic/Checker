namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;
    using System.Collections.ObjectModel;

    public class PersonalManagement : ViewModelBase
    {
        Random rnd = new Random();
        Array getColor = Enum.GetValues( typeof( HairColor ) );
        public List<Person> CreateRandomPerson( int countPerson )
        {
            List<Person> listPerson = new List<Person>();
            //Generiert Anzahl(PersonenAnzahl) an Personen
            for( int i = 0; i < countPerson; i++ )
            {
                Person person = new Person(
                        firstNameList.OrderBy( x => rnd.Next() ).First(),
                        lastNameList.OrderBy( x => rnd.Next() ).First(),
                        DateTime.Today.AddDays( -rnd.Next( 10 * 365 ) ),
                        (HairColor)getColor.GetValue( rnd.Next( 1, 7 ) ) );
                listPerson.Add( person );
            }
            return listPerson;
        }

        public IEnumerable<Person> SearchPerson( string firstName, string lastName, DateTime? birthDay, HairColor color, ObservableCollection<Person> listPerson )
        {
            IEnumerable<Person> filteredList = null;
            if( HasValue(firstName) || HasValue( lastName ) || birthDay.HasValue || color != HairColor.KeineAngabe )
            {
                filteredList = listPerson;

                //Suche Personen mit Vorname/ Nachname / Vorname und Nachname
                if( HasValue( firstName ) )
                {
                    filteredList = filteredList.Where( person => person.FirstName.Equals( firstName, StringComparison.OrdinalIgnoreCase ) ).ToList();
                }

                if(HasValue( lastName ) )
                {
                    filteredList = filteredList.Where( person => person.LastName.Equals( lastName, StringComparison.OrdinalIgnoreCase ) ).ToList();
                }

                if( birthDay.HasValue )
                {

                    filteredList = filteredList.Where( person => person.BirthDay.Equals( birthDay)).ToList();
                }

                if( color != HairColor.KeineAngabe )
                {
                    filteredList = filteredList.Where( person => person.HairColor.Equals( color ) ).ToList();
                }
            }
            return filteredList;
        }

        private bool HasValue(string s )
        {
            return !string.IsNullOrEmpty( s );
        }
        public Person CreateNewPerson( string firstName, string lastName, DateTime? birthDay, HairColor color )
        {
            Person person = new Person( firstName, lastName, birthDay, color );
            return person;
        }

        private List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Markus", "Patrick" };
        private List<string> lastNameList = new List<string>() { "Muster", "Pichler", "Eiweck", "Wolfrat", "Raböck", "Russen", "Grewen" };

    }
}

