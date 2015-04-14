using IdmNet.SoapModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdmNet.Tests
{
    [TestClass]
    public class SoapResourceClientModelTests
    {
        [TestMethod]
        public void It_has_a_Change_class_with_a_parameterless_constructor()
        {
            var it = new Change();

            Assert.IsNotNull(it);
        }
    }
}
