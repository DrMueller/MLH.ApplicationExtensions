namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models
{
    public class InformationEntry
    {
        private InformationEntry(string message, bool isBusy, InformationEntryType entryType)
        {
            Message = message;
            IsBusy = isBusy;
            EntryType = entryType;
        }

        public InformationEntryType EntryType { get; }
        public bool IsBusy { get; }
        public string Message { get; }

        public static InformationEntry CreateInfo(string infoMessage, bool isBusy) => new InformationEntry(infoMessage, isBusy, InformationEntryType.Info);

        public static InformationEntry CreateSuccess(string successMessage, bool isBusy)
            => new InformationEntry(successMessage, isBusy, InformationEntryType.Success);
    }
}