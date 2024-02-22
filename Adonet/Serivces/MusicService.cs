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
    internal class MusicService : IService<Music>
    {
        public void Add(Music model)
        {
            Sql.ExecCommand($"Insert into Musics values (N'{model.Name}',N'{model.Duration}')");
        }

        public void Delete(int Id)
        {
            Sql.ExecCommand($"Delete Musics where Id={Id}");
        }

        public List<Music> GetAll()
        {
            DataTable dt = Sql.ExecQuery("Select * from Musics");
            List<Music> list = new List<Music>();
            foreach (DataRow dr in dt.Rows) 
            {
                list.Add(new Music { Id = Convert.ToInt32(dr["Id"]) ,Name = dr["Name"].ToString() , Duration = Convert.ToInt32(dr["Duration"]) });
            }
            return list;

        }
    }
}
