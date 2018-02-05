namespace Checkers.ViewModels
{
    using Caliburn.Micro;

    class ShellViewModel : Conductor<object>, IShell
    {
        public ShellViewModel()
        {

        }
        public void Checker()
        {
            ActivateItem( new CheckerViewModel() );
        }
        public void PersonRandom()
        {
            ActivateItem( new PersonRandomViewModel() );
        }
        public void PersonInput()
        {
            ActivateItem( new PersonInputViewModel() );
        }

    }
}
