namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public long id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [Column(TypeName = "text")]
        public string content { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        public DateTime? create_at { get; set; }

        public DateTime? update_at { get; set; }
    }
}
