using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LoiSiSo : Exception
    {
        const string erroMessage = "Sĩ Số vượt quá quy định";
        public LoiSiSo() : base(erroMessage)
        {
        }
    }
}
