﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ProyectoPAV.Clases
{
    class ProveedoresABM
    {
        public DataTable ConsultarProveedoresFiltros(string razonsocial)
        {
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            string sql = @"SELECT P.*, L.Nombre
                             FROM Proveedor P JOIN Localidad L ON P.IdLocalidad = L.IdLocalidad
                            WHERE P.RazonSocial = '" + razonsocial + "'";
            DataTable dt = new DataTable();

            if (gestor.EjecutarConsulta(sql) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                dt = gestor.TablaResultado;
            }
            else
            {
                MessageBox.Show("No se consultaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public DataTable ConsultarProveedores()
        {
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            string sql = @"SELECT P.*, L.Nombre
                             FROM Proveedor P JOIN Localidad L ON P.IdLocalidad = L.IdLocalidad";
            DataTable dt = new DataTable();

            if (gestor.EjecutarConsulta(sql) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                dt = gestor.TablaResultado;
            }
            else
            {
                MessageBox.Show("No se consultaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void InsertarProveedor(string razonSocial, string calle, int numeroCalle, int idLocalidad, string email, int telefono)
        {
            string sql_insert = "";
            sql_insert = @"INSERT INTO Proveedor VALUES ('" + razonSocial + "'," +
                                                        " '" + calle + "'," +
                                                        " " + numeroCalle + "," +
                                                        " " + idLocalidad + "," +
                                                        " '" + email + "'," +
                                                        " " + telefono + ")";
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            if (gestor.Insertar(sql_insert) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                MessageBox.Show("Se cargaron correctamente los datos", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO se cargaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarProveedor(int IdProveedor)
        {
            string sql_delete = "";
            sql_delete = @"DELETE FROM Proveedor WHERE IdProveedor = " + IdProveedor;
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            if (gestor.Eliminar(sql_delete) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                MessageBox.Show("Se eliminaron correctamente los datos", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO se eliminaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable RecuperarDatos(string id)
        {
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            string sql = "SELECT * FROM Proveedor WHERE IdProveedor = " + id;
            DataTable dt = new DataTable();

            if (gestor.EjecutarConsulta(sql) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                dt = gestor.TablaResultado;
            }
            else
            {
                MessageBox.Show("No se consultaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
            //GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            //return gestor.EjecutarConsulta("SELECT * FROM Proveedor WHERE IdProveedor = " + id);

        }

        public void ModificarProveedor(int idProveedor,  string razonSocial, string calle, int numeroCalle, int idLocalidad, string email, int telefono)
        {
            string sql_modificar = "";
            sql_modificar = @"UPDATE Proveedor SET RazonSocial = '" + razonSocial + "'," +
                                                        "Calle = '" + calle + "'," +
                                                        "NumeroCalle = " + numeroCalle + "," +
                                                        "IdLocalidad = " + idLocalidad + "," +
                                                        "Email = '" + email + "'," +
                                                        "Telefono = " + telefono +
                                                        " WHERE IdProveedor = " + idProveedor;
            GestorTransaccionesSQL gestor = new GestorTransaccionesSQL();
            if (gestor.Insertar(sql_modificar) ==
                GestorTransaccionesSQL.ResultadoTransaccion.correcto)
            {
                MessageBox.Show("Se cargaron correctamente los datos", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("NO se cargaron correctamente los datos debido a: " +
                    gestor.mensajeError, "Importante!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
