using Ribbons.Data;

namespace Ribbons.Loyalty.Data.Databases
{
    public sealed class AdminDbOracle : AdminDb
    {
        public AdminDbOracle() : base(DatabaseProvider.Oracle) { }
    }
}