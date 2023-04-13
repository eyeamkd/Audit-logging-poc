namespace AuditLoggerPoc.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TableAnnotationAttribute : Attribute
    {
        public TableAnnotationAttribute(string contextName, string tableName)
        {
            ContextName = contextName;
            TableName = tableName;
        }

        public string ContextName { get; }
        public string TableName { get; }
    }

}
