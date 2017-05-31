using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace FruitsAndVeggies.Core.ViewModels
{
    public class VeggiesViewModel : MvxViewModel
    {
		public class Parameters
		{
			public string veggieIds { get; set; }
			public string veggiesCount { get; set; }
			public string veggieId { get; set; }
		}

      	public ObservableCollection<VeggieViewModel> Veggies { get; set; }

        public VeggiesViewModel()
        {
            Veggies = new ObservableCollection<VeggieViewModel>();

            var veggieViewModel = new VeggieViewModel();
            veggieViewModel.Name = "Carrot";
            veggieViewModel.Init(veggieViewModel);
            Veggies.Add(veggieViewModel);

            veggieViewModel = new VeggieViewModel();
            veggieViewModel.Name = "Kale";
            veggieViewModel.Init(veggieViewModel);
            Veggies.Add(veggieViewModel);

            veggieViewModel = new VeggieViewModel();
            veggieViewModel.Name = "Onion";
            veggieViewModel.Init(veggieViewModel);
            Veggies.Add(veggieViewModel);
        }

		public ICommand ShowDetailCommand
		{
			get
			{
				return new MvxCommand<VeggieViewModel>(item =>
				{
					Debug.WriteLine($"In ShowDetailCommand");
					VeggiesViewModel.Parameters parameters = new VeggiesViewModel.Parameters();
					foreach(var veggie in Veggies) {
					    parameters.veggieIds += "," + veggie.Name;
					}
					parameters.veggieIds = parameters.veggieIds.Remove(0, 1);
					parameters.veggiesCount = Veggies.Count.ToString();
					parameters.veggieId = item.Name;
					ShowViewModel<VeggiePagerViewModel>(parameters);
				});
			}
		}
    }
}