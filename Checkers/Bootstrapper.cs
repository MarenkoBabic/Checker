﻿namespace Checkers
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Caliburn.Micro;
    using Checkers.ViewModels;

    public class Bootstrapper : BootstrapperBase
    {
        public List<IChecker> ListChecker { get; set; }
        public Bootstrapper()
        {
            Initialize();
            ListChecker = new List<IChecker> { new PalindromeChecker(), new OddEvenChecker(), new PrimzahlChecker() };
        }

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            var settings = new Dictionary<string, object>()
            {
                {"Height",500 },{"Width",800 }
            };

            DisplayRootViewFor<ShellViewModel>( settings );
        }

    }
}