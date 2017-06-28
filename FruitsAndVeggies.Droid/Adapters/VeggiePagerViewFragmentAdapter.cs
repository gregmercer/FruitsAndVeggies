using System;
using System.Collections.Generic;
using System.Linq;
using Android.Support.V4.App;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.Droid.Fragments;
using FruitsAndVeggies.Droid.Views;
using System.Collections.ObjectModel;

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

			List<string> veggieIds = ViewModel.VeggieIds.Split(',').ToList();
			_fragmentInfos = new FragmentInfo[Convert.ToInt32(ViewModel.VeggiesCount)];
			int index = 0;
			foreach (var id in veggieIds)
			{
                var veggieFragment = new VeggieFragment();

                var veggieViewModel = new VeggieViewModel();
				veggieViewModel.Name = id;
				veggieViewModel.Init(veggieViewModel);

				veggieFragment.ViewModel = veggieViewModel;

				_fragmentInfos[index] = new FragmentInfo(
					$"Room {id}",
					veggieFragment,
					veggieViewModel
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