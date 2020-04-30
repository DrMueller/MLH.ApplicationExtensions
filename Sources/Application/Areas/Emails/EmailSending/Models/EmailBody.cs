namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models
{
    public class EmailBody
    {
        public string Content { get; }
        public bool IsHtmlBody { get; }

        public EmailBody(string content, bool isHtmlBody)
        {
            Content = content;
            IsHtmlBody = isHtmlBody;
        }
    }
}