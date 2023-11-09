using OOP3;

ICreditManager personalFinanceCredit = new PersonalFinanceCreditManager();
personalFinanceCredit.Calculate();

ICreditManager transportCredit = new TransportCreditManager();

ICreditManager mortgageCreditManager = new MortgageCreditManager();

ICreditManager tradesmanCreditManager = new TradesmanCreditManager();

ApplicationManager applicationManager = new ApplicationManager();
//applicationManager.Apply(personalFinanceCredit);



List<ICreditManager> credits = new List<ICreditManager>() { personalFinanceCredit, transportCredit };

Console.WriteLine("********************************************");



applicationManager.Apply(personalFinanceCredit,
    new List<ILoggerService>
    {
        new DatabaseLoggerService(),
        new SmsLoggerService()}
    );

applicationManager.Apply(tradesmanCreditManager, 
    new List<ILoggerService> 
    { 
        new FileLoggerService()
    }
    );
