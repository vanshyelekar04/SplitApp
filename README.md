# 🚀 Split App – Backend

A minimal REST API for splitting group expenses, inspired by apps like Splitwise and Google Pay Bills Split.

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

This API lets users split expenses, view/edit/delete them, and calculate balances & optimized settlement summaries.

---

## 2. Features

- 🧾 Add, view, edit, delete expenses  
- 👥 Auto-derived list of participants  
- ⚖️ Equal-share splitting by default  
- 💰 Calculate individual balances & min-transactions settlements  
- 🚨 Validation and clear HTTP error responses

---

## 3. Tech Stack

- **Backend**: ASP.NET Core 8  
- **Database**: PostgreSQL (hosted on Render.com)  
- **Authentication**: JWT Bearer Tokens  
- **ORM**: Entity Framework Core  
- **Password Hashing**: BCrypt

---

## 4. Getting Started

### Prerequisites

- .NET 8 SDK  
- PostgreSQL database (or use the default Render-hosted one)

### Local Setup

```bash
git clone https://github.com/vanshyelekar04/SplitApp.git
cd SplitApp/WebAPI
Configure appsettings.json
Update these values with your own credentials:

ConnectionStrings:DefaultConnection → your PostgreSQL connection string

JwtSettings:Key, Issuer, Audience → secure random strings

Build and Run
bash
Copy
Edit
dotnet restore
dotnet build
dotnet run
Access Swagger UI at: https://localhost:<port>/swagger

5. API Endpoints
Method	URL	Description
POST	/auth/register	Register a new user
POST	/auth/login	Login and receive JWT
GET	/expenses	List all expenses
POST	/expenses	Add a new expense
PUT	/expenses/{id}	Update existing expense
DELETE	/expenses/{id}	Delete an expense
GET	/people	Get list of all participants
GET	/balances	View balance per person
GET	/settlements	Get simplified settlements

6. Sample Requests / Test Cases
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
Login
json
Copy
Edit
POST /auth/login
{
  "email": "shan@example.com",
  "password": "P@ssw0rd!"
}
Add Expense
json
Copy
Edit
POST /expenses
{
  "amount": 600.00,
  "description": "Dinner",
  "paidBy": "Shantanu",
  "sharedWith": ["Shantanu", "Sanket", "Om"]
}
Edge Case Examples
Add with negative amount → 400 Bad Request

Missing fields → 400 Bad Request

Update/Delete with non-existent ID → 404 Not Found

No expenses yet → returns empty arrays

7. Postman Collection 📬
🔗 Split App – Postman Collection - https://web.postman.co/workspace/e8c0b6e0-d293-445e-b550-ebda8b91fbe9

How to Use:
Import the collection in Postman

Set {{base_url}} = https://split-app-api.onrender.com

Register → Login → Copy JWT token

Set token as {{auth_token}} in headers

Follow folders:

Expense Management

Settlements

Edge Cases

8. Deployment
Live URL:

arduino
Copy
Edit
https://split-app-api.onrender.com
EF Core migrations run at app startup. Data is seeded for testing.

Required Environment Variables:

env
Copy
Edit
ConnectionStrings__DefaultConnection=your_pg_url
JwtSettings__Key=your_secure_key
JwtSettings__Issuer=your_issuer
JwtSettings__Audience=your_audience
9. Validation & Error Handling
Uses [Required], [Range], [MinLength], etc.

400 for bad requests, 404 for not found

Responses always in format:

json
Copy
Edit
{
  "success": false,
  "message": "Error details here"
}

💻 Developed by Vansh Pravin Yelekar
