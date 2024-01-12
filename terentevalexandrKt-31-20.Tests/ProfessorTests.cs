using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using terentevalexandrKt_31_20.Models;

namespace terentevalexandrKt_31_20.Tests
{
    public class ProfessorTests
    {
        [Fact]
        public void IsValidFirstName_Иван_Test()
        {
            var testProfessor = new Professor
            {
                FirstName = "Иван"
            };

            var result = testProfessor.isValidFirstName();

            Assert.True(result);
        }
    }
}
