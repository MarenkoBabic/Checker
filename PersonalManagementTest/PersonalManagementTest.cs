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
        public void PersonManagement_CreateRandomPersonTest_CountPersonIs1000_ListIsNotNUll()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();

            //Act
            List<Person> result = personalmanagement.CreateRandomPerson(1000);

            //Assert
            Assert.Equal( result.Count,1000);
        }

        [Fact]
        public void PersonManagement_CreateNewPerson_True()
        {
            //Arrange
            PersonalManagement personalmanagement = new PersonalManagement();

            //Act
            List<Person> list = new List<Person>() { new Person( "Marenko", "Babic", DateTime.Now, Personalmanagement.Dto.HairColor.Braun ) };
            //Person person = new Person( "Marenko", "Babic", DateTime.Now, Personalmanagement.Dto.HairColor.Braun );
            //list.Add( person );
            //Assert
            Assert.Collection( list,
                item => Assert.Equal( "Marenko",item.FirstName),
                item => Assert.Equal( "Babic",item.LastName));
        }
        //        item => Assert.Equal(item.BirthDay, DateTime.Now ),
        //        item => Assert.Equal(item.HairColor,HairColor.Braun));
        //}


        [Fact]
        public void PersonManagement_SearchPerson_ParameterAllNull_()
        {
            //Arrange
            PersonRandomViewModel viewModel = new PersonRandomViewModel();
            PersonalManagement personalmanagement = new PersonalManagement();
            personalmanagement.CreateNewPerson( "Marenko", "Babic", new DateTime( 13 / 05 / 1986 ), Personalmanagement.Dto.HairColor.Braun );

            //Act
            IEnumerable<Person> filteredList = personalmanagement.SearchPerson(null,null,null, Personalmanagement.Dto.HairColor.KeineAngabe,null);

            //Assert
            //Assert.NotEqual();
        }

    }
}
