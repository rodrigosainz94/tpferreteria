using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaElCosito
{
    public class ComprasManager
    {
        private ComprasDAL _dal = new ComprasDAL();

        public DataTable ObtenerProveedores()
        {
            return _dal.GetProveedores();
        }

        public DataTable ObtenerProveedoresSoloNombre()
        {
            return _dal.GetProveedoresSoloNombre();
        }

        public DataTable ObtenerFormasDePago()
        {
            return _dal.GetFormasDePago();
        }

        public DataTable ObtenerTiposComprobante()
        {
            return _dal.GetTiposComprobante();
        }

        public DataTable ObtenerTiposMovimientoCaja()
        {
            return _dal.GetTiposMovimientoCaja();
        }

        public DataTable ObtenerNotasDePedido()
        {
            return _dal.GetNotasDePedido();
        }

        public DataTable ObtenerDetalleNotaDePedido(int idNotaDePedido)
        {
            return _dal.GetDetalleNotaDePedido(idNotaDePedido);
        }

        public DataTable ObtenerProveedorPorNotaDePedido(int idNotaDePedido)
        {
            return _dal.GetProveedorPorNotaDePedido(idNotaDePedido);
        }

        // --- MÉTODOS MODIFICADOS PARA ACEPTAR FECHA ---
        public decimal ObtenerSaldoInicialDelDia(DateTime fecha)
        {
            return _dal.GetSaldoInicialDelDia(fecha);
        }

        public DataTable ObtenerMovimientosDeCajaDiarios(DateTime fecha)
        {
            return _dal.GetMovimientosDeCajaDiarios(fecha);
        }

        public DataTable ObtenerReporteStock()
        {
            return _dal.GetReporteStock();
        }

        public int GuardarFactura(Compra compra, List<DetalleCompra> detalles, int idFormaPago, decimal montoPagado, int idTipoEgreso, string concepto)
        {
            return _dal.InsertarCompra(compra, detalles, idFormaPago, montoPagado, idTipoEgreso, concepto);
        }
    }

    public class Compra
    {
        public DateTime FechaCompra { get; set; }
        public int IdTipoComprobante { get; set; }
        public string NumeroComprobante { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Total { get; set; }
        public int? IdNotaDePedidoOrigen { get; set; }
        public string Estado { get; set; }
    }

    public class DetalleCompra
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}