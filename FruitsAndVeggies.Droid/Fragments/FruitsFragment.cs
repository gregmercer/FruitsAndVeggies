using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using FruitsAndVeggies.Core.ViewModels;
using MvvmCross.Binding.Droid.Views;
using Java.Lang;
using MvvmCross.Platform.IoC;

namespace FruitsAndVeggies.Droid.Fragments
{
	[MvxUnconventional]
	[Register("fruitsandveggies.droid.fragments.FruitsFragment")]
	public class FruitsFragment : MvxFragment<FruitsViewModel>
	{
	    private MvxListView _fruitsListView;

		public override void OnCreate(Bundle savedInstanceState)
		{
		  base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
		  this.EnsureBindingContextIsSet(savedInstanceState);
		  return this.BindingInflate(Resource.Layout.FruitsFragment, null);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
		  base.OnViewCreated(view, savedInstanceState);

		  // Get the list view.
		  _fruitsListView = view.FindViewById<MvxListView>(Resource.Id.fruits_list_view);
		}
	}
}