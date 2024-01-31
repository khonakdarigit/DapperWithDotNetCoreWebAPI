# Dapper Practice With .NetCore WebAPI

We have 2 entity Company,Employee with One to Many relation

Dapper Practice

1- Using Dapper Select Query
    
    var query = "SELECT * FROM Companies";

2- Using Parameters With Dapper Queries

    var query = "SELECT * FROM Companies WHERE Id=@Id";

3- Adding a New record in the Database with the Dapper "Execute(Async)" Method

    var query = 
        "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)" +
        "SELECT CAST(SCOPE_IDENTITY() as int)";

4- Dapper Working with Update and Delete
    
    var query = "UPDATE Companies SET Name = @Name, Address = @Address, Country = @Country WHERE Id = @Id";
    var query = "DELETE FROM Companies WHERE Id = @Id";

5- Running Stored Procedures with Dapper

    var procedureName = "Procedure_ShowCompanyForProvidedEmployeeId";

6- Executing Multiple SQL Statements with a Single Query

    var query =
        $"SELECT * FROM Companies WHERE Id = @Id" +
        $"SELECT * FROM Employees WHERE CompanyId = @Id";

7- Multiple Mapping

	var query = "SELECT * FROM Companies c JOIN Employees e ON c.Id=e.CompanyId";

8- Transactions With Dapper
Insert Multiple Company

    var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";


