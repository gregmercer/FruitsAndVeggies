using System;
using System.Linq;

using FruitsAndVeggies.Core.ViewModels;
using FruitsAndVeggies.iOS.Cells;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;

using UIKit;

using MvvmCross.Platform.WeakSubscription;
using System.Collections.Generic;

namespace FruitsAndVeggies.iOS.Views
{
    public partial class VeggiePagerView : MvxViewController<VeggiePagerViewModel>
    {
        private VeggiePagerViewController _pageViewController;

        public VeggiePagerView() : base("VeggiePagerView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            List<string> veggieIds = ViewModel.VeggieIds.Split(',').ToList();

            List<IVeggiePages> pages = new List<IVeggiePages>();

            int index = 0;
            foreach (var id in veggieIds)
            {
                var viewController = Activator.CreateInstance(typeof(VeggieView)) as VeggieView;

                var veggieViewModel = new VeggieViewModel();
                veggieViewModel.Name = id;
                veggieViewModel.Init(veggieViewModel);

                viewController.Title = $"Veggie {id}";
                viewController.ViewModel = veggieViewModel;

                pages.Add(viewController);
                index++;
            }

            View = new UIView();

            _pageViewController = new VeggiePagerViewController(
                new VeggiePagerViewDataSource(pages),
                GetCurrentPosition()
            );

            View.Add(_pageViewController.View);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
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
    }
}