<h1 align="center">ScheduleAPI - Backend Documentation</h1>

<p align="center">Welcome to the documentation for the ScheduleAPI backend. This API provides functionality to manage users' schedules.</p>

<h2 align="center">Overview</h2> 

<p align="center">The ScheduleAPI backend is built using ASP.NET Core and Entity Framework Core. It follows RESTful principles to expose endpoints for CRUD operations on user schedules.</p>

<h2 align="center">💻Technologies useds</h2>
<p align="center">
  <a href="https://learn.microsoft.com/pt-br/dotnet/csharp" target="blank"><img src="https://img.shields.io/badge/C%23-purple?logo=c-sharp&logoColor=white&labelColor=421e6b" alt="C# Badge"></a>
<a href="https://dotnet.microsoft.com/download/dotnet-core/6.0" target="_blank"><img src="https://img.shields.io/badge/ASP.NET_Core-6.0-grey?logo=.net&logoColor=white&labelColor=purple" alt="ASP.NET Core 6.0 Badge"></a>
<a href="https://www.mysql.com/" target="_blank"><img src="https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=white" alt="MySQL Badge"></a>
  <a href="https://swagger.io/" target="_blank"><img src="https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=black" alt="Swagger Badge"></a>
   <img src="https://img.shields.io/badge/Postman-FF6C37?logo=postman&logoColor=white" alt="Postman Badge">
</p>

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

This project is licensed under the [MIT License](LICENSE).
