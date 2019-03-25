using System.ComponentModel;

namespace IListSourceImplementation.Models
{
    public class EmployeeListSource : Component, IListSource
    {
        private readonly EmployeeDataSample _sampleData = null;

        public EmployeeListSource()
        {
            this._sampleData = new EmployeeDataSample();
        }

        public EmployeeListSource(IContainer container)
        {
            container.Add(this);
            this._sampleData = new EmployeeDataSample();
        }

        public EmployeeDataSample SampleData
        {
            get { return this._sampleData; }
        }

        #region IListSource Members

        bool IListSource.ContainsListCollection
        {
            get { return false; }
        }

        System.Collections.IList IListSource.GetList()
        {
            BindingList<Employee> ble = new BindingList<Employee>();

            if (!this.DesignMode) {
                ble = new BindingList<Employee>(this.SampleData);

                //ble.Add(new Employee("Aaberg, Jesper", 26000000));
                //ble.Add(new Employee("Cajhen, Janko", 19600000));
                //ble.Add(new Employee("Furse, Kari", 19000000));
                //ble.Add(new Employee("Langhorn, Carl", 16000000));
                //ble.Add(new Employee("Todorov, Teodor", 15700000));
                //ble.Add(new Employee("Harry, Paek", 15700000));
            }

            return ble;
        }

        #endregion
    }
}
