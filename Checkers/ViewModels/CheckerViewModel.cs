namespace Checkers.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using Caliburn.Micro;

    public class CheckerViewModel : ViewModelBase, IHaveDisplayName,IShell
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
        public string TextBlockMessage
        {
            get
            {
                return textBlockMessage;
            }
            set
            {
                textBlockMessage = value;
                OnPropertyChanged( "textBlockMessage" );
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
            CheckerAuswahl = new List<IChecker>() { new PalindromeChecker(), new OddEvenChecker(), new PrimzahlChecker() };
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
                    TextBlockMessage = "Text eingeben";
                }
            }
            else
            {
                TextBlockMessage = "Checker auswählen";
            }
        }

        public void Checker()
        {
            if( SelectedChecker is PalindromeChecker )
            {
                bool result = SelectedChecker.Validate( Text );
                TextBlockMessage = PalindromeResult( result );
            }
            else if( SelectedChecker is OddEvenChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool result = SelectedChecker.Validate( Text );
                    TextBlockMessage = OddEvenResult( result );
                }
                else
                {
                    TextBlockMessage = "Ungültige Angabe";
                }
            }
            else if( SelectedChecker is PrimzahlChecker )
            {
                //Prüft ob text nur Zahlen sind
                Regex reg = new Regex( "^[0-9]+$" );
                if( reg.IsMatch( text.TrimStart() ) )
                {
                    bool result = SelectedChecker.Validate( Text );
                    TextBlockMessage = PrimzahlResult( result );
                }
                else
                {
                    TextBlockMessage = "Ungültige Angabe";
                }
            }
        }

        #region Result
        public string PalindromeResult( bool result )
        {
            if( result )
            {
                return "Palindrome";
            }
            else
            {
                return "Kein Palindrome";
            }
        }
        public string OddEvenResult( bool result )
        {
            if( result == true )
            {
                return "Gerade Zahl";
            }
            else
            {
                return "Ungerade Zahl";
            }
        }
        public string PrimzahlResult( bool result )
        {
            if( result == true )
            {
                return "Primzahl";
            }
            else
            {
                return "Keine Primzahl";
            }
        }
        #endregion

        private string displayName = "CHECKERS";
        private string textBlockMessage;
        private string text;
    }
}
