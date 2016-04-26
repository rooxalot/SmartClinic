using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClinic.Data.Context
{
    public class ContextInitializer : CreateDatabaseIfNotExists<SmartClinicContext>
    {
        protected override void Seed(SmartClinicContext context)
        {
            var cmd = @"IF NOT EXISTS(SELECT 1 FROM Users WHERE ID = '3B209C4D-0968-4588-A6D6-87F7A660E533') " +
                               "INSERT INTO Users " +
                               "VALUES('3B209C4D-0968-4588-A6D6-87F7A660E533', 'admin', '202cb962ac59075b964b07152d234b70', 1, 0, GETDATE())";

            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
            base.Seed(context);
        }
    }
}
