using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExampleApp.Server.Data.Modal
{
    public class Orders
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid SupplierId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime ExpireDate { get; set; }


        // orders tablosundan users ve suppliers tablolarına ulaşabileceğimiz  bir bağlantı kuralım 
        public virtual Users CreateUser { get; set; }
        public virtual Suppliers Supplier { get; set; }


        // orderItems tarafında FK oluşması için tanım yapıyoruz.
        public virtual ICollection<OrderItems> OrderItems { get; set; }




    }
}
