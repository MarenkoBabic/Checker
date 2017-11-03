namespace Checkers
{
    using System.Text.RegularExpressions;
    public class PalindromeChecker : IChecker
    {
        bool IChecker.Validate(string value )
        {
            try
            {
                string tempText = "";
                value = Regex.Replace( value.ToLower(), "[^a-zA-z]+", string.Empty );
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
                    if( value == tempText )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

