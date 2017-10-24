namespace Checkers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class CheckerViewModel
    {
        public ObservableCollection<string> ComboBoxContent
        {
            get;
            private set;
        }

        public CheckerViewModel()
        {
            this.checker = new List<IChecker>()
            {
                new PalindromeChecker(),new OddEvenChecker()
            };
            ComboBoxContent = new ObservableCollection<string>
            {
                "Palindrome","Test2","Test3",
            };
        }


   
        private List<IChecker> checker;
    }
}
