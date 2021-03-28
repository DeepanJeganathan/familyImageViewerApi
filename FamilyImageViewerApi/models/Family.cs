using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyImageViewerApi.models
{
    public class Family
    {
        [Key]
        public int FamilyId { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Maximum charaacters exceeded ")]
        public string FamilyFirstName { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Maximum charaacters exceeded ")]
        public string FamilyLastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Relation { get; set; }

        public string Quote { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        

    }
}
