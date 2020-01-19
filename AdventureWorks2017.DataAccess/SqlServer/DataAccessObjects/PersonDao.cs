using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class PersonDao : AbstractDao<PersonModel>
    {
        public override string SelectQuery => @"select 
             BusinessEntityID,
             PersonType,
             NameStyle,
             Title,
             FirstName,
             MiddleName,
             LastName,
             Suffix,
             EmailPromotion,
             AdditionalContactInfo,
             Demographics,
             rowguid,
             ModifiedDate
 from Person";

        protected override PersonModel ToModel(SqlDataReader dataReader)
        {
            var result = new PersonModel();
             result.BusinessEntityID = (int)(dataReader["BusinessEntityID"]);
             result.PersonType = (string)(dataReader["PersonType"]);
             result.NameStyle = (bool)(dataReader["NameStyle"]);
             result.Title = (string)(dataReader["Title"] is DBNull ? null : dataReader["Title"]);
             result.FirstName = (string)(dataReader["FirstName"]);
             result.MiddleName = (string)(dataReader["MiddleName"] is DBNull ? null : dataReader["MiddleName"]);
             result.LastName = (string)(dataReader["LastName"]);
             result.Suffix = (string)(dataReader["Suffix"] is DBNull ? null : dataReader["Suffix"]);
             result.EmailPromotion = (int)(dataReader["EmailPromotion"]);
             result.AdditionalContactInfo = (System.Xml.XmlDocument)(dataReader["AdditionalContactInfo"] is DBNull ? null : dataReader["AdditionalContactInfo"]);
             result.Demographics = (System.Xml.XmlDocument)(dataReader["Demographics"] is DBNull ? null : dataReader["Demographics"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Person
(
BusinessEntityID,
PersonType,
NameStyle,
Title,
FirstName,
MiddleName,
LastName,
Suffix,
EmailPromotion,
AdditionalContactInfo,
Demographics,
rowguid,
ModifiedDate
)

VALUES
(
@BusinessEntityID,
@PersonType,
@NameStyle,
@Title,
@FirstName,
@MiddleName,
@LastName,
@Suffix,
@EmailPromotion,
@AdditionalContactInfo,
@Demographics,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, PersonModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, PersonModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", inserted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@PersonType", inserted.PersonType);
            sqlCommand.Parameters.AddWithValue("@NameStyle", inserted.NameStyle);
            sqlCommand.Parameters.AddWithValue("@Title", inserted.Title);
            sqlCommand.Parameters.AddWithValue("@FirstName", inserted.FirstName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", inserted.MiddleName);
            sqlCommand.Parameters.AddWithValue("@LastName", inserted.LastName);
            sqlCommand.Parameters.AddWithValue("@Suffix", inserted.Suffix);
            sqlCommand.Parameters.AddWithValue("@EmailPromotion", inserted.EmailPromotion);
            sqlCommand.Parameters.AddWithValue("@AdditionalContactInfo", inserted.AdditionalContactInfo);
            sqlCommand.Parameters.AddWithValue("@Demographics", inserted.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Person
Set
    PersonType=@PersonType,
    NameStyle=@NameStyle,
    Title=@Title,
    Suffix=@Suffix,
    EmailPromotion=@EmailPromotion,
    ModifiedDate=@ModifiedDate

Where
BusinessEntityID=@BusinessEntityID  AND 
FirstName=@FirstName  AND 
MiddleName=@MiddleName  AND 
LastName=@LastName  AND 
AdditionalContactInfo=@AdditionalContactInfo  AND 
Demographics=@Demographics  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, PersonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@PersonType", updated.PersonType);
            sqlCommand.Parameters.AddWithValue("@NameStyle", updated.NameStyle);
            sqlCommand.Parameters.AddWithValue("@Title", updated.Title);
            sqlCommand.Parameters.AddWithValue("@Suffix", updated.Suffix);
            sqlCommand.Parameters.AddWithValue("@EmailPromotion", updated.EmailPromotion);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, PersonModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", updated.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@FirstName", updated.FirstName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", updated.MiddleName);
            sqlCommand.Parameters.AddWithValue("@LastName", updated.LastName);
            sqlCommand.Parameters.AddWithValue("@AdditionalContactInfo", updated.AdditionalContactInfo);
            sqlCommand.Parameters.AddWithValue("@Demographics", updated.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    Person
where
BusinessEntityID=@BusinessEntityID  AND 
FirstName=@FirstName  AND 
MiddleName=@MiddleName  AND 
LastName=@LastName  AND 
AdditionalContactInfo=@AdditionalContactInfo  AND 
Demographics=@Demographics  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, PersonModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BusinessEntityID", deleted.BusinessEntityID);
            sqlCommand.Parameters.AddWithValue("@FirstName", deleted.FirstName);
            sqlCommand.Parameters.AddWithValue("@MiddleName", deleted.MiddleName);
            sqlCommand.Parameters.AddWithValue("@LastName", deleted.LastName);
            sqlCommand.Parameters.AddWithValue("@AdditionalContactInfo", deleted.AdditionalContactInfo);
            sqlCommand.Parameters.AddWithValue("@Demographics", deleted.Demographics);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
