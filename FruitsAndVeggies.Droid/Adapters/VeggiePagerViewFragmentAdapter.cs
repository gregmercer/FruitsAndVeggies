using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.Droid.Fragments;
using FruitsAndVeggies.Droid.Views;
using System.Linq;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace FruitsAndVeggies.Droid.Adapters
{
	public class VeggiePagerViewFragmentAdapter : MvxCachingFragmentPagerAdapter
	{
        public VeggiePagerView View { get; }
		public VeggiePagerViewModel ViewModel { get; set; }

		private readonly FragmentInfo[] _fragmentInfos;
		public override int Count => _fragmentInfos.Length;

		public VeggiePagerViewFragmentAdapter(VeggiePagerView veggiePagerView)
			: base(veggiePagerView.SupportFragmentManager)
		{
			View = veggiePagerView;
			ViewModel = veggiePagerView.ViewModel;

			List<string> fruitIds = ViewModel.VeggieIds.Split(',').ToList();
			_fragmentInfos = new FragmentInfo[Convert.ToInt32(ViewModel.VeggiesCount)];
			int index = 0;
			foreach (var id in fruitIds)
			{
				var fruitFragment = new FruitFragment();

				var fruitViewModel = new FruitViewModel();
				fruitViewModel.Name = id;
				fruitViewModel.Init(fruitViewModel);

				fruitFragment.ViewModel = fruitViewModel;

				_fragmentInfos[index] = new FragmentInfo(
					$"Room {id}",
					fruitFragment,
					fruitViewModel
				);
				index++;
			}
		}

		public override Fragment GetItem(int position, Fragment.SavedState fragmentSavedState = null)
		{
			return _fragmentInfos[position].Fragment;
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
            string Title = $"Title - {ViewModel.VeggieId}";
			return new Java.Lang.String(Title);
		}

	}
}