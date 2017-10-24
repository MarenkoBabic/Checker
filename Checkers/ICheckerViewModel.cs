namespace Checkers
{
    /// <summary>
    /// Interface für StringValidierungen
    /// </summary>
    public interface IChecker
    {


        /// <summary>
        /// Validiert einen String und liefert das Ergebnis als bool
        /// </summary>
        /// <param name="value">Der zu überprüfende Wert</param>
        /// <returns>Das Ergebnis des Checks</returns>
        bool Validate( string value );
    }
}
