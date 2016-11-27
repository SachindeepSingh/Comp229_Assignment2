namespace Comp229_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dessert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DessertsId { get; set; }

        [Required]
        [StringLength(50)]
        public string DessertsName { get; set; }

        [Required]
        [StringLength(350)]
        public string DessertsShortDescription { get; set; }

        [Required]
        [StringLength(650)]
        public string DessertsLongDescription { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DessertsPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string DessertsImage { get; set; }
    }
}
