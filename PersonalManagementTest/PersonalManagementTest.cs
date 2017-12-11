//namespace PersonalManagementTest
//{
//    using System;
//    using System.Collections.Generic;
//    using Checkers.ViewModels;
//    using Checkers.ViewModels.PersonRandom;
//    using Personalmanagement.Dto;
//    using Xunit;
//    public class PersonManagementTest
//    {
//        [Fact]
//        public void PersonManagement_CreateRandomPersonTest_CountPersonIs0_ListIsEmpty()
//        {
//            //Arrange
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            List<Person> result = personalmanagement.CreateRandomPerson( 0 );

//            //Assert
//            Assert.Empty( result );
//        }

//        [Fact]
//        public void PersonManagement_CreateRandomPersonTest_CountPersonIs1000_ListIsNotNUll()
//        {
//            //Arrange
//            PersonalManagement personalmanagement = new PersonalManagement();

//            //Act
//            List<Person> result = personalmanagement.CreateRandomPerson( 1000 );

//            //Assert
//            Assert.Equal( result.Count, 1000 );
//        }

//        [Fact]
//        public void PersonManagement_CreateNewPerson_EqaulListPersonAndPersonList()
//        {
//            //Arrange
//            PersonalManagement personalmanagement = new PersonalManagement();
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            List<Person> person = new List<Person>() { new Person( "Marenko", "Babic",null, HairColor.Braun )};
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( "Marenko", "Babic",null,HairColor.Braun );
//            //Assert
//            Assert.Equal(person,viewModel.PersonList);
//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithFirstName_ContainsFirstName()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( "Marenko", null, null, HairColor.KeineAngabe );
//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "Marenko" ) );
//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithLastName_ContainsLastName()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( null, "Babic", null, HairColor.KeineAngabe );
//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "Babic" ) );
//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithHairColor_ContainsHairColor()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( null, null, null, HairColor.Braun );
//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.Braun ) );
//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithBirthDay_ContainsBirthday()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( null, null, new DateTime( 1986, 05, 13 ), HairColor.KeineAngabe );
//            //Assert

//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithLastNameAndFirstName_ContainsLastNameAndFirstName()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( "Marenko", "Babic", null, HairColor.KeineAngabe );
//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "Marenko" ) );
//            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "Babic" ) );
//        }

//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithLastnameFirstnameBirthday_ContainsLastnameFirstnameAndBirthday()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();
//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( "Marenko", "Babic", new DateTime( 1986, 05, 13 ), HairColor.KeineAngabe );

//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "marenko", StringComparison.OrdinalIgnoreCase ) );
//            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "babic", StringComparison.OrdinalIgnoreCase ) );
//            //Assert.Contains( viewModel.PersonList, item => item.BirthDay.Equals( "19860513") );
//            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.KeineAngabe) );






//        }
//        [Fact]
//        public void PersonManagement_SearchPerson_ParameterWithAll_ContainsAll()
//        {
//            //Arrange
//            PersonRandomViewModel viewModel = new PersonRandomViewModel();
//            PersonalManagement personalmanagement = new PersonalManagement();

//            //Act
//            viewModel.PersonList = personalmanagement.CreateNewPerson( "Marenko", "Babic", DateTime.Now, HairColor.Braun );
//            //Assert
//            Assert.Contains( viewModel.PersonList, item => item.FirstName.Equals( "Marenko" ) );
//            Assert.Contains( viewModel.PersonList, item => item.LastName.Equals( "Babic" ) );
//            //Assert.Contains( viewModel.PersonList, item => item.BirthDay.Equals( DateTime.Now ) );
//            Assert.Contains( viewModel.PersonList, item => item.HairColor.Equals( HairColor.Braun ) );
//        }


//    }
//}
