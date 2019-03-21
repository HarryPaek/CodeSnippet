using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace IListSourceImplementation.Models
{
    public class EmployeeDataSample: List<Employee>
    {
        public EmployeeDataSample()
        {
            Init();
        }

        public List<Employee> Samples
        {
            get { return new List<Employee>(this); }
        }

        private void Init()
        {
            Employee employee = null;

            employee = new Employee("Aaberg, Jesper", 26000000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);

            employee = new Employee("Cajhen, Janko", 19600000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);

            employee = new Employee("Furse, Kari", 19000000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);

            employee = new Employee("Langhorn, Carl", 16000000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);

            employee = new Employee("Todorov, Teodor", 15700000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);

            employee = new Employee("Harry, Paek", 15700000);
            employee.PropertyChanged += Employee_PropertyChanged;
            this.Add(employee);
        }

        private void Employee_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show(string.Format("sender = [{0}]{2}PropertyName = [{1}]", sender, e.PropertyName, Environment.NewLine));
        }
    }
}
