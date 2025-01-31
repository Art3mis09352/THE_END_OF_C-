using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace THE_END_OF_C_.Models
{
    [Table("TRELATION")]
    [PrimaryKey(nameof(id_parent), nameof(id_child))]
    public class TRELATION
    {
        

        public long id_parent { get; set; }
        

        public long id_child { get; set; }
        
    }
}
