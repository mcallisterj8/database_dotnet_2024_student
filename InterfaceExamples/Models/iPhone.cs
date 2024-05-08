namespace InterfaceExamples.Models;
using InterfaceExamples.Interfaces;

public class iPhone: Phone, ISmartphone {
    public static string Browser { get; } = "Safari";
    public List<string> Commands = new List<string>{"Hey Siri", "Check Weather"};
    public List<string> CommandActions = new List<string>{"Listening...", "Displaying Weather"};

    public void CallSteveJobs() {
        Console.WriteLine("Calling Steve Jobs");
    }

    public void BrowseInternet() {
        // int[] numbers = new int[3];

        // for(int i = 0; i <= numbers.Length; i++){
        //     Console.WriteLine($"numbers[{i}] = {numbers[i]}");
        // }
        Console.WriteLine($"Using {iPhone.Browser} to browse the internet.");
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