namespace Checkers.ViewModels
{
    using Caliburn.Micro;

    class ShellViewModel : Conductor<object>, IShell,IHaveDisplayName
    {
        public ShellViewModel()
        {
            DisplayName = "Checker";
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
