using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FruitsAndVeggies.Core.ViewModels
{
	public class VeggiePagerViewModel : BaseViewModel
	{
		public class Parameters
		{
			public string veggieIds { get; set; }
			public string veggiesCount { get; set; }
			public string veggieId { get; set; }
		}

		public string VeggieIds { get; set; }
		public string VeggiesCount { get; set; }
		public string VeggieId { get; set; }

		public VeggiePagerViewModel()
	    {
	    }

		public void Init(Parameters parameters)
		{
			VeggieIds = parameters.veggieIds;
			VeggiesCount = parameters.veggiesCount;
			VeggieId = parameters.veggieId;
		}

		public override async void Start()
		{
			base.Start();
		}
	}
}