using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal class Videogame
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long SoftwareHouseId { get; set; }

        public Videogame(long _id, string _name, string _description, DateTime _releaseDate, long _sfotwareHouseId) 
        {
            Id = _id;
            Name = _name;
            Description = _description;
            ReleaseDate = _releaseDate;
            SoftwareHouseId = _sfotwareHouseId;
        }
    }
}
