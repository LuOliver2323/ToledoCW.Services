using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToledoCW.Services.Infraestructure.Entidades;

namespace ToledoCW.Services.Unit_Teste.Domain.Entidades.cs
{
    public class AtendenteTest
    {
        [Fact]
        public void EhValido_DeveValidarInstancia()
        {
            //Arrange
            var _obj = new Atendente();
            _obj.Nome = "Lucas";
            _obj.Estabelecimento = 1;

            //Act
            var _result = _obj.EhValido();

            //Assert
            Assert.True(_result);
        }
    }
}
