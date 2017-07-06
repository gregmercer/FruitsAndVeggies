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
    public partial class FruitPagerView : MvxViewController<FruitPagerViewModel>
    {
        private FruitPagerViewController _pageViewController;

        public FruitPagerView() : base("FruitPagerView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			List<string> fruitIds = ViewModel.FruitIds.Split(',').ToList();

			List<IFruitPages> pages = new List<IFruitPages>();

			int index = 0;
			foreach (var id in fruitIds)
			{
				var viewController = Activator.CreateInstance(typeof(FruitView)) as FruitView;

				var fruitViewModel = new FruitViewModel();
				fruitViewModel.Name = id;
				fruitViewModel.Init(fruitViewModel);

				viewController.Title = $"Fruit {id}";
				viewController.ViewModel = fruitViewModel;

				pages.Add(viewController);
				index++;
			}

			View = new UIView();

			_pageViewController = new FruitPagerViewController(
				new FruitPagerViewDataSource(pages),
				GetCurrentPosition()
			);

			View.Add(_pageViewController.View);
        }

        public override void ViewWillAppear(bool animated)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        private int GetCurrentPosition()
        {
            int position = 0;

            List<string> fruitIds = ViewModel.FruitIds.Split(',').ToList();
            foreach (var id in fruitIds)
            {
                if (id == ViewModel.FruitId)
                {
                    return position;
                }
                position++;
            }

            return position;
        }
    }
}

