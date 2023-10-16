# Vehicle Monitoring APIs 

## Overview

The Vehicle Monitoring APIs are designed to track the status of connected vehicles and their owners. It includes two microservices: **CustomerVehicleMicroservice** and **VehicleStatusMicroservice**. These microservices provide APIs for listing vehicles along with their status, filtering vehicles for a specific customer, and filtering vehicles based on their status.

## Table of Contents
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Logging](#logging)
- [Unit Testing](#unit-testing)
- [Built With](#built-with)
- [Architecture Advantages](#why-go-with-this-architecture)
- [Future Improvements](#future-improvements)

## Getting Started

To get started with the Vehicle Monitoring System, follow these steps:
### 1. Clone the Repository
 - git clone <https://github.com/zhuan0122/VehicleMonitor.git>

### 2. Set Up the Database

- The system uses a MySQL database to store customer information, vehicle details, and their respective statuses. The database is created by a database schema with sample data. The schema with sample data script is stored in Databse folder in the project.
- Use Eentity Framework to scaffold database to auto-create DbContext and Models. Entity Framework Core is utilized for seamless interaction with the database.

### 3. Configure the AppSettings

- Update the `appsettings.json` file with your database connection string.
- Update StartUp.cs or Program.cs file with your database connection string.

### 4. Run the backend Web APIs

- Build and run both microservices using .NET Core CLI or Visual Studio.
     - Navigate to each microservice project folder then run these command: 
       - donet clean
       - donet restore
       - dotnet build
       - dotnet run 

### 5. API Access/Testing
- Obtain a JWT token by sending a POST request to the authentication endpoint with predefined credentials.
    - In this project, JWT token generator logic is not implemented. It is in local development environment. Using Online JWT Token generator to henerate one for API authentication
- Access the APIs using tools like Postman.
    - Use the token in the Authorization header for subsequent requests to authorized endpoints in Postman with chosen type: Bearer Token
    - Send hettp/https request to API endpoints. Example: https://localhost:7106/api/vehiclestatus/ 
    

## API Endpoints

- **GET /api/customervehciles/{customerId}/vehicles:** Filter vehicles for a specific customer.
- **GET /api/vehiclestatus/status/{status}:** Filter vehicles with a specific status.
- **GET /api/vehiclestatus/status/{statusId}:** Filter vehicles with a specific status ID.
- **GET /api/vehiclestatus/:** Get all vehicles with their along status.

## Authentication

The API endpoints are secured and require authentication. JSON Web Tokens (JWT) are used for authentication. You can obtain a JWT token by signing in with valid credentials. The token must be included in the Authorization header of your API requests.

## Logging

API requests and responses are logged using `ILogger` in the respective controllers. Logging includes details such as request method, endpoint, response status code, and execution time. Logs are helpful for troubleshooting, performance monitoring, and auditing.

## Unit Testing

Comprehensive unit tests have been written for both services and controllers for each microservice. These tests cover various scenarios to validate the correctness of the implemented functionalities.
- Navigate to each microservice project and then give fullpath of unit test file to run unit test. Example: 
       - dotnet test --filter FullyQualifiedName~CustomerMicroservice.Tests.ServiceTests.CustomerVehicleServiceTest

## Built With
- **.NET Core**: For building robust, cross-platform APIs.
- **Entity Framework Core**: For efficient database operations.
- **MySQL Database**: For storing customer, vehicle, and status information.
- **JWT (JSON Web Tokens)**: For securing API endpoints and authenticating requests.
- **xUnit**: For unit testing the services and controllers.

## Architecture Advantages

The system follows a **Microservices Architecture**, where different components are decoupled into independent services. This architecture was chosen due to the following reasons:

- Decoupled Services

    - Microservices allow the system to be divided into smaller, manageable components, each responsible for specific tasks. **CustomerVehicleMicroservice** focuses on customer-related operations, while **VehicleStatusMicroservice** handles vehicle status-related functionality.

- Scalability

    - Microservices enable horizontal scaling. Each service can be deployed independently, allowing for better resource utilization and scaling of specific components based on demand.

- Separation of Concerns

    - By having distinct microservices, the concerns of each service are well-defined. This separation allows for easier development, maintenance, and testing of individual functionalities.

## Future Improvements

- **GUI Implementation**: Develop a web-based interface using Angular to visually display vehicle statuses and allow user interaction.
- **Dynamic Authentication logic**: Implement Auth logic between client side and backend server side. 
- **Real-Time Updates**: Implement a messaging platform (e.g., SignalR) for real-time updates on vehicle statuses.
- **Logging**: Integrate logging mechanisms to monitor API activities and errors effectively.
- **Data Simulator**: Create a data simulator to mimic real-time engine status changes for testing purposes.