using DAL.BillingCommon;
using DAL.BillingEntities;
using System;
using System.Collections.Generic;
using System.Data;
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
                            ContactNo = Convert.ToInt64(ds.Tables[0].Rows[i]["ContactNo"].ToString()),
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
                        entity.ContactNo = Convert.ToInt64(ds.Tables[0].Rows[i]["ContactNo"].ToString());
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
                            AccountNumber = Convert.ToInt64(ds.Tables[2].Rows[i]["AccountNumber"].ToString()),
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

        public static OwnerAddressEntity GetOwnerAddressById(int AddressId)
        {
            OwnerAddressEntity ownerAddressEntity = new OwnerAddressEntity();

            try
            {
                SqlParameter[] values =
                {
                    new SqlParameter("@AdressId",AddressId)
                };
                var ds = SqlHelper.GetResultSet("USP_GetOwnerAddressById", values);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ownerAddressEntity.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                        ownerAddressEntity.Street1 = ds.Tables[0].Rows[i]["Street1"].ToString();
                        ownerAddressEntity.Street2 = ds.Tables[0].Rows[i]["Street2"].ToString();
                        ownerAddressEntity.City = ds.Tables[0].Rows[i]["City"].ToString();
                        ownerAddressEntity.PostCode = Convert.ToInt32(ds.Tables[0].Rows[i]["PostCode"].ToString());
                        ownerAddressEntity.StateId = Convert.ToInt32(ds.Tables[0].Rows[i]["StateId"].ToString());

                    }
                }


            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }


            return ownerAddressEntity;
        }

        public static bool DeleteOwnerAddress(int AddressId, int OwnerId)
        {
            try
            {
                SqlParameter[] values =
                {
                    new SqlParameter("@OwnerId",OwnerId),
                    new SqlParameter("@AddressId",AddressId)

                };

                var i = SqlHelper.ExecuteSp("USP_DeleteOwnerAddress", values);

                return i > 0;
            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return false;
        }

        public static OwnerBankDetailEntity GetOwnerBankDetail(int BankId)
        {
            OwnerBankDetailEntity owner = new OwnerBankDetailEntity();

            try
            {
                SqlParameter[] values =
                  {
                new SqlParameter("@BankId",BankId)
            };

                var ds = SqlHelper.GetResultSet("USP_GetBankDetailById", values);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        owner.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                        owner.BankName = ds.Tables[0].Rows[i]["BankName"].ToString();
                        owner.Branch = ds.Tables[0].Rows[i]["BranchName"].ToString();
                        owner.AccountNumber = Convert.ToInt64(ds.Tables[0].Rows[i]["AccountNumber"].ToString());
                        owner.IFSC = ds.Tables[0].Rows[i]["IFSCCode"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return owner;
        }

        public static bool DeleteBankDetail(int BankId, int OwnerId)
        {
            try
            {
                SqlParameter[] values =
                {
                    new SqlParameter("@OwnerId",OwnerId),
                    new SqlParameter("@BankId",BankId)




                };

                var i = SqlHelper.ExecuteSp("USP_DeleteBankDetail", values);

                return i > 0;
            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return false;
        }


        public static bool CreateUpdateOwner(ManageOwnerEntity response)
        {

            try
            {

                DataTable AddressTable = UserDefinedDataTable.AddressDataTable();
                foreach (var item in response.OwnerAddress.AddressList)
                {
                    AddressTable.Rows.Add(item.Id, item.Street1, item.Street2, item.City, item.PostCode, item.StateId, response.OwnerId, item.IsCreated, item.IsUpdated);

                }

                DataTable BankTable = UserDefinedDataTable.BankDataTable();
                foreach (var item in response.OwnerBankDetails.OwnerBankList)
                {
                    BankTable.Rows.Add(item.Id, item.BankName, item.Branch, item.AccountNumber, item.IFSC, response.OwnerId, item.IsCreated, item.IsCreated);
                }

                //con.Open();

                SqlParameter[] values =
                {
                    new SqlParameter("@OwnerId",response.OwnerId),
                    new SqlParameter("@OwnerName",response.OwnerName),
                    new SqlParameter("@ContactNo",response.ContactNo),
                    new SqlParameter("@GSTNo",response.GSTNo),
                    new SqlParameter("@Juridication",response.Juridication),
                    new SqlParameter("@BusinessType",response.BusinessType),
                    new SqlParameter("@OwnerAddresses",AddressTable),
                    new SqlParameter("@OwnerBankDetails",BankTable)


                };

                var ds = SqlHelper.ExecuteSp("USP_CreateUpdateOwner", values);
                return ds > 0;

            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);

            }

            return false;

        }

        public static bool DeleteOwner(int OwnerId)
        {
            try
            {
                SqlParameter[] values =
                {
                    new SqlParameter("@OwnerId",OwnerId)
                };
                var i = SqlHelper.ExecuteSp("USP_DeleteOwner", values);

                return i > 0;
            }
            catch (Exception ex)
            {

                ApplicationCommon.WriteLog(ex.Message);
            }

            return false;
        }

        public static ManageInvoiceEntity GetInvoiceByOwnerId(int OwnerId)
        {

        }
    }
}
