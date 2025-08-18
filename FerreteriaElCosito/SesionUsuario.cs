public static class SesionUsuario
{
    public static int IdEmpleado { get; private set; }
    public static int IdRol { get; private set; }
    public static string NombreCompleto { get; private set; }

    public static void IniciarSesion(int idEmpleado, int idRol, string nombre, string apellido)
    {
        IdEmpleado = idEmpleado;
        IdRol = idRol;
        NombreCompleto = $"{nombre} {apellido}";
    }

    public static void CerrarSesion()
    {
        IdEmpleado = 0;
        IdRol = 0;
        NombreCompleto = string.Empty;
    }
}