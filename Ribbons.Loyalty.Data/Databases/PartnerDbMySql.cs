using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbMySql : PartnerDb
    {
        public PartnerDbMySql() : base(DatabaseProvider.MySql) { }
    }
}