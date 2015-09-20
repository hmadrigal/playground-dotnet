using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DataTableSample.Services;
using DataTables.Models;
using DataTableSample.Models;
using System.Linq.Dynamic;
using DataTables.Extensions;

namespace DataTableSample.Controllers
{
    public class EmployeesController : ApiController
    {
        private CompanyModel db = new CompanyModel();

        // GET: api/Employees
        public async Task<IHttpActionResult> GetEmployees([FromUri]DataTableRequest request)
        {
            var isUsingArrayOfArrays = request.Columns.Where(c => { var n = 0; return int.TryParse(c.Data, out n); }).Any();
            var response = isUsingArrayOfArrays
                ? db.Employees.AsNoTracking().AsQueryable().GetDataTableResponse(request, GetEntityFieldNames, GetEntityAsEnumerable)
                : db.Employees.AsNoTracking().AsQueryable().GetDataTableResponse(request)
                ;
            return Json(response);
        }

        /// <summary>
        /// Converts the Entity to a sequence of values (an Array)
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private System.Collections.IEnumerable GetEntityAsEnumerable(Employee e)
        {
            yield return e.FirstName;
            yield return e.LastName;
            yield return e.Position;
            yield return e.Office;
            yield return e.StartDate;
            yield return e.Salary;
        }

        /// <summary>
        /// Provides the name of the Columns used in the Array
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private IEnumerable<string> GetEntityFieldNames(Employee e)
        {
            yield return nameof(e.FirstName);
            yield return nameof(e.LastName);
            yield return nameof(e.Position);
            yield return nameof(e.Office);
            yield return nameof(e.StartDate);
            yield return nameof(e.Salary);
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employees.Add(employee);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.Id == id) > 0;
        }
    }
}