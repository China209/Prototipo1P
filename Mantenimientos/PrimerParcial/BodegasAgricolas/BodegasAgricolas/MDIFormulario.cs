using BodegasAgricolas.Mantenimientos.Bodega;
using BodegasAgricolas.Mantenimientos.Cargo;
using BodegasAgricolas.Mantenimientos.Categoria;
using BodegasAgricolas.Mantenimientos.Cliente;
using BodegasAgricolas.Mantenimientos.Empleado;
using BodegasAgricolas.Mantenimientos.Producto;
using BodegasAgricolas.Mantenimientos.Proveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegasAgricolas
{
    public partial class MDIFormulario : Form
    {
        public MDIFormulario()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenid@ a Bodegas Agricolas", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoCargo cargo = new IngresoCargo();
            cargo.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoCategoria categoria = new IngresoCategoria();
            categoria.Show();
        }

        private void bodegaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoBodega bodega = new IngresoBodega();
            bodega.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoProducto producto = new IngresoProducto();
            producto.Show();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoEmpleado empleado = new IngresoEmpleado();
            empleado.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoCliente cliente = new IngresoCliente();
            cliente.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresoProveedor proveedor = new IngresoProveedor();
            proveedor.Show();
        }
    }
}
