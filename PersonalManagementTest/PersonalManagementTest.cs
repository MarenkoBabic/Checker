namespace PersonalManagementTest
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Checkers.ViewModels;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;
    using Xunit;
    public class PersonManagementTest
    {
        [Fact]
        public void PersonManagement_CreateRandomPersonTest_CountPersonIs0_ListIsEmpty()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            //Act
            List<Person> result = personalmanagement.CreateRandomPerson( 0 );

            //Assert
            Assert.Empty( result );
        }

        [Fact]
        public void PersonManagement_CreateRandomPersonTest_CountPersonIs1000_ListCount1000()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();

            //Act
            List<Person> result = personalmanagement.CreateRandomPerson( 1000 );

            //Assert
            Assert.Equal( result.Count, 1000 );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWithParamters_PersonNotNUll()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalmanagement.CreateNewPerson( "Marenko", "Babic", new DateTime( 1986, 05, 13 ), HairColor.Braun );

            //Assert
            Assert.NotNull( person.FirstName );
            Assert.NotNull( person.LastName );
            Assert.NotNull( person.BirthDay );
            Assert.NotNull( person.HairColor );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWithoutParameter_ParameterNull()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalmanagement.CreateNewPerson( null, null, null, HairColor.KeineAngabe );

            //Assert
            Assert.Null( person.FirstName );
            Assert.Null( person.LastName );
            Assert.Null( person.BirthDay );
            Assert.Equal( person.HairColor,HairColor.KeineAngabe);
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWith1Parameter_FirstNameNotNull()
        {
            //Arrange
            PersonalManagement personalManagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalManagement.CreateNewPerson( "Marenko", null, null, HairColor.KeineAngabe );

            //Assert
            Assert.Equal( person.FirstName, "Marenko" );
            Assert.Null( person.LastName );
            Assert.Null( person.BirthDay );
            Assert.Equal( HairColor.KeineAngabe,HairColor.KeineAngabe );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWith2Parameter_EqualParameter()
        {
            //Arrange
            PersonalManagement personalManagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalManagement.CreateNewPerson( "Marenko", "Babic", null, HairColor.KeineAngabe );

            //Assert
            Assert.Equal( person.FirstName, "Marenko" );
            Assert.Equal( person.LastName, "Babic" );
            Assert.Null( person.BirthDay );
            Assert.Equal( person.HairColor, HairColor.KeineAngabe );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWith3Parameter_PersonNotNull()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalmanagement.CreateNewPerson( "Marenko", "Babic", DateTime.Parse("13.05.1986"),HairColor.KeineAngabe );

            //Assert
            Assert.Equal( person.FirstName, "Marenko");
            Assert.Equal( person.LastName, "Babic" );
            Assert.Equal( person.BirthDay,DateTime.Parse("13.05.1986"));
            Assert.Equal(person.HairColor,HairColor.KeineAngabe );

        }

        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithFirstName_ContainsPersonPersonListNotNull()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );
            ObservableCollection<Person> listPerson = new ObservableCollection<Person>()
            {
                new Person("Marenko", "Babic", new DateTime(1986,05,13), HairColor.Braun ),
                new Person("Patrick", "Knofel", new DateTime(2016,11,01), HairColor.Rot ),
                new Person("Robert","Baxa",new DateTime(1990,01,01),HairColor.Blond)
            };

            //Act
            personalmanagement.SearchPerson( "Robert", null, null, HairColor.KeineAngabe, listPerson );

            //Assert
            Assert.NotNull( listPerson );
            Assert.Equal( listPerson.Count, 3 );
            Assert.Contains( listPerson, item => item.FirstName.Equals( "Robert", StringComparison.OrdinalIgnoreCase ) );
        }

        [Fact]
        public void PersonManagement_SearchPersonWith2Parameter_PersonListNotNullContainPerson()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );
            ObservableCollection<Person> listPerson = new ObservableCollection<Person>()
            {
                new Person("Marenko", "Babic",new DateTime(1986,05,13), HairColor.Braun ),
                new Person("Marenko", "Babic", new DateTime(1986,05,13), HairColor.Rot ),
                new Person("Patrick", "Knofel", new DateTime(2016,11,01), HairColor.Rot ),
                new Person("Robert","Baxa",new DateTime(1990,01,01),HairColor.Blond)
            };

            //Act
            personalmanagement.SearchPerson( "Marenko", "Babic", null, HairColor.KeineAngabe, listPerson );

            //Assert
            Assert.NotNull( listPerson );
            Assert.Equal( listPerson.Count, 4 );
            Assert.Contains( listPerson,
                item => item.FirstName.Equals( "Marenko", StringComparison.OrdinalIgnoreCase )
                && item.LastName.Equals( "Babic", StringComparison.OrdinalIgnoreCase ) );
        }

        [Fact]
        public void PersonManagement_SearchPersonWith3Parameter_PersonListNotNullContainPerson()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );
            ObservableCollection<Person> listPerson = new ObservableCollection<Person>()
            {
                new Person("Marenko", "Babic", new DateTime(1986,05,13), HairColor.Braun ),
                new Person("Patrick", "Knofel", new DateTime(2016,11,01), HairColor.Rot ),
                new Person("Robert","Baxa",new DateTime(1990,01,01),HairColor.Blond)
            };

            //Act
            personalmanagement.SearchPerson( "Marenko", "Babic",DateTime.Parse("13.05.1986") , HairColor.KeineAngabe, listPerson );

            //Assert
            Assert.NotNull( listPerson );
            Assert.Equal( listPerson.Count, 3 );
            Assert.Contains( listPerson,
                item => item.FirstName.Equals( "Marenko", StringComparison.OrdinalIgnoreCase )
                && item.LastName.Equals( "Babic", StringComparison.OrdinalIgnoreCase ));
            Assert.True( person.BirthDay.HasValue );
        }

        [Fact]
        public void PersonManagement_SearchPersonWith4Parameter_PersonListNotNullContainPerson()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );
            ObservableCollection<Person> listPerson = new ObservableCollection<Person>()
            {
                new Person("Marenko", "Babic", new DateTime(1986,05,13), HairColor.Braun ),
                new Person("Patrick", "Knofel", new DateTime(2016,11,01), HairColor.Rot ),
                new Person("Robert","Baxa",new DateTime(1990,01,01),HairColor.Blond)
            };

            //Act
            personalmanagement.SearchPerson( "Marenko", "Babic", new DateTime( 1986, 05, 13 ), HairColor.Braun, listPerson );

            //Assert
            Assert.NotNull( listPerson );
            Assert.Equal( listPerson.Count, 3 );
            Assert.Contains( listPerson,
                item => item.FirstName.Equals( "Marenko", StringComparison.OrdinalIgnoreCase )
                && item.LastName.Equals( "Babic", StringComparison.OrdinalIgnoreCase )
                && item.BirthDay.Equals( new DateTime( 1986, 05, 13 ) )
                && item.HairColor.Equals( HairColor.Braun )
                );
        }
    }
}
