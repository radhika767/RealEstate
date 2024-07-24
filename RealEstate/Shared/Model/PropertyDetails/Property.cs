using System.ComponentModel.DataAnnotations;
namespace RealEstate.Server.Model.PropertyDetails
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public string Location { get; set; }
        public DateTime? DateListed { get; set; } = DateTime.Now;
    }
}
