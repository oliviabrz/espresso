## Important Concepts
### General
- Dependency Injection (DI)
  - A design pattern that allows an object to receive its dependencies from an external source rather than creating them itself.
- Constructor
  - A function that's required for creating instances of a class
  - Used to initialize a class instance to a known state
- Nuget Package
  - Packaging system 
- Data Transfer Object (DTO)
  - Carry data
  - No logic
- Domain Objects & Models
  - A DTO with logic 
  - Allows you to encapsulate logic in a domain specific way
- Serialization 
  - Going from instance to some representation (JSON, XML, GSON)
  - ex. DTO -> JSON
- Deserialization
  - Opposite of serialization
  - ex. JSON -> DTO
- Generics
  - A feature in programming that allows you to create classes, methods, and data structures that can work with any data type. Generics provide a way to write flexible and reusable code without sacrificing type safety.
  - ex. List<string>
  - ex. List<int>
- Interface
  - A contract in programming that defines a set of methods and properties that a class must implement. It specifies what a class should do, but not how it should do it.
- Class
  - A blueprint for creating objects in programming. It defines the properties (data) and methods (functions) that the objects created from the class will have.
- Instance
  - A specific object created from a class that is stored in memory and has a specific lifetime.
- Compiler
  - A program that translates code written in a high-level programming language (like C# or Java) into machine code (binary code) that a computer's processor can execute. The compiler checks the code for errors and optimizes it for performance.

### Dotnet
- Dotnet Framework
  - Software framework that provides a large library of pre-coded solutions to common programming problems
  - ex. DateTime functions, strings, dictionaries, a bunch more 
- ASP.net
  - Web application framework built on top of dotnet framework
  - Backend or frontend 
- Minimal API
  - A simplified way to built HTTP API's with ASP.NET Core minimal configuration and code
- Dapper
  - A non ORM library used to integrate C# with SQL databases
- Extension Methods
  - A feature in C# that allows you to add new methods to existing types without modifying their source code. They are defined as static methods in static classes but are called as if they were instance methods on the extended type.

### Docker
- rebuild EspressoDataService and start in Docker
  - `docker compose up --build espressodataservice -d`
- start pod
  - `docker compose up espressodataservice -d`
- stop pod
  - `docker compose stop espressodataservice`