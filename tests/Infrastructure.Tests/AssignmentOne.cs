using Dapper;
using System.Data;
using System.Data.SqlClient;
using Shouldly;

namespace Infrastructure.Tests;

public class AssignmentOne
{
    //todo move to configuration
    private readonly string _connectionString = "Server=localhost;Database=Northwind;Trusted_Connection=True;";

    [Fact]
    public async Task GetOrderSummary_ShouldReturnCorrectOrderSummary()
    {
        //Arrange
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        var startDate = new DateTime(1996, 1, 1,0,0,0, DateTimeKind.Utc);
        var endDate = new DateTime(1996, 8, 31,0,0,0, DateTimeKind.Utc);
        const int employeeId = 5;
        const string customerId = "VINET";
        
        //Act
        var sut = await connection
                .QueryAsync<OrderSummary>(
                        "pr_GetOrderSummary", 
                        new
                        {
                                StartDate = startDate, 
                                EndDate = endDate, 
                                EmployeeId = employeeId, 
                                CustomerId = customerId
                        }, 
                        commandType: CommandType.StoredProcedure);
        
        //Assert
        sut.ShouldNotBeNull();
        sut.ShouldNotBeEmpty();
        sut.Count().ShouldBe(1);

        var summary = sut.First();
        summary.EmployeeFullName.ShouldNotBeNull();
        summary.ShipperCompanyName.ShouldNotBeNull();
        summary.CustomerCompanyName.ShouldNotBeNull();
        summary.NumberOfOrders.ShouldBeGreaterThan(0);
        summary.Date.ShouldBeInRange(startDate, endDate);
        summary.TotalFreightCost.ShouldBeGreaterThan(0);
        summary.NumberOfDifferentProducts.ShouldBeGreaterThan(0);
        summary.TotalOrderValue.ShouldBeGreaterThan(0);
    }
    
    public class OrderSummary
    {
        public string? EmployeeFullName { get; set; }
        public string? ShipperCompanyName { get; set; }
        public string? CustomerCompanyName { get; set; }
        public int NumberOfOrders { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalFreightCost { get; set; }
        public int NumberOfDifferentProducts { get; set; }
        public decimal TotalOrderValue { get; set; }
    }
}