
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class BillOfMaterialsDao : AbstractDaoWithPrimaryKey<BillOfMaterialsModel,BillOfMaterialsModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [BillOfMaterialsID],
             [ProductAssemblyID],
             [ComponentID],
             [StartDate],
             [EndDate],
             [UnitMeasureCode],
             [BOMLevel],
             [PerAssemblyQty],
             [ModifiedDate]
 from [Production].[BillOfMaterials]";

        protected override BillOfMaterialsModel ToModel(SqlDataReader dataReader)
        {
            var result = new BillOfMaterialsModel();
             result.BillOfMaterialsID = (int)(dataReader["BillOfMaterialsID"]);
             result.ProductAssemblyID = (int?)(dataReader["ProductAssemblyID"] is DBNull ? null : dataReader["ProductAssemblyID"]);
             result.ComponentID = (int)(dataReader["ComponentID"]);
             result.StartDate = (DateTime)(dataReader["StartDate"]);
             result.EndDate = (DateTime?)(dataReader["EndDate"] is DBNull ? null : dataReader["EndDate"]);
             result.UnitMeasureCode = (string)(dataReader["UnitMeasureCode"]);
             result.BOMLevel = (short)(dataReader["BOMLevel"]);
             result.PerAssemblyQty = (decimal)(dataReader["PerAssemblyQty"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[BillOfMaterials]
(
[ProductAssemblyID],
[ComponentID],
[StartDate],
[EndDate],
[UnitMeasureCode],
[BOMLevel],
[PerAssemblyQty],
[ModifiedDate]
)
output 
inserted.[BillOfMaterialsID]

VALUES
(
@ProductAssemblyID,
@ComponentID,
@StartDate,
@EndDate,
@UnitMeasureCode,
@BOMLevel,
@PerAssemblyQty,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, BillOfMaterialsModel inserted)
        {
            inserted.BillOfMaterialsID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, BillOfMaterialsModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductAssemblyID", inserted.ProductAssemblyID);
            sqlCommand.Parameters.AddWithValue("@ComponentID", inserted.ComponentID);
            sqlCommand.Parameters.AddWithValue("@StartDate", inserted.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", inserted.EndDate);
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", inserted.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@BOMLevel", inserted.BOMLevel);
            sqlCommand.Parameters.AddWithValue("@PerAssemblyQty", inserted.PerAssemblyQty);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[BillOfMaterials]
Set
    [ProductAssemblyID]=@ProductAssemblyID,
    [ComponentID]=@ComponentID,
    [StartDate]=@StartDate,
    [EndDate]=@EndDate,
    [UnitMeasureCode]=@UnitMeasureCode,
    [BOMLevel]=@BOMLevel,
    [PerAssemblyQty]=@PerAssemblyQty,
    [ModifiedDate]=@ModifiedDate

Where
[BillOfMaterialsID]=@BillOfMaterialsID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, BillOfMaterialsModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductAssemblyID", updated.ProductAssemblyID);
            sqlCommand.Parameters.AddWithValue("@ComponentID", updated.ComponentID);
            sqlCommand.Parameters.AddWithValue("@StartDate", updated.StartDate);
            sqlCommand.Parameters.AddWithValue("@EndDate", updated.EndDate);
            sqlCommand.Parameters.AddWithValue("@UnitMeasureCode", updated.UnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@BOMLevel", updated.BOMLevel);
            sqlCommand.Parameters.AddWithValue("@PerAssemblyQty", updated.PerAssemblyQty);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, BillOfMaterialsModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@BillOfMaterialsID", updated.BillOfMaterialsID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[BillOfMaterials]
where
[BillOfMaterialsID]=@BillOfMaterialsID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, BillOfMaterialsModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@BillOfMaterialsID", deleted.BillOfMaterialsID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"BillOfMaterialsID=@BillOfMaterialsID 
";

        public override void MapPrimaryParameters(BillOfMaterialsModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@BillOfMaterialsID", key.BillOfMaterialsID);

        }

    }
}
