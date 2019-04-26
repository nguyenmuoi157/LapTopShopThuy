namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slide")]
    public partial class slide
    {
        public int id { get; set; }

        [StringLength(100)]
        public string link { get; set; }

        [StringLength(100)]
        public string image { get; set; }
    }
}
