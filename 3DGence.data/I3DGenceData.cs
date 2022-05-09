using _3DGence.Core;
using System.Collections.Generic;


namespace _3DGence.data
{
    public interface I3DGenceData
    {
        IEnumerable<Printer> GetPrinterByName(string name);
        Printer GetById(int id);
        Printer Update(Printer updatedPrinter);
        Printer Add(Printer newPrinter);
        Printer Delete (int id);    
        bool Contains(string name);  
        int Commit();

    }

    }
