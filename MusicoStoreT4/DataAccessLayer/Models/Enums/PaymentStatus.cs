namespace DataAccessLayer.Models.Enums
{
    public enum PaymentStatus
    {
        Pending = 0,      // Payment not completed yet
        Paid = 1,         // Payment successfully completed
        Failed = 2,       // Payment attempt failed
        Refunded = 3      // Payment was refunded
    }
}
