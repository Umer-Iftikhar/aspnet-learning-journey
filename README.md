# ASP.NET Core Learning Journey

Learning full-stack web development with ASP.NET Core, Razor, EF Core, and vanilla JS.

## Progress Tracker

### PHASE 1: Raw HTML Forms + ASP.NET Core Fundamentals 
- [✅] Project 1.1: Simple Calculator 
- [✅] Project 1.2: Task Collector 
- [✅] Project 1.3: Contact Form  
### PHASE 2: Razor Syntax + Proper MVC 
- [✅] Project 2.1: Student Grade Tracker 
- [✅] Project 2.2: Book Library
- [✅] Project 2.3: Login System (Memory-based)

### PHASE 3: CSS + Layouts (Current)
 - [ ] Project 3.1: Style Your Book Library 
 - [ ] Project 3.2: Dashboard with Cards
### Upcoming Phases
- [ ] Phase 4: SQL + Entity Framework Core
- [ ] Phase 5: JavaScript + DOM
- [ ] Phase 6: Authentication + Authorization
- [ ] Phase 7: Validation + Error Handling
- [ ] Phase 8: Capstone E-Commerce Project
- [ ] Phase 9: Production Patterns (MANDATORY)


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
* **ViewModels:**ViewModels are specialized classes that shape data for a specific view, separating UI concerns from domain models.
* **CRUD operations:**Learned `Edit` and `Delete` features and implemented them.
* **Partial views:**Created `_partial views` to avoid reuse of code.
* **ViewData["]:** Used this to pass small, unstructured data (like page titles) from a controller to a view without creating a full ViewModel.
* **Layout:**Used `_layout` in shared views and fixed the `nav` links. 
* **Session:**Learnt the use of `HttpContext.Session`.


## Current Phase
Phase 2 - Week 2 - Day 7
