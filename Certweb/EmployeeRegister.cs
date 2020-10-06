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
using Certweb.Database;
using System.ComponentModel.DataAnnotations;

namespace Certweb
{
    public partial class EmployeeRegister : Form
    {
        private Principal _telaPrincipal;

        public EmployeeRegister(Principal telaPrincipal)
        {
            InitializeComponent();
            _telaPrincipal = telaPrincipal;
        }

        private async void SalvarAction(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Name = txtNome.Text;
            employee.Email = txtEmail.Text;
            employee.Salary = Decimal.Parse(txtSalary.Text);

            employee.Gender = (rbMasculino.Checked) ? "M" : "F";
            employee.ContractType = (rbCLT.Checked) ? "CLT" : (rbPJ.Checked) ? "PJ" : "AUT" ;
            employee.RegisterDate = DateTime.Now;

            List<ValidationResult> errors = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(employee);
            bool validate = Validator.TryValidateObject(employee, context, errors, true);

            if (validate)
            {
                if(await EmployeeDataAccess.CreateEmployee(employee))
                {
                    _telaPrincipal.UpdateTable();
                    this.Close();
                }
                else
                {
                    lblErrors.Text = "Erro na inserção - Banco";
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (ValidationResult error in errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
                lblErrors.Text = sb.ToString();

            }
        }

    }
}
