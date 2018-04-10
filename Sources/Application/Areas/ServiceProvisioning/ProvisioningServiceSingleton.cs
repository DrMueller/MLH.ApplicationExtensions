namespace Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning
{
    public static class ProvisioningServiceSingleton
    {
        public static IProvisioningService Instance { get; private set; }

        internal static void Initialize(IProvisioningService instance)
        {
            Instance = instance;
        }
    }
}