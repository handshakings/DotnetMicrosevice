# Entity Framework Code First Database Connection

- Install below nuget packages (Versions should be compatible to the project .net version):-
	- Microsoft.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.SqlServer	
	- Microsoft.EntityFrameworkCore.Tools
- Create folder Database and a subfolder Entities
- Create entity classes (Models) like User.cs that would be mapped to Sql database tables 
- Create DatabaseContext.cs file in Database folder
    - Write connectionString property in appsetting.json file as
        ```json
        "ConnectionString":  "data source=DESKTOP-MJVV6N7; initial catalog=userDatabase; user id=test; password=123; persist security info=true;"
        ```
    - Create DbSets for all entities in DatabaseContext.cs as
        ```c#
        public DbSet<User> Users { get; set; }
        ```
    - Create DatabaseContext.cs Contructor as
        ```c#
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options){}
        ```
    - Inject DatabaseContext in program.cs as
        ```c#
        string conString = builder.Configuration.GetSection("ConnectionString").Value;
        builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(conString));
        ```
- Open Pachage Manager Console and run below commands to crete database
    - add-migration initial
    - update-database
- Create UserController and write http methods