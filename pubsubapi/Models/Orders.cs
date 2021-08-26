using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubapi.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }
        public string PhotoUrl { get; set; }
        public string UserEmail { get; set; }
        public string URD { get; set; }

    }
}
