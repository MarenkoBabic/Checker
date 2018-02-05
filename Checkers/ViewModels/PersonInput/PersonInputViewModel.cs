namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Personalmanagement.Dto;

    public class PersonInputViewModel : ViewModelBase
    {
        /// <summary>
        /// Liste für Auswahl Haarfarbe in der Combobox
        /// </summary>
        public IEnumerable<HairColor> HairColorList
        {
            get
            {
                return Enum.GetValues( typeof( HairColor ) ).Cast<HairColor>();
            }
        }

        /// <summary>
        /// Prüft ob der Wert validiert ist
        /// </summary>
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty( this.Error ) && !string.IsNullOrEmpty( CountPerson.ToString() );
            }
        }

        /// <summary>
        /// Zahleingabe für generieren von Personen
        /// </summary> 
        [Range( 1, 100000, ErrorMessage = "Maximal 100000" )]
        public int CountPerson
        {
            get
            {
                return countPerson;
            }
            set
            {
                countPerson = value;
                OnPropertyChanged( "CountPerson" );
                OnPropertyChanged( nameof( IsValid ) );
            }
        }

        /// <summary>
        /// Eingabe für Vorname
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged( FirstName );
            }
        }

        /// <summary>
        /// Eingabe für Nachname
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged( LastName );
            }
        }

        /// <summary>
        /// Eingabe für Geburtsdatum
        /// </summary>
        public string BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
                OnPropertyChanged( BirthDay );
            }
        }

        /// <summary>
        /// Auswahl Haarfarbe
        /// </summary>
        public HairColor HairColor
        {
            get
            {
                return hairColor;
            }
            set
            {
                hairColor = value;
                OnPropertyChanged( "HairColor" );
            }
        }

        public PersonInputViewModel()
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.birthDay = BirthDay;
            this.hairColor = HairColor;
            this.countPerson = CountPerson;
        }

        private HairColor hairColor;
        private string firstName;
        private string lastName;
        private string birthDay;
        private int countPerson;

    }
}
