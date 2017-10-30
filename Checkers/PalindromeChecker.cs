namespace Checkers
{
    using Caliburn.Micro;
    public class PalindromeChecker : IChecker
    {

        bool IChecker.Validate( string value )
        {
            string returnText = "";
            if( string.IsNullOrWhiteSpace( value ) )
            {
                return false;
            }
            else
            {
                for( int i = value.Length - 1; i >= 0; i-- )
                {
                    returnText = returnText + value[i];
                }

                if(
                    value.ToLower().Replace( " ", "" ).Replace( ".", "" ).Replace( ":", "" ).Replace( ",", "" ).Replace( ";", "" )
                    .Replace( "!", "" ).Replace( "?", "" ).Replace( "-", "" ).Replace( "_", "" )
                    ==
                    returnText.ToLower().Replace( " ", "" ).Replace( ".", "" ).Replace( ":", "" ).Replace( ",", "" ).Replace( ";", "" )
                    .Replace( "!", "" ).Replace( "?", "" ).Replace( "-", "" ).Replace( "_", "" ) )
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

