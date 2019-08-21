using Autofac;
using Autofac.Integration.Mvc;
using BusinessHR.Data;
using BusinessHR.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BusinessHR.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CertificateService>().As<ICertificateService>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CompanyService>().As<ICompanyService>();
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<PermissionService>().As<IPermissionService>();
            builder.RegisterType<PermissionTypeService>().As<IPermissionTypeService>();
            builder.RegisterType<PositionService>().As<IPositionService>();
            builder.RegisterType<RegionService>().As<IRegionService>();
            builder.RegisterType<SalaryService>().As<ISalaryService>();
            

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new AutoMapperConfig().Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
