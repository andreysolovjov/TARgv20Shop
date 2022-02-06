using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Targv20Shop.Core.Domain
{
    public class Car
    {
        public Guid? Id { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public double CarPrice { get; set; }
        public int CarAmount { get; set; }
        public DateTime CarCreatedAt { get; set; }
        public DateTime CarModifiedAt { get; set; }

        public IEnumerable<ExistingFilePath> ExistingFilePaths { get; set; } = new List<ExistingFilePath>();
    }
}
