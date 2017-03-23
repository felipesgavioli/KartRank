using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using static Business.RankBusiness;

namespace BusinessTest
{
    [TestClass]
    public class RankBusinessTest
    {
        [TestMethod]
        public void CalcularVoltasTest()
        {
            // Arrange
            var allLine = new string[3];
            allLine[0] = "23:49:08.277 	  038 – F.MASSA		  	  1		1:02.852 			44,275";
            allLine[1] = "23:49:10.858 	  033 – R.BARRICHELLO		  1		1:04.352 			43,243";
            allLine[2] = "23:49:11.075 	  002 – K.RAIKKONEN		  1		1:04.108 			43,408";

            // Act
            var result = CalcularVoltas(allLine);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ConverterListaTest()
        {
            // Arrange
            var allLine = new string[3];
            allLine[0] = "23:49:08.277 	  038 – F.MASSA		  	  1		1:02.852 			44,275";
            allLine[1] = "23:49:10.858 	  033 – R.BARRICHELLO		  1		1:04.352 			43,243";
            allLine[2] = "23:49:11.075 	  002 – K.RAIKKONEN		  1		1:04.108 			43,408";

            // Act
            var result = ConverterLista(allLine);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MelhortempoTest()
        {
            // Arrange
            var listRank = new List<RankModel>
            {
                new RankModel() {CodigoPiloto = "F.MASSA"},
                new RankModel() {CodigoPiloto = "R.BARRICHELLO" }
            };

            // Act
            var result = Melhortempo(listRank);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
