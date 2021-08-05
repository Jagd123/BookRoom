using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookRoom.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }


        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
