using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateCreditCard.Models;


namespace ValidateCreditCard.Tests
{
    [TestClass]
    public class TestValidateCreditCard
    {
        private ValidateCriditCard _validate;
        [TestInitialize]
        public void Inicializar()
        {
            _validate = new ValidateCriditCard();
        }


        [TestMethod]
        public void comprobarInversaoDeNro()
        {

            string nroCartao = "4111111111111";
            string nroInvertido = _validate.invertirNumero(nroCartao);//"1881888888882104";
            Assert.IsTrue(nroInvertido == "1111111111114");

        }

        [TestMethod]
        public void comprobarDuplicacaoAlternada()
        {
            string nroCartao = "4111111111111";
            string nroDuplicado = _validate.duplicarAlternada(nroCartao);//"116828168168168162208";
            Assert.IsTrue(nroDuplicado == "1212121212124");
        }


        [TestMethod]
        public void comprobarSumaMaioresANove()
        {
            string nroCartao = "4111111111111";
            string nroInvertido = _validate.sumaMayoresANueve(nroCartao);//"1782878787872208";
            Assert.IsTrue(nroInvertido == "1212121212124");
        }

        [TestMethod]
        public void comprobarSeNroCartaValido()
        {
            string nroCartao = "4111111111111";
            var mod = _validate.validarNroCartao(nroCartao);

            Assert.IsTrue(mod==0);
            
        }

        [TestMethod]
        public void verificarRetornarBandeiraCartaoVisa()
        {
            string nroCartao = "4111111111111";
            string bandeira = _validate.retornarTipoCartao(nroCartao);
            Assert.IsTrue(bandeira == "VISA");
        }
        [TestMethod]
        public void verificarRetornarBandeiraCartaoMasterCard()
        {
            string nroCartao = "5105105105105100";
            string bandeira = _validate.retornarTipoCartao(nroCartao);
            Assert.IsTrue(bandeira == "MasterCard");
        }

        [TestMethod]
        public void verificarRetornarBandeiraCartaoDiscover()
        {
            string nroCartao = "6011111111111117";
            string bandeira = _validate.retornarTipoCartao(nroCartao);
            Assert.IsTrue(bandeira == "DISCOVER");
        }

        [TestMethod]
        public void verificarRetornarBandeiraCartaoAmex()
        {
            string nroCartao = "378282246310005";
            string bandeira = _validate.retornarTipoCartao(nroCartao);
            Assert.IsTrue(bandeira == "AMEX");
        }
    }
}
