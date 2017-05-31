using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using FruitsAndVeggies.Core.ViewModels;
using MvvmCross.Binding.Droid.Views;
using Java.Lang;
using MvvmCross.Platform.IoC;
using Android.Support.V7.Widget;
using Android.Support.V7.App;

namespace FruitsAndVeggies.Droid.Fragments
{
	[MvxUnconventional]
	[Register("fruitsandveggies.droid.fragments.FruitFragment")]
	public class FruitFragment : MvxFragment<FruitViewModel>
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.EnsureBindingContextIsSet(savedInstanceState);

			//View rootView = inflater.inflate(Resource.Id.toolbar, container, false);

			return this.BindingInflate(Resource.Layout.FruitFragment, null);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);

			var toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);

			//SetSupportActionBar(toolbar);
			//SupportActionBar.SetDisplayHomeAsUpEnabled(true);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					ViewModel.CancelCommand.Execute(null);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
	}
}

