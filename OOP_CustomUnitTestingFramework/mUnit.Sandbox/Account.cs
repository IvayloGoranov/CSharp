using System;

public class Account
{
	private double balance = 0;
	
	public void Deposit(double amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Can not deposit negative or zero amount");
		}
		balance += amount;
	}

    public void Withdraw(double amount)
	{
		if (amount <= 0)
		{
			throw new ArgumentException("Can not withdraw negative or zero amount");
		}
		balance -= amount;
	}

    public void TransferFunds(Account destinationAcc, double amount)
	{
		if (destinationAcc == this)
		{
			throw new ArgumentException(
				"Source and destination accounts can not be the same");
		}
		balance -= amount;
		destinationAcc.balance += amount;
	}

    public void NotCoveredMethod()
    {
        Console.WriteLine("This method is never invoked");
    }

    public double Balance
	{
		get
		{
			return balance;
		}
	}
}
