# Shipment Tracking System

## Project Description

The Shipment Tracking System is a simple logistics management application built with a clean architecture approach. It allows users to:
- View a list of shipments.
- View details of a specific shipment
- Create new shipments.
- Edit existing shipments.
- Delete shipments (requires authentication).
- Filter list of shipments based on their name and status.

The application consists of:
-  **Backend API** for managing shipment data.
-  **Frontend Blazor WebAssembly Application** for interacting with the API.
---
## Steps to Run the Application

### **Backend (API)**
1. Open the **Infrastructure** project in Visual Studio.
2. Ensure you have the correct .NET version (8.0) installed.
3. Run the following commands to restore dependencies:
```bash
dotnet restore
```

4. Run the API using Visual Studio or:
```bash
dotnet run --project Infrastructure
```

5. Verify the API is running at:
- Swagger: `https://localhost:5001/swagger`

### **Frontend (Blazor WebAssembly)**

1. Open the **Presentation** project in Visual Studio.
2. Ensure the backend API is already running.
3. Update `HttpClient`'s base address in `Program.cs` if necessary.
4. Run the frontend application:

```bash
dotnet run --project Presentation
```

5. Access the frontend at:
-  `http://localhost:5136`
 
---
## Project Structure
- ShipmentTrackingSystem/
	- Domain/
	  - Models/
	  - Enums/
	- Application/
	  - Services/
	  - Validators/
	- Infrastructure/
	  - Controllers/
	- Presentation/
 	  - wwwroot/
	  - Layout/
	  - Pages/
	  - Components/
	  - Services/
	- ShipmentTrackingSystem.sln

---

## Technologies and Libraries Used

### **Backend**
- **.NET 8.0**
- **ASP.NET Core WebAPI**
- **JWT Bearer Authentication 8.0.0**
- **FluentValidation 11.3.0**
- **Serilog.AspNetCore 9.0.0**
- **Serilog.Sinks.Console 9.0.0**
- **Swashbuckle.AspNetCore 7.2.0** (API Documentation)

### **Frontend**
- **Blazor WebAssembly**
- **HttpClient** (API integration)
- **CSS** (Custom styles)

---

## Instructions for Testing Functionality

### **Authentication**
1. Run the backend and frontend applications.
2. Click the **Login** button in the frontend to authenticate.
3. Verify that the **Delete** button appears for shipments.

### **CRUD Operations**
1. **Create a Shipment**:
   - Go to **"Create a shipment"** in the Navbar.
   - Fill in shipment details and submit.
2. **View Shipments**:
   - Go to **Shipments** in the Navbar.
   - Use the search bar to filter shipments by name and status.
3. **View specific Shipment**:
	 -	Ensure you are in the **Shipments** page.
	 -	Ensure there is a shipment listed.
	 -	Click on the shipments name.
4. **Update a Shipment**:
   - Click the **Edit** button for a specific shipment.
   - Modify the details and save.
5. **Delete a Shipment**:
   - Ensure you are logged in.
   - Click the **Delete** button and confirm.

### **Validation**
- Verify client-side validation:
   - Shipment name cannot be empty.
   - Delivery date cannot be in the future or before the creation date.

---

## Additional Notes
- Ensure the backend API runs **before** starting the frontend.
- Use Swagger (`https://localhost:5001/swagger`) for manual API testing.
- An attempt was made to integrate [Blazored.FluentValidation](https://github.com/Blazored/FluentValidation), but due to compatibility issues with .NET 8.0 and project structure requirements, the integration was not successful. As a result, custom client-side validation was implemented instead.

---

## Author
**Aleksa Petrovic**  
Email: aleksa.petrovic2907@gmail.com