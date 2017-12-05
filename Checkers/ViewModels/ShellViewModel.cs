using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Checkers.ViewModels
{
    class ShellViewModel: Conductor<object>,IShell
    {
        public ShellViewModel()
        {
            
        }
        public void Checker()
        {
           ActivateItem( new CheckerViewModel() );
        }
        public void PersonGenerator()
        {
            ActivateItem( new PersonGeneratorViewModel() );
        }

    }
}
