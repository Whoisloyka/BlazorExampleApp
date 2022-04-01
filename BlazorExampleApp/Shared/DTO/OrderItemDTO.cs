using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExampleApp.Shared.DTO
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public String Description { get; set; }

        public String CreatedUserFullName { get; set; }
        public String OrderName { get; set; }
    }
}
