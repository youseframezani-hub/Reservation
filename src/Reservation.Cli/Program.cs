using Microsoft.Extensions.DependencyInjection;
using Reservation.Repositories;
using Reservation.Repositories.Abstractions;

IServiceProvider serviceProvider = ConfigureServices();

IServiceProvider ConfigureServices()
{
    var services = new ServiceCollection();
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    return services.BuildServiceProvider();
}

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