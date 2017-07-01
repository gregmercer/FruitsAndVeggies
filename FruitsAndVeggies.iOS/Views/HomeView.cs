using System;
using System.Linq;
using MvvmCross.iOS.Views;
using FruitsAndVeggies.Core.ViewModels;
using UIKit;
using MvvmCross.Platform.WeakSubscription;
using MvvmCross.Core.ViewModels;
using FruitsAndVeggies.iOS.Extensions;
using FruitsAndVeggies.iOS.Tabs;

namespace FruitsAndVeggies.iOS.Views
{
	public partial class HomeView : MvxTabBarViewController<HomeViewModel>
	{
		private readonly bool _viewConstructed;

		public HomeView()
		{
			_viewConstructed = true;
			ViewDidLoad();
		}

		public override void ViewWillAppear(bool animated)
		{
			// Hide the navigation bar.
			this.HideNavigationBar();
			ViewModel.OnResume();
			ViewDidAppear(animated);
		}

		public override void ViewDidLoad()
		{
			if (!_viewConstructed)
			{
				return;
			}

			base.ViewDidLoad();

			// Create and set tabs.
			var viewControllers = new[]
			{
				CreateTabViewController<FruitsTabView>("Fruits", "FruitsTabBarIcon", 0, new FruitsViewModel()),
                CreateTabViewController<VeggiesTabView>("Veggies", "VeggiesTabBarIcon", 1, new VeggiesViewModel())
			};
			ViewControllers = viewControllers;
			SelectedViewController = ViewControllers.First();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}

		private UIViewController CreateTabViewController<T>(string title, string icon, nint index, MvxViewModel viewModel) where T : MvxViewController
		{
			// Create view controller.
			var viewController = Activator.CreateInstance(typeof(T)) as T;
			if (viewController != null)
			{
				viewController.Title = title;
				viewController.TabBarItem = new UITabBarItem(title, UIImage.FromBundle(icon), index);
				viewController.ViewModel = viewModel;

				// Create the navigation controller.
				var navigationController = new UINavigationController();

				//navigationController.NavigationItem.Title = Title;
				navigationController.PushViewController(viewController, false);

				// Set the navigation bar style.
				viewController.SetNavigationBarStyle();

				return navigationController;
			}
			return null;
		}
	}
}