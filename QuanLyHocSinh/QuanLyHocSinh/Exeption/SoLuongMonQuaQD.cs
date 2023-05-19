using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SoLuongMonQuaQD :Exception
    {
        const string erroMessage = "Số lượng môn học vượt quá quy định";
        public SoLuongMonQuaQD() : base(erroMessage)
        {

        }
    }
}
