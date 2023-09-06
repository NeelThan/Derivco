# SQL and Roulette Assigment
## Description

This project is a C# REST API that simulates a game of roulette. 
It allows players to place bets, spin the roulette wheel, show previous spins, and receive payouts. 
The API is built using .NET 7 and EF Core SQLite concepts. The API demonstrates the structure with 
implementation and wiring up everything properly still to be add in future.

## Prerequisites

To run this project, you will need the following:

- Visual Studio or any compatible C# development environment
- SQL Server
- Microsoft Northwind Sample Database - https://raw.githubusercontent.com/microsoft/sql-server-samples/master/samples/databases/northwind-pubs/instnwnd.sql
- .NET 7 SDK

## Installation

1. Clone the repository.
2. Open the solution file in Visual Studio.
3. Restore the necessary NuGet packages.
4. Modify the connection string in the `appsettings.Development.json` file to point to your SQL Server and Northwind 
   database.
if required
5. Build the solution.

## Usage

Assignment 1
1. Run script in stored procedure in Northwind database - found in the Infrastructure scripts folder
2. Run unit test for script

Assignment 2
1. Run the API project in Visual Studio or using the `dotnet run` command.
2. Use a tool like Postman to send HTTP requests to the API endpoints (see [API Endpoints](#api-endpoints) section for details).
3. Refer to the API documentation or code comments for additional details on request payloads and response formats.

## API Endpoints

- `POST /api/bets`: Place a bet on a specific roulette number or color.
- `POST /api/spins`: Spin the roulette wheel and determine the winning number/color.
- `POST /api/payouts`: Calculate and pay out winnings to the players.
- `GET /api/spins`: Retrieve information about all previous roulette spins.
- `/api/players`

For detailed information about the request and response formats, 
please refer to the API documentation (swagger is enabled).

## Tests

The project includes unit tests to ensure the correctness of the implemented functionality. 
To run the tests:

1. Open the test project in Visual Studio.
2. Restore the necessary NuGet packages.
3. Run the tests using the test runner in your IDE or using the `dotnet test` command.
4. Test are there for concept and implementation can be added

## Global Exception Handling

The API includes global exception handling to capture and handle any unhandled exceptions 
that occur during request processing. The mediatr pipeline behaviour is used to achieve this.
The exceptions are logged and appropriate error responses are returned to the client.

## Design Patterns

This project demonstrates the use of the Repository design pattern to separate the data access logic 
from the business logic. 
The `IBetRepository` class provides an abstraction for interacting with the SQLite database.
