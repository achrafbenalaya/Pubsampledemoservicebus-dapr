using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pubsubmvcsample.Models
{
    public class Orders
    {
        public Guid OrderId { get; set; }
        public string PhotoUrl { get; set; }
        public string UserEmail { get; set; }
        public string URD { get; set; }
    }
}
