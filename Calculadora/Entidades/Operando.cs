using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// Constructor por defecto. Inicializa el atributo numero en 0.
        /// </summary>
        public Operando()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que inicializa el numero con el valor ingresado como parametro
        /// </summary>
        /// <param name="numero">Un numero</param>
        public Operando(double numero)
            : this()
        {
            this.numero = numero;
        }


        public Operando(string strNumero) 
            : this() 
        {
            Numero = strNumero;
        }

        /// <summary>
        /// Asigna el valor ingresado por teclado al atributo numero
        /// </summary>
        public string Numero
        {
            set
            { 
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Convierte un numero de binario a decimal
        /// </summary>
        /// <param name="binario">Numero binario</param>
        /// <returns>Si es posible retornará un numero decimal,
        /// de lo contrario, "Valor no invalido".</returns>
        public static string BinarioDecimal(string binario)
        {
            double decimalNum = 0;
            if (EsBinario(binario))
            {
                ///////// VER DE HACERLO CON FOR A VER SI QUEDA MAS CHIQUI
                double exponente = binario.Length-1;
                foreach (char item in binario)
                {
                    decimalNum += int.Parse(item.ToString()) * Math.Pow(2, exponente);
                    exponente--;
                }
                return decimalNum.ToString();
            }
            return "Valor invalido";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            if(numero > 0)
            {
                StringBuilder sb = new StringBuilder();

                while ((int)numero > 1)
                {
                    sb.Append(numero % 2);
                    numero /= 2;
                }
                sb.Append(1);
                
                return new string(sb.ToString().Reverse().ToArray());
            }
            return "Valor invalido";
        }

        public static string DecimalBinario(string numero)
        {
            double.TryParse(numero, out double resultado);
            return DecimalBinario(resultado);
        }

        /// <summary>
        /// Valida que el parametro ingresado sea un numero binario
        /// </summary>
        /// <param name="binario">Numero compuesto de 1s y 0s</param>
        /// <returns>TRUE si es binario, FALSE si no lo es.</returns>
        private static bool EsBinario(string binario)
        {
            foreach (char digit in binario)
            {
                if(digit != '0' && digit != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Comprueba que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero">String numerico</param>
        /// <returns>Numero en formato string parseado a double. Si no es un numero, se retornará 0</returns>
        private static double ValidarOperando(string strNumero)
        {
            double.TryParse(strNumero, out double numero);
            return numero;
        }

        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="n1">Minuendo</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>Diferencia</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="n1">Multiplicando</param>
        /// <param name="n2">Multiplicador</param>
        /// <returns>Producto</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos numeros
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Cociente</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            return n2.numero == 0 ? double.MinValue : n1.numero / n2.numero;
        }

        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="n1">Sumando</param>
        /// <param name="n2">Sumando</param>
        /// <returns>Total</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
