using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSAuthentication.Model
{
    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public String CreatedBy { get; set; }
        public String LastModifiedBy { get; set; }
        public bool Deleted { get; set; }
     
        [NotMapped]
        public String Exception { get; set; }
    //    public virtual ICollection<Site> Sites { get; set; }

        //[NotMapped]
        //public int SiteCount {

        //    get
        //    {
        //        return Sites.Count();
        //    }
        //}
    }
}