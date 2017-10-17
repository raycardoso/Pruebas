using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAnyadir_Click(object sender, EventArgs e)
        {
            if (HayError())
                return;

            double precio = Convert.ToDouble(txtPrecio.Text);

            // si no hay error añado la pintura a la lista y al combo
            listaPinturas.Add(new Pintura(nuevoColor, txtNombreColor.Text, precio));
            cbColor.Items.Add(new Pintura(nuevoColor, txtNombreColor.Text, precio));

            MessageBox.Show("La pintura ha sido añadida a la lista", "Operación OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        bool HayError()
        {
            bool error = false;
            string mensajeError = "";
            double precio;
            errorProvider1.Clear();

            if (txtNombreColor.Text.Length < 1)
            {
                error = true;
                mensajeError = "Debe escribir el nombre del color\n";

            }
            else
            {
                foreach (Pintura p in listaPinturas)
                    if (txtNombreColor.Text == p.Nombre)
                    {
                        error = true;
                        mensajeError += "Ya existe un color con dicho nombre\n";
                        break;
                    }
            }

            if (txtPrecio.Text.Length < 1)
            {
                error = true;
                mensajeError += "Debe introducir el precio\n";
            }
            else if (!Double.TryParse(txtPrecio.Text, out precio))
            {
                error = true;
                mensajeError += "No ha indicado un precio válido\n";
            }

            if (nuevoColor == this.BackColor)
            {
                error = true;
                mensajeError += "Debe elegir un color\n";
            }
            else
            {
                foreach (Pintura p in listaPinturas)
                    if (nuevoColor == p._Color)
                    {
                        error = true;
                        mensajeError += "Ya existe el color elegido\n";
                        break;
                    }
            }

            if (error)
                MessageBox.Show(mensajeError, "Hay error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return error;
        }

    }
}
