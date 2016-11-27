namespace Comp229_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Snack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SnacksId { get; set; }

        [Required]
        [StringLength(50)]
        public string SnacksName { get; set; }

        [Required]
        [StringLength(350)]
        public string SnacksShortDescription { get; set; }

        [Required]
        [StringLength(650)]
        public string SnacksLongDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SnacksPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string SnacksImage { get; set; }
    }
}
