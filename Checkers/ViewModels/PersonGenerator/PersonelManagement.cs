namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Checkers.ViewModels.PersonGenerator;

    public class PersonelManagement : ViewModelBase
    {
        Random rnd = new Random();
        Array getColor = Enum.GetValues( typeof( HairColor ) );
        public List<Person> ListPerson { get; set; }
        public List<Person> ListFilterPerson { get; set; }
        public PersonelManagement()
        {
            ListPerson = new List<Person>();
            ListFilterPerson = new List<Person>();
        }
        public void PersonGenerator( int input )
        {
            //Generiert Anzahl(input) an Personen
            for( int i = 0; i < input; i++ )
            {
                Person person = new Person(
                        firstNameList.OrderBy( x => rnd.Next() ).First(),
                        lastNameList.OrderBy( x => rnd.Next() ).First(),
                        DateTime.Today.AddDays( -rnd.Next( 10 * 365 ) ),
                        (HairColor)getColor.GetValue( rnd.Next( getColor.Length ) ) );
                ListPerson.Add( person );
            }
        }


        #region Filter
        public void searchHairColor( string hairColor )
        {
            // Suche nach Personen mit der Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.HairColor.ToString().ToLower() == hairColor.ToLower() ).ToList();
        }
        public void SearchDate( DateTime? birthDay )
        {
            //Suche na Personen mit dem Geburtsdatum
            ListFilterPerson = ListPerson.Where( x => x.BirthDay == birthDay ).ToList();
        }
        public void SearchPerson( string firstName, string lastName )
        {
            //Suche Personen mit Vorname/Nachname/Vorname und Nachname
            if( !string.IsNullOrEmpty( firstName ) && string.IsNullOrEmpty( lastName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.FirstName.ToLower() == firstName.ToLower() ).ToList();
            }
            else if( !string.IsNullOrEmpty( lastName ) && string.IsNullOrEmpty( firstName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.LastName.ToLower() == lastName.ToLower() ).ToList();
            }
            else if( !string.IsNullOrEmpty( firstName ) && !string.IsNullOrEmpty( lastName ) )
            {
                ListFilterPerson = ListPerson.Where( x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == lastName.ToLower() ).ToList();
            }
        }
        public void SearchPersonWithNameAndBirthDay( string firstName, string lastName, DateTime? birthDay )
        {
            //Suche Personen mit Vorname,Nachname und Geburtsdatum
            ListFilterPerson = ListPerson.Where( x => x.FirstName.ToLower() == firstName.ToLower() || x.LastName.ToLower() == lastName.ToLower() && x.BirthDay == birthDay ).ToList();
        }
        public void SearchPersonWithNameAndHairColor( string firstName, string lastName, string hairColor )
        {
            //Suche Personen mit Vorname,Nachname und Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == lastName.ToLower() && x.HairColor.ToString().ToLower() == hairColor.ToLower() ).ToList();
        }
        public void SearchPersonWithAllInput( string firstName, string lastName, DateTime? birthDay, string hairColor )
        {
            //Suche Personen mit Vorname,Nachname,Geburtsdatum und Haarfarbe
            ListFilterPerson = ListPerson.Where( x => x.FirstName.ToLower() == firstName.ToLower() && x.LastName.ToLower() == lastName.ToLower() && x.BirthDay == birthDay && x.HairColor.ToString().ToLower() == hairColor.ToLower() ).ToList();
        }
        #endregion

        private List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Markus", "Patrick" };
        private List<string> lastNameList = new List<string>() { "Muster", "Pichler", "Eiweck", "Wolfrat", "Raböck", "Russen", "Grewen" };
    }

}

