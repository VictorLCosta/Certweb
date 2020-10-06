using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certweb
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            UpdateTable();
        }

        public void UpdateTable()
        {
            dgvEmployees.DataSource = Database.EmployeeDataAccess.FindAllEmployees();
        }

        private void ActionNovo(object sender, EventArgs e)
        {
            new EmployeeRegister(this).Show();
        }

        private void ActionEditar(object sender, EventArgs e)
        {
            int id = (int) dgvEmployees.SelectedRows[0].Cells[0].Value;
            new EmployeeRegister(this, id).Show();
        }
    }
}
