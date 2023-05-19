using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LoiSoLuongLop :Exception
    {
        const string erroMessage = "Số lượng lớp vượt quá quy định";
        public LoiSoLuongLop() : base(erroMessage)
        {
            
        }
    }
}
