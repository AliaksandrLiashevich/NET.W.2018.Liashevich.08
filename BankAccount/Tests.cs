using System;
using System.Collections.Generic;

namespace BankAccount.Tests
{
    class Tests
    {
        static void Main(string[] args)
        {
            AccountType goldType = new AccountType(0, "Gold", 8, 9);
            AccountType baseType = new AccountType(1, "Base", 3, 5);
            AccountType platinumType = new AccountType(2, "Platinum", 15, 13);

            AccountTypeService typeService = new AccountTypeService();
            typeService.AddType(goldType);
            typeService.AddType(baseType);
            typeService.AddType(platinumType);

            Account goldAccount = new Account(0, 0, "Ivan", "Popov");
            Account baseAccount = new Account(1, 1, "Denis", "Demenkovets");
            Account platinumAccount = new Account(2, 2, "Jack", "Hunter");

            IPointsCalculations calculator = new PlusCalculator();
            AccountService accountService = new AccountService(typeService, calculator);
            accountService.AddAccount(goldAccount);
            accountService.AddAccount(baseAccount);
            accountService.AddAccount(platinumAccount);

            PrintAccounts(accountService.GetAccounts());

            accountService.PutMoney(2, 10);
            accountService.WithdrawMoney(2, 5);
            PrintAccounts(accountService.GetAccounts());

            accountService.ChangeCalcLogics(new MultCalculator());
            accountService.PutMoney(2, 10);
            PrintAccounts(accountService.GetAccounts());

            typeService.ChangeType(2, 30, 13);
            accountService.PutMoney(2, 10);
            PrintAccounts(accountService.GetAccounts());

            accountService.SaveAccounts();
            typeService.SaveTypes();

            Console.ReadKey();
        }

        static void PrintAccounts(List<Account> accounts)
        {
            foreach (Account account in accounts )
            {
                Console.WriteLine(account);
            }

            Console.WriteLine('\n');
        }
    }
}
