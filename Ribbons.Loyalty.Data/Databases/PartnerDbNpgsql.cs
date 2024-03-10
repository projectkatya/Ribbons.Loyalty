using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbNpgsql : PartnerDb
    {
        public PartnerDbNpgsql() : base(DatabaseProvider.Npgsql) { }
    }
}