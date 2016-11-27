namespace Comp229_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Non_Vegfood
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Non_VegfoodId { get; set; }

        [Required]
        [StringLength(50)]
        public string Non_VegfoodName { get; set; }

        [Required]
        [StringLength(250)]
        public string Non_VegfoodShortDescription { get; set; }

        [Required]
        [StringLength(500)]
        public string Non_VegfoodLongDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Non_VegfoodPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Non_VegfoodImage { get; set; }
    }
}
