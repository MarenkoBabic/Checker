
namespace PersonalGeneratorTest
{
    using System;
    using System.Collections.Generic;
    using Checkers.ViewModels;
    using Checkers.ViewModels.PersonGenerator;
    using Xunit;

    public class PersonelManagementTest
    {
        PersonalManagement pm = new PersonalManagement();

        [Fact]
        public void PersonelManagementTest_PersonGeneratorInputIs100000()
        {
            //Arrange
            int input = 100000;


            //Act
            pm.PersonGenerator( input );

            //Assert
            Assert.Equal( pm.ListPerson.Count, input );
        }
        [Fact]
        public void PersonelManagementTest_PersonGeneratorInputIsNull_ListPerson_isEmpty()
        {
            //Arrange
            int input = 0;

            //Act
            pm.PersonGenerator( input );

            //Assert
            Assert.Empty( pm.ListPerson );
        }
        [Fact]
        public void PersonelManagementTest_SearchHair_String_Blond_FilterListPerson_NotNull()
        {
            //Arrange
            int input = 100;
            string hairColor = "Blond";

            //Act
            pm.PersonGenerator( input );
            //pm.searchHairColor( hairColor );

            //Assert
            Assert.NotNull( pm.ListFilterPerson );
        }
        [Fact]
        public void PersonelManagementTest_SearchPersonWith_FirstName_FilterListPerson_NotNull()
        {
            //Arrange
            string firstName = "Andi";
            int input = 100;
            //Act
            pm.PersonGenerator( input );
            //pm.SearchPerson( firstName, null );

            //Assert
            Assert.NotNull( pm.ListFilterPerson );
        }
        [Fact]
        public void PersonelManagementTest_SearchPersonWith_LastName_FilterListPerson_NotNull()
        {
            //Arrange
            string lastName = "Muster";
            int input = 100;
            //Act
            pm.PersonGenerator( input );
            //pm.SearchPerson( null, lastName);

            //Assert
            Assert.NotNull( pm.ListFilterPerson );
        }
        [Fact]
        public void PersonelManagementTest_SearchBirthDay_DateTime_NotNull()
        {
            //Arrange
            DateTime birthDay = DateTime.MaxValue;
            int input = 100;
            List<Person> TestList = new List<Person>();
            //Act
            pm.PersonGenerator( input );
            //pm.SearchDate( birthDay );
            //Assert
            Assert.NotNull(pm.ListFilterPerson);
        }
    }
}
