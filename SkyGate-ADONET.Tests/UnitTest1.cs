using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkyGate_ADONET.Utilities; // 確保引用了你的工具類別

namespace SkyGate_ADONET.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void Test_Email格式正確_應回傳True()
        {
            bool result = ValidationHelper.ValidateEmail("service@skygate.com");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Email格式錯誤_應回傳False()
        {
            bool result = ValidationHelper.ValidateEmail("bad-email-format");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_工號格式正確_應回傳True()
        {
            // 根據你的 Regex: ^E\d{3}$
            bool result = ValidationHelper.ValidateEmployeeId("E123");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_工號格式錯誤_應回傳False()
        {
            bool result = ValidationHelper.ValidateEmployeeId("A123"); // 開頭錯
            Assert.IsFalse(result);
        }
    }
}
