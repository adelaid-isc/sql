using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexion exitosa");

            dgv.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM ALUMNOS;";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNOS (ID, NOMBRES, APELLIDOS, EDAD) VALUES (@ID, @NOMBRES, @APELLIDOS, @EDAD);";
            SqlCommand cmd = new SqlCommand(insertar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@NOMBRES", txtNombre.Text);
            cmd.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text);
            cmd.Parameters.AddWithValue("@EDAD", int.Parse(txtEdad.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Datos agregados con exito");

            dgv.DataSource = llenar_grid();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtApellidos.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                txtEdad.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            }

            catch
            {

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNOS SET ID=@ID, NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS, EDAD=@EDAD WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(actualizar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@NOMBRES", txtNombre.Text);
            cmd.Parameters.AddWithValue("@APELLIDOS", txtApellidos.Text);
            cmd.Parameters.AddWithValue("@EDAD", int.Parse(txtEdad.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Datos modificados con exito");

            dgv.DataSource = llenar_grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM ALUMNOS WHERE ID=@ID;";
            SqlCommand cmd = new SqlCommand(eliminar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));

            cmd.ExecuteNonQuery();

            MessageBox.Show("Datos eliminados con exito");

            dgv.DataSource = llenar_grid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtEdad.Clear();
            txtId.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string buscar = "SELECT * FROM ALUMNOS WHERE NOMBRES LIKE @NOMBRES + '%';";
            SqlCommand cmd = new SqlCommand(buscar, Conexion.Conectar());
            cmd.Parameters.AddWithValue("@NOMBRES", txtBuscar.Text);

            cmd.ExecuteNonQuery();

            dgv.DataSource = llenar_grid();
        }
    }
}
