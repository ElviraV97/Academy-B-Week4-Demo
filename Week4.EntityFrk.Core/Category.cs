using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Week4.EntityFrk.Core
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public List<Ticket> Tickets { get; set; }   // nav prop
    }
}