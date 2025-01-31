using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace THE_END_OF_C_.Models
{
    [Table("TGROUP")]
    public class TGROUP
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
