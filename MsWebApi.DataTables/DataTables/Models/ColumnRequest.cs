using System.Runtime.Serialization;

namespace DataTables.Models
{
    /// <summary>
    /// Holds the information required for a given column
    /// </summary>
    [DataContract]
    public class ColumnRequest
    {
        /// <summary>
        /// Specific search information for the column
        /// </summary>
        [DataMember(Name = "search")]
        public SearchRequest Search { get; set; }

        /// <summary>
        /// Column's data source, as defined by columns.data.
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }

        /// <summary>
        /// Column's name, as defined by columns.name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Flag to indicate if this column is search-able (true) or not (false). This is controlled by columns.searchable.
        /// </summary>
        [DataMember(Name = "searchable")]
        public bool? Searchable { get; set; }

        /// <summary>
        /// Flag to indicate if this column is orderable (true) or not (false). This is controlled by columns.orderable.
        /// </summary>
        [DataMember(Name = "orderable")]
        public bool? Orderable { get; set; }

    }
}
