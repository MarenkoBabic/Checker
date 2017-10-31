namespace Checkers
{
    using System;
    public class OddEvenChecker : ViewModelBase, IChecker
    {
        public bool Validate( string value )
        {
            int zahl;
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
            return "Odd or Even";
        }
    }
}
