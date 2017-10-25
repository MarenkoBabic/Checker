namespace Checkers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;

    public class CheckerViewModel : ViewModelBase
    {
        #region propertys

        public IChecker SelectedChecker { get; set; }


        /// <summary>
        /// ReturnWert Text für TextBox
        /// </summary>
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

        ///<summary>
        /// Property für Text
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
            }
        }

        /// <summary>
        /// Property ComboboxInhalt
        /// </summary>
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
                new PalindromeChecker(),new GermanChecker(),new OddEvenChecker()
            };
            CheckerAuswahl = checker;
        }


        /// <summary>
        /// 
        /// 
        /// </summary>
        public void CheckButton()
        {
            bool result = SelectedChecker.Validate( text );
            TextBoxMessage = result.ToString();
        }

        private string textBoxMessage;
        private string text;
        private List<IChecker> checker;
    }
}
