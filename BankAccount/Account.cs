using System;

namespace BankAccount
{
    public class Account
    {
        public int ID { set; get; }
        public int TypeID { set; get; }
        public string FirstName { private set; get; }
        public string LastName { private set; get; }
        public double Bill { set; get; }
        public int PutPoints { set; get; }
        public int WithdrawPoints { set; get; }

        public Account(int id, int typeId, string firstName, string lastName, 
            double bill = 0, int putPoints = 0, int withdrawPoints = 0)
        {
            ID = id;
            TypeID = typeId;
            FirstName = firstName;
            LastName = lastName;
            Bill = bill;
            PutPoints = putPoints;
            WithdrawPoints = withdrawPoints;
        }

        public override bool Equals(object obj)
        {
            Account account = obj as Account;

            if (account != null)
            {
                return ID.Equals(account.ID) &
                    FirstName.Equals(account.FirstName) &
                    LastName.Equals(account.LastName);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format($"ID: *{ID}* TypeID: *{TypeID}* FirstName: *{FirstName}* LastName: *{LastName}*" +
                $" Bill: *{Bill}* PutPoints: *{PutPoints}* WithdrawPoints: *{WithdrawPoints}*");
        }
    }
}
