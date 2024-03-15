using System.Text.RegularExpressions;

namespace Ribbons.Loyalty.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex("^[a-zA-Z0-9._]+$");

            List<string> userNames = ["shawninvento", "ShawnInvento", "shawn.invento", "shawn_invento", "shawn@invento"];

            foreach (string userName in userNames)
            {
                Console.WriteLine(regex.IsMatch(userName));
            }
        }
    }
}
