using System;
using ExpectedObjects;
using Xunit;

namespace Test.XUnit.Domain.Entities
{
    public class CursoTest
    {
        [Fact(DisplayName ="Criar Curso")]
        public void TestDeveCriarCurso()
        {
            //########################### Cenario ###########################
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)169
            };

            //############################ Acao ##############################
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, 
                cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //######################### Verificacao ##########################
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TestCursoNaoDeveTerNomeInvalido(string nomeInvalido)
        {
            //########################### Cenario ###########################
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)169
            };

            //######################### Verificacao ##########################
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(nomeInvalido, cursoEsperado.CargaHoraria, 
                    cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal("Nome Invalido!", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void TestCursoNaoDeveTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //########################### Cenario ###########################
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)169
            };

            //######################### Verificacao ##########################
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cargaHorariaInvalida, 
                    cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).Message;
            Assert.Equal("Carga horaria invalida!", message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void TestCursoNaoDeveTerValorMenorQue1(double valorInvalido)
        {
            //########################### Cenario ###########################
            var cursoEsperado = new
            {
                Nome = "Informática Básica",
                CargaHoraria = (double)40,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)169
            };

            //######################### Verificacao ##########################
            var message = Assert.Throws<ArgumentException>(() =>
                new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, 
                    cursoEsperado.PublicoAlvo, valorInvalido)).Message;
            Assert.Equal("Valor invalido!", message);
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome Invalido!");
            }

            if (cargaHoraria < 1)
            {
                throw new ArgumentException("Carga horaria invalida!");
            }

            if (valor < 1)
            {
                throw new ArgumentException("Valor invalido!");
            }

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
