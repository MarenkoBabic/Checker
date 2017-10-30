namespace Checkers
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;

    public class OddEvenChecker : IChecker
    {
        public bool Validate( string value )
        {
            if( string.IsNullOrWhiteSpace( value ) )
            {
                MessageBox.Show( "Zahl eingeben" );
                return false;
            }
            else
            {
                if( !Regex.IsMatch( value, "^[0-9]*$" ) )
                {
                    MessageBox.Show( "Nur Zahlen von 0-9 eingeben" );
                    return false;
                }
                else
                {
                    int zahl = Convert.ToInt32( value );
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
}
