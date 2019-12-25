using DAL.BillingCommon;
using DAL.BillingEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.BillingServices
{
    public class OwnerService
    {
        #region DropDown
        public static List<StateDropDownEntity> GetStateDD()
        {
            List<StateDropDownEntity> stateList = new List<StateDropDownEntity>();

            try
            {


                var ds = SqlHelper.GetResultSet("USP_StateList", null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        stateList.Add(new StateDropDownEntity()
                        {
                            Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()),
                            StateName = ds.Tables[0].Rows[i]["StateName"].ToString()
                        });

                    }

                }

            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return stateList;
        }
        #endregion

        public static List<OwnerEntitiy> GetOwnerList()
        {
            List<OwnerEntitiy> ownerList = new List<OwnerEntitiy>();

            try
            {
                var ds = SqlHelper.GetResultSet("USP_GetAllOwners", null);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ownerList.Add(new OwnerEntitiy()
                        {
                            Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()),
                            OwnerName = ds.Tables[0].Rows[i]["OwnerName"].ToString(),
                            GSTNo = ds.Tables[0].Rows[i]["GSTNo"].ToString(),
                            ContactNo = Convert.ToInt32(ds.Tables[0].Rows[i]["ContactNo"].ToString()),
                            OwnerAddress = ds.Tables[0].Rows[i]["OwnerAddress"].ToString()

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

        public static ManageOwnerEntity GetOwnerById(int OwnerID)
        {
            ManageOwnerEntity entity = new ManageOwnerEntity();
            entity.OwnerAddress = new OwnerAddressEntity();
            entity.OwnerBankDetails = new OwnerBankDetailEntity();
            try
            {
                SqlParameter[] values =
                    {
                new SqlParameter("@OwnerId",OwnerID)
            };

                var ds = SqlHelper.GetResultSet("USP_GetOwnerById", values);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        entity.OwnerId = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                        entity.OwnerName = ds.Tables[0].Rows[i]["OwnerName"].ToString();
                        entity.ContactNo = Convert.ToInt32(ds.Tables[0].Rows[i]["ContactNo"].ToString());
                        entity.GSTNo = ds.Tables[0].Rows[i]["GSTNo"].ToString();
                        entity.Juridication = ds.Tables[0].Rows[i]["Juridication"].ToString();
                        entity.BusinessType = ds.Tables[0].Rows[i]["BusinessType"].ToString();
                    }

                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        entity.OwnerAddress.AddressList.Add(new OwnerAddressEntity()
                        {
                            Id = Convert.ToInt32(ds.Tables[1].Rows[i]["Id"].ToString()),
                            Street1 = ds.Tables[1].Rows[i]["Street1"].ToString(),
                            Street2 = ds.Tables[1].Rows[i]["Street2"].ToString(),
                            City = ds.Tables[1].Rows[i]["City"].ToString(),
                            PostCode = Convert.ToInt32(ds.Tables[1].Rows[i]["PostCode"].ToString()),
                            StateId = Convert.ToInt32(ds.Tables[1].Rows[i]["StateId"].ToString()),
                        });
                    }

                }



                if (ds.Tables[2].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                    {
                        entity.OwnerBankDetails.OwnerBankList.Add(new OwnerBankDetailEntity()
                        {
                            Id = Convert.ToInt32(ds.Tables[2].Rows[i]["Id"].ToString()),
                            BankName = ds.Tables[2].Rows[i]["BankName"].ToString(),
                            Branch = ds.Tables[2].Rows[i]["BranchName"].ToString(),
                            AccountNumber = Convert.ToInt32(ds.Tables[2].Rows[i]["AccountNumber"].ToString()),
                            IFSC = ds.Tables[2].Rows[i]["IFSCCode"].ToString()
                        });
                    }

                }


            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return entity;
        }
    }
}
