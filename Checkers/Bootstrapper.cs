namespace Checkers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using Caliburn.Micro;

    public class Bootstrapper : BootstrapperBase
    {

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup( object sender, StartupEventArgs e )
        {
            var settings = new Dictionary<string, object>
            {
                {"SizeContent",SizeToContent.Manual },
                {"MinHeight",420 },
                {"MaxHeight",420 },
                {"MinWidth",780 },
                {"MaxWidth",780 }
            };
            DisplayRootViewFor<CheckerViewModel>(settings);
        }


    }
}
