using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("3064158700018")]
        [DataRow("3064158700018912")]
        [DataRow("abcd")]
        [DataRow("306abcd158123189")]
        [DataRow("abcdefghjijklçasld")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var doc = new Document(cnpj, EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("30641587000189", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("2294717309")]
        [DataRow("229471730922")]
        [DataRow("abcd")]
        [DataRow("2294717BC09")]
        [DataRow("2294717309AB")]
        [DataRow("abcdefghijk")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var doc = new Document("22947173090", EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
