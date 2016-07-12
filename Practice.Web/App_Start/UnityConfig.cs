using Microsoft.Practices.Unity;
using Practice.Services.EmployeesCRUD;
using Practice.Services.Interfaces;
using Repository.Interfaces;
using Repository.MasterRepo;
using System.Web.Http;
using Unity.WebApi;

namespace Practice.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
           
            container.RegisterType<IAddEmployee, AddEmployee>();
            container.RegisterType<IDeleteEmployee, DeleteEmployee>();
            container.RegisterType<IAddEmp, AddEmp>();
            container.RegisterType<IDeleteEmp, DeleteEmp>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}