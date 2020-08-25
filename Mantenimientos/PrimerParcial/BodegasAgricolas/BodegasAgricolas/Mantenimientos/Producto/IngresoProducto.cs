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

namespace BodegasAgricolas.Mantenimientos.Producto
{
    public partial class IngresoProducto : Form
    {
        public IngresoProducto()
        {
            InitializeComponent();
            inicializarCategoria();
        }

        Conexion cn = new Conexion();
        //Variables que se inicializan y permiten arrastrar y movilizar el formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private bool insertarCargos()
        {
            try
            {
                
                string cadena = "INSERT INTO producto (nombre, cantidad, precio, idCategoia, estado) VALUES ('" + txtNombre.Text + "','" + txtCantidad.Text + "','" + txtPrecio.Text + "','" + cmbCategoria.SelectedItem.ToString() + "', 1);";
                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                consulta.Connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al guardar Datos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BorrarTextbox();
                return false;
            }

        }
        void BorrarTextbox()
        {
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            cmbCategoria.SelectedIndex = 0;
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

        private void picMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (insertarCargos() == true)
            {
                MessageBox.Show("Datos guardados", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BorrarTextbox();
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta dentro de esa ventana", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAct_Eliminar_Click(object sender, EventArgs e)
        {
            AEProducto actualizar = new AEProducto();
            actualizar.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto buscar = new BuscarProducto();
            this.Hide();
            buscar.Show();

        }

        private void pnlFormMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void inicializarCategoria()
        {
            try
            {
                string sSQL = "SELECT idCategoria FROM categoria_producto WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();
                
                cmbCategoria.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbCategoria.Items.Add(registro["idCategoria"].ToString());
                }
                cmbCategoria.SelectedIndex.Equals(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al datos al combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
