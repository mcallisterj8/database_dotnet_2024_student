namespace InterfaceExamples.Models;
using InterfaceExamples.Interfaces;
public class Android: Phone, ISmartphone {
    public static string Browser { get; } = "Chrome";
    public List<string> Commands = new List<string>{"Ok Google", "Check Email"};
    public List<string> CommandActions = new List<string>{"Listening...", "Checking Email"};

    public void CallLarryPage() {
        Console.WriteLine("Calling Larry Page");
    }

    public void BrowseInternet() {
        Console.WriteLine($"Using {Android.Browser} to browse the internet.");
    }

    public void UseAssistant(string givenCommand) {
        for(int i = 0; i < this.Commands.Count; i++) {
            if(this.Commands[i] == givenCommand) {
                Console.WriteLine(this.CommandActions[i]);
                
                return;
            }
        }
        Console.WriteLine($"'{givenCommand}' is not a valid command.");
    }
}