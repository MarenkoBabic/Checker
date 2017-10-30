namespace Checkers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text.RegularExpressions;
    using System.Windows;

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
            if( SelectedChecker == null )
            {
                MessageBox.Show( "Checker Auswählen" );
            }
            //läuft die Methode durch und holt sich den wert zurück
            bool result = SelectedChecker.Validate( text );
            // Trägt in der TextBox ein ob der Check richtig / falsch ist
            TextBoxMessage = result.ToString();
        }

        private string textBoxMessage;
        private string text;
        private List<IChecker> checker;
    }
}
