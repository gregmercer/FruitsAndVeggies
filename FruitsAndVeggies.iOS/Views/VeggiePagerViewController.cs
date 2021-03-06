﻿using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using UIKit;

namespace FruitsAndVeggies.iOS.Views
{
    public partial class VeggiePagerViewController : UIPageViewController
    {
        public VeggiePagerViewController(VeggiePagerViewDataSource dataSource, int index)
            : base(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal)
        {
            DataSource = dataSource;
            SetViewControllers(
                new[] { dataSource.Pages.ElementAt(index) as UIViewController },
                UIPageViewControllerNavigationDirection.Forward,
                false,
                null
            );
        }
    }

    public class VeggiePagerViewDataSource : UIPageViewControllerDataSource
    {
        private readonly List<IVeggiePages> _pages;

        public VeggiePagerViewDataSource(List<IVeggiePages> pages)
        {
            if (pages == null)
            {
                throw new ArgumentNullException(nameof(pages));
            }
            if (!pages.Any())
            {
                throw new ArgumentException("pages cannot be empty.", nameof(pages));
            }

            if (pages.Any(s => !(s is UIViewController)))
            {
                throw new ArgumentException("all pages must be a UIViewController", nameof(pages));
            }

            _pages = pages;

            for (int index = 0; index < _pages.Count; index++)
            {
                var page = _pages[index];
                page.PageIndex = index;
            }
        }

        public List<IVeggiePages> Pages => _pages;

        public override UIViewController GetPreviousViewController(UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            var page = referenceViewController as IVeggiePages;
            if (page == null)
            {
                return null;
            }

            var index = _pages.IndexOf(page);
            if (index <= 0)
            {
                return null;
            }

            return _pages[index - 1] as UIViewController;
        }

        public override UIViewController GetNextViewController(UIPageViewController pageViewController,
            UIViewController referenceViewController)
        {
            var page = referenceViewController as IVeggiePages;
            if (page == null)
            {
                return null;
            }
            var index = _pages.IndexOf(page);
            if (index + 1 == _pages.Count)
            {
                return null;
            }

            return _pages[(page.PageIndex + 1)] as UIViewController;
        }
    }

    public interface IVeggiePages : IDisposable
    {
        int PageIndex { get; set; }
    }
}

