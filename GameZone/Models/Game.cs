namespace GameZone.Models
{
    public class Game : BaseEntity
    {
     
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;
        // hena code el fk 3shan arbot b table 
        public int CategoryId { get; set; } // fk
        public Category Category { get; set; } = default!;
        //......... relation many to many
        public ICollection<GameDevice> Devices { get; set; }=new List<GameDevice>();

    }
}
