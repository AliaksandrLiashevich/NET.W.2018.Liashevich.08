using System;
using System.Collections.Generic;
using System.IO;


namespace BankAccount
{
    public class AccountService
    {
        private string path;
        private List<Account> accounts;
        private AccountTypeService typeService;
        private IPointsCalculations calculator;

        public AccountService(AccountTypeService service, IPointsCalculations obj)
        {
            if (service == null || obj == null)
                throw new ArgumentNullException();
            accounts = new List<Account>();
            typeService = service;
            calculator = obj;
        }

        public void AddAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException();

            AccountType type = typeService.FindType(account.TypeID);
            Account searched = FindAccount(account.ID);

            if (type == null)
            {
                throw new NullReferenceException("Account type doesn't exist");
            }
            else if (searched != null && account.Equals(searched))
            {
                throw new NullReferenceException("This account already exist");
            }
            else if (searched != null && !account.Equals(searched))
            {
                throw new NullReferenceException("Invalid ID");
            }
            else
            {
                accounts.Add(account);
            }
        }

        public void DeleteAccount(int id)
        {
            Account searched = FindAccount(id);

            if (searched != null)
            {
                accounts.Remove(searched);
            }
            else
            {
                throw new ArgumentException("Invalid ID");
            }
        }

        public Account FindAccount(int id)
        {
            return accounts.Find(accounts => accounts.ID == id);
        }

        public void PutMoney(int id, double amount) 
        {
            Account account = FindAccount(id);

            if (account == null)
                throw new NullReferenceException("Account with this number doesn't exist");

            int weight = typeService.FindType(account.TypeID).PutWeights;
            account.PutPoints += calculator.Calculations(weight);
            account.Bill += amount;
        }

        public void WithdrawMoney(int id, double amount)
        {
            Account account = FindAccount(id);

            if (account == null)
                throw new NullReferenceException("Account with this number doesn't exist");

            int weight = typeService.FindType(account.TypeID).WithdrawWeights;
            account.WithdrawPoints += calculator.Calculations(weight);

            account.Bill -= amount;

            if (account.Bill < 0)
                account.Bill = 0;
        }

        public void ChangeCalcLogics(IPointsCalculations obj)
        {
            if(obj == null)
            calculator = obj;
        }

        public void LoadAccounts(string path = "AccountsFile")
        {
            this.path = path;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    int typeID = reader.ReadInt32();
                    string firstName = reader.ReadString();
                    string lastName = reader.ReadString();
                    double bill = reader.ReadDouble();
                    int putPoints = reader.ReadInt32();
                    int withdrawPoints = reader.ReadInt32();
                    accounts.Add(new Account(id, typeID, firstName, lastName, bill, putPoints, withdrawPoints));
                }
            }
        }

        public void SaveAccounts(string path = "AccountsFile")
        {
            this.path = path;

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (Account account in accounts)
                {
                    writer.Write(account.ID);
                    writer.Write(account.TypeID);
                    writer.Write(account.FirstName);
                    writer.Write(account.LastName);
                    writer.Write(account.Bill);
                    writer.Write(account.PutPoints);
                    writer.Write(account.WithdrawPoints);
                }
            }
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
    }
}