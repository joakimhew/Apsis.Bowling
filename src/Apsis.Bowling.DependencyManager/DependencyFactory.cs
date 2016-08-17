using Apsis.Bowling.Service;
using Ninject;

namespace Apsis.Bowling.DependencyManager
{
    public class DependencyFactory
    {
        private readonly IKernel _kernel;

        public DependencyFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void RegisterAll()
        {
            _kernel.Bind<IGame>().To<Game>().WithConstructorArgument("numberOfFrames", 10);
            _kernel.Bind<IGameHandler>().To<GameHandler>();
        }
    }
}