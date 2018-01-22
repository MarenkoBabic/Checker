namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Checkers.ViewModels.Checker;

    public class CheckerViewModel : ViewModelBase, IHaveDisplayName, IShell
    {
        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName
        {
            get
            {
                return displayName;
            }
            set
            {
                displayName = value;
            }
        }

        /// <summary>
        /// Fehlermeldung bei falsche Eingabe
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                OnPropertyChanged( "errorMessage" );
            }
        }

        /// <summary>
        /// Texteingabe 
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged( Text );
            }
        }

        /// <summary>
        /// Checkerauswahl
        /// </summary>
        public IChecker SelectedChecker
        {
            get;
            set;
        }

        /// <summary>
        /// Liste an Checker
        /// </summary>
        public List<IChecker> CheckerAuswahl
        {
            get;
            set;
        }

        /// <summary>
        /// Liste alle Ergebnisse
        /// </summary>
        public ObservableCollection<Result> ResultList { get; set; }

        public CheckerViewModel()
        {
            DisplayName = "Checker";
            CheckerAuswahl = new List<IChecker>
            {
                new PalindromeChecker(),new OddEvenChecker(),new PrimzahlChecker()
            };
            ResultList = new ObservableCollection<Result>();

        }

        /// <summary>
        /// Prüft ob Checker ausgewählt ist
        /// Prüft ob ein Texteingabe leer ist
        /// </summary>
        public void CheckButton()
        {
            // Prüft ob Checker ausgewählt ist
            if( SelectedChecker != null )
            {
                // Prüft ob Text vorhanden ist
                if( !string.IsNullOrWhiteSpace( Text ) )
                {
                    Checker();
                }
                else
                {
                    ErrorMessage = "Text eingeben";
                }
            }
            else
            {
                ErrorMessage = "Checker auswählen";
            }
        }

        /// <summary>
        /// Prüft welche Checker ausgewählt ist 
        /// </summary>
        public void Checker()
        {
            if( SelectedChecker is PalindromeChecker )
            {
                bool test = SelectedChecker.Validate( Text );
                Result result = new Result() { Text = Text, TestTime = DateTime.Now, TestResult = PalindromeResult( test ) };
                ResultList.Add( result );

            }
            else if( SelectedChecker is OddEvenChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool test = SelectedChecker.Validate( Text );
                    Result result = new Result() { Text = Text, TestTime = DateTime.Now, TestResult = OddEvenResult( test ) };
                    ResultList.Add( result );

                }
                else
                {
                    ErrorMessage = "Ungültige Angabe";
                }
            }

            else if( SelectedChecker is PrimzahlChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool test = SelectedChecker.Validate( Text );
                    Result result = new Result() { Text = Text, TestTime = DateTime.Now, TestResult = PrimzahlResult( test ) };
                    ResultList.Add( result );
                }
                else
                {
                    ErrorMessage = "Ungültige Angabe";
                }
            }
        }


        /// <summary>
        /// Validiert ein bool zum String
        /// </summary>
        /// <param name="result">Bool Ergebnis</param>
        /// <returns>Ergebnis als String</returns>
        public string PalindromeResult( bool result )
        {
            if( result )
            {
                return " ist ein Palindrome";
            }
            else
            {
                return "ist kein Palindrome";
            }
        }

        /// <summary>
        /// Validiert ein bool zum String
        /// </summary>
        /// <param name="result">Bool Ergebnis</param>
        /// <returns>Ergebnis als String</returns>
        public string OddEvenResult( bool result )
        {
            if( result )
            {
                return "ist eine gerade Zahl";
            }
            else
            {
                return "ist eine ungerade Zahl";
            }
        }

        /// <summary>
        /// Validiert ein bool zum String
        /// </summary>
        /// <param name="result">Bool Ergebnis</param>
        /// <returns>Ergebnis als String</returns>
        public string PrimzahlResult( bool result )
        {
            if( result )
            {
                return "ist eine Primzahl";
            }
            else
            {
                return "ist keine Primzahl";
            }
        }

        private string displayName;
        private string errorMessage;
        private string text;
    }
}
