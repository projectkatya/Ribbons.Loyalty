using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class AdminDbNpgsql : AdminDb
    {
        public AdminDbNpgsql() : base(DatabaseProvider.Npgsql) { }
    }
}