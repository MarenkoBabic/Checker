namespace Checkers.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
        public ObservableCollection<string> PalindromeList
        {
            get
            {
                return palindromeList;
            }
            set
            {
                palindromeList = value;
            }
        }
        public ObservableCollection<string> PrimzahlList
        {
            get
            {
                return primzahlList;
            }
            set
            {
                primzahlList = value;
                OnPropertyChanged( "PrimzahlList" );
            }
        }

        public ObservableCollection<string> OddEvenList
        {
            get { return oddEvenList; }
            set { oddEvenList = value; }
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
            oddEvenList = new ObservableCollection<string>();
            PalindromeList = new ObservableCollection<string>();
            PrimzahlList = new ObservableCollection<string>();
            DisplayName = "Checker";
            CheckerAuswahl = new List<IChecker>
            {
                new PalindromeChecker(),new OddEvenChecker(),new PrimzahlChecker()
            };
        }
        int count = 0;
        public void CheckButton()
        {
            // Prüft ob Checker ausgewählt ist
            if( SelectedChecker != null )
            {
                // Prüft ob Text vorhanden ist
                if( !string.IsNullOrWhiteSpace( Text ) )
                {
                    count++;
                    Checker( count );
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

        public void Checker( int count )
        {
            if( SelectedChecker is PalindromeChecker )
            {
                bool result = SelectedChecker.Validate( Text );
                PalindromeList.Add( Text + " " + PalindromeResult( result ) );
            }
            else if( SelectedChecker is OddEvenChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool result = SelectedChecker.Validate( Text );
                    OddEvenList.Add( Text + " " + OddEvenResult( result ) );
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
                    PrimzahlList.Add( text + " " + PrimzahlResult( result ) );
                }
                else
                {
                    ErrorMessage = "Ungültige Angabe";
                }
            }

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


        private string displayName;
        private string errorMessage;
        private string text;
        private ObservableCollection<string> primzahlList;
        private ObservableCollection<string> oddEvenList;
        private ObservableCollection<string> palindromeList;

    }
}
