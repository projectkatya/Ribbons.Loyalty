using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbMsSql : PartnerDb
    {
        public PartnerDbMsSql() : base(DatabaseProvider.MsSql) { }
    }
}