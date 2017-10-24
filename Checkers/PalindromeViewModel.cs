namespace Checkers
{
    using Caliburn.Micro;
    public class PalindromViewModel : PropertyChangedBase, IChecker
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

        public bool CanResult()
        {
            return !string.IsNullOrWhiteSpace( Text );
        }

        public string Result( string Text )
        {
            string returnText = "";
            for( int i = Text.Length - 1; i >= 0; i-- )
            {
                returnText = returnText + Text[i];
            }

            if( Text == returnText )
            {
                return Text + " ist ein Palindrome ";
            }
            else
            {
                return Text + " ist kein Palindrome ";
            }
        }

        public bool Validate( string value )
        {
            throw new System.NotImplementedException();
        }

        private string text;

    }
}



