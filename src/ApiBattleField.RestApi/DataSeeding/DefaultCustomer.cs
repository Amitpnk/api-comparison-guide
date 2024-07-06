using ApiBattleField.RestApi.Model;

namespace ApiBattleField.RestApi.DataSeeding
{
    public static class DefaultCustomer
    {
        public static List<Customer> CustomerList()
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, CustomerName = "Simone", CustomerCode = "86621" },
                new Customer { Id = 2, CustomerName = "Bell", CustomerCode = "70767" },
                new Customer { Id = 3, CustomerName = "Nolan", CustomerCode = "58221" },
                new Customer { Id = 4, CustomerName = "Zephania", CustomerCode = "18704" },
                new Customer { Id = 5, CustomerName = "Uriel", CustomerCode = "73449" },
                new Customer { Id = 6, CustomerName = "Melissa", CustomerCode = "66433" },
                new Customer { Id = 7, CustomerName = "Lavinia", CustomerCode = "93924" },
                new Customer { Id = 8, CustomerName = "Imani", CustomerCode = "60479" },
                new Customer { Id = 9, CustomerName = "Hiroko", CustomerCode = "59322" },
                new Customer { Id = 10, CustomerName = "Erich", CustomerCode = "79314" },
                new Customer { Id = 11, CustomerName = "Jade", CustomerCode = "67333" },
                new Customer { Id = 12, CustomerName = "Tarik", CustomerCode = "33570" },
                new Customer { Id = 13, CustomerName = "Cynthia", CustomerCode = "55701" },
                new Customer { Id = 14, CustomerName = "Adrienne", CustomerCode = "73547" },
                new Customer { Id = 15, CustomerName = "Shaine", CustomerCode = "77752" },
                new Customer { Id = 16, CustomerName = "Hector", CustomerCode = "43886" },
                new Customer { Id = 17, CustomerName = "Amal", CustomerCode = "01865" },
                new Customer { Id = 18, CustomerName = "Brady", CustomerCode = "68197" },
                new Customer { Id = 19, CustomerName = "Jaquelyn", CustomerCode = "06804" },
                new Customer { Id = 20, CustomerName = "Giacomo", CustomerCode = "94645" },
                new Customer { Id = 21, CustomerName = "Reese", CustomerCode = "33352" },
                new Customer { Id = 22, CustomerName = "Orson", CustomerCode = "87443" },
                new Customer { Id = 23, CustomerName = "Nigel", CustomerCode = "03160" },
                new Customer { Id = 24, CustomerName = "Chaney", CustomerCode = "96725" },
                new Customer { Id = 25, CustomerName = "Tiger", CustomerCode = "41379" },
                new Customer { Id = 26, CustomerName = "Lewis", CustomerCode = "56894" },
                new Customer { Id = 27, CustomerName = "Brenden", CustomerCode = "82726" },
                new Customer { Id = 28, CustomerName = "Chaim", CustomerCode = "60860" },
                new Customer { Id = 29, CustomerName = "Quamar", CustomerCode = "65190" },
                new Customer { Id = 30, CustomerName = "Avram", CustomerCode = "34812" }
            };
        }
    }
}
