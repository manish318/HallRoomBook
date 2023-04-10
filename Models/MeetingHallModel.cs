using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class MeetingHallModel
    {
        [Key]
        public int RowId { get; set; }
        public string? HallName { get; set; }
        public bool IsActive { get; set; }
    }
}