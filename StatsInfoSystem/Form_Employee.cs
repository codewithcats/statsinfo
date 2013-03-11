using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatsInfoSystem
{
    public partial class Form_Employee : UserControl
    {
        public Form_Employee()
        {
            InitializeComponent();
            using (var context = new StsContext())
            {
                department_cmb.DataSource = context.Departments.ToArray();
                department_cmb.DisplayMember = "Code";
                department_cmb.ValueMember = "Id";

                importEmployee_listBox.DisplayMember = "FirstName";
                importEmployee_listBox.ValueMember = "Id";

                employee_listBox.DataSource = context.Employees.ToArray();
                employee_listBox.DisplayMember = "FullName";
                employee_listBox.ValueMember = "Id";
            }
        }

        private void addEmployee_btn_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee
            {
                Code = employeeCode_txtBox.Text,
                FirstName = employeeFirstName_txtBox.Text,
                LastName = employeeLastName_txtBox.Text,
                Username = username_txtBox.Text,
                Password = password_txtBox.Text
            };
            using (var context = new StsContext())
            {
                Department department = (Department) department_cmb.SelectedItem;
                var deptQuery = from d in context.Departments where d.Id == department.Id select d;
                emp.Department = deptQuery.Single();
                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }

        private void openFile_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                employeeImport_txtBox.Text = openFileDialog.FileName;
            }
        }

        private void employeeImport_btn_Click(object sender, EventArgs e)
        {
            try
            {
                String xlsName = null;
                if ((xlsName = openFileDialog.FileName) != null)
                {
                    using (var context = new StsContext())
                    {
                        var excel = new Microsoft.Office.Interop.Excel.Application();
                        var workbooks = excel.Workbooks.Open(xlsName);
                        var sheet = workbooks.Sheets["department"];
                        var range = sheet.UsedRange;
                        var i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            var dept = new Department
                            {
                                Code = row.Cells[1, 1].Value.ToString(),
                                Name = row.Cells[1, 2].Value.ToString()
                            };
                            context.Departments.Add(dept);
                        }
                        context.SaveChanges();
                        department_cmb.DataSource = context.Departments.ToArray();

                        sheet = workbooks.Sheets["user"];
                        range = sheet.UsedRange;
                        i = 0;
                        foreach (var row in range.Rows)
                        {
                            if (i++ == 0) continue;
                            if (row.Cells[1, 1].Value == null) continue;
                            var emp = new Employee
                            {
                                Code = row.Cells[1, 1].Value.ToString(),
                                FirstName = row.Cells[1, 2].Value.ToString(),
                                LastName = row.Cells[1, 3].Value.ToString(),
                                Username = row.Cells[1, 4].Value.ToString(),
                                Password = row.Cells[1, 5].Value.ToString()
                            };
                            string deptCode = row.Cells[1, 6].Value.ToString();
                            var deptQuery = from d in context.Departments where d.Code == deptCode select d;
                            var department = deptQuery.Single();
                            emp.Department = department;
                            context.Employees.Add(emp);
                            context.SaveChanges();
                        }
                        importEmployee_listBox.DataSource = context.Employees.ToArray();
                    }

                    MessageBox.Show("นำเข้าข้อมูลเรียบร้อยแล้ว");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        private void employee_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emp = (Employee)employee_listBox.SelectedItem;
            employeeCode_txtBox.Text = emp.Code;
            employeeFirstName_txtBox.Text = emp.FirstName;
            employeeLastName_txtBox.Text = emp.LastName;
            username_txtBox.Text = emp.Username;
            department_cmb.SelectedItem = emp.Department;
        }
    }
}
