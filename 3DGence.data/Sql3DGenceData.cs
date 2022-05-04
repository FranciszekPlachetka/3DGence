using _3DGence.Core;
using System.Collections.Generic;
using System.Linq;


namespace _3DGence.data
{
    public class Sql3DGenceData : I3DGenceData
    {
        private readonly _3DGenceDbContext db;

        public Sql3DGenceData(_3DGenceDbContext db) 
        {
            this.db = db;
        }
        public Printer Add(Printer newPrinter)
        {
            db.Add(newPrinter);
            return newPrinter;

        }

        public int Commit()
        {
           return db.SaveChanges();
        }

        public Printer Delete(int id)
        {
            var printer = GetById(id);
            if(printer != null)
            {
                db.printers.Remove(printer);    
            }
            return printer;
        }

        public Printer GetById(int id)
        {
            return db.printers.Find(id);
        }

        public IEnumerable<Printer> GetPrinterByName(string name)
        {
            var query = from p in db.printers
                        where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby p.Name
                        select p;
            return query;
        }

        public Printer Update(Printer updatedPrinter)
        {
            var entity = db.printers.Attach(updatedPrinter);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedPrinter;
        }
    }
}
