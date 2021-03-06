﻿using System;

namespace Checkers.ViewModels
{
    public class PrimzahlChecker : ViewModelBase, IChecker
    {
        /// <summary>
        /// Prüft ob Eingabe eine Primzahl ist
        /// </summary>
        /// <param name="value">Texteingabe</param>
        /// <returns>Boolwert</returns>
        bool IChecker.Validate(string value)
        {
            if( value != null )
            {
                bool result = double.TryParse( value, out zahl );
                if( zahl % 2 != 0 )
                {
                    for( int i = 3; i < Math.Sqrt(zahl); i += 2 )
                    {
                        if( zahl % i == 0 )
                        {
                            return false;
                        }
                    }
                    return true;

                }
            }
            return false;
        }
        public override string ToString()
        {
            return "Primzahl - Checker";
        }
        private double zahl;

    }
}

