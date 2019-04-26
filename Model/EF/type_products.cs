namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class type_products
    {
        public long id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
