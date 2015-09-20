using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataTables.Models
{
    /// <summary>
    /// This class holds the minimum amount of information provided by DataTable to perform a request on server side.
    /// </summary>
    [DataContract]
    public class DataTableRequest
    {
        /// <summary>
        /// Column data request description
        /// </summary>
        [DataMember(Name = "columns")]
        public List<ColumnRequest> Columns { get; set; }

        /// <summary>
        /// Column requested order description
        /// </summary>
        [DataMember(Name = "order")]
        public List<OrderRequest> Order { get; set; }

        /// <summary>
        /// Global search value. To be applied to all columns which have search-able as true.
        /// </summary>
        [DataMember(Name = "search")]
        public SearchRequest Search { get; set; }

        /// <summary>
        /// Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        /// </summary>
        [DataMember(Name = "start")]
        public int? Start { get; set; }

        /// <summary>
        /// Number of records that the table can display in the current draw. It is expected that the number of records returned will be equal to this number, unless the server has fewer records to return. 
        /// </summary>
        [DataMember(Name = "length")]
        public int? Length { get; set; }

        /// <summary>
        /// Draw counter. This is used by DataTables to ensure that the Ajax returns from server-side processing requests are drawn in sequence by DataTables (Ajax requests are asynchronous and thus can return out of sequence). 
        /// This is used as part of the draw return parameter. 
        /// </summary>
        [DataMember(Name = "draw")]
        public int? Draw { get; set; }
    }
}
