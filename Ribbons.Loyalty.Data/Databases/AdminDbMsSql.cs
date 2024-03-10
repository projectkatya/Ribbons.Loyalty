using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class AdminDbMsSql : AdminDb
    {
        public AdminDbMsSql() : base(DatabaseProvider.MsSql) { }
    }
}