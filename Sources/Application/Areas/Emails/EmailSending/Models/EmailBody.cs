namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models
{
    public class EmailBody
    {
        public EmailBody(string content, bool isHtmlBody)
        {
            Content = content;
            IsHtmlBody = isHtmlBody;
        }

        public string Content { get; }
        public bool IsHtmlBody { get; }
    }
}