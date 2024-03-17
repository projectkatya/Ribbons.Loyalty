namespace Ribbons.Loyalty.Services.Partners.Models
{
    public enum CreatePartnerStatus
    {
        Ok,
        InvalidRequest,
        DbServerNotFound,
        AccountNumberTaken,
        AliasTaken,
        Error
    }
}