using System;
using System.Text.RegularExpressions;

namespace Checkers
{
    class OddEvenChecker : IChecker
    {
        public bool Validate( string value )
        {

            double zahl = Convert.ToDouble( value );

            if( zahl % 2 == 0 )
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
