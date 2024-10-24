
using DeveloperAssessment;

static void Main(string[] args)
{
    var repository = new ClientService();
    var client = CaptureClientDetails();
    repository.SaveClient(client);
    Console.WriteLine("Client details saved successfully!");
}
static Client CaptureClientDetails()
{
    var client = new Client();

    Console.WriteLine("Capture Client Details");

    client.ClientName = PromptForInput("Enter Client Name: ");
    client.DateRegistered = DateTime.Parse(PromptForInput("Enter Date Registered (yyyy-mm-dd): "));
    client.Location = PromptForInput("Enter Location: ");
    client.NumberOfUsers = int.Parse(PromptForInput("Enter Number of Users: "));

    return client;
}
static string PromptForInput(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}