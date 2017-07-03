using System;
using System.Linq;

using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.iOS.Cells;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

using UIKit;

using MvvmCross.Platform.WeakSubscription;

namespace FruitsAndVeggies.iOS.Tabs
{
    public partial class VeggiesTabView : MvxViewController
    {
        public VeggiesTabView() : base("VeggiesTabView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create the table view source.
            var source = new MvxSimpleTableViewSource(TableView, VeggiesTableViewCell.Key, VeggiesTableViewCell.Key);

            // Create and apply the binding set.
            var set = this.CreateBindingSet<VeggiesTabView, VeggiesViewModel>();
            set.Bind(source).To(vm => vm.Veggies);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ShowDetailCommand);
            set.Apply();

            // Set the table view source and refresh.
            TableView.Source = source;
            TableView.RowHeight = 60;
            TableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

