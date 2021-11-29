using System;
using System.Collections.Generic;
using System.Text;

namespace Cálculadora_de_Integrales
{
    public class FuncionTraductor
    {
        public static string Traducir(string integral)
        {
            //"√(4x+1)"   "raiz(4x+1)";

            var integralReescrita = integral.Replace("√", "raiz");
            return integralReescrita;
        }
    }
}
