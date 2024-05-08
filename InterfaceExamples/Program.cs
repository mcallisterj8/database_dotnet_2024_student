using InterfaceExamples.Models;
using InterfaceExamples.Interfaces;

// iPhone phoneA = new iPhone {
//                     Brand = "Apple", 
//                     Model = "iPhone 11"
//                 };
// Android phoneB = new Android {
//             Brand = "Google", 
//             Model = "Samsung Galaxy 23"
//         };

// iPhone phoneC = new iPhone {
//             Brand = "Apple", 
//             Model = "iPhone 8"
//         };
// Android phoneD = new Android {
//             Brand = "Google", 
//             Model = "Samsung Galaxy 12"
//         };

// phoneA.BrowseInternet(); // iPhone
// phoneB.BrowseInternet(); // Android

// phoneA.UseAssistant("Check Weather"); // Valid command
// phoneA.UseAssistant("Test"); // Invalid command


ISmartphone phoneE = new iPhone {
                        Brand = "Apple",
                        Model = "iPhone 16"
                    };

ISmartphone phoneF = new Android {
                        Brand = "Google",
                        Model = "Samsung Galaxy 20"
                    };


phoneE.BrowseInternet();
phoneF.BrowseInternet();

// phoneE.CallSteveJobs();


// phoneE = new Android {
//             Brand = "Google",
//             Model = "Samsung Galaxy 208"
//         };
// phoneE.BrowseInternet();

// phoneA.CallSteveJobs();

/////////////////////////////////////


// List<ISmartphone> smartphones = new List<ISmartphone>{
//     phoneA,
//     phoneB,
//     phoneC,
//     phoneD
// };

// foreach(ISmartphone phone in smartphones) {
//     phone.BrowseInternet();
// }








