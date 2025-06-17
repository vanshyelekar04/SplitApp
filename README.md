# 🚀 Split App – Backend

A minimal REST API for splitting group expenses, inspired by apps like Splitwise and Google Pay.

## Table of Contents

1. [Overview](#overview)  
2. [Features](#features)  
3. [Tech Stack](#tech-stack)  
4. [Getting Started](#getting-started)  
5. [API Endpoints](#api-endpoints)  
6. [Sample Requests / Test Cases](#sample-requests--test-cases)  
7. [Postman Collection](#postman-collection)  
8. [Deployment](#deployment)  
9. [Validation & Error Handling](#validation--error-handling)  
10. [Roadmap & Enhancements](#roadmap--enhancements)

---

## 1. Overview

This API allows users to split expenses among a group, providing functionality to add, view, edit, and delete expenses, and compute settlement recommendations.

## 2. Features

- 🧾 Add, view, edit, delete expenses  
- 👥 Auto-derived list of participants  
- ⚖️ Equal-share splitting  
- 💰 Calculate balances & optimized settlements  
- 🚨 Input validation & error handling  

## 3. Tech Stack

- **Backend**: ASP.NET Core 8  
- **Database**: PostgreSQL (hosted on Render.com)  
- **Authentication**: JWT Bearer tokens  
- **ORM**: EF Core  
- **Password Hashing**: BCrypt  

## 4. Getting Started

### Prerequisites

- .NET 8 SDK  
- PostgreSQL database (or use the default Render-hosted one)  

### Local Setup

1. **Clone the repository**  
   ```bash
   git clone https://github.com/vanshyelekar04/SplitApp.git
   cd SplitApp/WebAPI
Stage important project changes

bash
Copy
Edit
git add \
  ../Application/Application.csproj \
  ../Infrastructure/Services/AuthService.cs \
  ../Infrastructure/Data/AppDbContext.cs \
  ../Infrastructure/Services/ExpenseService.cs
git commit -m "Add updated services and configurations"
Configure appsettings.json

Add your PostgreSQL connection string under ConnectionStrings:DefaultConnection

Ensure JwtSettings has valid Key, Issuer, and Audience

Restore packages & build

bash
Copy
Edit
dotnet restore
dotnet build
Run application

bash
Copy
Edit
dotnet run
Swagger UI available at: https://localhost:<port>/swagger

5. API Endpoints
Use these endpoints after logging in (attach Authorization: Bearer <token>):

Method	URL	Description
POST	/auth/register	Register a new user
POST	/auth/login	Login and receive JWT
GET	/expenses	List all expenses
POST	/expenses	Add a new expense
PUT	/expenses/{id}	Update existing expense by ID
DELETE	/expenses/{id}	Delete an expense by ID
GET	/people	Get list of people involved
GET	/balances	View current balances by person
GET	/settlements	Get optimized settlement summary

6. Sample Requests / Test Cases
Full Flow:
Register

json
Copy
Edit
POST /auth/register
{
  "username": "Shantanu",
  "email": "shan@example.com",
  "password": "P@ssw0rd!"
}
Login → Receive JWT

Create Expenses

json
Copy
Edit
POST /expenses
{
  "amount": 600.00,
  "description": "Dinner",
  "paidBy": "Shantanu",
  "sharedWith": ["Shantanu","Sanket","Om"]
}
View / Update / Delete Expenses

Summary Operations

GET /people

GET /balances

GET /settlements

Edge Cases:
Negative amount → returns 400

Missing fields → returns 400

Non-existent ID for update/delete → returns 404

No expenses → returns empty collections

7. Postman Collection 📬
All endpoints and example requests are included in this Postman collection:
👉 Import the collection here

Steps to use:

Click the link above and import into Postman.

Set the {{base_url}} environment variable to https://split-app-api.onrender.com.

Inside collection:

First call Register, then Login

Copy the received token into {{auth_token}} environment variable

Use {{auth_token}} in Authorization header for protected calls

Run through folders in sequence:

Expense Management → Settlements & Summary → Edge Cases

8. Deployment
Live API URL:

arduino
Copy
Edit
https://split-app-api.onrender.com
EF Core migrations run automatically at startup

Ensure environment variables are set for DB connection and JWT keys

9. Validation & Error Handling
Data annotations: [Required], [Range], [StringLength], [MinLength]

Returns HTTP 400 for bad inputs, 404 for missing resources

Error responses include a success: false flag and helpful message

10. Roadmap & Enhancements
Areas for future work:

Support non-equal splits (percentage or exact amounts)

Add expense categories & reporting

Enable recurring expenses

Build a simple web or mobile frontend

