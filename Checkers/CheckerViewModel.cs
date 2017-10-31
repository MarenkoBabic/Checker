namespace Checkers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CheckerViewModel : ViewModelBase
    {
        #region propertys
        public IChecker SelectedChecker { get; set; }
        public string TextBoxMessage
        {
            get
            {
                return textBoxMessage;
            }
            set
            {
                textBoxMessage = value;
                OnPropertyChanged( "textBoxMessage" );
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
            // Prüft ob der Checker ausgewählt ist/ Texteingabe leer 
            if( SelectedChecker == null && string.IsNullOrEmpty( text ) )
            {
                TextBoxMessage = "Checker auswählen und text eingeben";
            }
            else if( SelectedChecker == null )
            {
                TextBoxMessage = "Checker Auswählen";
            }
            else
            {
                //läuft die Methode durch und holt sich den wert zurück
                if( SelectedChecker == checker[0] )
                {
                    if( text == null || text.Trim() == "" )
                    {
                        TextBoxMessage = " Text eingeben";
                    }
                    else
                    {
                        bool result = SelectedChecker.Validate( text );
                        TextBoxMessage = PalindromeResult( result );
                    }
                }
                //Trägt in der TextBox ein ob der Check richtig / falsch ist
                else if( SelectedChecker == checker[1] )
                {
                    if( text == null || text == "" )
                    {
                        TextBoxMessage = " Zahl eingeben";
                    }
                    else
                    {
                        text = Regex.Replace( text, "[^0-9]+", string.Empty );
                        bool result = SelectedChecker.Validate( text );
                        TextBoxMessage = OddEvenResult( result );
                    }
                }
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
            if( text == null || text == "" )
            {
                text = "0";
            }
            if( result == true )
            {
                return text + " ist eine gerade Zahl";
            }
            else
            {
                return text + " ist eine ungerade Zahl";
            }
        }

        private string textBoxMessage;
        private string text;
        private List<IChecker> checker;
    }
}
