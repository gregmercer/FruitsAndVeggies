using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;

using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;
using FruitsAndVeggies.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace FruitsAndVeggies.Droid.Views
{
    [Activity(Label = "VeggiesView")]
    public class VeggiesView : MvxAppCompatActivity<VeggiesViewModel>
    {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetContentView(Resource.Layout.fruits_view);

      var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
      SetSupportActionBar(toolbar);

      var recyclerView = FindViewById<MvxRecyclerView>(Resource.Id.recycler_view);
      recyclerView.SetLayoutManager(new LinearLayoutManager(this));
    }
    }
}