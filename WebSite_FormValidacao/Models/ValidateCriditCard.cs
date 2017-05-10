using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidateCreditCard.Models
{
    public class ValidateCriditCard
    {
        //Array auxiliar que almacena os numeros que é sumado no metodo duplicarAlternada 
        public string[] cartaoNro;
          
        //Metodo que retorna o tipo de Cartão a traves dos primeiros digitos do numero de cartão
        public string retornarTipoCartao(string nroCartao)
        {
            string bandeira = "";
            
                string digitoDos = nroCartao.Substring(0,2);
                string digitoCuatro = nroCartao.Substring(0, 4);
                string digitoUn = nroCartao.Substring(0, 1);
                if (Convert.ToInt16(digitoDos) == 34 || Convert.ToInt16(digitoDos) == 37)
                {
                     bandeira = "AMEX";
                }
                else if (Convert.ToInt16(digitoCuatro) == 6011)
                {
                     bandeira = "DISCOVER";
                }
                else if (Convert.ToInt16(digitoUn) == 4)
                {
                     bandeira = "VISA";
                }
                else if (Convert.ToInt16(digitoDos) >= 51 && Convert.ToInt16(digitoDos) <= 55)
                    bandeira = "MasterCard";
                else { bandeira = "Desconhecido"; }
            
            return bandeira;
        }

        //Metod Principal que executa as validaçao do numero fornecido implementando os metods Seguintes
        public int validarNroCartao( string nroCartao)
        {
            string nroFinal = sumaMayoresANueve(nroCartao);
            var nroArray = nroFinal.ToCharArray();
            int suma=0;
            for (int i = 0; i < nroArray.Length; i++)
            {
                suma = suma + Convert.ToInt16(nroArray[i].ToString());
            }
            return suma % 10;

        }

        //Metodo que busca os numero maiores a 9 sumando e convirtiendo numa unidade
        public string sumaMayoresANueve(string nroCartao)
        {
            string nro = duplicarAlternada(nroCartao);
            string nrofinal = "";
            for (int i = 0; i < cartaoNro.Length; i++)
            {
                if (Convert.ToInt16(cartaoNro[i].ToString()) > 9)
                {
                    nrofinal += Convert.ToString(Convert.ToInt16(cartaoNro[i]) - 9);
                }
                else
                {
                    nrofinal += cartaoNro[i].ToString();
                }
            }
            return nrofinal;

        }

        //Metodo para realizar a duplicaçaõ dos valores nas posições impres no nro de cartão leido desde um array
        public string duplicarAlternada(string nroCartao)
        {
            string nro = invertirNumero(nroCartao);

           var nroArray = nro.ToCharArray();
            cartaoNro = new string[nroArray.Length];
            string nroDuplicado = nroArray[0].ToString();
            cartaoNro[0] = nroDuplicado;
            for (int i = 1; i < nroArray.Length;i++ )
            {
                
                int a = Convert.ToInt16(nroArray[i].ToString());
                if (i % 2 == 0)
                {
                    nroDuplicado += nroArray[i].ToString();
                    cartaoNro[i] = nroArray[i].ToString();
                }
                else
                {
                    nroDuplicado += Convert.ToString(a * 2);
                    cartaoNro[i] = Convert.ToString(a * 2);
                }
                
            }

            return nroDuplicado;
        }

        //Metodo para inersão do numero de cartão
        public string invertirNumero(string nroCartao)
        {
            char[] charArray = nroCartao.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}