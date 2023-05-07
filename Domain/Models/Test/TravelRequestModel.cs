using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Test
{

    public class TravelRequestModel
    {
        public string HotelName { get; set; }

        public string CheckIn { get; set; }

        public string CheckOut { get; set; }

        public string ReservID { get; set; }

        public string RoomType { get; set; }

        public string CancelData { get; set; }

        public bool IsActive { get; set; }


    }
}

