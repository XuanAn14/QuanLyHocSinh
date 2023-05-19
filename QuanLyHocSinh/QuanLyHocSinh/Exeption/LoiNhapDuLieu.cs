using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LoiNhapDuLieu: Exception
    {
        const string erroMessage = "Lỗi chưa nhập đủ dữ liệu";
        public LoiNhapDuLieu() : base(erroMessage)
        {

        }
    }
}
