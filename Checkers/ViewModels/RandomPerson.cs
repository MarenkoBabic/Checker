namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    enum HairColor { Rot, Blau, Grün, Blond, Schwarz, Weiß }

    class RandomPerson : ViewModelBase
    {
        public List<string> PersonList { get; set; }

        public RandomPerson()
        {
            PersonList = new List<string>();
        }

        public void PersonGenerator( string input )
        {
            bool result = int.TryParse( input, out int number );
            Random rnd = new Random();
            Array getColor = Enum.GetValues( typeof( Haarfarbe ) );

            for( int i = 0; i < number; i++ )
            {
                string firstName = firstNameList.OrderBy( x => rnd.Next() ).First();
                string lastName = lastNameList.OrderBy( x => rnd.Next() ).First();
                DateTime date = DateTime.Today.AddDays( -rnd.Next( 10 * 365 ) );
                var farbe = (Haarfarbe)getColor.GetValue( rnd.Next( getColor.Length ) );
                string Person = firstName + " " + lastName + " " + date.ToString( "dd.MM.yyyy" ) + " " + farbe;
                PersonList.Add( Person );
            }
        }

        private DateTime date;
        private List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Marenko", "Patrick" };
        private List<string> lastNameList = new List<string>() { "Prethaler", "Pichler", "Eiweck", "Wolfrath", "Ratzenböck", "Babic", "Grewe" };
    }

}

