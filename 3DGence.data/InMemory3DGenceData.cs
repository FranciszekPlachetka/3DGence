using _3DGence.Core;
using System.Collections.Generic;

using System.Linq;


namespace _3DGence.data
{
    public class InMemory3DGenceData : I3DGenceData
    {
        List<Printer> printers;

        public InMemory3DGenceData()
        {
            printers = new List<Printer>()
            {
                new Printer{ Id =1, Name ="F421.00001", Model =PrinterType.F421},
                new Printer{ Id =2, Name ="F420.00002", Model =PrinterType.F420},
                new Printer{ Id =3, Name ="F350.00003", Model =PrinterType.F350}
            };
        }
        public Printer GetById(int id)
        {
            return printers.SingleOrDefault(p => p.Id == id);
        }

        public Printer Update(Printer updatedPrinter)
        {
            var printer = printers.SingleOrDefault(r=>r.Id == updatedPrinter.Id);    
            if(printer != null)
            {
                printer.Name = updatedPrinter.Name;
                printer.Model = updatedPrinter.Model;
               

            }
            return printer;
        }

        public IEnumerable<Printer> GetPrinterByName(string name)
        {
            return from p in printers
                   where string.IsNullOrEmpty(name) || p.Name.StartsWith(name)
                   orderby p.Name
                   select p;
        }

        public int Commit()
        {
            return 0;
        }

        public Printer Add(Printer newPrinter)
        {
            printers.Add(newPrinter);
            newPrinter.Id = printers.Max(r=>r.Id)+1;
            return newPrinter;
        }

        public Printer Delete(int id)
        {
            var printer = printers.FirstOrDefault(p => p.Id == id);
            if(printer != null)
            {
                printers.Remove(printer);
            }
            return printer;
        }
    }
}
