# FeedbackApp
Feedback app with vue.js frontend and asp.net core web api backend

<h1>Feedback App</h1>

This is ASP.NET CORE web api app bundled together with vue.js frontend.

You can find my demo of this project running as Azure Web App Here:

https://vueapp1server20240105200453.azurewebsites.net/

<h1>How To Build</h1>

<h2>Prerequisites:</h2>

+ Make sure you have .NET 8.0 SDK installed or Download here: https://dotnet.microsoft.com/en-us/download
+ I would recommend to use Visual Studio 2022 as IDE. Download here: https://visualstudio.microsoft.com/
+ You need to have SQL Server and connection string to connect with app.
+ When installing Visual Studio install ASP.NET workloads.
+ Install Node.js. Download here https://nodejs.org/en/download/current

<h2>Download app from Github:</h2>

Clone this project to desired directory.

<h2>Connecting to SQL:</h2>

Next step is to add your SQL database connection string to appsettings.json. If you want to run back end tests add connection string as parameter to UseSqlServer method found in FeedbacksServiceTests.cs

<h2>Build</h2>

Make sure that both FeedbackApp.Server and feedbackapp.client are selected as startup project.

Now you are ready to start the project.

You should see npm cli for frontend cli for backend opening.

App will now seed the database with initial entities. There should be 5 feedback entities and 1 user entity with admin role.

Make sure frontend is running on https://localhost:5173/ and backend in https://localhost:7287/.

If backends port is not 7287, you have to change correct port in both files feedback.client/src/services/FeedbackService.js and in feedback.client/src/services/login.js

You can check the available endpoints in: https://localhost:7287/swagger/index.html

You can use credentials: admin@admin.com, Password123! to login. Login will give permission to AdminView where you can delete feedback entities. 


<h1>How To Run Tests</h1>

You can run backend xUnit tests by clicking Test -> Run All Tests.

To run frontend tests cd to feedback.client directory and give command 'npm run test'.
