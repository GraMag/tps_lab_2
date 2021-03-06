using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;

        public enum ETipo
        {
            Moto, Automovil, Camioneta, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto. Inicializa la lista
        /// </summary>
        private Taller()
        {
            vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Instancia un taller
        /// </summary>
        /// <param name="espacioDisponible">Espacios disponibles</param>
        public Taller(int espacioDisponible)
            :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Lista de vehiculos en el taller</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Lista del tipo de vehiculo seleccionado</returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            sb.AppendLine("");
            if(taller != null)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    switch (tipo)
                    {
                        case ETipo.Camioneta:
                            if(v is Suv)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        case ETipo.Moto:
                            if(v is Ciclomotor)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        case ETipo.Automovil:
                            if(v is Sedan)
                            {
                                sb.AppendLine(v.Mostrar());
                            }
                            break;
                        default:
                            sb.AppendLine(v.Mostrar());
                            break;
                    }
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Taller</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if(!(taller is null && vehiculo is null) && taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v != vehiculo)
                    {
                        continue;
                    }
                    else
                    { 
                        return taller;
                    }
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Taller</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            if(!(taller is null && vehiculo is null))
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        taller.vehiculos.Remove(v);
                        break;
                    }
                }
            }
            return taller;
        }
        #endregion
    }
}
