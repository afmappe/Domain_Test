using System.Runtime.Serialization;

namespace Cars.Library.Infrastructure.Common.Entities
{
    /// <summary>
    /// Entidad utilizada para los parámetros de búsqueda
    /// </summary>
    public class SearchInfo : PaginationInfo
    {
        private string search;

        /// <summary>
        /// Parámetro de búsqueda
        /// </summary>
        [DataMember(Name = "search")]
        public string Search
        {
            get { return search == null ? string.Empty : search.Trim(); }
            set { search = value; }
        }
    }
}