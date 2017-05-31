using Android.Support.V4.App;
using Java.Lang;
using MvvmCross.Droid.Support.V4;
using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.Droid.Fragments;
using FruitsAndVeggies.Droid.Views;
using System.Linq;

namespace FruitsAndVeggies.Droid.Adapters
{
    public class HomeViewFragmentsAdapter : MvxCachingFragmentPagerAdapter
    {
    public HomeView View { get; }

    private readonly FragmentInfo[] _fragmentInfos;
    public override int Count => _fragmentInfos.Length;

    public HomeViewFragmentsAdapter(HomeView homeView)
            : base(homeView.SupportFragmentManager)
        {
      View = homeView;
      _fragmentInfos = new[]
      {
                new FragmentInfo("Fruits", new FruitsFragment(), new FruitsViewModel()),
                new FragmentInfo("Veggies", new VeggiesFragment(), new VeggiesViewModel()),
      };

            // Set view model for each fragment.
            foreach (var fi in _fragmentInfos.Select(i => i))
      {
                fi.Fragment.ViewModel = fi.ViewModel;
      }
    }

    public override Fragment GetItem(int position, Fragment.SavedState fragmentSavedState = null)
    {
      return _fragmentInfos[position].Fragment;
    }

    public override ICharSequence GetPageTitleFormatted(int position)
    {
      return new String(_fragmentInfos[position].Title);
    }

  }
}
