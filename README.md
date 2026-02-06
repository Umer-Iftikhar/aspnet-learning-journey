# ASP.NET Core Learning Journey

Learning full-stack web development with ASP.NET Core, Razor, EF Core, and vanilla JS.

## Progress Tracker

### PHASE 1: Raw HTML Forms + ASP.NET Core Fundamentals ✅
- [✅] Project 1.1: Simple Calculator 
- [✅] Project 1.2: Task Collector 
- [✅] Project 1.3: Contact Form  

### PHASE 2: Razor Syntax + Proper MVC ✅
- [✅] Project 2.1: Student Grade Tracker 
- [✅] Project 2.2: Book Library
- [✅] Project 2.3: Login System (Memory-based)

### PHASE 3: CSS + Layouts ✅
- [✅] Project 3.1: Style Your Book Library 
- [✅] Project 3.2: Dashboard with Cards

### PHASE 4: SQL + Entity Framework Core (In Progress)
- [✅] Setup: MySQL + EF Core Tools
- [✅] LINQ Deep Dive Practice (2 hours)
- [✅] Project 4.1: Todo App with Database
- [ ] Project 4.2: Blog Posts
- [ ] Project 4.3: Product Inventory
- [ ] SQL Practice Block (Day 1-2, 4-5 hours total)

### Upcoming Phases
- [ ] Phase 5: JavaScript + DOM
- [ ] Phase 6: Authentication + Authorization
- [ ] Phase 7: Validation + Error Handling
- [ ] Phase 8: Project: Indie Game Discovery Platform
- [ ] Phase 9: Production Patterns (MANDATORY)
- [ ] Phase 10: WEB API: Convert Capstone to REST API
- [ ] Phase 11: Azure Deployment
- [ ] Phase 11: React Frontend (API Consumer)

## 🧠 Key Lessons Learned


### Phase 1: Fundamentals
* **The PRG Pattern:** Learned to use "Post-Redirect-Get". Instead of returning a View directly from a POST action (which causes "Confirm Form Resubmission" errors on refresh), I now redirect to a GET action.
* **Statelessness:** Observed how data in `static` lists disappears when the server restarts, highlighting the need for databases.
* **Model Binding:** Discovered how ASP.NET Core automatically maps HTML `name` attributes to C# Class properties.
* **TempData:** Used this to persist small amounts of data across a single redirect.


### Phase 2: Razor & Tag Helpers
* **Tag Helpers vs Raw HTML:** Tag Helpers (`asp-for`, `asp-action`) provide compile-time safety and auto-generate correct HTML attributes based on C# types.
* **Strongly-Typed Models:** Using `@model` directive and passing models to views gives IntelliSense and catches errors at compile-time vs runtime.
* **Data Annotations:** `[Required]`, `[Range]` enable declarative validation on models.
* **Server-Side Validation:** `ModelState.IsValid` is mandatory for security - client-side validation is only for UX, not security.
* **LINQ Fundamentals:** Learned `.Max()` with lambda expressions (`s => s.Id`) for finding maximum values in collections.
* **Nullable Reference Types:** Understanding why `string?` with `[Required]` allows compile-time null-safety while enforcing runtime validation.
* **ViewModels:** ViewModels are specialized classes that shape data for a specific view, separating UI concerns from domain models.
* **CRUD operations:** Learned `Edit` and `Delete` features and implemented them.
* **Partial views:** Created `_partial views` to avoid reuse of code.
* **ViewData[""]:** Used this to pass small, unstructured data (like page titles) from a controller to a view without creating a full ViewModel.
* **Layout:** Used `_layout` in shared views and fixed the `nav` links. 
* **Session:** Learnt the use of `HttpContext.Session`.


