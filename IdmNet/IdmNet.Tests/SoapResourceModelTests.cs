using IdmNet.SoapModels;
using Xunit;

namespace IdmNet.Tests
{
    public class SoapResourceClientModelTests
    {
        [Fact]
        public void It_has_a_Change_class_with_a_parameterless_constructor()
        {
            var it = new Change();

            Assert.NotNull(it);
        }
    }
}
