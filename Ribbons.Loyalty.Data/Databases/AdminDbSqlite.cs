using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class AdminDbSqlite : AdminDb
    {
        public AdminDbSqlite() : base(DatabaseProvider.Sqlite) { }
    }
}