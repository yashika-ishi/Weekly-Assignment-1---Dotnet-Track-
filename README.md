<div align="center">
  <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=asp-net&logoColor=white" alt="ASP.NET Core">
  <img src="https://img.shields.io/badge/CQRS-Pattern-yellowgreen?style=for-the-badge" alt="CQRS">
  <img src="https://img.shields.io/badge/MediatR-Design-blueviolet?style=for-the-badge" alt="MediatR">
  <img src="https://img.shields.io/badge/Entity%20Framework%20Core-2699FB?style=for-the-badge&logo=dot-net&logoColor=white" alt="EF Core">
  <h1>Student Management System API - CQRS with MediatR</h1>
  <p>An ASP.NET Core Web API showcasing the implementation of the <strong>CQRS (Command Query Responsibility Segregation)</strong> and <strong>Mediator</strong> patterns.</p>
  <p>🧑‍💻 By <strong>Yashika Negi</strong> | <a href="https://github.com/yashika-ishi/Weekly-Assignment-1---Dotnet-Track-.git">View Repository</a></p>
</div>

---

## 🌟 Overview
This project is a simple Student Management System API built with **ASP.NET Core**. It serves as a practical example of applying **CQRS** for clear separation of read (Queries) and write (Commands) operations, utilizing the **MediatR** library to implement the **Mediator pattern**.

Data persistence is handled by **Entity Framework Core** using an **InMemory Database**, which is pre-seeded with three initial student records upon application startup.

### ✨ Key Features
* **CQRS Implementation:** Strict separation between data modification and data retrieval logic.
* **Mediator Pattern:** Uses **MediatR** to decouple senders (Controllers) from handlers (Business Logic).
* **Core CRUD Operations:**
    * Add a new student
    * Update student details
    * Delete a student
    * Retrieve all students
* **EF Core InMemory Database:** Lightweight, in-memory data store for quick setup and testing.
* **Pre-Seeded Data:** Starts with 3 ready-to-use student entries.

---
## NuGet Packet Manager
<img src="https://github.com/yashika-ishi/Weekly-Assignment-1---Dotnet-Track-/blob/main/Dependencies.png" width="1000"/>

---

## Solution Explorer
<div align="center">
  <img src="https://github.com/yashika-ishi/Weekly-Assignment-1---Dotnet-Track-/blob/main/Folder%20schema%201.png?raw=true" width="300" style="padding-right: 10px;"/>
  <img src="https://github.com/yashika-ishi/Weekly-Assignment-1---Dotnet-Track-/blob/main/Folder%20schema%202.png?raw=true" width="300"/>
</div>

---
## 🏗 Project Architecture

The solution is organized to reflect the principles of CQRS and the Mediator pattern, promoting a clean, maintainable structure.

```mermaid
graph TD
    A[Controllers] -->|Sends Commands/Queries| B(MediatR);
    B -->|Routes Commands| C(Command Handlers);
    B -->|Routes Queries| D(Query Handlers);
    C --> E[AppDbContext/EF Core];
    D --> E;
    subgraph Application
        C;
        D;
    end
    subgraph Data
        E;
    end
    subgraph StudentManagementCQRS_Yashika
        A;
        Application;
        Data;
        F[Models];
        G[Program.cs];
    end

