using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace rezokoKanriApp.Models
{
    public class StorageLocation
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }

        // [DataType(DataType.Date)]
        // public DateTime ReleaseDate { get; set; }

        // [DataType(DataType.Date)]
        // public DateTime StartDate { get; set; }

        public string Sublocation { get; set; }
    }
}
