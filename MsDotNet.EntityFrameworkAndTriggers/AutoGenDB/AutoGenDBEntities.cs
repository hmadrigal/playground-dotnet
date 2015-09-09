using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenDB
{
    public partial class AutoGenDBEntities : DbContext
    {
        public override int SaveChanges()
        {
            var entriesToReload = ChangeTracker.Entries<IDetail>().Where(e => e.State == EntityState.Added).ToList();
            int rowCount = base.SaveChanges();
            if (rowCount > 0 && entriesToReload.Count > 0)
                entriesToReload.ForEach(e => e.Reload());
            return rowCount;
        }

    }

    public partial class Detail : AutoGenDB.IDetail
    {

    }
}
