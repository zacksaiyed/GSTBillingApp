using DAL.BillingCommon;
using DAL.BillingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BillingServices
{
    public  class OwnerService
    {
        public static List<OwnerEntitiy> GetOwnerList()
        {
            List<OwnerEntitiy> ownerList = new List<OwnerEntitiy>();

            try
            {
                var ds = SqlHelper.GetResultSet("USP_GetAllOwners", null);

                if (ds.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ownerList.Add(new OwnerEntitiy()
                        {
                            Id=Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()),
                            OwnerName= ds.Tables[0].Rows[i]["OwnerName"].ToString(),
                            GSTNo = ds.Tables[0].Rows[i]["GSTNo"].ToString(),
                            ContactNo = Convert.ToInt32(ds.Tables[0].Rows[i]["ContactNo"].ToString()),
                            OwnerAddress= ds.Tables[0].Rows[i]["OwnerAddress"].ToString()

                        });

                    }

                }

                
            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return ownerList;

        }
    }
}
