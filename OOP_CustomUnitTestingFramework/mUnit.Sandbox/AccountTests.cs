namespace mUnit.Sandbox
{
    using System;
    using Core.Assertions;
    using Core.Attributes;

    [TestContainer]
    public class AccountTests
    {
        [Test]
        [TestCase(300.0d)]
        [TestCase(400.0d)]
        [TestCase(500.0d)]
        public void TestDeposit(double sum)
        {
            var account = new Account();
            account.Deposit(300.0);
        
            Assert.AreEqual(300.0, account.Balance);
        }

        [Test]
        [ShouldThrow(typeof(ArgumentException))]
        public void DepositNegativeSum_EmptyAccount_ShouldThrowException()
        {
            var account = new Account();
            account.Deposit(-300.0);
        }

        [Test]
        public void Withdraw_NonEmptyAccount_ShouldPass()
        {
            var account = new Account();
            account.Deposit(3000.0);
            account.Withdraw(2000.0);

            Assert.AreEqual(1000.0, account.Balance);
        }
    }
}
