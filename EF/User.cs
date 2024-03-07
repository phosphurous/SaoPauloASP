namespace MSSaoPauloASP.NET.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Runners = new HashSet<Runner>();
        }

        //Things I added
        [DisplayName("Email:")]
        [Required(ErrorMessage = "This field is required.")]
        //---

        [Key]
        [StringLength(100)]
        public string Email { get; set; }

        //Things I added
        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        //---

        [StringLength(100)]
        public string Password { get; set; }


        [StringLength(80)]
        public string FirstName { get; set; }

        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1)]
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Runner> Runners { get; set; }

        //Things I added
        //public string LoginErrorMessage { get; set; }

        //public override string ToString()
        //{
        //    return (FirstName + ", " + LastName);
        //}
    }
}
