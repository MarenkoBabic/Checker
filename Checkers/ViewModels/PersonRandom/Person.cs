﻿namespace Checkers.ViewModels.PersonRandom
{
    using System;
    using System.Globalization;
    using Personalmanagement.Dto;
    using System.ComponentModel.DataAnnotations;


    public class Person : ViewModelBase
    {
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }
        public DateTime? BirthDay
        {
            get;
            set;
        }
        public HairColor HairColor
        {
            get;
            set;
        }

        public Person()
        { }
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
