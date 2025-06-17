Here's a properly formatted and complete `README.md` with raw links:

```markdown
# 🚀 Split App – Backend API

A REST API for splitting group expenses with balance calculations and settlement summaries.

## Table of Contents
1. [Features](#features)
2. [Tech Stack](#tech-stack)  
3. [API Endpoints](#api-endpoints)  
4. [Setup](#setup)  
5. [Usage Examples](#usage-examples)  
6. [Deployment](#deployment)  
7. [Postman Collection](#postman-collection)

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
    "Audience": "Your_Audience"
  }
}
```

3. Run the application:
```bash
dotnet restore
dotnet run
```

## Usage Examples

### Create Expense
```http
POST https://split-app-api.onrender.com/expenses
Content-Type: application/json
Authorization: Bearer {token}

{
  "amount": 600.00,
  "description": "Dinner",
  "paidBy": "Alice",
  "sharedWith": ["Alice", "Bob", "Charlie"]
}
```

### Get Balances
```http
GET https://split-app-api.onrender.com/balances
Authorization: Bearer {token}
```

## Deployment
Live API endpoint:  
[https://split-app-api.onrender.com](https://split-app-api.onrender.com)

## Postman Collection
[![Run in Postman](https://run.pstmn.io/button.svg)](https://www.postman.com/vanshyelekar/workspace/split-app/collection/e8c0b6e0-d293-445e-b550-ebda8b91fbe9)

Direct collection link:  
[https://www.postman.com/collections/e8c0b6e0-d293-445e-b550-ebda8b91fbe9](https://www.postman.com/collections/e8c0b6e0-d293-445e-b550-ebda8b91fbe9)

---

Developed by [Vansh Yelekar](https://github.com/vanshyelekar04)
```
