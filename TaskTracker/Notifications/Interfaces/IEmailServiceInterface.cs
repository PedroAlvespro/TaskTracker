namespace TaskTracker.Notifications.Interfaces
{
    public interface IEmailServiceInterface
    {
        Task SendEmailAsync(string to, string subject, string message);
    }
}
