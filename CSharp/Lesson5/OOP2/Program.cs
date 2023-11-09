using OOP2;

IndividualCustomer customer1 = new IndividualCustomer();
customer1.FirstName = "Kadir";
customer1.LastName = "Avşar";
customer1.TcNo = "12345678910";



CoorporateCustomer customer2 = new CoorporateCustomer();
customer2.Id = 1;
customer2.CompanyName = "İstanbulKodluyor";
customer2.CustomerNumber = "616161"; // Ata class(Customer) geldi
customer2.TaxNo = "61616161";

Customer customer3 = new IndividualCustomer();
Customer customer4 = new CoorporateCustomer();


CustomerManager customerManager = new CustomerManager();
customerManager.Add(customer3);
customerManager.Add(customer2);

