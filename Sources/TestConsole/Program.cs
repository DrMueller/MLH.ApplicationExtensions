using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole
{
    public static class Program
    {
        public static void Main()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly);
            using var container = ServiceProvisioningInitializer.CreateContainer(containerConfig);
            container
                .GetInstance<IConsoleCommandsStartupService>()
                .Start();
        }
    }
}