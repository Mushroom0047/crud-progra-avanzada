using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Biblioteca {
    public class Conexion {
        public SqlConnection getConnection() {
            try {
                string cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\C#\trabajoFinal\trabajoFinal\App_Data\Database1.mdf;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn;
            } catch (Exception) {
                return null;
            }
        }
    }
}
