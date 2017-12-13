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
        //    container.Singleton<IEventAggregator, EventAggregator>();

        //    container.Singleton<IShell, ShellViewModel>();
        //}

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            //var settings = new Dictionary<string, object>()
            //{
            //    {"MinHeight",800 },{"MinWidth",1000 }
            //};

            DisplayRootViewFor<ShellViewModel>();
        }

        //protected override object GetInstance( Type service, string key )
        //{
        //    var instance = container.GetInstance( service, key );
        //    if( instance != null )
        //        return instance;

        //    throw new Exception( "Could not locate any instances." );
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