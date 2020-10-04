using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Certweb.Models;

namespace Certweb
{
    public partial class EmployeeRegister : Form
    {
        public EmployeeRegister()
        {
            InitializeComponent();
        }

        private void SalvarAction(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Name = txtNome.Text;
            employee.Email = txtEmail.Text;
            employee.Salary = Decimal.Parse(txtSalary.Text);

            employee.Gender = (rbMasculino.Checked) ? "M" : "F";
            employee.ContractType = (rbCLT.Checked) ? "CLT" : (rbPJ.Checked) ? "PJ" : "AUT" ;
            employee.RegisterDate = DateTime.Now;
        }
    }
}
