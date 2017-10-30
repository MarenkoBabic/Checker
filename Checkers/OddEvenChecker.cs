using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Checkers
{
    public class OddEvenChecker : IChecker
    {
        public bool Validate( string value )
        {
            if( !Regex.IsMatch( value, "^[0-9.]*$" ) )
            {
                MessageBox.Show( "Nur Zahlen von 0-9 eingeben" );
                return false;
            }
            else
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
}
