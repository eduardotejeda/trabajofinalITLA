using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace trabajofinal


{
    public partial class Form1 : Form


    {
        public Form1()
        {
            InitializeComponent();

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox3.Text, textBox4.Text);
            iReset();
            
            
        }

        private void iReset()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void iDelete()
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void iDelete2()
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            iDelete();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rutaArchivo = @"C:\Users\FranciscoA\Desktop\datos.csv"; // Ajusta la ruta aquí
            string rutaArchivoU = @"C:\Users\FranciscoA\Desktop\usuarios.csv"; // Ajusta la ruta aquí
            CargarCSV(rutaArchivo);
            CargarCSV2(rutaArchivoU);
            CargarCSV3(rutaArchivo);
            CargarCSV4(rutaArchivoU);
        }

        private void CargarCSV3(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo)) return;

            string[] lineas = File.ReadAllLines(rutaArchivo);

            if (lineas.Length > 0)
            {
                dataGridView3.Rows.Clear();
                dataGridView3.Columns.Clear();

                // Encabezados
                string[] encabezados = lineas[0].Split(',');
                dataGridView3.ColumnCount = encabezados.Length;
                for (int i = 0; i < encabezados.Length; i++)
                {
                    dataGridView3.Columns[i].Name = encabezados[i];
                }

                // Filas
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] fila = lineas[i].Split(',');
                    dataGridView3.Rows.Add(fila);
                }
            }
        }

        private void CargarCSV4(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo)) return;

            string[] lineas = File.ReadAllLines(rutaArchivo);

            if (lineas.Length > 0)
            {
                dataGridView4.Rows.Clear();
                dataGridView4.Columns.Clear();

                // Encabezados
                string[] encabezados = lineas[0].Split(',');
                dataGridView4.ColumnCount = encabezados.Length;
                for (int i = 0; i < encabezados.Length; i++)
                {
                    dataGridView4.Columns[i].Name = encabezados[i];
                }

                // Filas
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] fila = lineas[i].Split(',');
                    dataGridView4.Rows.Add(fila);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            iReset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Mostrar diálogo para elegir dónde guardar el archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo CSV (*.csv)|*.csv";
            guardar.Title = "Guardar como archivo CSV";
            guardar.FileName = "datos.csv";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(guardar.FileName))
                {
                    // Escribir encabezados de columna
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        sw.Write(dataGridView1.Columns[i].HeaderText);
                        if (i < dataGridView1.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Escribir filas
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                    {
                        if (!fila.IsNewRow) // evitar fila vacía al final
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                sw.Write(fila.Cells[i].Value?.ToString());
                                if (i < dataGridView1.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos CSV (*.csv)|*.csv";
            openFile.Title = "Seleccionar archivo CSV";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFile.FileName;
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (lineas.Length > 0)
                {
                    // Leer encabezados
                    string[] encabezados = lineas[0].Split(',');
                    dataGridView1.ColumnCount = encabezados.Length;

                    for (int i = 0; i < encabezados.Length; i++)
                    {
                        dataGridView1.Columns[i].Name = encabezados[i];
                    }

                    // Agregar las filas restantes
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        string[] fila = lineas[i].Split(',');
                        dataGridView1.Rows.Add(fila);
                    }

                    MessageBox.Show("Datos cargados exitosamente.");
                }
            }
        }

        private void CargarCSV(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo)) return;

            string[] lineas = File.ReadAllLines(rutaArchivo);

            if (lineas.Length > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Encabezados
                string[] encabezados = lineas[0].Split(',');
                dataGridView1.ColumnCount = encabezados.Length;
                for (int i = 0; i < encabezados.Length; i++)
                {
                    dataGridView1.Columns[i].Name = encabezados[i];
                }

                // Filas
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] fila = lineas[i].Split(',');
                    dataGridView1.Rows.Add(fila);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.CurrentRow.Cells[0].Value = textBox3.Text;
                dataGridView1.CurrentRow.Cells[1].Value = textBox4.Text;
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(textBox5.Text, textBox6.Text, textBox7.Text);
            iReset();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                dataGridView2.CurrentRow.Cells[0].Value = textBox5.Text;
                dataGridView2.CurrentRow.Cells[1].Value = textBox6.Text;
                dataGridView2.CurrentRow.Cells[2].Value = textBox7.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            iDelete2();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            iReset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Mostrar diálogo para elegir dónde guardar el archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivo CSV (*.csv)|*.csv";
            guardar.Title = "Guardar como archivo CSV";
            guardar.FileName = "usuarios.csv";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(guardar.FileName))
                {
                    // Escribir encabezados de columna
                    for (int i = 0; i < dataGridView2.Columns.Count; i++)
                    {
                        sw.Write(dataGridView2.Columns[i].HeaderText);
                        if (i < dataGridView2.Columns.Count - 1)
                            sw.Write(",");
                    }
                    sw.WriteLine();

                    // Escribir filas
                    foreach (DataGridViewRow fila in dataGridView2.Rows)
                    {
                        if (!fila.IsNewRow) // evitar fila vacía al final
                        {
                            for (int i = 0; i < dataGridView2.Columns.Count; i++)
                            {
                                sw.Write(fila.Cells[i].Value?.ToString());
                                if (i < dataGridView2.Columns.Count - 1)
                                    sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                }

                MessageBox.Show("Datos guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarCSV2(string rutaArchivoU)
        {
            if (!File.Exists(rutaArchivoU)) return;

            string[] lineas = File.ReadAllLines(rutaArchivoU);

            if (lineas.Length > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                // Encabezados
                string[] encabezados = lineas[0].Split(',');
                dataGridView2.ColumnCount = encabezados.Length;
                for (int i = 0; i < encabezados.Length; i++)
                {
                    dataGridView2.Columns[i].Name = encabezados[i];
                }

                // Filas
                for (int i = 1; i < lineas.Length; i++)
                {
                    string[] fila = lineas[i].Split(',');
                    dataGridView2.Rows.Add(fila);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Archivos CSV (*.csv)|*.csv";
            openFile.Title = "Seleccionar archivo CSV";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFile.FileName;
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (lineas.Length > 0)
                {
                    // Leer encabezados
                    string[] encabezados = lineas[0].Split(',');
                    dataGridView2.ColumnCount = encabezados.Length;

                    for (int i = 0; i < encabezados.Length; i++)
                    {
                        dataGridView2.Columns[i].Name = encabezados[i];
                    }

                    // Agregar las filas restantes
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        string[] fila = lineas[i].Split(',');
                        dataGridView2.Rows.Add(fila);
                    }

                    MessageBox.Show("Datos cargados exitosamente.");
                }
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Verifica si ya está prestado
            string disponibilidad = dataGridView3.CurrentRow.Cells["disponible"].Value.ToString();
            if (disponibilidad == "No")
            {
                MessageBox.Show("Este libro ya está prestado.");
                return;
            }

            // Marcar como prestado
            dataGridView3.CurrentRow.Cells["disponible"].Value = "No";



            // Asegúrate que haya una fila seleccionada en ambos DataGridView
            if (dataGridView4.CurrentRow == null || dataGridView3.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario y un libro.");
                return;
            }

            // Obtener datos del usuario
            string idUsuario = dataGridView4.CurrentRow.Cells["id"].Value.ToString();
            string nombre = dataGridView4.CurrentRow.Cells["nombre"].Value.ToString();
            string apellido = dataGridView4.CurrentRow.Cells["apellido"].Value.ToString();

            // Obtener datos del libro
            string libro = dataGridView3.CurrentRow.Cells["titulo"].Value.ToString();

            // Agregar al DataGridView de préstamos
            dataGridView5.Rows.Add(idUsuario, nombre + " " + apellido, libro);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView5.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un préstamo a devolver.");
                return;
            }

            // Obtener el título del libro a devolver
            string libroDevuelto = dataGridView5.CurrentRow.Cells["Libro"].Value.ToString();

            // Marcar el libro como disponible nuevamente
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells["titulo"].Value.ToString() == libroDevuelto)
                {
                    row.Cells["disponible"].Value = "Sí";
                    break;
                }
            }

            // Eliminar la fila de préstamo
            dataGridView5.Rows.Remove(dataGridView5.CurrentRow);
        }
    }
}
