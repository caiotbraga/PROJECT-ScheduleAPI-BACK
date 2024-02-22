# ScheduleAPI - Backend Documentation

Welcome to the documentation for the ScheduleAPI backend. This API provides functionality to manage users' schedules.

## Overview

The ScheduleAPI backend is built using ASP.NET Core and Entity Framework Core. It follows RESTful principles to expose endpoints for CRUD operations on user schedules.

## Installation

1. **Clone the Repository:**
```
  - git clone https://github.com/caiotbraga/ScheduleAPI.git
```
2. **Navigate to the Project Directory:**
```
  - cd ScheduleAPI
```
3. **Restore Packages:**
```
  - dotnet restore
```
5. **Run the Application:**
```
  - dotnet run
```


The API will be available at `https://localhost:5001` by default.

## Endpoints

### User Management

### **Add User**
- URL: `POST /user`
- Request Body: 
 ```json
 {
   "userName": "example_user",
   "email": "user@example.com",
   "phoneNumber": "123456789"
 }
 ```
- Response: Returns the newly created user.

### **Get Users**
- URL: `GET /user`
- Query Parameters: 
 - `skip` (optional): Number of records to skip (default: 0)
 - `take` (optional): Number of records to take (default: 100)
- Response: Returns a list of users with pagination.

### **Get User by ID**
- URL: `GET /user/{id}`
- Path Parameter: `id` - ID of the user to retrieve
- Response: Returns the user with the specified ID.

### **Update User**
- URL: `PUT /user/{id}`
- Path Parameter: `id` - ID of the user to update
- Request Body: Updated user data
- Response: No content.

### **Partially Update User**
- URL: `PATCH /user/{id}`
- Path Parameter: `id` - ID of the user to update
- Request Body: JSON Patch document for partial update
- Response: No content.

### **Delete User**
- URL: `DELETE /user/{id}`
- Path Parameter: `id` - ID of the user to delete
- Response: No content.

## Dependencies

- ASP.NET Core
- Entity Framework Core
- AutoMapper

## Testing with Swagger

Swagger is integrated into the API for testing and exploring endpoints. After running the application, navigate to `https://localhost:7156/swagger` to access the Swagger UI.

## Contributing

Contributions are welcome! Feel free to open issues and pull requests.

## License

This project was made by Caio Braga (github.com/caiotbraga)
