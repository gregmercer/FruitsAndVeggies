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
	public class FruitPagerViewFragmentsAdapter : MvxCachingFragmentPagerAdapter
	{
		public FruitPagerView View { get; }
		public FruitPagerViewModel ViewModel { get; set; }

		public ObservableCollection<string> RoomIds { get; set; }

		private readonly FragmentInfo[] _fragmentInfos;
		public override int Count => _fragmentInfos.Length;

        public FruitPagerViewFragmentsAdapter(FruitPagerView fruitPagerView)
			: base(fruitPagerView.SupportFragmentManager)
		{
			View = fruitPagerView;
			ViewModel = fruitPagerView.ViewModel;

			List<string> fruitIds = ViewModel.FruitIds.Split(',').ToList();
			_fragmentInfos = new FragmentInfo[Convert.ToInt32(ViewModel.FruitsCount)];
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
			string Title = $"Title - {ViewModel.FruitId}";
			return new Java.Lang.String(Title);
		}

	}
}

