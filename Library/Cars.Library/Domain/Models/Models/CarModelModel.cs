namespace Cars.Library.Domain.Models.Models
{
    public class CarModelModel
    {
        /// <summary>
        /// Identificador de la marca a la que pertenece el modelo
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Nombre de la marca a la que pertenece el modelo
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Identificador único
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del modelo
        /// </summary>
        public string Name { get; set; }
    }
}