namespace Checkers.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Caliburn.Micro;

    public class CheckerViewModel : ViewModelBase, IHaveDisplayName, IShell
    {
        #region propertys
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
        public string TestResults
        {
            get
            {
                return testResults;
            }
            set
            {
                testResults = value;
                OnPropertyChanged( "testResults" );
            }
        }
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
        public IChecker SelectedChecker
        {
            get;
            set;
        }
        public List<IChecker> CheckerAuswahl { get; set; }
        #endregion
        public CheckerViewModel()
        {
            DisplayName = "Checker";
            CheckerAuswahl = new List<IChecker>
            {
                new PalindromeChecker(),new OddEvenChecker(),new PrimzahlChecker()
            };
        }

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

        public void Checker()
        {
            List<string> ResultList = new List<string>();

            if( SelectedChecker is PalindromeChecker )
            {
                bool result = SelectedChecker.Validate( Text );
                ResultList.Add( Text + " " + PalindromeResult( result ) );
            }
            else if( SelectedChecker is OddEvenChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool result = SelectedChecker.Validate( Text );
                    ResultList.Add( Text + " " + OddEvenResult( result ) );
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
                    bool result = SelectedChecker.Validate( Text );
                    ResultList.Add( text + " " + PrimzahlResult(result) );
                }
                else
                {
                    ErrorMessage = "Ungültige Angabe";
                }
            }
            TextResult( ResultList );
        }

        #region Result
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
        #endregion

        public void TextResult( List<string> Result )
        {
            foreach( string item in Result)
            {
                TestResults += item + ",\t";
            }
        }
        private string displayName;
        private string errorMessage;
        private string text;
        private string testResults;
    }
}
