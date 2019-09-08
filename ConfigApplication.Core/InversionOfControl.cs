using Ninject;
using Ninject.Modules;

namespace ConfigApplication
{
    public class InversionOfControl
    {
        private static IReadOnlyKernel _kernel;
        internal static IReadOnlyKernel Kernel {
            get
            {
                if(_kernel is null) { InitializeKernel(); }
                return _kernel;
            }
        }

        private static void InitializeKernel()
            => _kernel = new KernelConfiguration(new InjectionModule()).BuildReadonlyKernel();
    }

    internal class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfig>().To<Config>().InSingletonScope();
        }
    }
}