namespace Checkers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;

    public class CheckerViewModel : ViewModelBase
    {
        #region propertys
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
                OnPropertyChanged( textBoxMessage );
            }
        }

        /// <summary>
        /// Property für Auswahl Comboboxitem
        /// </summary>
        public string SelectedItem
        {

            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged( "Auswahl" );
            }
        }
        /// <summary>
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
        public ObservableCollection<string> ComboBoxContent
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
                new PalindromeChecker(),new GermanChecker()
            };
            //ComboBoxItems befüllen mit strings
            ComboBoxContent = new ObservableCollection<string>
            {
                "PalindromeChecker","OddEvenChecker","GermanChecker",
            };
        }


      /// <summary>
      /// 
      /// 
      /// </summary>
        public void CheckButton()
        {
            #region If Else AuswahlCombobox
            if( SelectedItem == "PalindromeChecker" )
            {
                string resultText = "";
                PalindromeChecker palindromeChecker = new PalindromeChecker();
                if(!string.IsNullOrEmpty( Text ) )
                {
                    palindromeChecker.Result(Text,resultText);
                    textBoxMessage = resultText;
                }
                else
                {
                    palindromeChecker.CanResult();

                }
            }
            else if( selectedItem == "OddEvenChecker" )
            {
                OddEvenChecker oddEvenChecker = new OddEvenChecker();
                MessageBox.Show( "oddEvenCHecker" );
            }
            else
            {
                GermanChecker germanChecker = new GermanChecker();
                MessageBox.Show( "GermanChecker" );

            }
            #endregion

        }

        private string textBoxMessage;
        private string text;
        private string selectedItem;
        private List<IChecker> checker;
    }
}
