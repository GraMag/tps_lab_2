using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del auto</param>
        /// <param name="chasis">Chasis del auto</param>
        /// <param name="color">Color del auto</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        /// <summary>
        /// Instancia un auto
        /// </summary>
        /// <param name="marca">Marca del auto</param>
        /// <param name="chasis">Chasis del auto</param>
        /// <param name="color">Color del auto</param>
        /// <param name="tipo">Cantidad de puertas</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
           : this(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// MUestra los datos del auto
        /// </summary>
        /// <returns>Datos del auto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
