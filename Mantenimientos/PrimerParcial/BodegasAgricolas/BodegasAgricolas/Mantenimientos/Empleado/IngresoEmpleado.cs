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

namespace BodegasAgricolas.Mantenimientos.Empleado
{
    public partial class IngresoEmpleado : Form
    {
        public IngresoEmpleado()
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
                
                string cadena = "INSERT INTO empleado (idCargo, dpi, nit, nombre, apellido, correo, telefono, direccion, estado) VALUES ('" +cmbCargo.SelectedItem.ToString() + "','"+ txtDPI.Text + "','" + txtNIT.Text + "','" + txtNombre.Text + "','" + txtApellido.Text + "','" + txtCorreo.Text + "','" + txtTelefono.Text + "','" + txtDireccion.Text + "', 1);";
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
            txtApellido.Text = "";
            txtDPI.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtNIT.Text = "";
            txtTelefono.Text = "";
            cmbCargo.SelectedIndex = 0;
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
            AEEmpleado actualizar = new AEEmpleado();
            actualizar.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarEmpleado buscar = new BuscarEmpleado();
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
                string sSQL = "SELECT idCargo FROM cargo WHERE estado=1";
                OdbcCommand comando = new OdbcCommand(sSQL, cn.conexion());
                OdbcDataReader registro = comando.ExecuteReader();
                
                cmbCargo.SelectedIndex = 0;
                while (registro.Read())
                {
                    cmbCargo.Items.Add(registro["idCargo"].ToString());
                }
                cmbCargo.SelectedIndex.Equals(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al datos al combobox", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
