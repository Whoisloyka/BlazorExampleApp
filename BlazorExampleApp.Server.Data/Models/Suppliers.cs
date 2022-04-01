using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExampleApp.Server.Data.Modal
{
    public class Suppliers
    {
        public Guid Id { get; set; }
        public DateTime CreateDate{ get; set; }
        public String Name{ get; set; }
        public String WebURL { get; set; }
        public bool IsActive { get; set; }

        // order'ın supplier'ını görmek için bir bağlantı kuruyoruz.
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
