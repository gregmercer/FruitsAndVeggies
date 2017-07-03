﻿using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using FruitsAndVeggies.Core.ViewModels;
using UIKit;

namespace FruitsAndVeggies.iOS.Cells
{
    public partial class VeggiesTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("VeggiesTableViewCell");
        public static readonly UINib Nib;

        static VeggiesTableViewCell()
        {
            Nib = UINib.FromName("VeggiesTableViewCell", NSBundle.MainBundle);
        }

        protected VeggiesTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
            // Create and apply the binding set.
                var set = this.CreateBindingSet<VeggiesTableViewCell, VeggieViewModel>();
                set.Bind(Name).To(vm => vm.Name);
                set.Apply();
            });
        }
    }
}
