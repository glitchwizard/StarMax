
# StarMax Application

StarMax is an ASP.NET MVC application that retrieves and displays starship data from the Star Wars API (SWAPI). It consists of two components: a backend API built with ASP.NET MVC and a frontend UI built with React. The backend API retrieves data from SWAPI, stores it in a SQL Server database, and exposes endpoints to interact with the data. The frontend UI consumes the API and displays starship information to the user.

## Features

- Retrieve starship data from SWAPI and store it in a SQL Server database
- Display starship information in a user-friendly manner using Material-UI components
- Randomly display a starship from the database on each application load
- Implement CRUD operations to manipulate starship data
- Dockerize the application for easy deployment

## Technologies Used

- .NET 6
- ASP.NET MVC
- Entity Framework Core
- MS SQL Server
- React
- Material-UI
- Docker

## Getting Started

To get started with the StarMax application, follow these steps:

1. Clone the repository:

```shell
git clone <repository-url>
```

2. Navigate to the project directory:

```shell
cd StarMax
```

3. Install the necessary dependencies:

- For the backend API (StarMax_BackEnd):

```shell
dotnet restore
```

- For the frontend UI (StarMax_FrontEnd):
```shell
cd StarMax_FrontEnd
npm install
```

4. Configure the database connection:

Update the connection string in the `appsettings.json` file in the StarMax_BackEnd folder to point to your SQL Server database.

5. Seed the database:

```shell
cd StarMax_BackEnd
dotnet ef database update
```

6. Start the application:

- For the backend API (StarMax_BackEnd):

```shell
dotnet run
```

- For the frontend UI (StarMax_FrontEnd):

```shell
cd ../StarMax_FrontEnd
npm start
```

The backend API will be accessible at `http://localhost:5000`, and the frontend UI will be accessible at `http://localhost:3000`.

## Contributing

Contributions are welcome! If you find a bug or have a suggestion for improvement, please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).