namespace Integrated_Construction_Management_System_ICMS.Services.Interfaces
{
    public interface IGroqService
    {
        Task<string> AskAsync(string userMessage);
    }
}
