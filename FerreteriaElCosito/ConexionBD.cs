using MySql.Data.MySqlClient;

namespace FerreteriaElCosito
{
    public static class ConexionBD
    {
        private static readonly string cadenaConexion =
            "server=bkqymy1borojhlsillq3-mysql.services.clever-cloud.com;" +
            "port=3306;" +
            "user=uuoe1ny0zqkumerf;" +
            "password=dTZa3XPyebjXff9xkfmj;" +
            "database=bkqymy1borojhlsillq3;" +
            "SslMode=none;";

        public static MySqlConnection ObtenerConexion()
        {
            var conexion = new MySqlConnection(cadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}