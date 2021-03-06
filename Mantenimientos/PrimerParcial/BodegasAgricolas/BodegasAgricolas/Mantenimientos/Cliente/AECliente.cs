﻿using RentaDeVideos.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegasAgricolas.Mantenimientos.Cliente
{
    public partial class AECliente : Form
    {
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;
        //Variables que permiten que se arrastre el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public AECliente()
        {
            InitializeComponent();
            CargarDatos();
        }


        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT  idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE estado=1";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string sCadena;
        int iID;
        int iIDEliminar;

        private void dgridVista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                sCadena = dgridVista.Rows[e.RowIndex].Cells["idCliente"].Value.ToString();
                if (sCadena == "")
                {
                    iID = 0;
                }
                else
                {
                    iID = int.Parse(dgridVista.Rows[e.RowIndex].Cells["idCliente"].Value.ToString());
                }
                if (iID != 0)
                {
                    if (dgridVista.CurrentRow != null)
                    {
                        string cadena = "UPDATE cliente SET dpi='" + dgridVista.Rows[e.RowIndex].Cells["dpi"].Value.ToString() + "', nit='" + dgridVista.Rows[e.RowIndex].Cells["nit"].Value.ToString() + "', nombre='" + dgridVista.Rows[e.RowIndex].Cells["nombre"].Value.ToString()
                            + "', apellido='" + dgridVista.Rows[e.RowIndex].Cells["apellido"].Value.ToString() + "', correo='" + dgridVista.Rows[e.RowIndex].Cells["correo"].Value.ToString() + "', telefono='" + dgridVista.Rows[e.RowIndex].Cells["telefono"].Value.ToString()
                            + "', direccion='" + dgridVista.Rows[e.RowIndex].Cells["direccion"].Value.ToString() + "' WHERE idCliente='" + iID + "';";
                        datos = new OdbcDataAdapter(cadena, cn.conexion());
                        dt = new DataTable();
                        datos.Fill(dt);
                        dgridVista.DataSource = dt;
                        MessageBox.Show("Datos Correctamente Actualizados", "Actualizacion/Modificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string cadena = "UPDATE cliente SET estado=0  WHERE idCliente='" + iIDEliminar + "';";
                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridVista.DataSource = dt;
                MessageBox.Show("Datos Eliminados", "Eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al eliminar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picSalir_Click(object sender, EventArgs e)
        {
            DialogResult drResultadoMensaje;
            drResultadoMensaje = MessageBox.Show("¿Realmente desea salir?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (drResultadoMensaje == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            IngresoCliente ingreso= new IngresoCliente();
            this.Hide();
            ingreso.Show();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarCliente buscar = new BuscarCliente();
            this.Hide();
            buscar.Show();
        }

        private void dgridVista_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                iIDEliminar = int.Parse(dgridVista.Rows[e.RowIndex].Cells["idCliente"].Value.ToString());
                this.cmsDelete.Show(this.dgridVista, e.Location);
                cmsDelete.Show(Cursor.Position);
            }
        }
    }
}
