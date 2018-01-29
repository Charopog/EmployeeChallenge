# EmployeeChallenge

Sample Project for creating Web Api with Asp .Net Core and Entity Framework Core- Code First
and a Xamarin Forms client that consumes it.

## Getting Started

** Server **

* Open EmployeeChallenge solution inside src/server folder in Visual Studio Build it.
* Select EmployeeChallenge.API as Startup Project and run it as Standard not on IIS.
* On first run server will create a new database in VS Local Db and fill with dummy data
* Web api is configured to listen all incoming connections on port 60000
* You can use swagger to test the api by visiting http://(your local IP Address):60000/swagger/

** Client **
* Open EmployeeChallenge.Xam solution inside src/client folder in Visual Studio.
* Install EmployeeChallenge.Dtos.1.0.0.nupkg from Nuget folder to EmployeeChallenge.Xam Project
* Build (For iOS you need to connect with Xamarin Mac Agent)
* Change HttpClientBaseAddress constant of App.xaml.cs in EmployeeChallenge.Xam Project
  to http://(Local IP Address that web api runs):60000/
* Select EmployeeChallenge.Xam.Android or EmployeeChallenge.Xam.iOS project as startup
* Run

## Built With

* [EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/2.0.1) - ORM Framework used
* [FluentValidation](https://www.nuget.org/packages/FluentValidation/7.4.0) - Used for Validation Rules
* [AutoMapper](https://www.nuget.org/packages/AutoMapper/6.2.2) - Used for object to object Mapping
* [Prism.Unity.Forms](https://www.nuget.org/packages/Prism.Unity.Forms/7.0.0.396) - MVVM Framework used
* [Acr.UserDialogs](https://www.nuget.org/packages/Acr.UserDialogs/7.0.1) - Used for cross platform user dialogs
* [modernhttpclient](https://www.nuget.org/packages/modernhttpclient/2.4.2) - HttpClient handler for platform specific networking




