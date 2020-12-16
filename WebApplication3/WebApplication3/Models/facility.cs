using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class facility
    {
        [Key]
        public int fid { get;  set; }
        public string fCode { get; set; }
        public string fName { get; set; }
        public string fModel { get; set; }
        
        public int fPrice { get; set; }
    }
}