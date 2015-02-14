using AngularJSAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace AngularJSAuthentication.API.Controllers
{
    [RoutePrefix("api/Projects")]
    public class ProjectsController : ApiController
    {
        iAuthContext context = new AuthContext();

        [Authorize]
        [Route("")]
        public IEnumerable<Project> Get()
        {

            return context.AllProjects;
        }

        public Project Add(Project item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            context.AddProject(item);

            return item;
        }

        public void Remove(int id)
        {
            context.DeleteProject(id);
        }

        public bool Update(Project item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            Project index = context.UpdateProject(item);
            if (index == null)
            {
                return false;
            }

            return true;
        }
        
        //[Authorize]
        //[Route("")]
        //public IHttpActionResult Get()
        //{

        //    AuthContext context = new AuthContext();
         
        //    //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

        //    //var Name = ClaimsPrincipal.Current.Identity.Name;
        //    //var Name1 = User.Identity.Name;

        //    //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;

        //    return Ok(Helper.CreateProjects());
        //}

    }


}



