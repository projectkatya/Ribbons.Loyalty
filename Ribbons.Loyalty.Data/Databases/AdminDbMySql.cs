using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class AdminDbMySql : AdminDb
    {
        public AdminDbMySql() : base(DatabaseProvider.MySql) { }
    }
}