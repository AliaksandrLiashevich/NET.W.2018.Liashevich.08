using System;

namespace BankAccount
{
    public class AccountType
    { 
        public int ID { private set; get; }
        public string TypeName { set; get; }
        public int PutWeights { set; get; }
        public int WithdrawWeights { set; get; }

        public AccountType(int id, string typeName, int putWeights, int withdrawWeights)
        {
            ID = id;
            TypeName = typeName;
            PutWeights = putWeights;
            WithdrawWeights = withdrawWeights;
        }

        public override bool Equals(object obj)
        {
            AccountType type = obj as AccountType;

            if (type != null)
            {
                return TypeName.Equals(type.TypeName) &
                    PutWeights.Equals(type.PutWeights) &
                    WithdrawWeights.Equals(type.WithdrawWeights);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (PutWeights + WithdrawWeights).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format($"TypeName: {TypeName} PutWeights: {PutWeights} " +
                $"WithdrawWeights: {WithdrawWeights}");
        }
    }
}