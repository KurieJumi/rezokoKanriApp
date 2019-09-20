using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace rezokoKanriApp.Models
{
    public class StoredItemsClass
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string LocationName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }

    }
}
