using System;
using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.iOS.Extensions;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace FruitsAndVeggies.iOS.Views
{
    public partial class VeggieView : MvxViewController, IVeggiePages
    {
        public int PageIndex { get; set; }

        public VeggieView() : base("VeggieView", null)
        {
        }

        public VeggieView(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<VeggieView, VeggieViewModel>();
            set.Bind(Name).To(vm => vm.Name);
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            // Show the navigation bar.
            //this.ShowNavigationBar();
            base.ViewWillAppear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

