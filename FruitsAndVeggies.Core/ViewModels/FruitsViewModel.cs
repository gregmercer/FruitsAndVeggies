using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace FruitsAndVeggies.Core.ViewModels
{
    public class FruitsViewModel : MvxViewModel
    {
		public class Parameters
		{
			public string fruitIds { get; set; }
			public string fruitsCount { get; set; }
			public string fruitId { get; set; }
		}

    	public ObservableCollection<FruitViewModel> Fruits { get; set; }

        public FruitsViewModel()
        {
            Fruits = new ObservableCollection<FruitViewModel>();

			var fruitViewModel = new FruitViewModel();
			fruitViewModel.Name = "Apple";
			fruitViewModel.Init(fruitViewModel);
			Fruits.Add(fruitViewModel);

			fruitViewModel = new FruitViewModel();
			fruitViewModel.Name = "Bannana";
			fruitViewModel.Init(fruitViewModel);
			Fruits.Add(fruitViewModel);

			fruitViewModel = new FruitViewModel();
			fruitViewModel.Name = "Pear";
			fruitViewModel.Init(fruitViewModel);
			Fruits.Add(fruitViewModel);
        }

		public ICommand ShowDetailCommand
		{
			get
			{
				return new MvxCommand<FruitViewModel>(item =>
				{
					Debug.WriteLine($"In ShowDetailCommand");
					FruitsViewModel.Parameters parameters = new FruitsViewModel.Parameters();
					foreach(var fruit in Fruits) {
					    parameters.fruitIds += "," + fruit.Name;
					}
					parameters.fruitIds = parameters.fruitIds.Remove(0, 1);
					parameters.fruitsCount = Fruits.Count.ToString();
					parameters.fruitId = item.Name;
					ShowViewModel<FruitPagerViewModel>(parameters);
				});
			}
		}
    }
}