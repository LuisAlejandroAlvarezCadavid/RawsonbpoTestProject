using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RawsonbpoTestProject.Repository.DataModel
{
    
    public class UserInfo
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Identification { get; set; }     

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(20)]
        public string PhoneNumberOne { get; set; }

        [MaxLength(20)]
        public string PhoneNumberTwo { get; set; }

        [MaxLength(100)]
        public string AddressOne { get; set; }

        [MaxLength(100)]
        public string AddressTwo { get; set; }

        [MaxLength(100)]
        public string EmailOne { get; set; }

        [MaxLength(100)]
        public string EmailTwo { get; set; }
    }
}
