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
	[Register("fruitsandveggies.droid.fragments.VeggiesFragment")]
	public class VeggiesFragment : MvxFragment<VeggiesViewModel>
	{
	    private MvxListView _veggiesListView;

		public override void OnCreate(Bundle savedInstanceState)
		{
		  base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
		  this.EnsureBindingContextIsSet(savedInstanceState);
		  return this.BindingInflate(Resource.Layout.VeggiesFragment, null);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
		  base.OnViewCreated(view, savedInstanceState);

		  // Get the list view.
		  _veggiesListView = view.FindViewById<MvxListView>(Resource.Id.veggies_list_view);
		}
	}
}