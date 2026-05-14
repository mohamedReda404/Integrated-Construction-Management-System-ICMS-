namespace Integrated_Construction_Management_System_ICMS.Abstractions
{
    public record Error(string Code, string Descriptoin)
    {
        public static readonly Error None = new(string.Empty, string.Empty);
    }
}
