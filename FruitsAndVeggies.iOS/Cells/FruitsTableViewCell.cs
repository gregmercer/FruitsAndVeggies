using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using FruitsAndVeggies.Core.ViewModels;
using UIKit;

namespace FruitsAndVeggies.iOS.Cells
{
    public partial class FruitsTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("FruitsTableViewCell");
        public static readonly UINib Nib;

        static FruitsTableViewCell()
        {
            Nib = UINib.FromName("FruitsTableViewCell", NSBundle.MainBundle);
        }

        protected FruitsTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
            // Create and apply the binding set.
                var set = this.CreateBindingSet<FruitsTableViewCell, FruitViewModel>();
                set.Bind(Name).To(vm => vm.Name);
                set.Apply();
            });
        }
    }
}
