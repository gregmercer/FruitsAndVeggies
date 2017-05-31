using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FruitsAndVeggies.Core.ViewModels
{
	public class FruitPagerViewModel : BaseViewModel
	{
		public class Parameters
		{
			public string fruitIds { get; set; }
			public string fruitsCount { get; set; }
			public string fruitId { get; set; }
		}

		public string FruitIds { get; set; }
		public string FruitsCount { get; set; }
		public string FruitId { get; set; }

		public FruitPagerViewModel()
	    {
	    }

		public void Init(Parameters parameters)
		{
			FruitIds = parameters.fruitIds;
			FruitsCount = parameters.fruitsCount;
			FruitId = parameters.fruitId;
		}

		public override async void Start()
		{
			base.Start();
		}
	}
}