### Phase 3: CSS + Layouts
* **Box Model:** Understanding margin (outside), border, padding (inside), and content layers for proper spacing.
* **Flexbox Basics:** Using `display: flex`, `gap`, and `flex-direction` to arrange elements horizontally or vertically.
* **Descendant Selectors:** Targeting nested elements like `nav a` (all `<a>` inside `<nav>`) for precise styling without class pollution.
* **Pseudo-classes:** Using `:hover`, `:nth-child(even)`, `:nth-child(odd)` for interactive and alternating styles.
* **Pseudo-elements:** Creating decorative elements with `::after` for effects like animated underlines without extra HTML.
* **CSS Transitions:** Adding smooth animations with `transition` property (e.g., `transition: all 0.25s ease`).
* **Media Queries:** Using `@media (max-width: 768px)` to apply responsive styles for mobile devices.
* **Browser DevTools:** Using Inspect (F12) to debug CSS, see applied styles, and understand the HTML structure.
* **CSS Cascade:** Understanding that styles read top-to-bottom, and later rules override earlier ones with equal specificity.
* **Razor Partial Views:** Created reusable UI components (`_StatCard.cshtml`) that can be called multiple times with different data - change the partial once, all instances update.
* **ViewModels for Components:** Used `StatCardViewModel` with `object` type to handle different data types (int, string, decimal) in a single reusable component.
* **Flexbox Grid Layouts:** Built responsive card grids using `flex-wrap`, `gap`, and `calc()` for dynamic column layouts (3 → 2 → 1 columns).
* **CSS Transform & Box Shadow:** Applied `transform: translateY()` for hover lift effects and layered `box-shadow` for depth perception.
* **Responsive Design Patterns:** Implemented mobile-first thinking with breakpoints at 768px (tablet) and 480px (mobile).
* **Controller Data Sharing:** Used `public static` properties to expose private data between controllers (`BooksController.Books`).
* **Manual Algorithm Implementation:** Built most-popular-category logic using nested loops (O(n²)) instead of LINQ, demonstrating understanding of underlying logic.


### Phase 4: LINQ Deep Dive 
* **Method Syntax vs Query Syntax:** Used method syntax (`.Where()`, `.Select()`) throughout - more concise and closer to functional programming style.
* **Deferred Execution:** `IEnumerable` queries don't execute until iterated - learned the difference between building a query and running it.
* **`.ToList()` Materialization:** Calling `.ToList()` executes the query immediately and caches results in memory - prevents re-execution on multiple iterations.
* **Filtering with `.Where()`:** Applied lambda predicates to filter collections based on conditions (price, category, stock levels).
* **Sorting with `.OrderBy()` and `.ThenBy()`:** Chained sorting operations - primary sort by category, secondary by price.
* **Aggregation Functions:** Used `.Sum()`, `.Average()`, `.Max()`, `.Count()` for calculations without manual loops.
* **Grouping with `.GroupBy()`:** Grouped products by category, accessed `group.Key` and iterated over group items.
* **Projection with `.Select()`:** Transformed data into new shapes - anonymous types with calculated properties (e.g., `PriceWithTax`).
* **Anonymous Types:** Created objects on-the-fly with `new { Property = value }` - useful for queries but can't be returned from methods.
* **Method Chaining:** Combined multiple LINQ operations in one chain - filter → sort → group → project.
* **`.Any()` for Existence Checks:** Used `.Any()` to check if a collection has items before iterating - cleaner than `.Count() > 0`.
* **IEnumerable vs IQueryable (Theory):** Learned IEnumerable works in-memory (C# does filtering), IQueryable works with databases (SQL does filtering) - critical for Phase 4 EF Core.


### Phase 4: SQL + Entity Framework Core (In Progress)
* **Code-First Workflow:** Define C# classes (models) first, EF Core generates matching database tables via migrations - keeps models as source of truth and eliminates manual SQL.
* **Migrations as Version Control:** Migrations track database schema changes over time - changing a model without creating a migration causes a mismatch between code and database structure.
* **Async Database Operations:** Using `async`/`await` (e.g., `.ToListAsync()`) releases server threads while waiting for database responses - synchronous methods block threads, reducing concurrent request capacity.
* **DbContext and DbSet<T>:** DbContext acts as a bridge between the application and database; `DbSet<T>` represents a table where each entity type gets its own queryable collection.
* **Database Persistence vs In-Memory:** With database storage, data persists across app restarts - unlike Phase 1's `static List<>` where data disappeared when the server restarted.
* **Dependency Injection with DbContext:** ASP.NET Core injects `AppDbContext` into controller constructors automatically - enables centralized connection management and makes code testable without hardcoding database dependencies.
* **SaveChangesAsync Pattern:** EF Core tracks changes in memory but doesn't persist them until `SaveChangesAsync()` is called - forgetting it means changes are lost after the request ends; async version prevents thread blocking during I/O operations.
* **Migration Workflow:** `Add-Migration` generates C# code with `Up()` (apply changes) and `Down()` (rollback) methods; `Update-Database` executes the migration and runs actual SQL - separation allows reviewing changes before touching the database.


## Current Phase
**Phase 4 Started:** Project 4.1 Complete ✅  
**Next Up:** Project 4.2: 

----

## 📊 Stats
- **Total Projects Completed:** 10 mini-projects
- **LINQ Exercises Completed:** 8/8 (2-hour deep dive)
- **Phases Completed:** 3/9
- **Current Focus:** Preparing for database persistence with MySQL + Entity Framework Core