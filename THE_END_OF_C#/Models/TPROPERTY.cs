using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace THE_END_OF_C_.Models
{
    [Table("TPROPERTY")]
    public class TPROPERTY
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id_prop")]
        public long id_prop { get; set; }
        public string prop_name { get; set; }
        public string value { get; set; }

        [ForeignKey("TGROUP")]
        public long group_id { get; set; }
        public TGROUP TGROUP { get; set; }




    }
}
