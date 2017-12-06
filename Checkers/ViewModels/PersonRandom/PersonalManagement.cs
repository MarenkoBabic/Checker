namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;

    public class PersonalManagement : ViewModelBase
    {
        Random rnd = new Random();
        Array getColor = Enum.GetValues( typeof( HairColor ) );
        public List<Person> CreateRandomPerson( int input )
        {
            List<Person> listPerson = new List<Person>();

            //Generiert Anzahl(input) an Personen
            for( int i = 0; i < input; i++ )
            {
                Person person = new Person(
                        firstNameList.OrderBy( x => rnd.Next() ).First(),
                        lastNameList.OrderBy( x => rnd.Next() ).First(),
                        DateTime.Today.AddDays( -rnd.Next( 10 * 365 ) ),
                        (HairColor)getColor.GetValue( rnd.Next( getColor.Length ) ) );
                listPerson.Add( person );
            }

            return listPerson;
        }

        public IEnumerable<Person> SearchPerson( string firstName, string lastName, DateTime? birthDay, HairColor color, List<Person> listPerson )
        {
            IEnumerable<Person> filteredList = listPerson;
            
            //Suche Personen mit Vorname/ Nachname / Vorname und Nachname
            if( !string.IsNullOrEmpty( firstName ) )
            {
                filteredList = filteredList.Where(person => person.FirstName.Equals(firstName,StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if( !string.IsNullOrEmpty( lastName ) )
            {
                filteredList = filteredList.Where( person => person.LastName.Equals(lastName,StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if( birthDay.HasValue )
            {
                filteredList = filteredList.Where( person => person.BirthDay == birthDay).ToList();
            }

            if( color != HairColor.keineAngabe )
            {
                filteredList = filteredList.Where( person => person.HairColor ==  color).ToList();
            }
            return filteredList;
        }
        private  List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Markus", "Patrick" };
        private  List<string> lastNameList = new List<string>() { "Muster", "Pichler", "Eiweck", "Wolfrat", "Raböck", "Russen", "Grewen" };
    }

}

