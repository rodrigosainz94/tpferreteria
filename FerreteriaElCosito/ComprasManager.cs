using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaElCosito
{
    // Clase CierreDeCaja (necesaria para guardar y recuperar registros de cierre)
    public class CierreDeCaja
    {
        public DateTime Fecha { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoFinal { get; set; }
        public string Observaciones { get; set; }
        public int IdEmpleado { get; set; }
    }

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

        public DataTable ObtenerMovimientosDeCajaDiarios(DateTime fecha)
        {
            return _dal.GetMovimientosDeCajaDiarios(fecha);
        }

        public DataTable ObtenerReporteDiarioStock(DateTime fecha)
        {
            return _dal.GetReporteDiarioStock(fecha);
        }

        // Método para obtener el saldo inicial (saldo final del día anterior)
        public decimal ObtenerSaldoInicialDelDia(DateTime fecha)
        {
            return _dal.GetSaldoInicialDelDia(fecha);
        }

        // MÉTODO CLAVE: Obtiene el registro completo de la caja (SaldoInicial y Arqueo) para un día cerrado
        public DataTable ObtenerDatosCajaCerrada(DateTime fecha)
        {
            return _dal.GetDatosCajaCerrada(fecha);
        }

        public void GuardarCierreDeCaja(CierreDeCaja cierre)
        {
            _dal.InsertarCierreDeCaja(cierre);
        }

        public bool VerificarCajaCerrada(DateTime fecha)
        {
            return _dal.CajaYaCerrada(fecha);
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