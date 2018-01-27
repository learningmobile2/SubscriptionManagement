using System;

namespace DataAnnotation
{
    public class DataFieldAttribute:Attribute
    {
        string ColumnName { get; set; }
        string ConvertMethod { get; set; }
    }
}
