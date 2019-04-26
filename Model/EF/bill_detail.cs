namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_detail
    {
        public long id { get; set; }

        public int? id_bill { get; set; }

        public int? id_product { get; set; }

        public int? quantity { get; set; }

        public float? unit_price { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
