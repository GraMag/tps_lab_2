using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza operaciones matematicas
        /// </summary>
        /// <param name="num1">Primer numero</param>
        /// <param name="num2">Segundo numero</param>
        /// <param name="operador">Operador matematico</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            switch(ValidarOperador(operador))
            {
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    return num1 / num2;
                default:
                    return num1 + num2;
            }
        }

        /// <summary>
        /// Valida si el operador ingresado es un operador valido. 
        /// </summary>
        /// <param name="operador">Operador de la operacion</param>
        /// <returns>El mismo operador si es valido. Valor default: +/returns>
        private static char ValidarOperador(char operador)
        {
            return (operador == '-' || operador == '*' || operador == '/') ? operador : '+';
        }
    }
}
