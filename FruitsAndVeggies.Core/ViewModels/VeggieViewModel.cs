using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace FruitsAndVeggies.Core.ViewModels
{
    public class VeggieViewModel : MvxViewModel
    {
        public VeggieViewModel()
        {
            CancelCommand = new MvxCommand(Cancel);
        }

		public void Init(VeggieViewModel veggie)
		{
			Name = veggie.Name;
		}

	    private void Cancel()
	    {
	    	Close(this);
	    }

        public ICommand CancelCommand { get; }

		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				if (Name == value) return;
				_name = value;
				RaisePropertyChanged();
			}
		}
    }
}