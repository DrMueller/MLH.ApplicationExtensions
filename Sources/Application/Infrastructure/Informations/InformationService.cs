using System.Diagnostics;

namespace Mmu.Mlh.ApplicationExtensions.Infrastructure.Informations
{
    internal static class InformationService
    {
        internal static void DebugMessage(string message)
        {
            Debug.WriteLine(message);
        }
    }
}