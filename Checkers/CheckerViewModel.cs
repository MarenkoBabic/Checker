namespace Checkers
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Windows;
    using System.Windows.Controls;
    using Caliburn.Micro;

    public class CheckerViewModel : ViewModelBase, IHaveDisplayName
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
        public IChecker SelectedChecker { get; set; }
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
            }
        }
        public List<IChecker> CheckerAuswahl
        {
            get;
            private set;
        }

        #endregion
        public CheckerViewModel()
        {
            //List<IChecker> befüllen mit Klassen
            this.checker = new List<IChecker>()
            {
                new PalindromeChecker(),new OddEvenChecker()
            };
            CheckerAuswahl = checker;

        }


        /// <summary>
        /// Funktion beim betätigen vom Button 
        /// </summary>
        public void CheckButton()
        {
            // Prüft ob Checker ausgewählt ist
            if( SelectedChecker != null )
            {
                // Prüft ob Text vorhanden ist
                if( !string.IsNullOrWhiteSpace( text ) )
                {
                    //Prüft welche Checker ausgewählt ist
                    if( SelectedChecker is PalindromeChecker )
                    {
                        bool result = SelectedChecker.Validate( text );
                        TextBlockMessage = PalindromeResult( result );
                    }
                    else if( SelectedChecker is OddEvenChecker )
                    {
                        bool result = SelectedChecker.Validate( text );
                        TextBlockMessage = OddEvenResult( result );
                    }
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
        public string PalindromeResult( bool result )
        {
            if( result == true )
            {
                return text + "\nist ein Palindrome";
            }
            else
            {
                return text + "\nist kein Palindrome";
            }
        }
        public string OddEvenResult( bool result )
        {
            if( result == true )
            {
                return text + " ist eine gerade Zahl";
            }
            else
            {
                return text + " ist eine ungerade Zahl";
            }
        }


        private string displayName = "Checkers";
        private string textBlockMessage;
        private string text;
        private List<IChecker> checker;
    }
}
