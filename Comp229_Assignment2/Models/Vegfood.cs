namespace Comp229_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vegfood")]
    public partial class Vegfood
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VegfoodId { get; set; }

        [Required]
        [StringLength(50)]
        public string VegfoodName { get; set; }

        [Required]
        [StringLength(150)]
        public string VegfoodShortDescription { get; set; }

        [Required]
        [StringLength(250)]
        public string VegfoodLongDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal VegfoodPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string VegfoodImage { get; set; }
    }
}
