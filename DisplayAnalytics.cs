using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperAssessment
{
    public class DisplayAnalytics
    {
        static void Main(string[] args)
        {
            var service = new ClientService();
            var clients = service.LoadClients();

            if (!clients.Any())
            {
                Console.WriteLine("No clients found.");
                return;
            }

            DisplayClientAnalytics(clients);
        }

        static void DisplayClientAnalytics(List<Client> clients)
        {
            Console.WriteLine("Client Analytics");
            Console.WriteLine($"Total Clients: {clients.Count}");
            Console.WriteLine($"Total Users: {clients.Sum(c => c.NumberOfUsers)}");

            var groupedByLocation = clients.GroupBy(c => c.Location)
                                           .Select(g => new
                                           {
                                               Location = g.Key,
                                               ClientCount = g.Count(),
                                               TotalUsers = g.Sum(c => c.NumberOfUsers)
                                           });

            Console.WriteLine("\nClients by Location:");
            foreach (var group in groupedByLocation)
            {
                Console.WriteLine($"Location: {group.Location}, Clients: {group.ClientCount}, Total Users: {group.TotalUsers}");
            }
        }
    }
}
