using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Instancia una moto
        /// </summary>
        /// <param name="marca">Marca de la moto</param>
        /// <param name="chasis">Chasis de la moto</param>
        /// <param name="color">Color de la moto</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base (chasis, marca, color)
        {
            
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos de la moto
        /// </summary>
        /// <returns>Datos de la moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
