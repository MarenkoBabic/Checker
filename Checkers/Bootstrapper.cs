namespace Checkers
{
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
            DisplayRootViewFor<CheckerViewModel>();
        }
    }
}
