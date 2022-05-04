using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _3DGence.Core
{
    public partial class Printer
    {

        public int Id { get; set; }
        [Required,RegularExpression("[F][4][2][0][.][0-9]{5}") ]
        public string Name { get; set; }

        public PrinterType  Model { get; set; }
    }
}
