# InventoryHub - Full-Stack Integration Project

InventoryHub is a full-stack sample that integrates:
- Back-End: .NET Minimal API
- Front-End: Blazor WebAssembly

## Project Structure
- `InventoryHub.Api` - Product API with CORS, JSON responses, pagination, and output caching
- `InventoryHub.Web` - Blazor UI that consumes the API asynchronously using `HttpClient`
- `InventoryHub.slnx` - Solution file

## Features Mapped to Grading Criteria

### 1) GitHub Repository
The project is ready to be pushed to a public GitHub repository named `InventoryHub`.

### 2) Integration Code
- Frontend calls backend endpoint: `GET /api/products?pageNumber={x}&pageSize={y}`
- Blazor service uses `GetFromJsonAsync<PagedResult<Product>>()`

### 3) Debugging with Copilot
Common integration problems handled in code:
- CORS policy configured in API for Blazor origins
- API failures handled in UI with `try-catch`
- Fallback data shown when API is unavailable

### 4) JSON Structures
Backend JSON matches strongly typed models:
- `Product`: `id`, `name`, `quantity`, `price`
- `PagedResult<T>`: `items`, `pageNumber`, `pageSize`, `totalCount`, `totalPages`

### 5) Performance Optimization
- Pagination implemented in API and UI
- Output caching enabled in API (`CacheOutput` with 30-second expiration)

### 6) Reflective Summary
Use this sample summary in your submission:

> Microsoft Copilot helped me complete the InventoryHub project faster and with better code quality. It assisted me in generating the Product model and Minimal API endpoint, then guided me in configuring CORS so the Blazor frontend could communicate with the backend across different ports. Copilot also helped me implement async data fetching with `GetFromJsonAsync`, and suggested clean `try-catch` handling with fallback UI content when the API is unavailable. For performance, Copilot supported adding pagination and response caching, which improved load time and reduced unnecessary data transfer. Overall, Copilot acted like a real-time coding partner for building, debugging, and optimizing the full-stack integration.

## Run Locally
1. Run API:
   - `dotnet run --project InventoryHub.Api`
2. Run Blazor app:
   - `dotnet run --project InventoryHub.Web`
3. Open the Blazor URL shown in terminal and navigate to `/products`.

## GitHub Upload Steps
1. Create a new public repository named `InventoryHub` on GitHub.
2. From this folder, run:
   - `git init`
   - `git add .`
   - `git commit -m "Initial commit"`
   - `git branch -M main`
   - `git remote add origin <YOUR_GITHUB_REPO_URL>`
   - `git push -u origin main`
3. Copy your repository URL and submit it in the Coursera `My submission` tab with your reflective summary.

## Submission Template
- Title: `InventoryHub - Full-Stack Integration Project`
- URL: `<YOUR_PUBLIC_GITHUB_REPO_URL>`
- Reflective Summary: Use the paragraph above (or your own version)
