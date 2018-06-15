namespace Cars.Library.Domain.Cars
{
    /// <summary>
    /// Clase que representa la información de un automóvil de una modelo
    /// </summary>
    public class CarInfo
    {
        /// <summary>
        /// Obtiene o establece el identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece la imagen
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Obtiene o establece el indicador de disponibilidad
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Obtiene o establece el indicador de nuevo
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Obtiene o establece la placa
        /// </summary>
        public string License { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del modelo
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// Obtiene o establece el año de fabricación
        /// </summary>
        public int Year { get; set; }
    }
}