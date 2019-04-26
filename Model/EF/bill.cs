namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill
    {
        public long id { get; set; }

        public long? id_customer { get; set; }

        public DateTime? date_order { get; set; }

        public float? total { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
