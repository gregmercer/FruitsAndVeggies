using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;

using Android.Content.PM;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using FruitsAndVeggies.Droid.Adapters;
using FruitsAndVeggies.Droid.Fragments;
using FruitsAndVeggies.Core.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace FruitsAndVeggies.Droid.Views
{
	[Activity(Label = "VeggiePagerView", Theme = "@style/Theme.Light.NoActionBar",
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class VeggiePagerView : MvxAppCompatActivity<VeggiePagerViewModel>
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		protected override void OnViewModelSet()
		{
			Title = "Veggie Detail";

			SetContentView(Resource.Layout.VeggiePagerActivity);
			base.OnViewModelSet();

			// Get toolbar and set title.
			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);
			toolbar.Title = "Veggies";

			// Configure tab layout.
			var viewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
			viewPager.Adapter = new VeggiePagerViewFragmentAdapter(this);
			viewPager.CurrentItem = GetCurrentPosition();

			//var tabLayout = FindViewById<TabLayout>(Resource.Id.tab_layout);
			//tabLayout.SetupWithViewPager(viewPager);
		}

		private int GetCurrentPosition()
		{
			int position = 0;

            List<string> veggieIds = ViewModel.VeggieIds.Split(',').ToList();
			foreach (var id in veggieIds)
			{
                if (id == ViewModel.VeggieId)
				{
					return position;
				}
				position++;
			}

			return position;
		}

		protected override void OnResume()
		{
			ViewModel.OnResume();
			base.OnResume();
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					ViewModel.GoBackCommand.Execute(null);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
		}
	}
}
