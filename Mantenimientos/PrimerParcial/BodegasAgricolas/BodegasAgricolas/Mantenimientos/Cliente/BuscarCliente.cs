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

namespace BodegasAgricolas.Mantenimientos.Cliente
{
    public partial class BuscarCliente : Form
    {
        Conexion cn = new Conexion();
        OdbcDataAdapter datos;
        DataTable dt;
        //Variables que permiten arrastrar formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public BuscarCliente()
        {
            InitializeComponent();
            CargarDatos();
        }

        void CargarDatos()
        {
            try
            {
                string cadena = "SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE estado=1";//Estado =1 se refiere al que el registro esta activo o permitido

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
            IngresoCliente ingreso = new IngresoCliente();
            this.Hide();
            ingreso.Show();
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            AECliente actualizar = new AECliente();
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
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE idEmpleado='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "DPI")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE dpi='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "NIT")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE nit='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Nombre")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE nombre='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }

                else if (cmbColumna.Text == "Apellido")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE apellido='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Correo")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE correo='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Telefono")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE telefono='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
                    dt = new DataTable();
                    datos.Fill(dt);
                    dgridDatos.DataSource = dt;
                }
                else if (cmbColumna.Text == "Direccion")
                {
                    datos = new OdbcDataAdapter("SELECT idCliente,nombre, apellido, nit, dpi, telefono, correo, direccion FROM cliente WHERE direccion='" + txtBuscar.Text + "' AND estado=1", cn.conexion());
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
