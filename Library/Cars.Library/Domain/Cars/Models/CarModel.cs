using Cars.Library.Infrastructure.Common.Entities;

namespace Cars.Library.Domain.Cars.Models
{
    public class CarModel
    {
        /// Identificador de la marca
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Nombre de la marca
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Identificador único
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Imagen
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Indicador de disponibilidad
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Indicador de nuevo
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Placa
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Identificador del modelo
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Nombre del modelo
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Año de fabricación
        /// </summary>
        public int Year { get; set; }
    }

    public class CarSearch : SearchInfo
    {
        private int[] _ModelIds;
        private int[] _Years;

        /// <summary>
        /// Indicador de nuevo
        /// </summary>
        public bool IsNew { get; set; }

        public int[] ModelIds
        {
            get { return _ModelIds ?? new int[] { }; }
            set { _ModelIds = value; }
        }

        public int[] Years
        {
            get { return _Years ?? new int[] { }; }
            set { _Years = value; }
        }
    }
}