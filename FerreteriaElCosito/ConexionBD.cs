using MySql.Data.MySqlClient;

namespace FerreteriaElCosito
{
    public class ConexionBD
    {
        private string cadenaConexion = "server=bkqymy1borojhlsillq3-mysql.services.clever-cloud.com;port=3306;user=uuoe1ny0zqkumerf;password=dTZa3XPyebjXff9xkfmj;database=bkqymy1borojhlsillq3;SslMode=none;";
        private MySqlConnection conexion;

        public ConexionBD()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        public MySqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}

