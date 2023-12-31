
using AddressBook.Shared.Interfaces;
using AddressBook.Shared.Services;
using AddressBookConsole.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<MenuService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();
menuService.ShowMainMenu();