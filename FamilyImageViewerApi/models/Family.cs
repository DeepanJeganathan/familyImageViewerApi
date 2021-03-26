using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string FirstName { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Maximum charaacters exceeded ")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }
        [Required]
        public string FamilyRelation { get; set; }

        public string Quote { get; set; }

    }
}
