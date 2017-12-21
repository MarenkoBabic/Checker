namespace Checkers.ViewModels
{
    using Caliburn.Micro;
    using System.Text.RegularExpressions;
    public class PalindromeChecker : IChecker
    {
        /// <summary>
        /// Prüft ob Text ein palidrom ist
        /// </summary>
        /// <param name="value">Texteingabe</param>
        /// <returns>Boolwert</returns>
        bool IChecker.Validate( string value )
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

        public override string ToString()
        {
            return "Palindrome - Checker";
        }
    }
}

