namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkers.ViewModels.PersonGenerator;

    class RandomPerson : ViewModelBase
    {
        Random rnd = new Random();
        Array getColor = Enum.GetValues( typeof( HairColor ) );
        public List<Person> ListPerson { get; set; }
        public List<Person> ListFilterPerson { get; set; }
        public RandomPerson()
        {
            ListPerson = new List<Person>();
            ListFilterPerson = new List<Person>();
        }

        public void PersonGenerator( int input )
        {
            for( int i = 0; i < input; i++ )
            {
                Person person = new Person(
                        firstNameList.OrderBy( x => rnd.Next() ).First().ToLower(),
                        lastNameList.OrderBy( x => rnd.Next() ).First().ToLower(),
                        DateTime.Today.AddDays( -rnd.Next( 10 * 365 ) ),
                        (HairColor)getColor.GetValue( rnd.Next( getColor.Length ) ) );
                ListPerson.Add( person );
            }
        }

        #region filter
        public void searchHairColor( string hairColor )
        {
            // Suche nach Personen mit der Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.HairColor.ToString() == hairColor ).ToList();
        }
        public void SearchDate( DateTime? birthDay )
        {
            //Suche na Personen mit dem Geburtsdatum
            ListFilterPerson = ListPerson.Where( x => x.BirthDay == birthDay ).ToList();
        }
        public void SerachPerson( string firstName, string lastName )
        {
            //Suche Personen mit Vorname/Nachname/Vorname und Nachname
            if( !string.IsNullOrEmpty( firstName ) && string.IsNullOrEmpty( lastName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.FirstName == firstName ).ToList();
            }
            else if( !string.IsNullOrEmpty( lastName ) && string.IsNullOrEmpty( firstName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.LastName == lastName ).ToList();
            }
            else if( !string.IsNullOrEmpty( firstName ) && !string.IsNullOrEmpty( lastName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.FirstName == firstName && x.LastName == lastName ).ToList();
            }
        }
        public void SearchPersonWithNameAndBirthDay( string firstName, string lastName, DateTime? birthDay )
        {
            //Suche Personen mit Vorname,Nachname und Geburtsdatum
            ListFilterPerson = ListPerson.Where( x => x.FirstName == firstName || x.LastName == lastName && x.BirthDay == birthDay ).ToList();
        }
        public void SearchPersonWithNameAndHairColor( string firstName, string lastName, string hairColor )
        {
            //Suche Personen mit Vorname,Nachname und Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.FirstName == firstName || x.LastName == lastName && x.HairColor.ToString() == hairColor ).ToList();
        }
        public void SearchPersonWithAllInput( string firstName, string lastName, DateTime? birthDay, string hairColor )
        {
            //Suche Personen mit Vorname,Nachname,Geburtsdatum und Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.FirstName == firstName && x.LastName == lastName && x.BirthDay == birthDay && x.HairColor.ToString() == hairColor ).ToList();
        }

        #endregion



        private string errorMessageGenerator;
        private List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Mareno", "Patrick" };
        private List<string> lastNameList = new List<string>() { "Muster", "Pichler", "Eiweck", "Wolfrat", "Raböck", "Russen", "Grewen" };
    }

}

