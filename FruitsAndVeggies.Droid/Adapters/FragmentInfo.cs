using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;

namespace FruitsAndVeggies.Droid.Adapters
{
    public class FragmentInfo
    {
        public string Title { get; set; }
        public MvxFragment Fragment { get; set; }
        public MvxViewModel ViewModel { get; set; }

        public FragmentInfo(string title, MvxFragment fragment, MvxViewModel viewModel)
        {
            Title = title;
            Fragment = fragment;
            ViewModel = viewModel;
        }
    }
}