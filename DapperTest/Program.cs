using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DapperTest
{
  class People
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public void getPersonInfo()
    {
      Console.WriteLine($"ID: {this.Id}, FirstName: {this.FirstName}, LastName: {this.LastName}");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      string getPeople = "SELECT * FROM dbo.People;";
      string insertNewPerson = "INSERT INTO dbo.People (FirstName, LastName) VALUES (@FirstName, @LastName)";
      using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\DapperTest\DapperTest\Database1.mdf;Integrated Security=True"))
      {

        //connection.Execute(insertNewPerson, new { FirstName =  "Adam", LastName = "Nowak" });
        var people = connection.Query<People>(getPeople).ToList();
        foreach (var person in people)
        {
          person.getPersonInfo();
        }
      }

      Console.ReadKey();
    }
  }
}
