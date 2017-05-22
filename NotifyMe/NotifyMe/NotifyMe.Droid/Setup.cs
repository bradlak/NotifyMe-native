using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using NotifyMe.Core;
using NotifyMe.Core.Infrastructure;
using MvvmCross.Plugins.Visibility;
using System.Linq;

namespace NotifyMe.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.RegisterType<ILoginService, LoginService>();
        }

        public override void LoadPlugins(MvvmCross.Platform.Plugins.IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvxVisibilityValueConverter>();
            base.LoadPlugins(pluginManager);
        }

        protected override System.Collections.Generic.IEnumerable<System.Reflection.Assembly> ValueConverterAssemblies
        {
            get
            {
                var result = base.ValueConverterAssemblies.ToList();
                result.Add(typeof(MvxVisibilityValueConverter).Assembly);
                return result;
            }
        }
    }
}
