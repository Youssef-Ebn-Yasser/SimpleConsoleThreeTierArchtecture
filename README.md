# Contact Management System

## Overview
The **Contact Management System** is a console-based application built using **C# .NET** following the **N-Tier Architecture** pattern. It provides functionalities for managing contacts, including adding, updating, deleting, and retrieving contact information from an SQL Server database.

## Architecture
This project follows the **N-Tier Architecture** pattern, separating concerns into the following layers:

1. **Presentation Layer (UI Layer)**
   - Handles user interaction via the console application.
   - Calls business layer functions to perform CRUD operations.
   
2. **Business Layer (BLL - Business Logic Layer)**
   - Contains business logic and validation.
   - Acts as an intermediary between the Presentation Layer and the Data Layer.
   - Defines the `clsContacts` class for managing contacts.

3. **Data Layer (DAL - Data Access Layer)**
   - Directly interacts with the SQL Server database.
   - Implements data persistence logic.
   - Uses ADO.NET for executing SQL queries.

## Features
- **Find Contact**: Retrieve contact details by ID.
- **Add Contact**: Insert a new contact into the database.
- **Update Contact**: Modify existing contact details.
- **Delete Contact**: Remove a contact by ID.
- **List All Contacts**: Display all saved contacts.
- **Check Contact Existence**: Verify if a contact exists in the database.

## Technologies Used
- **C# .NET** (Console Application)
- **SQL Server** (Database Management System)
- **ADO.NET** (Data Access Technology)

## Prerequisites
Ensure you have the following installed:
- **.NET SDK** (Version 6.0 or later recommended)
- **SQL Server** (Ensure `contactsdb` database exists)
- **Visual Studio** (or any C# development environment)

## Database Schema
```sql
CREATE TABLE contacts (
    contactid INT IDENTITY(1,1) PRIMARY KEY,
    firstname NVARCHAR(50),
    lastname NVARCHAR(50),
    email NVARCHAR(100),
    phone NVARCHAR(20),
    address NVARCHAR(255),
    countryid INT,
    dateofbirth DATE,
    imagepath NVARCHAR(255)
);
```

## Installation & Setup
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/your-username/ContactManagementSystem.git
   cd ContactManagementSystem
   ```

2. **Configure the Database Connection:**
   - Open `clsDataContacts.cs` inside the `DataLayer`.
   - Update the connection string:
     ```csharp
     private static string connectionstring = "server=YOUR_SERVER;database=contactsdb;user id=YOUR_USER;password=YOUR_PASSWORD;";
     ```

3. **Build and Run the Project:**
   - Open the solution in **Visual Studio**.
   - Set `TreeTierArchitecture_project` as the startup project.
   - Press **F5** to run.

## Usage
- **Find a Contact:**
  ```csharp
  testfind(2);
  ```
- **Add a New Contact:**
  ```csharp
  testaddnewcontact();
  ```
- **Delete a Contact:**
  ```csharp
  testdelete(21);
  ```
- **Update a Contact:**
  ```csharp
  testupdatecontact(21);
  ```
- **List All Contacts:**
  ```csharp
  testlist();
  ```
- **Check if a Contact Exists:**
  ```csharp
  testiscontactexist(2);
  ```



## Author
Developed by **Yousef Yasser**

