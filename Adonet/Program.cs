using Adonet.Helper;
using Adonet.Models;
using Adonet.Serivces;
using Microsoft.Data.SqlClient;

namespace Adonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sql.ExecCommand("INSERT INTO Artists VALUES (N'Mehmet',N'Gureli')");
            ArtistService artistService = new ArtistService();
            //Artist artist1 = new Artist { Name = "Ilham", Surname = "Mikayilov" };
            //artistService.Add(artist1);
            foreach (Artist item in artistService.GetAll())
            {
                Console.WriteLine(item);
            }
            //artistService.Delete(2);
        }
    }
}