namespace PersonalManagementTest
{
    using System;
    using System.Collections.Generic;
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
        public void PersonManagement_CreateNewPersonWithParamters_ParameterNotNull()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalmanagement.CreateNewPerson( "Marenko", "Babic", new DateTime(1986,05,13), HairColor.Braun );

            //Assert
            Assert.NotNull(person.FirstName);
            Assert.NotNull( person.LastName);
            Assert.NotNull(person.BirthDay );
            Assert.NotNull(person.HairColor );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWithoutParameter_ParameterNull()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalmanagement.CreateNewPerson( null, null, null,HairColor.KeineAngabe);

            //Assert
            Assert.Null( person.FirstName );
            Assert.Null( person.LastName );
            Assert.Null( person.BirthDay );
            Assert.NotNull( person.HairColor );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWithFirstName_FirstNameNotNull()
        {
            //Arrange
            PersonalManagement personalManagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalManagement.CreateNewPerson( "Marenko", null, null, HairColor.KeineAngabe );

            //Assert
            Assert.Equal(person.FirstName,"Marenko");
            Assert.Null( person.LastName );
            Assert.Null( person.BirthDay );
            Assert.NotNull( HairColor.KeineAngabe );
        }

        [Fact]
        public void PersonManagement_CreateNewPersonWith2Parameter_NotNull()
        {
            //Arrange
            PersonalManagement personalManagement = new PersonalManagement();
            Person person = new Person( null, null, null, HairColor.KeineAngabe );

            //Act
            person = personalManagement.CreateNewPerson( "Marenko", "Babic", null, HairColor.KeineAngabe );

            //Assert
            Assert.Equal( person.FirstName, "Marenko" );
            Assert.Equal( person.LastName,"Babic" );
            Assert.Null( person.BirthDay );
            Assert.NotNull( HairColor.KeineAngabe );
        }


        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithHairColor_ContainsHairColor()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();
            //Act
            //Assert
            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.Braun ) );
        }

        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithBirthDay_ContainsBirthday()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();
            //Act
            //Assert

        }

        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithLastNameAndFirstName_ContainsLastNameAndFirstName()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();
            //Act
            //Assert
            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "Marenko" ) );
            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "Babic" ) );
        }

        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithLastnameFirstnameBirthday_ContainsLastnameFirstnameAndBirthday()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();
            //Act

            //Assert
            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "marenko", StringComparison.OrdinalIgnoreCase ) );
            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "babic", StringComparison.OrdinalIgnoreCase ) );
            //Assert.Contains( viewModel.PersonList, item => item.BirthDay.Equals( "19860513") );
            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.KeineAngabe ) );






        }
        [Fact]
        public void PersonManagement_SearchPerson_ParameterWithAll_ContainsAll()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();

            //Act
            //Assert
            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "Marenko" ) );
            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "Babic" ) );
            //Assert.Contains( viewModel.PersonList, item => item.BirthDay.Equals( DateTime.Now ) );
            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.Braun ) );
        }


    }
}
