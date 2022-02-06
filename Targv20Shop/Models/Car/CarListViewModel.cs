using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Targv20Shop.Models.Car
{
    public class CarListViewModel
    {
        public Guid? Id { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public double CarPrice { get; set; }
        public int CarAmmount { get; set; }
        public DateTime CarCreatedAt { get; set; }
        public DateTime CarModifiedAt { get; set; }
    }
}
