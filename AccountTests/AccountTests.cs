using System;
using System.Diagnostics.CodeAnalysis;
using Banking;
using Xunit;

namespace AccountTests
{
	[ExcludeFromCodeCoverage]
    public class AccountTests
    {
	    [Fact]
	    public void NewAccount_ShouldHaveBalanceEqualToZero()
	    {
		    IAccount newAccount = new Account(() => { });

		    Assert.Equal(0, newAccount.Balance);
	    }

		[Fact]
	    public void Calling_Deposit_OnUnverifiedAccount_ShouldAddDepositedAmountToBalance()
		{
			const decimal amountToDeposit = 5;
			IAccount unverifiedAccount = new Account(() => { });

			unverifiedAccount.Deposit(amountToDeposit);

			Assert.Equal(amountToDeposit, unverifiedAccount.Balance);
	    }

	    [Fact]
	    public void Calling_Withdraw_OnUnverifiedAccount_ShouldNotChangeBalance()
	    {
		    IAccount unverifiedAccount = new Account(() => { });

			unverifiedAccount.Withdraw(5);

		    Assert.Equal(0, unverifiedAccount.Balance);
		}

	    [Fact]
	    public void Calling_Deposit_OnClosedAccount_ShouldNotChangeBalance()
	    {
		    IAccount closedAccount = new Account(() => { });
			closedAccount.Close();

			closedAccount.Deposit(5);

		    Assert.Equal(0, closedAccount.Balance);
	    }

	    [Fact]
	    public void Calling_Withdraw_OnClosedAccount_ShouldNotChangeBalance()
	    {
		    IAccount closedAccount = new Account(() => { });
		    closedAccount.Close();

			closedAccount.Deposit(5);

		    Assert.Equal(0, closedAccount.Balance);
	    }

	    [Theory]
		[InlineData(5, -5)]
	    [InlineData(10, -10)]
	    public void Calling_Withdraw_OnVerifiedAccount_ShouldSubtractWithdrawnAmountFromBalance(decimal amountToWithdraw, decimal resultingBalance)
	    {
		    IAccount account = new Account(() => { });
			account.VerifyHolder();

			account.Withdraw(amountToWithdraw);

		    Assert.Equal(resultingBalance, account.Balance);
	    }

	    [Theory]
	    [InlineData(5, 5)]
	    [InlineData(10, 10)]
	    public void Calling_Deposit_OnVerifiedAccount_ShouldAddDepositedAmountToBalance(decimal amountToDeposit, decimal resultingBalance)
	    {
		    IAccount account = new Account(() => { });
		    account.VerifyHolder();

			account.Deposit(amountToDeposit);

		    Assert.Equal(resultingBalance, account.Balance);
	    }

	    [Fact]
	    public void Calling_Withraw_OnFrozenAccount_ShouldTriggerCustomAction()
	    {
		    var wasCustomActionCalled = false;
		    Action customAction = () => wasCustomActionCalled = true;
		    IAccount account = new Account(customAction);
		    account.VerifyHolder();
			account.Freeze();

		    account.Withdraw(5);

		    Assert.True(wasCustomActionCalled);
	    }

		[Fact]
	    public void Calling_Deposit_OnFrozenAccount_ShouldTriggerCustomAction()
	    {
		    var wasCustomActionCalled = false;
		    Action customAction = () => wasCustomActionCalled = true;
		    IAccount account = new Account(customAction);
		    account.VerifyHolder();
			account.Freeze();

		    account.Deposit(5);

		    Assert.True(wasCustomActionCalled);
		}

	    [Fact]
	    public void Calling_Deposit_OnUnfrozenAccount_ShouldNotTriggerCustomAction()
	    {
		    var wasCustomActionCalled = false;
		    Action customAction = () => wasCustomActionCalled = true;
		    IAccount account = new Account(customAction);
		    account.VerifyHolder();
		    
		    account.Deposit(5);

		    Assert.False(wasCustomActionCalled);
	    }

		[Fact]
	    public void Calling_Withraw_OnUnfrozenAccount_ShouldNotTriggerCustomAction()
	    {
		    var wasCustomActionCalled = false;
		    Action customAction = () => wasCustomActionCalled = true;
		    IAccount account = new Account(customAction);
		    account.VerifyHolder();
		    
		    account.Withdraw(5);

		    Assert.False(wasCustomActionCalled);
	    }
	}
}
