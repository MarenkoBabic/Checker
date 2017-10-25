namespace Checkers
{
    using Caliburn.Micro;
    public class PalindromeChecker : IChecker
    {

        bool IChecker.Validate( string value )
        {
            string returnText = "";

            for( int i = value.Length - 1; i >= 0; i-- )
            {
                returnText = returnText + value[i];
            }

            if( value == returnText )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}