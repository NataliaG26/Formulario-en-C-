using Formulario.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class Form1 : Form    {

        DataTable table;
        Data data = new Data();

        public Form1()
        {
            InitializeComponent();
            Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Celphone = txtCelphone.Text
            };
            
            data.Write(user);
            Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Clear();
            table.Clear();
            Start();
            Consultar();
          
        }

        private void Start()
        {

            table = new DataTable();
            table.Columns.Add("Nombre");
            table.Columns.Add("Apellido");
            table.Columns.Add("Correo");
            table.Columns.Add("Celular");
            grid.DataSource = table;
        }

        private void Consultar()
        {
            data.Read();
            foreach (var item in data.getList())
            {
                DataRow row = table.NewRow();
                row["Nombre"] = item.Name;
                row["Apellido"] = item.LastName;
                row["Correo"] = item.Email;
                row["Celular"] = item.Celphone;
                table.Rows.Add(row);
            }
        }

        private void Clear()
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtCelphone.Text = "";
        }
    }
}
