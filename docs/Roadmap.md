# Roadmap

### PHASE 1: Raw HTML Forms + ASP.NET Core Fundamentals (Week 1-1.5)

```Goal: Understand HTTP request/response cycles, build forms without frameworks, and handle POST/GET manually.```

* **Project 1.1:** Simple Calculator – Create an MVC project with raw HTML forms and a controller that receives data via parameters.

* **Project 1.2:** Task Collector – Use an in-memory List<string> to store tasks; learn how data disappears when the app restarts.

* **Project 1.3:** Contact Form – Create a ContactSubmission model and use TempData to pass data between requests.

----

### PHASE 2: Razor Syntax + Proper MVC (Week 2-2.5)

```Goal: Master Razor syntax, use Tag Helpers, and understand ViewModels vs. Models.```

* **Project 2.1:** Student Grade Tracker – Display students in an HTML table using @foreach and implement server-side validation.

* **Project 2.2:** Book Library – Perform full CRUD operations and use ViewModels to separate form data from domain models.

* **Project 2.3:** Login System (Memory-based) – Implement a login form and store state in a Session.

----

### PHASE 3: CSS Fundamentals + Razor Layouts (Week 3-3.5)

```Goal: Learn box models, flexbox, and shared layouts to make projects responsive and visually acceptable.```

* **Project 3.1:** Style Your Book Library – Add site.css and style tables and forms with media queries for mobile.

* **Project 3.2:** Dashboard with Cards – Build a dashboard using flexbox and reusable partial views (_StatCard.cshtml).

----

### PHASE 4: SQL + Entity Framework Core (Week 4-5)

```Goal: Design databases and use EF Core Code-First approach for real persistence.```

* **LINQ Practice**

* **Project 4.1:** Todo App with Database – Use AppDbContext and migrations to perform CRUD with a real database.

* **Project 4.2:** Blog Posts – Implement search and sorting functionality using LINQ.

* **Project 4.3:** Product Inventory – Manage one-to-many relationships (Category → Products) and use .Include() for data fetching.

* **SQL Practice**

----

### PHASE 5: JavaScript + DOM Manipulation (Week 6)

```Goal: Use vanilla JS for DOM manipulation and make AJAX calls with the fetch() API.```

* **Project 5.1:** Client-Side Todo Toggle – Send AJAX POST requests to update UI without page reloads.

* **Project 5.2:** Live Search – Implement live search by title using both MVC partial views and minimal API endpoints.

* **Project 5.3:** Dynamic Form Fields – Use JS to dynamically add/remove input fields for a recipe form.

----

### PHASE 6: Authentication + Authorization (Week 7)

```Goal: Implement ASP.NET Core Identity and protect routes using roles.```

* **Project 6.1:** User Registration + Login – Scaffold Identity pages manually and use cookie authentication.

* **Project 6.2:** Blog with Authors – Link posts to specific users and restrict editing/deletion to the original author.

* **Project 6.3:** Role-Based Bookstore – Create "Admin" and "Customer" roles with different access permissions.

----

### PHASE 7: Validation + Error Handling (Week 8)

```Goal: Master Data Annotations, global error handling, and unit testing with xUnit.```

* **Project 7.1:** Enhanced Product Management – Add complex validation (e.g., custom attributes) and write unit tests for your models.

* **Project 7.2:** Contact Form with Async Validation – Use Remote validation to check for unique emails against the database.

* **Project 7.3:** Global Error Handling – Create custom 404/500 pages and implement error logging middleware.

----

### PHASE 8: Capstone Project - Indie Game Discovery Platform (Week 9-10)

```Goal: Build a full-scale application using a hybrid data access strategy (EF Core + Dapper).```

* **Hybrid Database uproach:** Using both Entity Framework Core and Dapper but better performance

* **Core Features:** User roles (Admin, Dev, Player), image uploads, AJAX-based wishlist, and integration with the GitHub API.

* **Technical Highlights:** Use the Bogus library for data seeding and implement responsive design.

----

### PHASE 9: Production Patterns & Clean Architecture (Week 11-12)

```Goal: Refactor the Phase 8 capstone into a professional, portfolio-ready application.```

* **Architecture Foundations:** Implement Dependency Injection (DI), the Service Layer pattern with DTOs, and the Repository Pattern.

* **Advanced Features:** Integrate the RAWG API for real-world game data and use EF Core Fluent API for advanced database configurations.

----

### PHASE 10: The Web API Decoupling (Week 13-14)

```Goal: Move away from Server-Side Rendering (Razor) and build a "Headless" backend. This allows your data to be consumed by Mobile Apps or Modern Frontends.```

* **Project 10.1:** The RESTful Refactor – Convert your GameController into a GameApiController, JSON: Master JSON serialization (camelCase vs PascalCase).

* **Project 10.2:** Security with JWT (JSON Web Tokens) – Replace Cookie-based authentication with Token-based authentication and protect endpoints using the [Authorize] attribute with Bearer tokens.

* **Project 10.3:** API Documentation with Swagger – Integrate Swashbuckle/OpenAPI and Test backend using the Swagger UI and Postman instead of a browser.

----

### PHASE 11: Azure Deployment & DevOps (Week 15)

```Goal: Get your code off your machine and into the real world. Learn the "DevOps" side of .NET.```

* **Project 11.1:** Azure App Service – Deploy your Web API to the cloud.Learn to manage Environment Variables in the Azure Portal (keeping your Secrets out of the cloud code).

* **Project 11.2:** Azure SQL & Blob Storage – Migrate your local database to Azure SQL and move game images from wwwroot to Azure Blob Storage (Cloud file hosting).

* **Project 11.3:** CI/CD with GitHub Actions – Create a .yml workflow file and automate your deployment so that every time you git push, Azure automatically updates your live site.

----

### PHASE 12: React Frontend (API Consumer) (Week 16-17)
```Goal: Prove your API works. You aren't becoming a React expert; you are learning how a "Client" talks to your "Server."```

* **The Task:** Build a small, separate React application (using Vite).

*Features:*

Fetch data: Use useEffect and fetch() to call your Azure-hosted API.
Authentication: Handle the login flow by storing the JWT in localStorage.
Display: Build a simple "Game Gallery" that pulls data from your backend.

**Key Lesson:** Solve CORS (Cross-Origin Resource Sharing) issues on the backend to allow your React app to talk to your API.