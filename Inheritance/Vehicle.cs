public class Vehicle {
    public string Name { get; set; } = "Default Name";
    public int ModelYear { get; set; } = 2023;
    protected string Manufacturer { get; set; } = "Default Manufacturer";    
    
    public Vehicle(){
        Console.WriteLine("Vehicle Constuctor ONE!");
    }

    public Vehicle(string vehicleName){
        this.Name = vehicleName;
        Console.WriteLine("Vehicle Constuctor TWO!");
    }

    public Vehicle(int something){
        Console.WriteLine("Vehicle Constuctor TESTER!");
    }

    public Vehicle(string vehicleName, int vehicleModelYear, string vehicleManufacturer){
        Console.WriteLine("Vehicle Constuctor THREE!");
    }

    public Vehicle(int vehicleModelYear, string vehicleName,  string vehicleManufacturer){
        Console.WriteLine("Vehicle Constuctor FOUR!");
    }

    public virtual void Drive() {
        Console.WriteLine("Vehicle is moving");
    }

    public virtual void Stop() {
        Console.WriteLine("Vehicle has stopped");
    }

    private void MaintenanceCheck() {
        Console.WriteLine("Performing maintenance check");
    }

    protected void DisplayManufacturer() {
        Console.WriteLine("Manufacturer: " + this.Manufacturer);
    }    
}