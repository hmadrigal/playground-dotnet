using DataTableSample.Models;
using DataTableSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace DataTableSample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (var dbContext = new CompanyModel())
            {
                dbContext.Database.CreateIfNotExists();
                if (!dbContext.Employees.Any())
                {
                    dbContext.Employees.AddRange(GetDataPerson(300));
                    dbContext.SaveChanges();
                }
            }
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
#if DEBUG
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
#endif

        }

        public static IEnumerable<Employee> GetDataPerson(int number)
        {
            return Enumerable.Range(0, number).Select(index => new Employee
            {
                Id = index,
                //ID = MockData.RandomNumber.Next(0,number*100),
                FirstName = MockData.Person.FirstName(),
                LastName = MockData.Person.Surname(),
                Office = MockData.Address.Country(),
                Position = string.Join(" ", MockData.Lorem.Words(3)),
                StartDate = MockData.Utils.RandomDate(DateTime.Now.Subtract(TimeSpan.FromDays(365)), DateTime.Now),
                Salary = MockData.RandomNumber.Next(1000000),
            });
        }
    }
}
