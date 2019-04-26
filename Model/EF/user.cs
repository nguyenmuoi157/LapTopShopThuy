namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        public long id { get; set; }

        [StringLength(255)]
        public string username { get; set; }

        [StringLength(255)]
        public string full_name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int RoleID { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}
