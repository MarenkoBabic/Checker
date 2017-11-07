
namespace Checkers
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using Checkers.ViewModels;
    public class Bootstrapper : BootstrapperBase
    {


        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShell, CheckerViewModel>();
            container.PerRequest<PalindromeChecker, PalindromeChecker>();
        }

        protected override object GetInstance( Type service, string key )
        {
            object instance = container.GetInstance( service, key );
            if( instance != null )
                return instance;

            throw new InvalidOperationException( "Could not locate any instances." );
        }

        protected override IEnumerable<object> GetAllInstances( Type service )
        {
            return container.GetAllInstances( service );
        }

        protected override void BuildUp( object instance )
        {
            container.BuildUp( instance );
        }

        protected override void OnStartup( object sender, System.Windows.StartupEventArgs e )
        {
            Dictionary<string, object> settings = new Dictionary<string, object> { { "MinHeight", 800 }, { "MinWidth", 720 } };
            DisplayRootViewFor<IShell>(settings);
        }

        private SimpleContainer container;
    }
}