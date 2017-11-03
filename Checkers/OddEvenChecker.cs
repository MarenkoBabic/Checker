namespace Checkers
{
    using System;
    using System.Text.RegularExpressions;

    public class OddEvenChecker : ViewModelBase, IChecker
    {
        public bool Validate( string value )
        {
            if( value != null)
            {
                bool result = Int32.TryParse( value, out zahl );
                if( zahl % 2 == 0 )
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            return "Odd or Even - Checker";
        }
        private int zahl;
    }
}
