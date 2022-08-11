using JetBrains.Annotations;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models
{
    [PublicAPI]
    public class InformationEntry
    {
        private InformationEntry(string message, bool isBusy, InformationEntryType entryType, int? lengthInSeconds)
        {
            Message = message;
            IsBusy = isBusy;
            EntryType = entryType;
            LengthInSeconds = lengthInSeconds;
        }

        public InformationEntryType EntryType { get; }
        public bool IsBusy { get; }
        public int? LengthInSeconds { get; }
        public string Message { get; }

        public static InformationEntry CreateEmpty()
        {
            return new InformationEntry(string.Empty, false, InformationEntryType.None, null);
        }

        public static InformationEntry CreateInfo(string infoMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(infoMessage, isBusy, InformationEntryType.Info, lengthInSeconds);
        }

        public static InformationEntry CreateSuccess(string successMessage, bool isBusy, int? lengthInSeconds = null)
        {
            return new InformationEntry(successMessage, isBusy, InformationEntryType.Success, lengthInSeconds);
        }
    }
}