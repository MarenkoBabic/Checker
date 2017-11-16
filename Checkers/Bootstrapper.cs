namespace Checkers
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

        //protected override void Configure()
        //{
        //    container = new SimpleContainer();

        //    container.Singleton<IWindowManager, WindowManager>();

        //    container.Singleton<IShell, CheckerViewModel>();
        //    container.PerRequest<IChecker, PalindromeChecker>();
        //    container.PerRequest<IChecker, OddEvenChecker>();
        //    container.PerRequest<IChecker, PrimzahlChecker>();
        //}

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            var settings = new Dictionary<string, object>() 
            {
                {"MinHeight",500 },{"MinWidth",800 }
            };

            DisplayRootViewFor<CheckerViewModel>(settings);
        }

        //protected override object GetInstance( Type service, string key )
        //{
        //    return container.GetInstance( service, key );
        //}

        //protected override IEnumerable<object> GetAllInstances( Type service )
        //{
        //    return container.GetAllInstances( service );
        //}

        //protected override void BuildUp( object instance )
        //{
        //    container.BuildUp( instance );
        //}

        //private SimpleContainer container;
    }
}