SELECT e.ID, e.FirstName, e.LastName,edu.Description
FROM Employees.Employee e
Left join Employees.Education edu ON e.ID=edu.EmployeeID; 
