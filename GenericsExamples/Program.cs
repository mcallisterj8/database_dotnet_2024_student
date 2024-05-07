using GenericsExamples.Models;

iPhone iphoneA = new iPhone {
    Brand = "Apple",
    Model = "iPhone 11"
};

iPhone iphoneB = new iPhone {
    Brand = "Apple",
    Model = "iPhone 12"
};

iPhone iphoneC = new iPhone {
    Brand = "Apple",
    Model = "iPhone 8"
};

Android androidA = new Android {
    Brand = "Google",
    Model = "Samsung Galaxy 23"
};


Android androidB = new Android {
    Brand = "Google",
    Model = "Samsung Galaxy 20"
};

Android androidC = new Android {
    Brand = "Google",
    Model = "Samsung Galaxy 24"
};

List<string> words = new List<string> { "apple", "berry", "cherry", "date" };
List<int> numbers = new List<int> { 12, 16, 18, 24, 80 };

List<iPhone> iPhoneList = new List<iPhone> {
    iphoneA,
    iphoneB,
    iphoneC
};

List<Android> androidList = new List<Android> {
    androidA,
    androidB,
    androidC
};



Box<string> boxA = new Box<string>("boxA", "Star Item", words);
Console.WriteLine(boxA.ToString());

Console.WriteLine("\n=======================================");

Box<int> boxB = new Box<int>("boxB", 8, numbers);
Console.WriteLine(boxB.ToString());


Console.WriteLine("\n=======================================");

SmartBox<iPhone> boxC = new SmartBox<iPhone>("boxC (smartbox)", iphoneA, iPhoneList);
Console.WriteLine(boxC.ToString());

// Console.WriteLine($"iPhoneA => {iphoneA.Model}");