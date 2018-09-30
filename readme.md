# Simple Survey App

## Main Technologies Used:
 - ASP.NET Core 2.1 and C# 7.3 for cross-platform server-side code
 - Angular 5.2.0 and TypeScript 2.5 for client-side code
 - Bootstrap 3.3.7 for layout and styling
 - MongoDB for NoSQL data aggregate storage
 - Docker for containerization

## Running the App:

###### Running Locally
 - Ensure Node.js and .NET Core 2.1 runtime are installed
 - Download MongoDB and ensure that it is running on port 27017 (or use the mongodb docker image)
 - From the root folder cd to SimpleCustomerSurveyApp
 - From this directory run the command "dotnet run". This will automatically run "npm install" amd start the client application along with the server-side .NET Core api

###### Running from Docker
	-From the root file run "docker-compose up". ***Not currently working (having issues with npm and exposing proper ports)***