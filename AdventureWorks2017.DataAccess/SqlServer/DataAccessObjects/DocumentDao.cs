using System;
using System.Data.SqlClient;
using AdventureWorks2017.Models;

namespace AdventureWorks2017.SqlServer.DataAccessObjects
{
    public class DocumentDao : AbstractDao<DocumentModel>
    {
        public override string SelectQuery => @"select 
             DocumentNode,
             DocumentLevel,
             Title,
             Owner,
             FolderFlag,
             FileName,
             FileExtension,
             Revision,
             ChangeNumber,
             Status,
             DocumentSummary,
             Document,
             rowguid,
             ModifiedDate
 from Document";

        protected override DocumentModel ToModel(SqlDataReader dataReader)
        {
            var result = new DocumentModel();
             result.DocumentNode = (string)(dataReader["DocumentNode"]);
             result.DocumentLevel = (short)(dataReader["DocumentLevel"] is DBNull ? null : dataReader["DocumentLevel"]);
             result.Title = (string)(dataReader["Title"]);
             result.Owner = (int)(dataReader["Owner"]);
             result.FolderFlag = (bool)(dataReader["FolderFlag"]);
             result.FileName = (string)(dataReader["FileName"]);
             result.FileExtension = (string)(dataReader["FileExtension"]);
             result.Revision = (string)(dataReader["Revision"]);
             result.ChangeNumber = (int)(dataReader["ChangeNumber"]);
             result.Status = (byte)(dataReader["Status"]);
             result.DocumentSummary = (string)(dataReader["DocumentSummary"] is DBNull ? null : dataReader["DocumentSummary"]);
             result.Document = (byte[])(dataReader["Document"] is DBNull ? null : dataReader["Document"]);
             result.rowguid = (Guid)(dataReader["rowguid"]);
             result.ModifiedDate = (DateTime)(dataReader["ModifiedDate"]);
            return result;
        }
        
        public override string InsertQuery => @"Insert Into Document
(
DocumentNode,
DocumentLevel,
Title,
Owner,
FolderFlag,
FileName,
FileExtension,
Revision,
ChangeNumber,
Status,
DocumentSummary,
Document,
rowguid,
ModifiedDate
)

VALUES
(
@DocumentNode,
@DocumentLevel,
@Title,
@Owner,
@FolderFlag,
@FileName,
@FileExtension,
@Revision,
@ChangeNumber,
@Status,
@DocumentSummary,
@Document,
@rowguid,
@ModifiedDate
)";

        public override void InsertionGeneratedAutoIdMapping(object id, DocumentModel inserted)
        {
        }

        public override void InsertionParameterMapping(SqlCommand sqlCommand, DocumentModel inserted)
        {
            sqlCommand.Parameters.AddWithValue("@DocumentNode", inserted.DocumentNode);
            sqlCommand.Parameters.AddWithValue("@DocumentLevel", inserted.DocumentLevel);
            sqlCommand.Parameters.AddWithValue("@Title", inserted.Title);
            sqlCommand.Parameters.AddWithValue("@Owner", inserted.Owner);
            sqlCommand.Parameters.AddWithValue("@FolderFlag", inserted.FolderFlag);
            sqlCommand.Parameters.AddWithValue("@FileName", inserted.FileName);
            sqlCommand.Parameters.AddWithValue("@FileExtension", inserted.FileExtension);
            sqlCommand.Parameters.AddWithValue("@Revision", inserted.Revision);
            sqlCommand.Parameters.AddWithValue("@ChangeNumber", inserted.ChangeNumber);
            sqlCommand.Parameters.AddWithValue("@Status", inserted.Status);
            sqlCommand.Parameters.AddWithValue("@DocumentSummary", inserted.DocumentSummary);
            sqlCommand.Parameters.AddWithValue("@Document", inserted.Document);
            sqlCommand.Parameters.AddWithValue("@rowguid", inserted.rowguid);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", inserted.ModifiedDate);

        }

        public override string UpdateQuery =>
            @"Update Document
Set
    Title=@Title,
    Owner=@Owner,
    FolderFlag=@FolderFlag,
    FileExtension=@FileExtension,
    ChangeNumber=@ChangeNumber,
    Status=@Status,
    DocumentSummary=@DocumentSummary,
    Document=@Document,
    ModifiedDate=@ModifiedDate

Where
DocumentNode=@DocumentNode  AND 
DocumentLevel=@DocumentLevel  AND 
FileName=@FileName  AND 
Revision=@Revision  AND 
rowguid=@rowguid 
";

        public override void UpdateParameterMapping(SqlCommand sqlCommand, DocumentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@Title", updated.Title);
            sqlCommand.Parameters.AddWithValue("@Owner", updated.Owner);
            sqlCommand.Parameters.AddWithValue("@FolderFlag", updated.FolderFlag);
            sqlCommand.Parameters.AddWithValue("@FileExtension", updated.FileExtension);
            sqlCommand.Parameters.AddWithValue("@ChangeNumber", updated.ChangeNumber);
            sqlCommand.Parameters.AddWithValue("@Status", updated.Status);
            sqlCommand.Parameters.AddWithValue("@DocumentSummary", updated.DocumentSummary);
            sqlCommand.Parameters.AddWithValue("@Document", updated.Document);
            sqlCommand.Parameters.AddWithValue("@ModifiedDate", updated.ModifiedDate);
        }

        public override void UpdateWhereParameterMapping(SqlCommand sqlCommand, DocumentModel updated)
        {
            sqlCommand.Parameters.AddWithValue("@DocumentNode", updated.DocumentNode);
            sqlCommand.Parameters.AddWithValue("@DocumentLevel", updated.DocumentLevel);
            sqlCommand.Parameters.AddWithValue("@FileName", updated.FileName);
            sqlCommand.Parameters.AddWithValue("@Revision", updated.Revision);
            sqlCommand.Parameters.AddWithValue("@rowguid", updated.rowguid);
        }

        public override string DeleteQuery =>
@"delete from
    Document
where
DocumentNode=@DocumentNode  AND 
DocumentLevel=@DocumentLevel  AND 
FileName=@FileName  AND 
Revision=@Revision  AND 
rowguid=@rowguid 
";

        public override void DeleteWhereParameterMapping(SqlCommand sqlCommand, DocumentModel deleted)
        {
            sqlCommand.Parameters.AddWithValue("@DocumentNode", deleted.DocumentNode);
            sqlCommand.Parameters.AddWithValue("@DocumentLevel", deleted.DocumentLevel);
            sqlCommand.Parameters.AddWithValue("@FileName", deleted.FileName);
            sqlCommand.Parameters.AddWithValue("@Revision", deleted.Revision);
            sqlCommand.Parameters.AddWithValue("@rowguid", deleted.rowguid);
        }
    }
}
