using System.ComponentModel.DataAnnotations;

namespace HallRoomBook.Models
{
    public class MeetingHall
    {
        [Key]
        public int RowId { get; set; }
        public string? HallName { get; set; }
        public bool IsActive { get; set; }    

    }
}
