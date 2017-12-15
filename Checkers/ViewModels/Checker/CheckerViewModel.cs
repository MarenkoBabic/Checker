namespace Checkers.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using Checkers.ViewModels.Checker;

    public class CheckerViewModel : ViewModelBase, IHaveDisplayName, IShell
    {
        XmlHelper xml = new XmlHelper();
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
        public List<IChecker> CheckerAuswahl
        {
            get;
            set;
        }
        public ObservableCollection<Result> ResultList { get; set; }
        public CheckerViewModel()
        {
            DisplayName = "Checker";
            CheckerAuswahl = new List<IChecker>
            {
                new PalindromeChecker(),new OddEvenChecker(),new PrimzahlChecker()
            };
            ResultList = new ObservableCollection<Result>();
            ResultList = xml.DeserializeResultList();

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
            if( SelectedChecker is PalindromeChecker )
            {
                bool test = SelectedChecker.Validate( Text );
                Result result = new Result() {Text = Text,TestTime = DateTime.Now,TestResult = PalindromeResult(test)};
                ResultList.Add( result );
                xml.SerializeResultList( ResultList );

            }
            else if( SelectedChecker is OddEvenChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool test = SelectedChecker.Validate( Text );
                    Result result = new Result() { Text = Text, TestTime = DateTime.Now,TestResult = OddEvenResult(test) };
                    ResultList.Add( result );
                    xml.SerializeResultList( ResultList );

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
                    Result result = new Result() { Text = Text, TestTime = DateTime.Now,TestResult = PrimzahlResult(test)};
                    ResultList.Add( result );
                    xml.SerializeResultList( ResultList );
                }
                else
                {
                    ErrorMessage = "Ungültige Angabe";
                }
            }
        }

        public string PalindromeResult( bool result )
        {
            if( result )
            {
                return  " ist ein Palindrome";
            }
            else
            {
                return  "ist kein Palindrome";
            }
        }

        public string OddEvenResult( bool result )
        {
            if( result )
            {
                return  "ist eine gerade Zahl";
            }
            else
            {
                return  "ist eine ungerade Zahl";
            }
        }

        public string PrimzahlResult( bool result )
        {
            if( result )
            {
                return  "ist eine Primzahl";
            }
            else
            {
                return  "ist keine Primzahl";
            }
        }

        private string displayName;
        private string errorMessage;
        private string text;
    }
}
