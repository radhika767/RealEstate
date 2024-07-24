using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Shared.DTO.PropertyDetails
{
    public class PropertyDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title Field is Mandatory")]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Location { get; set; }
    }
}
