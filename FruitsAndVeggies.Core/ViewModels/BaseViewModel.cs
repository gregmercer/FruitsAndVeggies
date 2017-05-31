using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace FruitsAndVeggies.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected bool _isLoading;

	    public bool IsLoading
	    {
	      get { return _isLoading; }
	      set
	      {
	        _isLoading = value;
	        RaisePropertyChanged(() => IsLoading);
	      }
	    }

	    public ICommand GoBackCommand => new MvxCommand(() => Close(this));

	    public virtual void OnResume()
	    {
	      RaiseAllPropertiesChanged();
	    }
    }
}