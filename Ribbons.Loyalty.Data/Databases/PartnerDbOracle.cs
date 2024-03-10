using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class PartnerDbOracle : PartnerDb
    {
        public PartnerDbOracle() : base(DatabaseProvider.Oracle) { }
    }
}