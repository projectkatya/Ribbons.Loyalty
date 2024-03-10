using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbSqlite : PartnerDb
    {
        public PartnerDbSqlite() : base(DatabaseProvider.Sqlite) { }
    }
}