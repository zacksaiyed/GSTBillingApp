using System.Data;

namespace DAL.BillingCommon
{
    public class UserDefinedDataTable
    {
        public static DataTable AddressDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Street1", typeof(string));
            dataTable.Columns.Add("Street2", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("PostCode", typeof(string));
            dataTable.Columns.Add("OwnerState", typeof(int));
            dataTable.Columns.Add("OwnerId", typeof(int));
            dataTable.Columns.Add("IsUpdated", typeof(bool));
            dataTable.Columns.Add("IsCreated", typeof(bool));
            
            return dataTable;
        }


        public static DataTable BankDataTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("BankName", typeof(string));
            dataTable.Columns.Add("BranchName", typeof(string));
            dataTable.Columns.Add("AccountNumber", typeof(int));
            dataTable.Columns.Add("IFSCCode", typeof(string));
            dataTable.Columns.Add("OwnerId", typeof(int));
            dataTable.Columns.Add("IsUpdated", typeof(bool));
            dataTable.Columns.Add("IsCreated", typeof(bool));

            return dataTable;
        }




    }
}
