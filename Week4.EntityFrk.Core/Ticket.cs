using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week4.EntityFrk.Core
{
    // POCO - Plain Old C# Object
    //[Table("Biglietti")]
    public class Ticket
    {
        //[Key]
        public int Id { get; set; }

        //[MaxLength(100)]
        //[MinLength(10)]
        //[Required]
        public string Title { get; set; }
        public string Description { get; set; }

        //public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
