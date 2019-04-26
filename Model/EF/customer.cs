namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("customer")]
    public partial class customer
    {
        public long id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public bool? gender { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(20)]
        public string phone_number { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
