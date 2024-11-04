using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CustomAuthBlazor.Models
{
    public class UserDetails
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salary { get; set; }

    }
}
