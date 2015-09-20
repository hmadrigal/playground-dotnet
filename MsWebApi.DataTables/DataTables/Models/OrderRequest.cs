using System.Runtime.Serialization;

namespace DataTables.Models
{
    /// <summary>
    /// Contains the information about the sort request
    /// </summary>
    [DataContract]
    public class OrderRequest
    {
        /// <summary>
        /// Indicates the orientation of the sort "asc" for ascending or "desc" for desc
        /// </summary>
        [DataMember(Name = "dir")]
        public string Dir { get; set; }

        /// <summary>
        /// Column which contains the number of column which requires this sort.
        /// </summary>
        [DataMember(Name = "column")]
        public int? Column { get; set; }

        public string ToExpression(DataTableRequest request)
        {
            return string.Concat(request.Columns[Column.Value].Data, " ", Dir);
        }
    }
}
