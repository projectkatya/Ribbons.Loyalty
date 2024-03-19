namespace Ribbons.Loyalty.Services.Partners.Models
{
    public enum CreatePartnerStatus
    {
        Ok,
        PartnerInvalid,
        RootUserInvalid,
        DbServerNotFound,
        AccountNumberTaken,
        AliasTaken,
        Error
    }
}