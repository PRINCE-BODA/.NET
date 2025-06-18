using System;
public class BankDetails
{
    public int AccountNumber;
    public string AccountHolderName;
    public string BankName;
    public double Balance;
    public void GetDetails(int accountNumber, string accountHolderName, string bankName, double balance)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        BankName = bankName;
        Balance = balance;
    }
    public void DisplayDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Account Holder Name: {AccountHolderName}, Bank Name: {BankName}, Balance: {Balance}");
    }
}