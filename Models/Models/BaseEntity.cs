using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public String CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public String? UpdatedBy { get; set; }

    }
}
