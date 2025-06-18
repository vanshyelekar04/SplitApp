```markdown
# 🚀 Split App – Backend API

A REST API for splitting group expenses with balance calculations and settlement summaries.

## Table of Contents
1. [Features](#features)
2. [Tech Stack](#tech-stack)  
3. [API Endpoints](#api-endpoints)  
4. [Setup](#setup)  
5. [Authentication Flow](#authentication-flow)  
6. [Usage Examples](#usage-examples)  
7. [Deployment](#deployment)  
8. [Postman Collection](#postman-collection)  
9. [Troubleshooting](#troubleshooting)

## Features
- ✅ Expense management (CRUD operations)
- 👥 Automatic participant tracking
- ⚖️ Equal expense splitting
- 💰 Balance calculations
- 🔄 Optimal settlement suggestions
- 🔒 JWT Authentication

## Tech Stack
| Component       | Technology |
|----------------|------------|
| Backend        | .NET 8     |
| Database       | PostgreSQL |
| ORM            | EF Core 8  |
| Authentication | JWT        |
| Hosting        | Render     |

## API Endpoints

### Authentication
| Method | Endpoint       | Description          |
|--------|----------------|----------------------|
| POST   | `/auth/register` | Register new user    |
| POST   | `/auth/login`    | Login and get JWT    |

### Expenses
| Method | Endpoint          | Description            |
|--------|-------------------|------------------------|
| GET    | `/expenses`       | List all expenses      |
| POST   | `/expenses`       | Create new expense     |
| PUT    | `/expenses/{id}`  | Update expense         |
| DELETE | `/expenses/{id}`  | Delete expense         |

### Calculations
| Method | Endpoint        | Description              |
|--------|-----------------|--------------------------|
| GET    | `/people`       | List all participants    |
| GET    | `/balances`     | Show individual balances |
| GET    | `/settlements`  | Get settlement plan      |

## Setup

1. Clone repository:
```bash
git clone https://github.com/vanshyelekar04/SplitApp.git
cd SplitApp/WebAPI
```

2. Configure `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_PostgreSQL_Connection_String"
  },
  "JwtSettings": {
    "Key": "Your_256-bit_Secret_Key",
    "Issuer": "Your_Issuer",
    "Audience": "Your_Audience",
    "ExpiryInMinutes": 60
  }
}
```

3. Run the application:
```bash
dotnet restore
dotnet build
dotnet run
```

## Authentication Flow

### 1. Register a New User
```http
POST https://split-app-api.onrender.com/auth/register
Content-Type: application/json

{
  "username": "testuser",
  "email": "test@example.com",
  "password": "P@ssw0rd123!"
}
```

### 2. Login to Get JWT Token
```http
POST https://split-app-api.onrender.com/auth/login
Content-Type: application/json

{
  "email": "test@example.com",
  "password": "P@ssw0rd123!"
}
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expires": "2025-06-18T12:00:00Z"
}
```

### 3. Use the Token
Add to request headers:
```text
Authorization: Bearer your_jwt_token_here
```

## Usage Examples

### Create Expense
```http
POST https://split-app-api.onrender.com/expenses
Content-Type: application/json
Authorization: Bearer your_jwt_token_here

{
  "amount": 600.00,
  "description": "Dinner",
  "paidBy": "Alice",
  "sharedWith": ["Alice", "Bob", "Charlie"]
}
```

### Update Expense
```http
PUT https://split-app-api.onrender.com/expenses/3676daae-2103-42a1-b375-343b528b0f35
Content-Type: application/json
Authorization: Bearer your_jwt_token_here

{
  "amount": 650.00,
  "description": "Updated Dinner",
  "paidBy": "Om",
  "sharedWith": ["Om", "Shantanu"]
}
```

## Deployment
Live API endpoint:  
[https://split-app-api.onrender.com](https://split-app-api.onrender.com)

## Postman Collection

### Import Instructions
1. **Download Collection**:  
   [Raw Collection JSON](https://raw.githubusercontent.com/vanshyelekar04/SplitApp/main/postman/SplitApp.postman_collection.json)

2. **Set Up Environment**:
   - Create new environment in Postman
   - Add variables:
     ```text
     base_url = https://split-app-api.onrender.com
     auth_token = {{jwt_token}}
     ```

3. **Run in Postman**:  
   [![Run in Postman](https://run.pstmn.io/button.svg)](https://web.postman.co/workspace/e8c0b6e0-d293-445e-b550-ebda8b91fbe9)

   **Direct Link for Postman Collection**
   https://web.postman.co/workspace/e8c0b6e0-d293-445e-b550-ebda8b91fbe9



### Collection Structure
1. **Authentication**
   - Register user
   - Login and save token

2. **Expense Management**
   - Create, read, update, delete expenses

3. **Calculations**
   - Get balances
   - View settlements

4. **Test Cases**
   - Error scenarios
   - Validation tests

## Troubleshooting

### Common Issues
| Error | Solution |
|-------|----------|
| 401 Unauthorized | Verify token is valid and in Authorization header |
| 404 Not Found | Check endpoint URL and ID parameters |
| 400 Bad Request | Validate request body matches schema |
| Token Expired | Re-login to get new token |

### Debugging Tips
1. Check server logs for errors
2. Verify database connection
3. Test with Postman's "Console" view
4. Ensure CORS is properly configured

---

Developed by [Vansh Yelekar](https://github.com/vanshyelekar04)
```
