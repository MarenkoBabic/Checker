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

        /// <summary>
        /// Generiert eine Person per Zufall
        /// </summary>
        /// <param name="countPerson"> Anzahl an Personen </param>
        /// <returns>Liste mit Personen</returns>
        public List<Person> CreateRandomPerson( int countPerson )
        {
            List<Person> listPerson = new List<Person>();
            //Generiert Anzahl(PersonenAnzahl) an Personen
            for( int i = 0; i < countPerson; i++ )
            {
                Person person = new Person(
                        firstNameList.OrderBy( x => rnd.Next() ).First(),
                        lastNameList.OrderBy( x => rnd.Next() ).First(),
                        DateTime.Today.AddDays( -rnd.Next( 30 * 365 ) ),
                        (HairColor)getColor.GetValue( rnd.Next( 1, 7 ) ) );
                listPerson.Add( person );
            }
            return listPerson;
        }

        /// <summary>
        /// Filtert die Personenliste
        /// </summary>
        /// <param name="firstName"> Der mitgebene Wert zum filtern</param>
        /// <param name="lastName"> Der mitgebene Wert zum filtern</param>
        /// <param name="birthDay"> Der mitgebene Wert zum filtern</param>
        /// <param name="color"> Der mitgebene Wert zum filtern</param>
        /// <param name="listPerson">Die mitgebene Liste zum Filtern </param>
        /// <returns> Gefilterte Liste an Personen</returns>
        public ObservableCollection<Person> SearchPerson( string firstName, string lastName, DateTime? birthDay, HairColor color, ObservableCollection<Person> listPerson, ObservableCollection<Person> ListPersonFiltered )
        {
            ObservableCollection<Person> list = new ObservableCollection<Person>();
            IEnumerable<Person> filteredList = null;
            if( HasValue( firstName ) || HasValue( lastName ) || birthDay.HasValue || color != HairColor.KeineAngabe )
            {
                //prüft welche liste Werte hat
                if( listPerson.Count >= 1 )
                {
                    filteredList = listPerson;
                }
                else
                {
                    filteredList = ListPersonFiltered;
                }

                //Prüft ob Vorname ein wert hat
                if( HasValue( firstName ) )
                {
                    filteredList = filteredList.Where( person => person.FirstName.Equals( firstName, StringComparison.OrdinalIgnoreCase ) ).ToList();
                }
                //Prüft ob Nachname ein wert hat
                if( HasValue( lastName ) )
                {
                    filteredList = filteredList.Where( person => person.LastName.Equals( lastName, StringComparison.OrdinalIgnoreCase ) ).ToList();
                }
                //Prüft ob Geburtstag ein wert hat
                if( birthDay.HasValue )
                {

                    filteredList = filteredList.Where( person => person.BirthDay.Equals( birthDay ) ).ToList();
                }
                //Prüft ob Haarfarbe ein wert hat
                if( color != HairColor.KeineAngabe )
                {
                    filteredList = filteredList.Where( person => person.HairColor.Equals( color ) ).ToList();
                }
            }
            //Prüft ob list nicht leer ist
            if( filteredList != null )
            {
                filteredList.ToList().ForEach( list.Add );
            }
            return list;
        }

        /// <summary>
        /// Validiert einen String und liefert das Ergebnis als bool
        /// </summary>
        /// <param name="s">Der zu überprüfende Wert</param>
        /// <returns>True or False</returns>
        private bool HasValue( string s )
        {
            return !string.IsNullOrEmpty( s );
        }

        /// <summary>
        /// Erzeugt eine neue Person
        /// </summary>
        /// <param name="firstName">Eingabe Vorname</param>
        /// <param name="lastName">Eingabe Nachname</param>
        /// <param name="birthDay">Eingabe Geburtsdatum</param>
        /// <param name="color">Eingabe Haarfarbe</param>
        /// <returns>neue Person</returns>
        public Person CreateNewPerson( string firstName, string lastName, DateTime? birthDay, HairColor color )
        {
            Person person = new Person( firstName, lastName, birthDay, color );
            return person;
        }

        private List<string> firstNameList = new List<string>() { "Josef", "Sepp", "Hans", "Andi", "Peter", "Robert", "Markus", "Patrick" };
        private List<string> lastNameList = new List<string>() { "Muster", "Pichler", "Eiweck", "Wolfrat", "Raböck", "Russen", "Grewen" };
    }
}

