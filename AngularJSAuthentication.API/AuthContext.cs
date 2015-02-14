
using AngularJSAuthentication.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API
{
    public interface iAuthContext
    {

        IEnumerable<Customer> AllCustomers { get; }
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        bool DeleteCustomer(int id);

        IEnumerable<Project> AllProjects { get; }
        Project AddProject(Project project);
        Project UpdateProject(Project project);
        bool DeleteProject(int id);

    }

    public class AuthContext : IdentityDbContext<IdentityUser>, iAuthContext
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IEnumerable<Customer> AllCustomers
        {
            get { return Customers.AsEnumerable(); }
        }


        public Customer AddCustomer(Customer customer)
        {
            List<Customer> customers = Customers.Where(c => c.Name.Trim().Equals(customer.Name.Trim())).ToList();
            Customer objCustomer = new Customer();
            if (customers.Count == 0)
            {
                Customers.Add(customer);
                int id = this.SaveChanges();
                customer.CustomerId = id;
                return customer;
            }
            else
            {
                objCustomer.Exception = "Already";
                return objCustomer;
            }


        }

        public Customer UpdateCustomer(Customer objCust)
        {
            //Customer c = new Customer();
            Customer customer = Customers.Where(x => x.CustomerId == objCust.CustomerId).FirstOrDefault();
            if (customer != null)
            {
                customer.UpdatedDate = DateTime.Now;
                customer.Name = objCust.Name;

                customer.Description = objCust.Description;
                customer.LastModifiedBy = objCust.LastModifiedBy;
                Customers.Attach(customer);
                this.Entry(customer).State = EntityState.Modified;
                this.SaveChanges();
                return objCust;
            }
            else
            {
                return objCust;
            }
        }


        public bool DeleteCustomer(int objCust)
        {
            Customer customer = Customers.Where(x => x.CustomerId == objCust).FirstOrDefault();
            if (customer != null)
            {
                customer.UpdatedDate = DateTime.Now;
                customer.Deleted = true;

                Customers.Attach(customer);
                this.Entry(customer).State = EntityState.Modified;
                this.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }




        public IEnumerable<Project> AllProjects
        {
            get { return Projects.AsEnumerable(); }
        }

        public Project AddProject(Project project)
        {
            List<Project> projects = Projects.Where(c => c.ProjectName.Trim().Equals(project.ProjectName.Trim())).ToList();
            Project objProject = new Project();
            if (projects.Count == 0)
            {
                Projects.Add(project);
                int id = this.SaveChanges();
                project.ProjectID = id;
                return project;
            }
            else
            {
                //objProject.Exception = "Already";
                return objProject;
            }
        }

        public Project UpdateProject(Project objCust)
        {
            Project proj = Projects.Where(x => x.ProjectID == objCust.ProjectID).FirstOrDefault();
            if (proj != null)
            {
                proj.UpdatedDate = DateTime.Now;
                proj.ProjectName = objCust.ProjectName;

                proj.Discription = objCust.Discription;
                proj.CreatedBy = objCust.CreatedBy;
                proj.CreatedDate = objCust.CreatedDate;
                proj.UpdateBy = objCust.UpdateBy;

                Projects.Attach(proj);
                this.Entry(proj).State = EntityState.Modified;
                this.SaveChanges();
                return objCust;
            }
            else
            {
                return objCust;
            }
        }

        public bool DeleteProject(int objCust)
        {
            Project project = Projects.Where(x => x.ProjectID == objCust).FirstOrDefault();
            if (project != null)
            {
                project.UpdatedDate = DateTime.Now;
                project.Deleted = true;

                Projects.Attach(project);
                this.Entry(project).State = EntityState.Modified;
                this.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}