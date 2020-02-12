
using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class ProductDao : AbstractDaoWithPrimaryKey<ProductModel,ProductModelPrimaryKey>
    {
        public override string SelectQuery => @"select 
             [ProductID],
             [Name],
             [ProductNumber],
             [MakeFlag],
             [FinishedGoodsFlag],
             [Color],
             [SafetyStockLevel],
             [ReorderPoint],
             [StandardCost],
             [ListPrice],
             [Size],
             [SizeUnitMeasureCode],
             [WeightUnitMeasureCode],
             [Weight],
             [DaysToManufacture],
             [ProductLine],
             [Class],
             [Style],
             [ProductSubcategoryID],
             [ProductModelID],
             [SellStartDate],
             [SellEndDate],
             [DiscontinuedDate],
             [rowguid],
             [ModifiedDate]
 from [Production].[Product]";

        protected override ProductModel ToModel(SqlDataReader dataReader)
        {
            var result = new ProductModel();
             result.ProductID = (int)(dataReader["ProductID"]);
             result.Name = (string)(dataReader["Name"]);
             result.ProductNumber = (string)(dataReader["ProductNumber"]);
             result.MakeFlag = (bool)(dataReader["MakeFlag"]);
             result.FinishedGoodsFlag = (bool)(dataReader["FinishedGoodsFlag"]);
             result.Color = (string?)(dataReader["Color"] is DBNull ? null : dataReader["Color"]);
             result.SafetyStockLevel = (short)(dataReader["SafetyStockLevel"]);
             result.ReorderPoint = (short)(dataReader["ReorderPoint"]);
             result.StandardCost = (decimal)(dataReader["StandardCost"]);
             result.ListPrice = (decimal)(dataReader["ListPrice"]);
             result.Size = (string?)(dataReader["Size"] is DBNull ? null : dataReader["Size"]);
             result.SizeUnitMeasureCode = (string?)(dataReader["SizeUnitMeasureCode"] is DBNull ? null : dataReader["SizeUnitMeasureCode"]);
             result.WeightUnitMeasureCode = (string?)(dataReader["WeightUnitMeasureCode"] is DBNull ? null : dataReader["WeightUnitMeasureCode"]);
             result.Weight = (decimal?)(dataReader["Weight"] is DBNull ? null : dataReader["Weight"]);
             result.DaysToManufacture = (int)(dataReader["DaysToManufacture"]);
             result.ProductLine = (string?)(dataReader["ProductLine"] is DBNull ? null : dataReader["ProductLine"]);
             result.Class = (string?)(dataReader["Class"] is DBNull ? null : dataReader["Class"]);
             result.Style = (string?)(dataReader["Style"] is DBNull ? null : dataReader["Style"]);
             result.ProductSubcategoryID = (int?)(dataReader["ProductSubcategoryID"] is DBNull ? null : dataReader["ProductSubcategoryID"]);
             result.ProductModelID = (int?)(dataReader["ProductModelID"] is DBNull ? null : dataReader["ProductModelID"]);
             result.SellStartDate = (DateTime)(dataReader["SellStartDate"]);
             result.SellEndDate = (DateTime?)(dataReader["SellEndDate"] is DBNull ? null : dataReader["SellEndDate"]);
             result.DiscontinuedDate = (DateTime?)(dataReader["DiscontinuedDate"] is DBNull ? null : dataReader["DiscontinuedDate"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into [Production].[Product]
(
[Name],
[ProductNumber],
[MakeFlag],
[FinishedGoodsFlag],
[Color],
[SafetyStockLevel],
[ReorderPoint],
[StandardCost],
[ListPrice],
[Size],
[SizeUnitMeasureCode],
[WeightUnitMeasureCode],
[Weight],
[DaysToManufacture],
[ProductLine],
[Class],
[Style],
[ProductSubcategoryID],
[ProductModelID],
[SellStartDate],
[SellEndDate],
[DiscontinuedDate],
[rowguid],
[ModifiedDate]
)
output 
inserted.[ProductID]

VALUES
(
@Name,
@ProductNumber,
@MakeFlag,
@FinishedGoodsFlag,
@Color,
@SafetyStockLevel,
@ReorderPoint,
@StandardCost,
@ListPrice,
@Size,
@SizeUnitMeasureCode,
@WeightUnitMeasureCode,
@Weight,
@DaysToManufacture,
@ProductLine,
@Class,
@Style,
@ProductSubcategoryID,
@ProductModelID,
@SellStartDate,
@SellEndDate,
@DiscontinuedDate,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, ProductModel inserted)
        {
            inserted.ProductID = (int)id;
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, ProductModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@Name", inserted.Name);
            sqlCommand.Parameters.AddWithValue("@ProductNumber", inserted.ProductNumber);
            sqlCommand.Parameters.AddWithValue("@MakeFlag", inserted.MakeFlag);
            sqlCommand.Parameters.AddWithValue("@FinishedGoodsFlag", inserted.FinishedGoodsFlag);
            sqlCommand.Parameters.AddWithValue("@Color", inserted.Color);
            sqlCommand.Parameters.AddWithValue("@SafetyStockLevel", inserted.SafetyStockLevel);
            sqlCommand.Parameters.AddWithValue("@ReorderPoint", inserted.ReorderPoint);
            sqlCommand.Parameters.AddWithValue("@StandardCost", inserted.StandardCost);
            sqlCommand.Parameters.AddWithValue("@ListPrice", inserted.ListPrice);
            sqlCommand.Parameters.AddWithValue("@Size", inserted.Size);
            sqlCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", inserted.SizeUnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", inserted.WeightUnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@Weight", inserted.Weight);
            sqlCommand.Parameters.AddWithValue("@DaysToManufacture", inserted.DaysToManufacture);
            sqlCommand.Parameters.AddWithValue("@ProductLine", inserted.ProductLine);
            sqlCommand.Parameters.AddWithValue("@Class", inserted.Class);
            sqlCommand.Parameters.AddWithValue("@Style", inserted.Style);
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", inserted.ProductSubcategoryID);
            sqlCommand.Parameters.AddWithValue("@ProductModelID", inserted.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@SellStartDate", inserted.SellStartDate);
            sqlCommand.Parameters.AddWithValue("@SellEndDate", inserted.SellEndDate);
            sqlCommand.Parameters.AddWithValue("@DiscontinuedDate", inserted.DiscontinuedDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update [Production].[Product]
Set
    [Name]=@Name,
    [ProductNumber]=@ProductNumber,
    [MakeFlag]=@MakeFlag,
    [FinishedGoodsFlag]=@FinishedGoodsFlag,
    [Color]=@Color,
    [SafetyStockLevel]=@SafetyStockLevel,
    [ReorderPoint]=@ReorderPoint,
    [StandardCost]=@StandardCost,
    [ListPrice]=@ListPrice,
    [Size]=@Size,
    [SizeUnitMeasureCode]=@SizeUnitMeasureCode,
    [WeightUnitMeasureCode]=@WeightUnitMeasureCode,
    [Weight]=@Weight,
    [DaysToManufacture]=@DaysToManufacture,
    [ProductLine]=@ProductLine,
    [Class]=@Class,
    [Style]=@Style,
    [ProductSubcategoryID]=@ProductSubcategoryID,
    [ProductModelID]=@ProductModelID,
    [SellStartDate]=@SellStartDate,
    [SellEndDate]=@SellEndDate,
    [DiscontinuedDate]=@DiscontinuedDate,
    [rowguid]=@rowguid,
    [ModifiedDate]=@ModifiedDate

Where
[ProductID]=@ProductID 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, ProductModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Name", updated.Name);
            sqlCommand.Parameters.AddWithValue("@ProductNumber", updated.ProductNumber);
            sqlCommand.Parameters.AddWithValue("@MakeFlag", updated.MakeFlag);
            sqlCommand.Parameters.AddWithValue("@FinishedGoodsFlag", updated.FinishedGoodsFlag);
            sqlCommand.Parameters.AddWithValue("@Color", updated.Color);
            sqlCommand.Parameters.AddWithValue("@SafetyStockLevel", updated.SafetyStockLevel);
            sqlCommand.Parameters.AddWithValue("@ReorderPoint", updated.ReorderPoint);
            sqlCommand.Parameters.AddWithValue("@StandardCost", updated.StandardCost);
            sqlCommand.Parameters.AddWithValue("@ListPrice", updated.ListPrice);
            sqlCommand.Parameters.AddWithValue("@Size", updated.Size);
            sqlCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", updated.SizeUnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", updated.WeightUnitMeasureCode);
            sqlCommand.Parameters.AddWithValue("@Weight", updated.Weight);
            sqlCommand.Parameters.AddWithValue("@DaysToManufacture", updated.DaysToManufacture);
            sqlCommand.Parameters.AddWithValue("@ProductLine", updated.ProductLine);
            sqlCommand.Parameters.AddWithValue("@Class", updated.Class);
            sqlCommand.Parameters.AddWithValue("@Style", updated.Style);
            sqlCommand.Parameters.AddWithValue("@ProductSubcategoryID", updated.ProductSubcategoryID);
            sqlCommand.Parameters.AddWithValue("@ProductModelID", updated.ProductModelID);
            sqlCommand.Parameters.AddWithValue("@SellStartDate", updated.SellStartDate);
            sqlCommand.Parameters.AddWithValue("@SellEndDate", updated.SellEndDate);
            sqlCommand.Parameters.AddWithValue("@DiscontinuedDate", updated.DiscontinuedDate);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, ProductModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", updated.ProductID);
        }

        public override string DeleteQuery =>
@"delete from
    [Production].[Product]
where
[ProductID]=@ProductID 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, ProductModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", deleted.ProductID);
        }

        public override string ByPrimaryWhereConditionWithArgs => 
@"ProductID=@ProductID 
";

        public override void MapPrimaryParameters(ProductModelPrimaryKey key, SqlCommand sqlCommand)
        {
            sqlCommand.Parameters.AddWithValue("@ProductID", key.ProductID);

        }

    }
}
