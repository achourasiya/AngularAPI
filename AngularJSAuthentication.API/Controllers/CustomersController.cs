using AngularJSAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSAuthentication.API.Controllers
{
     [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {

         iAuthContext context = new AuthContext();

         [Authorize]
         [Route("")]
         public IEnumerable<Customer> Get()
         {
            
             return context.AllCustomers ;
         }

         public Customer Add(Customer item)
         {
             if (item == null)
             {
                 throw new ArgumentNullException("item");
             }
         
             context.AddCustomer(item);
             
             return item;
         }

         public void Remove(int id)
         {
             context.DeleteCustomer(id);
         }

         public bool Update(Customer item)
         {
             if (item == null)
             {
                 throw new ArgumentNullException("item");
             }

            Customer index = context.UpdateCustomer(item);
             if (index == null)
             {
                 return false;
             }
            
             return true;
         }

        //public IHttpActionResult Get()
        //{

        //    iAuthContext context = new AuthContext();
        //    return Ok(context.AllCustomers());
          
        //    //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

        //    //var Name = ClaimsPrincipal.Current.Identity.Name;
        //    //var Name1 = User.Identity.Name;

        //    //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;

        //    return Ok(Helper.CreateCustomers());
        //}

    }



}
