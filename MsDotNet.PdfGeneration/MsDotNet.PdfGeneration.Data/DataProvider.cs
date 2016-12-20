using FakeData;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace PdfGeneration.Data
{
    public class DataProvider
    {
        public dynamic GetReportData()
        {
            // Generating employee list
            var employees = Enumerable
                .Range(0, NumberData.GetNumber(10, 50))
                .Select(i =>
                   {
                       dynamic newEmployee = new ExpandoObject();
                       newEmployee.BirthDate = DateTimeData.GetDatetime(new DateTime(1973, 1, 1), new DateTime(1997, 12, 1));
                       newEmployee.FirstName = NameData.GetFirstName();
                       newEmployee.LastName = NameData.GetSurname();
                       newEmployee.Company = NameData.GetCompanyName();
                       newEmployee.Email = NetworkData.GetEmail();
                       newEmployee.PhoneNumber = PhoneNumberData.GetInternationalPhoneNumber();
                       newEmployee.Address = string.Format("{0} {1} {2}\n{3},{4} {5}", PlaceData.GetStreetName(), PlaceData.GetStreetNumber(), PlaceData.GetAddress(), PlaceData.GetCity(), PlaceData.GetState(), PlaceData.GetZipCode());
                       newEmployee.PersonalQuote = TextData.GetSentences(5);
                       newEmployee.PorfileFileName = $"{FakeData.NumberData.GetNumber(0,7)}.png";
                       // NOTE: Even though ExpandoObject is compatible with IDictionary<string,object>,
                       //       The template engine only accepts Dictionary<string,object>
                       return new Dictionary<string, object>(newEmployee);
                   })
                .ToList();

            dynamic reportData = new ExpandoObject();
            reportData.Employees = employees;
            return reportData;
        }
    }
}
