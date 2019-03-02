using Xunit;

namespace Test.XUnit.Domain.Entities
{
    public class CursoTest
    {
        [Fact(DisplayName ="Criar Curso")]
        public void TestDeveCriarCurso()
        {
            //Cenario            
            const string nome = "Informática Básica";
            const double cargaHoraria = 40;
            const string publicoAlvo = "Estudante";
            const double valor = 199;

            //Acao
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Verificacao
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);
        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}
