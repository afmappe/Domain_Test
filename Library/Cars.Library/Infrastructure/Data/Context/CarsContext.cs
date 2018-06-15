using Cars.Library.Domain.Brands;
using Cars.Library.Domain.Cars;
using Cars.Library.Domain.Models;
using Cars.Library.Infrastructure.Data.Mappers;
using System.Data.Common;
using System.Data.Entity;

namespace Cars.Library.Infrastructure.Data.Context
{
    /// <summary>
    /// Contexto de acceso a datos
    /// </summary>
    public class CarsContext : DbContext
    {
        #region propiedades

        /// <summary>
        /// Esquema de la base de datos
        /// </summary>
        protected readonly string Schema;

        /// <summary>
        /// Conjunto de datos de marcas
        /// </summary>
        public DbSet<BrandInfo> Brand { get; set; }

        /// <summary>
        /// Conjunto de datos de automóviles
        /// </summary>
        public DbSet<CarInfo> Car { get; set; }

        /// <summary>
        /// Conjunto de datos de modelos
        /// </summary>
        public DbSet<ModelInfo> Model { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor estático
        /// Un constructor estático se utiliza para inicializa cualquier dato estático o realizar una acción determinada
        /// que solo debe realizarse una vez. Es llamado automáticamente antes de crear la primera instancia o de hacer
        /// referencia a cualquier miembro estático.
        /// <a href="https://msdn.microsoft.com/es-co/library/k9x6w0hc(v=vs.110).aspx"></a>
        /// </summary>
        static CarsContext()
        {
            //Deshabilitar la inicializacion de la base de datos
            Database.SetInitializer<CarsContext>(null);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connection">Una conexión existente para usar para el nuevo contexto.</param>
        /// <param name="schema">Esquema de la base de datos</param>
        public CarsContext(DbConnection connection, string schema) :
           base(connection, true)
        {
            Schema = schema;
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion

        #region Implementación de DBContext

        /// <summary>
        /// Sobrecarga de <see cref="DbContext.OnModelCreating"/>
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Agregar los mappers de las entidades
            modelBuilder.Configurations.Add(new BrandMapper(Schema));
            modelBuilder.Configurations.Add(new CarMapper(Schema));
            modelBuilder.Configurations.Add(new ModelMapper(Schema));
        }

        #endregion
    }
}