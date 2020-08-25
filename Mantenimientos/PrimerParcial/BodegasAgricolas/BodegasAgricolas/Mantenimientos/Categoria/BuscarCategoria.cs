using RentaDeVideos.Clases;
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

namespace BodegasAgricolas.Mantenimientos.Categoria
{
    public partial class BuscarCategoria : Form
    {
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;
        //Variables que permiten arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public BuscarCategoria()
        {
            InitializeComponent();
            CargarDatos();
        }

        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT idCategoria, nombre, descripcion FROM categoria_producto WHERE estado=1";//Estado =1 se refiere al que el registro esta activo o permitido

                datos = new OdbcDataAdapter(cadena, cn.conexion());
                dt = new DataTable();
                datos.Fill(dt);
                dgridDatos.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al cargar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            IngresoCategoria ingreso = new IngresoCategoria();
            this.Hide();
            ingreso.Show();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            AECategoria actualizar = new AECategoria();
            actualizar.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbColumna.Text == "ID")
                {
                    datos = new OdbcDataAdapter("SELECT idCategoria, nombre, descripcion FROM categoria_producto WHERE idCategoria='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Nombre")
                {
                    datos = new OdbcDataAdapter("SELECT idCategoria, nombre, descripcion FROM categoria_producto WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Descripcion")
                {
                    datos = new OdbcDataAdapter("SELECT idCategoria, nombre, descripcion FROM categoria_producto WHERE descripcion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al buscar datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
