namespace Checkers
{
    using System;
    using System.Text.RegularExpressions;

    public class OddEvenChecker : ViewModelBase, IChecker
    {
        public bool Validate( string value )
        {
            int zahl;
            value = Regex.Replace( value, "[^0-9]+", string.Empty );
            bool result = Int32.TryParse( value, out zahl );
            if( zahl % 2 == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return "Odd or Even - Checker";
        }
    }
}
