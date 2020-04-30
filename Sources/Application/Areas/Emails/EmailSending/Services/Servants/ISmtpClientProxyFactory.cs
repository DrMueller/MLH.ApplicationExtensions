namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants
{
    internal interface ISmtpClientProxyFactory
    {
        ISmtpClientProxy CreateProxy();
    }
}