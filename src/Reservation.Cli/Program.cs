using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservation.Domain;
using Reservation.Repositories;
using Reservation.Repositories.Abstractions;
using Reservation.Repositories.Extensions;

var host = Host.CreateDefaultBuilder();
host.ConfigureServices((context, services) =>
{

})

IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();
    services.ConfigureRepository();
    return services.BuildServiceProvider();
}

var repo = serviceProvider.GetRequiredService<ICustomerRepository>();
await repo.AddEntityAsync(new Customer()
{
    Email = "test@test.com",
    Name = "Test"
});
var all = await repo.GetAllAsync();
Console.Out.WriteLine($"number of customers: {all.Count()}");

ShowMenu();
int userInput = ReadUserInput();
if (userInput == 1)
{
    CustomerMenu();
    int userInputForCustomerMenu = ReadUserInput();
    ProcessCustomerCommand(userInputForCustomerMenu);

    void ProcessCustomerCommand(int key)
    {
        if (key == 1)
        {
            AddNewCustomer();

            void AddNewCustomer()
            {
                var customerRepo = serviceProvider.GetRequiredService<ICustomerRepository>();
            }
        }
    }
}


int ReadUserInput()
{
    var chosenMenu = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(chosenMenu))
    {
        return int.Parse(chosenMenu);
    }

    throw new ArgumentNullException("Enter a valid value");
}

void ShowMenu()
{
    var menu = @"
1. Customers
2. Suppliers
3. Appointments
";

    Console.WriteLine(menu);
}

void CustomerMenu()
{
    var menu = @"
1. Add new Customer
2. Edit customer
3. List all customers
";
}