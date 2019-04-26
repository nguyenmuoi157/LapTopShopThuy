namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product
    {
        public long id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? id_type { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public float? unit_price { get; set; }

        public double? promotion_price { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public bool isSale { get; set; } = false;

        public long? viewCount { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
