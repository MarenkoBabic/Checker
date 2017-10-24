namespace Checkers
{
    using System.Windows;
    using System.Windows.Controls;
    using Caliburn.Micro;

    public class PalindromeChecker : PropertyChangedBase, IChecker
    {
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                NotifyOfPropertyChange( () => CanResult() );
                NotifyOfPropertyChange( () => Text );
            }
        }






        public bool Validate( string value )
        {
            return false;
        }


        public bool CanResult()
        {
            return !string.IsNullOrWhiteSpace( Text );
        }

        public string Result( string Text,string resultText )
        {
            string returnText = "";
            for( int i = Text.Length - 1; i >= 0; i-- )
            {
                returnText = returnText + Text[i];
            }

            if( Text == returnText )
            {
                resultText = Text + "ist ein Palidrome";
                return resultText;
            }
            else
            {
                MessageBox.Show( Text + " ist Kein Palidrome" );
                return text;
            }
        }


        private string text;


    }
}