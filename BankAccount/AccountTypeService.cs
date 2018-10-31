using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccount
{
    public class AccountTypeService
    {
        private string path;
        private List<AccountType> listTypes;

        public AccountTypeService()
        {
            listTypes = new List<AccountType>();
        }

        public void AddType(AccountType type)
        {
            if (type == null)
                throw new ArgumentNullException();

            AccountType overlap = listTypes.Find(listTypes => listTypes.TypeName == type.TypeName);

            if (overlap == null)
            {
                listTypes.Add(type);
            }
            else
            {
                throw new ArgumentException("This object already exist");
            }
        }

        public void ChangeType(int id, int putWeights, int withdrawWeights, string typeName = "")
        {
            AccountType type = FindType(id);

            if (type != null)
            {
                type.TypeName = String.IsNullOrEmpty(typeName) ? type.TypeName : typeName;
                type.PutWeights = putWeights;
                type.WithdrawWeights = withdrawWeights;
            }
            else
            {
                Console.WriteLine("Invalid ID");
            }
        }

        public AccountType FindType(int id)
        {
            return listTypes.Find(listTypes => listTypes.ID == id);
        }

        public void LoadTypes(string path = "AccountTypesFile")
        {
            this.path = path;

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                while (reader.PeekChar() > -1)
                {
                    int id = reader.ReadInt32();
                    string typeName = reader.ReadString();
                    int putWeights = reader.ReadInt32();
                    int withdrawWeights = reader.ReadInt32();
                    listTypes.Add(new AccountType(id, typeName, putWeights, withdrawWeights));
                }
            }
        }

        public void SaveTypes(string path = "AccountTypesFile")
        {
            this.path = path;

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (AccountType type in listTypes)
                {
                    writer.Write(type.ID);
                    writer.Write(type.TypeName);
                    writer.Write(type.PutWeights);
                    writer.Write(type.WithdrawWeights);
                }
            }
        }

        public List<AccountType> GetTypes()
        {
            return listTypes;
        }
    }
}