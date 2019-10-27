﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Resources;
using System.Data.SqlClient;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;
using System.Data.OleDb;

namespace ProyectoPAV.Formularios.Forms_Reportes
{
    public partial class FrmReporteProductos : Form
    {
        public string cadenaConexion = "Provider=SQLNCLI11;Data Source=DESKTOP-FHCPBI9" + "\u005C" + "SQLEXPRESS01;Integrated Security=SSPI;Initial Catalog=ProyectoPAV";
        public FrmReporteProductos()
        {
            InitializeComponent();
        }

        private void FrmReporteProductos_Load(object sender, EventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection();
            OleDbCommand comando = new OleDbCommand();
            DataTable tabla = new DataTable();
            string sql = @"SELECT p.IdProducto as IdProducto, p.Nombre as Nombre,
                        m.Nombre as Marca, c.Nombre as Categoria, p.StockDisponible as StockDisponible
                        FROM Producto p JOIN Marca m ON p.IdMarca = m.IdMarca JOIN Categoria c ON p.IdCategoria = c.IdCategoria";
           

            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;
            tabla.Load(comando.ExecuteReader());
            productosBindingSource.DataSource = tabla;
            reportViewerProductos.RefreshReport();
            reportViewerProductos.ZoomMode = ZoomMode.PageWidth;
            conexion.Close();
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            if (radioButtonMarcas.Checked == true)
            {
                OleDbConnection conexion = new OleDbConnection();
                OleDbCommand comando = new OleDbCommand();
                DataTable tabla = new DataTable();
                string sql = @"SELECT m.Nombre as descripcion, COUNT(*) as valor
                        FROM Producto p JOIN Marca m ON p.IdMarca = m.IdMarca
                        GROUP BY m.Nombre";

     

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                tabla.Load(comando.ExecuteReader());
                EstadisticasBindingSource.DataSource = tabla;
                reportViewerEstadistica.RefreshReport();
                conexion.Close();
                label1.Visible = true;
                label1.Text = "MARCAS";
            }

            if (radioButtonCategorias.Checked == true)
            {


                OleDbConnection conexion = new OleDbConnection();
                OleDbCommand comando = new OleDbCommand();
                DataTable tabla = new DataTable();
                string sql = @"SELECT c.Nombre as descripcion, COUNT(*) as valor
                        FROM Producto p JOIN Categoria c ON p.IdMarca = c.IdCategoria
                        GROUP BY c.Nombre";

                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql;
                tabla.Load(comando.ExecuteReader());
                EstadisticasBindingSource.DataSource = tabla;
                reportViewerEstadistica.RefreshReport();
                conexion.Close();
                label1.Visible = true;
                label1.Text = "CATEGORIAS";
            }

        }
    }
}
