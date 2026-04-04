namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record BOQPricingRequest
    {
        public int Id;
        public int BOQId;
        public int ApplicationUserId;
        public string Title;
        public string Description;
        public string Status;
        public string UnitRate;
        public long TotalPrice;
        public DateOnly Date;
        public BOQ? bOQ;
    }
}
