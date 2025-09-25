using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FerreteriaElCosito
{
    public class ComprasDAL
    {
        public DataTable GetProveedores()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdProveedor, CONCAT(Nombre, ' ', Apellido) AS NombreCompleto FROM proveedores ORDER BY Nombre";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetProveedoresSoloNombre()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdProveedor, Nombre FROM proveedores ORDER BY Nombre";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetTiposComprobante()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdTipoComprobante, DenominacionComprobante FROM tipocomprobante ORDER BY DenominacionComprobante";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetFormasDePago()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdFormaPago, Descripcion FROM formapago";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetTiposMovimientoCaja()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdTipoMovimientoCaja, Descripcion FROM tipomovimientocaja ORDER BY Descripcion";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // --- MÉTODO CORREGIDO ---
        public DataTable GetMovimientosDeCajaDiarios(DateTime fecha)
        {
            DataTable dt = new DataTable();
            string query = @"
            SELECT
                mc.IdMovimientoCaja,
                DATE_FORMAT(mc.FechaHoraMovimiento, '%d/%m/%Y') AS Fecha,
                tmc.Descripcion,
                -- Usamos un CASE para determinar la forma de pago
                CASE
                    WHEN mc.IdCompra IS NOT NULL THEN (SELECT fp.Descripcion FROM pagocompra pc JOIN formapago fp ON pc.IdFormaPago = fp.IdFormaPago WHERE pc.IdCompra = mc.IdCompra)
                    WHEN mc.IdVenta IS NOT NULL THEN (SELECT fp.Descripcion FROM pagoventa pv JOIN formapago fp ON pv.IdFormaPago = fp.IdFormaPago WHERE pv.IdVenta = mc.IdVenta)
                    ELSE 'Efectivo' -- O cualquier valor por defecto para otros movimientos
                END AS FormaDePago,
                mc.Monto,
                mc.Concepto,
                COALESCE(mc.IdCompra, mc.IdVenta) AS IdComprobante
            FROM movimientocaja mc
            JOIN tipomovimientocaja tmc ON mc.IdTipoMovimientoCaja = tmc.IdTipoMovimientoCaja
            WHERE DATE(mc.FechaHoraMovimiento) = @Fecha
            ORDER BY mc.FechaHoraMovimiento DESC";

            try
            {
                using (MySqlConnection conn = ConexionBD.ObtenerConexion())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Considera un manejo de errores más específico
                throw new Exception("Error al obtener los movimientos de caja.", ex);
            }

            return dt;
        }

        public DataTable GetReporteStock()
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdProducto, NombreProducto, Cantidad FROM productos";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetNotasDePedido()
        {
            DataTable dt = new DataTable();
            string query = "SELECT c.IdCompra, c.NumeroComprobante, p.Nombre AS Proveedor FROM compras c JOIN proveedores p ON c.IdProveedor = p.IdProveedor WHERE c.IdTipoComprobante = 7 AND c.Estado = 'Pendiente'";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetDetalleNotaDePedido(int idNotaDePedido)
        {
            DataTable dt = new DataTable();
            string query = "SELECT d.IdProducto, pr.NombreProducto, d.Cantidad, d.PrecioUnitario, d.Subtotal FROM detallecompra d JOIN productos pr ON d.IdProducto = pr.IdProducto WHERE d.IdCompra = @idCompra";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idCompra", idNotaDePedido);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetProveedorPorNotaDePedido(int idNotaDePedido)
        {
            DataTable dt = new DataTable();
            string query = "SELECT IdProveedor FROM compras WHERE IdCompra = @idCompra";
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idCompra", idNotaDePedido);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // --- MÉTODO CORREGIDO ---
        public decimal GetSaldoInicialDelDia(DateTime fecha)
        {
            decimal saldoInicial = 0;
            // La consulta obtiene el último saldo final de la tabla 'caja' de un día anterior a la fecha seleccionada.
            string query = "SELECT SaldoFinal FROM caja WHERE DATE(Fecha) < @Fecha ORDER BY Fecha DESC LIMIT 1";
            using (var conn = ConexionBD.ObtenerConexion())
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Fecha", fecha.Date); // Agregamos el parámetro
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        saldoInicial = Convert.ToDecimal(result);
                    }
                }
            }
            return saldoInicial;
        }

        public int InsertarCompra(Compra compra, List<DetalleCompra> detalles, int idFormaPago, decimal montoPagado, int idTipoEgreso, string concepto)
        {
            int idCompra = 0;
            using (MySqlConnection conn = ConexionBD.ObtenerConexion())
            {
                MySqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string compraQuery = "INSERT INTO compras (FechaCompra, IdTipoComprobante, NumeroComprobante, IdProveedor, IdEmpleado, Total, IdNotaDePedidoOrigen, Estado) VALUES (@fecha, @idTipo, @nro, @idProveedor, @idEmpleado, @total, @idNotaDePedidoOrigen, @estado); SELECT LAST_INSERT_ID();";
                    using (MySqlCommand cmdCompra = new MySqlCommand(compraQuery, conn, transaction))
                    {
                        cmdCompra.Parameters.AddWithValue("@fecha", compra.FechaCompra);
                        cmdCompra.Parameters.AddWithValue("@idTipo", compra.IdTipoComprobante);
                        cmdCompra.Parameters.AddWithValue("@nro", compra.NumeroComprobante);
                        cmdCompra.Parameters.AddWithValue("@idProveedor", compra.IdProveedor);
                        cmdCompra.Parameters.AddWithValue("@idEmpleado", compra.IdEmpleado);
                        cmdCompra.Parameters.AddWithValue("@total", compra.Total);
                        cmdCompra.Parameters.AddWithValue("@idNotaDePedidoOrigen", compra.IdNotaDePedidoOrigen ?? (object)DBNull.Value);
                        cmdCompra.Parameters.AddWithValue("@estado", compra.Estado);
                        idCompra = Convert.ToInt32(cmdCompra.ExecuteScalar());
                    }

                    foreach (var detalle in detalles)
                    {
                        string detalleQuery = "INSERT INTO detallecompra (IdCompra, IdProducto, Cantidad, PrecioUnitario, Subtotal) VALUES (@idCompra, @idProducto, @cantidad, @precio, @subtotal)";
                        using (MySqlCommand cmdDetalle = new MySqlCommand(detalleQuery, conn, transaction))
                        {
                            cmdDetalle.Parameters.AddWithValue("@idCompra", idCompra);
                            cmdDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdDetalle.Parameters.AddWithValue("@precio", detalle.PrecioUnitario);
                            cmdDetalle.Parameters.AddWithValue("@subtotal", detalle.Subtotal);
                            cmdDetalle.ExecuteNonQuery();
                        }

                        string stockQuery = "UPDATE productos SET Cantidad = Cantidad + @cantidad WHERE IdProducto = @idProducto";
                        using (MySqlCommand cmdStock = new MySqlCommand(stockQuery, conn, transaction))
                        {
                            cmdStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdStock.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdStock.ExecuteNonQuery();
                        }

                        string movStockQuery = "INSERT INTO movimientostock (IdProducto, IdTipoMovimiento, Cantidad, FechaMovimiento, DetalleMovimiento, IdDeposito, IdEmpleado) VALUES (@idProducto, 1, @cantidad, @fecha, 'Compra por factura', @idDeposito, @idEmpleado)";
                        using (MySqlCommand cmdMovStock = new MySqlCommand(movStockQuery, conn, transaction))
                        {
                            cmdMovStock.Parameters.AddWithValue("@idProducto", detalle.IdProducto);
                            cmdMovStock.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmdMovStock.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmdMovStock.Parameters.AddWithValue("@idDeposito", 1);
                            cmdMovStock.Parameters.AddWithValue("@idEmpleado", compra.IdEmpleado);
                            cmdMovStock.ExecuteNonQuery();
                        }
                    }

                    string pagoQuery = "INSERT INTO pagocompra (IdCompra, FechaPago, IdFormaPago, Monto) VALUES (@idCompra, @fecha, @idFormaPago, @monto)";
                    using (MySqlCommand cmdPago = new MySqlCommand(pagoQuery, conn, transaction))
                    {
                        cmdPago.Parameters.AddWithValue("@idCompra", idCompra);
                        cmdPago.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmdPago.Parameters.AddWithValue("@idFormaPago", idFormaPago);
                        cmdPago.Parameters.AddWithValue("@monto", montoPagado);
                        cmdPago.ExecuteNonQuery();
                    }

                    string cajaQuery = "INSERT INTO movimientocaja (IdCaja, FechaHoraMovimiento, IdTipoMovimientoCaja, Monto, Concepto, IdCompra) VALUES (@idCaja, @fecha, @idTipo, @monto, @concepto, @idCompra)";
                    using (MySqlCommand cmdCaja = new MySqlCommand(cajaQuery, conn, transaction))
                    {
                        cmdCaja.Parameters.AddWithValue("@idCaja", 1);
                        cmdCaja.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmdCaja.Parameters.AddWithValue("@idTipo", idTipoEgreso);
                        cmdCaja.Parameters.AddWithValue("@monto", montoPagado);
                        cmdCaja.Parameters.AddWithValue("@concepto", concepto);
                        cmdCaja.Parameters.AddWithValue("@idCompra", idCompra);
                        cmdCaja.ExecuteNonQuery();
                    }

                    if (compra.IdNotaDePedidoOrigen.HasValue)
                    {
                        string updateNPQuery = "UPDATE compras SET Estado = 'Facturada' WHERE IdCompra = @idNotaDePedidoOrigen";
                        using (MySqlCommand cmdUpdateNP = new MySqlCommand(updateNPQuery, conn, transaction))
                        {
                            cmdUpdateNP.Parameters.AddWithValue("@idNotaDePedidoOrigen", compra.IdNotaDePedidoOrigen.Value);
                            cmdUpdateNP.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    return idCompra;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}