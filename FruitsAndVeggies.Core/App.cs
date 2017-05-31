using MvvmCross.Platform.IoC;

using System.Threading.Tasks;
using System.Diagnostics;

namespace FruitsAndVeggies.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override async void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.HomeViewModel>();
        }
    }
}
