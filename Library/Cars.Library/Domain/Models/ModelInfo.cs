namespace Cars.Library.Domain.Models
{
    /// <summary>
    /// Clase que representa la información de modelo de una marca
    /// </summary>
    public class ModelInfo
    {
        /// <summary>
        /// Obtiene o establece el identificador de la marca
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre
        /// </summary>
        public string Name { get; set; }
    }
}