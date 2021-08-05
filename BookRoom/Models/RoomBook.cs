using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRoom.Models
{
    public class RoomBook
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }


        [Display(Name = "Number OF Rooms")]
        public string NumberOfRooms { get; set; }

        [Display(Name = "Room Booking Date")]
        public string RoomBookingDate { get; set; }

        [Display(Name = "RoomId")]
        public int RoomId { get; set; }
    }
}
