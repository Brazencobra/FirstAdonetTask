using Adonet.Abstraction;
using Adonet.Helper;
using Adonet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonet.Serivces
{

    internal class ArtistService : IService<Artist>
    {
        public void Add(Artist model)
        {
            Sql.ExecCommand($"Insert into Artists values (N'{model.Name}',N'{model.Surname}')");
        }

        public void Delete(int Id)
        {
            Sql.ExecCommand($"Delete Artists where Id={Id}");
        }

        public List<Artist> GetAll()
        {
            DataTable dt =  Sql.ExecQuery($"Select * from Artists");
            List<Artist> artists = new List<Artist>();
            foreach (DataRow item in dt.Rows)
            {
                artists.Add(new Artist{ Id = Convert.ToInt32(item["Id"]) , Name = item["Name"].ToString() , Surname = item["Surname"].ToString()  });
            }
            return artists;
        }
    }
}
