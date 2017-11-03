namespace Checkers
{
    using System.Text.RegularExpressions;
    public class PalindromeChecker : IChecker
    {
        bool IChecker.Validate( string value )
        {
            try
            {
                string tempText = "";
                value = Regex.Replace( value, "[^a-zA-Z]+", string.Empty );
                if( string.IsNullOrWhiteSpace( value ) )
                {
                    return false;
                }
                else
                {
                    for( int i = value.Length - 1; i >= 0; i-- )
                    {
                        tempText = tempText + value[i];
                    }
                    return string.Equals( value, tempText, System.StringComparison.OrdinalIgnoreCase );
                }
            }
            catch( System.Exception )
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Palindrome - Checker";
        }
    }
}

