using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NAME_REPLACE.Entities
{
    [Table("X")]
    public class Sample
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public bool FLAG { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{{ 'ID': {0}, 'NAME': {1}, 'FLAG': {2} }}",
                ID, NAME, FLAG
            );
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ID.Equals(obj);
        }
    }
}
