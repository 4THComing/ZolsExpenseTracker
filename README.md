# Zols Enterprise Expense Tracker Ecosystem

A multi-tiered financial management ecosystem built with C# and .NET 10. This project is structured as a modular monorepo that evolves from a local console application into a high-scale, cloud-integrated Open Banking Platform.

---

## Architectural Version Roadmap

```text
💡 Phase 1: Engine ──► 💡 Phase 2: Server ──► 💡 Phase 3: Open Banking Platform ──► 💡 Phase 4: Client ──► 💡 Phase 5: Enterprise
   [.NET 10 Console]     [ASP.NET Core API]      [Stitch Open API]      [Flutter Mobile]      [SAP CPI / Azure]
```

### 🔹 V1.0 - Core Console Engine (Active)
* **Objective**: Establish the core business logic, filtering engines, and mathematical validation rules.
* **Features**: Manual expense entry, custom category mapping, comprehensive analytical reporting modules, and local JSON data persistence.

### 🔹 V2.0 - ASP.NET Core Web API (In Development)
* **Objective**: Migrate the engine to an independent backend server to serve multi-user application requests.
* **Features**: Relational database migration via Entity Framework Core, structured Data Transfer Objects (DTOs), clean Controller routing, and automated OpenAPI (Swagger) contract documentation.

### 🔹 V3.0 - Stitch Open Banking Integration (Planned)
* **Objective**: Introduce real-time automated transaction tracking using native South African Open Banking Platform infrastructure.
* **Features**: Secure OAuth 2.0 authorization flows, GraphQL transaction ledger queries, custom webhook receivers for instant card-swipe alerts, and automated Regex merchant descriptor cleansing.

### 🔹 V4.0 - Cross-Platform Flutter Mobile Client (Planned)
* **Objective**: Build a responsive visual interface to consume the unified backend APIs.
* **Features**: Shared backend API client generation via OpenAPI utilities, secure localized token storage, and dynamic charting components for reporting dashboards.

### 🔹 V5.0 - SAP CPI & Azure Cloud Integration (Planned)
* **Objective**: Scale the platform into a secure, production-grade enterprise system.
* **Features**: Cloud hosting on Azure App Services/Azure SQL, credential management via Azure Key Vault, API gateway controls through Azure APIM, and automated corporate expense synchronization iFlows built in SAP Cloud Platform Integration (CPI).

---

## Active V1 Engine Features

### Expense Management
* Add, view, and delete expenses
* Rigorous data input validation rules
* Persistent state management via local JSON storage

### Categories Managed
* None |Food | Transportation | Utilities | Entertainment | Healthcare | Education | Other

### Analytics & Reporting
* Comprehensive financial metric aggregation (Total, Average, Highest, and Lowest costs)
* Granular search features (Filter by category, description keywords, date ranges, and cost parameters)
* Automated localized monthly summary formatting

---

## Testing & CI/CD Discipline

High reliability is enforced at the core through automated validation pipelines.

* **Test Suite**: Driven by **xUnit** covering mathematical total aggregations, range boundaries, and filter matrices.
* **Current Status**: ✅ **11 Passing Tests**
* **CI/CD Pipeline**: Governed via **GitHub Actions** (`dotnet.yml`) to automatically execute dependency restoration, compilation verification, and continuous test runs on every code check-in.

---

## Monorepo Project Layout

```text
ZolsConsoleExpenseTracker
│
├── .github/workflows/
│   └── dotnet.yml            # CI/CD pipeline automation script
│
├── docs/                     
│   ├── diagrams/             # Version roadmap architectures
│   ├── images/               # Application runtime screenshots
│   ├── wireframes/           # Initial UI visual mockups
│   └── case-studies/         # Enterprise integration solution blueprints
│
├── src/                      
│   └── Zols.ExpenseTracker.V1.Console/
│       ├── Data/             # Contains localized expenses.json
│       ├── Models/           # Core structural entities (Expense.cs)
│       ├── Services/         # Decoupled transaction logic components
│       ├── Storage/          # Data reading and writing handlers
│       └── Program.cs        # Console execution entry point
│
└── tests/                    
    └── Zols.ExpenseTracker.V1.Tests/
        └── UnitTest1.cs      # Core business logic validation suites
```

---

## Technology Stack & Ecosystem

* **Languages & Frameworks**: C# 10, .NET 10, Dart (Future), GraphQL (Future)
* **Testing & Tools**: xUnit, Swashbuckle (Swagger), Git, VS Code, Visual Studio (`.slnx`)
* **Infrastructure Target**: GitHub Actions, Azure Cloud Platform, SAP Integration Suite (CPI), Stitch Open Banking API

---

## Visual Assets

### Main Menu
![Main Menu](docs/images/main-menu.png)

### Expense List
![Expense List](docs/images/expenses-list.png)

### Monthly Report
![Monthly Report](docs/images/monthly-report.png)

### Architecture Wireframe
![Wireframe](docs/wireframes/expense-tracker-wireframe.png)

---

## Author

**Zolani Mjikeliso** 
SELF-TAUGHT DEVELOPER 
*Building skills in Clean Architecture, Full-Stack .NET Development, Azure Cloud Services, and SAP Enterprise Integration.*

* [LinkedIn Profile](https://www.linkedin.com/in/zolani-mjikeliso-89b039213)
