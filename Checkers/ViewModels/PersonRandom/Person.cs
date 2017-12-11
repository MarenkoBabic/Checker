namespace Checkers.ViewModels.PersonRandom
{
    using System;
    using Personalmanagement.Dto;
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public HairColor HairColor { get; set; }

        public Person( string firstName, string lastName, DateTime? birthDay, HairColor hairColor )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.HairColor = hairColor;
        }

        public override string ToString()
        {
            return "Vorname: " + FirstName + "\t Nachname: " + LastName + "\t Geburtsdatum: " + BirthDay + "\t Haarfarbe: " + HairColor + "\n";
        }
    }
}
