using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Server=localhost\\SQLEXPRESS; Database=BD; Trusted_Connection=True;");
            cn.Open();
            return cn;
        }
    }
}
