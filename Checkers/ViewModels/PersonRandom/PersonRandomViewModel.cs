namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Windows;
    using Checkers.ViewModels.PersonRandom;
    using Personalmanagement.Dto;
    public class PersonRandomViewModel : ViewModelBase, IShell
    {
        XmlHelper xml = new XmlHelper();
        PersonalManagement personalManager = new PersonalManagement();
        #region Property

        public PersonInputViewModel PersonInputViewModel
        {
            get
            {
                return personInputViewModel;
            }
            set
            {
                personInputViewModel = value;
                OnPropertyChanged( nameof( PersonInputViewModel ) );
            }
        }


        /// <summary>
        /// Personenliste gefiltert
        /// </summary>
        public ObservableCollection<Person> ListPersonFiltered
        {
            get
            {
                return listPersonFiltered;
            }
            set
            {
                listPersonFiltered = value;
                OnPropertyChanged( nameof( ListPersonFiltered ) );
            }
        }


        /// <summary>
        /// Collection von Personenliste
        /// </summary>
        public ObservableCollection<Person> PersonList { get; set; }

        /// <summary>
        /// Speichert den Path von der zuletzt geöffnetet Xml
        /// </summary>
        public string XmlPath
        {
            get
            {
                return xmlPath;
            }
            set
            {
                xmlPath = value;
                OnPropertyChanged( "XmlPath" );
            }
        }

        #endregion

        public PersonRandomViewModel()
        {
            PersonList = new ObservableCollection<Person>();
            ListPersonFiltered = new ObservableCollection<Person>();
            PersonInputViewModel = new PersonInputViewModel();
        }

        /// <summary>
        /// Erzeugt eine Liste an Personen per Zufall
        /// </summary>
        public void GenerateRandomPerson()
        {
            var list = new List<Person>();
            bool result = int.TryParse(PersonInputViewModel.CountPerson.ToString(), out int number );
            list = personalManager.CreateRandomPerson( number );
            list.ForEach( PersonList.Add );
            ListPersonFiltered = PersonList;
        }

        /// <summary>
        /// Filtert die Personenliste
        /// </summary>
        public void Filter()
        {
            if( !string.IsNullOrEmpty( PersonInputViewModel.BirthDay ) )
            {
                bool result = DateTime.TryParse( PersonInputViewModel.BirthDay, out DateTime birthDay );
                this.ListPersonFiltered = personalManager.SearchPerson( PersonInputViewModel.FirstName, PersonInputViewModel.LastName, birthDay, PersonInputViewModel.HairColor, PersonList );
            }
            else
            {
                DateTime? birthDayNull = null;
                this.ListPersonFiltered = personalManager.SearchPerson( PersonInputViewModel.FirstName, PersonInputViewModel.LastName, birthDayNull, PersonInputViewModel.HairColor, PersonList );
            }
        }

        /// <summary>
        /// Resettet die Eingabefelder
        /// </summary>
        public void Reset()
        {
            PersonInputViewModel.FirstName = null;
            PersonInputViewModel.LastName = null;
            PersonInputViewModel.BirthDay = null;
            PersonInputViewModel.HairColor = HairColor.KeineAngabe;
        }
        /// <summary>
        /// Erzeugt eine einzelne Person
        /// </summary>
        public void CreateNewPerson()
        {
            if( !string.IsNullOrEmpty( PersonInputViewModel.BirthDay ) )
            {
                PersonList.Add( personalManager.CreateNewPerson( PersonInputViewModel.FirstName, PersonInputViewModel.LastName, DateTime.Parse( PersonInputViewModel.BirthDay ), personInputViewModel.HairColor ) );
            }
            else
            {
                DateTime? birthDayNull = null;
                PersonList.Add( personalManager.CreateNewPerson( PersonInputViewModel.FirstName, PersonInputViewModel.LastName, birthDayNull, PersonInputViewModel.HairColor ) );
            }
        }

        /// <summary>
        /// Der Personenliste eine Xml-Datein hinzufügen
        /// </summary>
        public void AddXmlFile()
        {
            XmlPath = xml.OpenFileDialog();
            List<Person> list = new List<Person>();
            list = xml.LoadXmlFile( XmlPath );
            list.ForEach( PersonList.Add );
        }

        /// <summary>
        /// Der gefilterten Liste eine Xml-Datein hinzufügen
        /// </summary>
        public void AddFilterList()
        {
            XmlPath = xml.OpenFileDialog();
            List<Person> list = new List<Person>();
            list = xml.LoadXmlFile( XmlPath );
            if( list.Count >= 1 )
            {
                list.ForEach( ListPersonFiltered.Add );
            }
        }

        /// <summary>
        /// Leert die Liste
        /// </summary>
        public void DeleteList()
        {
            ///Frage den User, ob er wirklich die Liste löschen will 
            MessageBoxResult result = MessageBox.Show( "Liste wirklich löschen ? Nicht gespeichert Daten gehen verloren!", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question );
            if( result == MessageBoxResult.Yes )
            {
                PersonList.Clear();
            }
        }

        /// <summary>
        /// Leert die gefilterete Liste
        /// </summary>
        public void DeleteFilterList()
        {
            ///Frage den User, ob er wirklich die Liste löschen will 
            MessageBoxResult result = MessageBox.Show( "Liste wirklich löschen ? Nicht gespeichert Daten gehen verloren!", "caption", MessageBoxButton.YesNo, MessageBoxImage.Question );
            if( result == MessageBoxResult.Yes )
            {
                ListPersonFiltered.Clear();
            }
        }

        /// <summary>
        /// Speichert die Personenliste als Xml-File
        /// </summary>
        public void SaveListAsXmlFile()
        {
            xml.SaveXmlFile( PersonList );
        }

        /// <summary>
        /// Speichert die gefilterete Liste als Xml-File
        /// </summary>
        public void SaveFilterListAsXmlFile()
        {
            xml.SaveXmlFile( ListPersonFiltered );
        }


        #region private
        private ObservableCollection<Person> listPersonFiltered;
        private string xmlPath;
        private PersonInputViewModel personInputViewModel;

        #endregion
    }
}
