using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace PRS_ServerProject.Model {

    public class RequestLine {

        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int RequestId { get; set; }
        [Required]
        public int Quantity { get; set; }


        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }

        private void ReCalRequestTotal(int requestId) {

        }



    }
}
