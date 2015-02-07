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
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {

            AuthContext context = new AuthContext();
         
            //ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            //var Name = ClaimsPrincipal.Current.Identity.Name;
            //var Name1 = User.Identity.Name;

            //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;

            return Ok(Project.CreateOrders());
        }

    }


    #region Helpers

    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Discription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdateBy { get; set; }
        public static List<Project> CreateOrders()
        {
            List<Project> OrderList = new List<Project> 
            {
                new Project {ProjectID = 10248, ProjectName = "Taiseer 1 Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" },
               new Project {ProjectID = 10241, ProjectName = "Taiseer 2 Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" },
               new Project {ProjectID = 10242, ProjectName = "Taiseer3 Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" },
               new Project {ProjectID = 10243, ProjectName = "Taiseer4  Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" },
               new Project {ProjectID = 10244, ProjectName = "Taiseer5 Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" },
               new Project {ProjectID = 10245, ProjectName = "Taiseer 6 Joudeh", Discription = "Amman",CreatedDate = DateTime.Now,UpdatedDate =DateTime.Now,CreatedBy ="Akhilesh",UpdateBy="Akhilesh" }
              
            };

            return OrderList;
        }
    }

    #endregion
}
