using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_ServerProject.Model {

    public class Product {

        //RequestLine = new HashSet<RequestLine>();

        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PrtNbr { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(11, 2)")]
        public double Price { get; set; }
        [Required]
        [StringLength(30)]
        public string Unit { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }
        [Required]
        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<RequestLine> RequestLine { get; set; }


        public Product() {


        }
    }
}
