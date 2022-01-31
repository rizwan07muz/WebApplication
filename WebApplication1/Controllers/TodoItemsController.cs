using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace WebApplication1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TodoItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        ////// HttpGet retrive data ///////////
        
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Id,Name,IsComplete,CompletedAt,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt 
            from dbo.TodoItem";
            DataTable table = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    myreader = mycommand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        ////// HttpPost Insert data ///////////

        [HttpPost]
        public JsonResult Post(TodoItems todo)
        {
            string query = @"
                           insert into dbo.TodoItem
                           (Name,IsComplete,CompletedAt,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,DeletedBy,DeletedAt)
                    values (@Name,@IsComplete,@CompletedAt,@CreatedBy,@CreatedAt,@UpdatedBy,@UpdatedAt,@DeletedBy,@DeletedAt)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Name", todo.Name);
                    myCommand.Parameters.AddWithValue("@IsComplete", todo.IsComplete);
                    myCommand.Parameters.AddWithValue("@CompletedAt", todo.CompletedAt);
                    myCommand.Parameters.AddWithValue("@CreatedBy", todo.CreatedBy);
                    myCommand.Parameters.AddWithValue("@CreatedAt", todo.CreatedAt);
                    myCommand.Parameters.AddWithValue("@UpdatedBy", todo.UpdatedBy);
                    myCommand.Parameters.AddWithValue("@UpdatedAt", todo.UpdatedAt);
                    myCommand.Parameters.AddWithValue("@DeletedBy", todo.DeletedBy);
                    myCommand.Parameters.AddWithValue("@DeletedAt", todo.DeletedAt);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        ////// HttpPut Update data ///////////

        [HttpPut]

        public JsonResult Put(TodoItems todo)
        {
            string query = @"update dbo.TodoItem set Name = @Name,
            IsComplete = @IsComplete,
            CompletedAt = @CompletedAt,
            CreatedBy = @CreatedBy,
            CreatedAt = @CreatedAt,
            UpdatedBy = @UpdatedBy,
            UpdatedAt = @UpdatedAt,
            DeletedBy = @DeletedBy,
            DeletedAt = @DeletedAt
            where Id=@Id";
            DataTable table = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", todo.Id);
                    myCommand.Parameters.AddWithValue("@Name", todo.Name);
                    myCommand.Parameters.AddWithValue("@IsComplete", todo.IsComplete);
                    myCommand.Parameters.AddWithValue("@CompletedAt", todo.CompletedAt);
                    myCommand.Parameters.AddWithValue("@CreatedBy", todo.CreatedBy);
                    myCommand.Parameters.AddWithValue("@CreatedAt", todo.CreatedAt);
                    myCommand.Parameters.AddWithValue("@UpdatedBy", todo.UpdatedBy);
                    myCommand.Parameters.AddWithValue("@UpdatedAt", todo.UpdatedAt);
                    myCommand.Parameters.AddWithValue("@DeletedBy", todo.DeletedBy);
                    myCommand.Parameters.AddWithValue("@DeletedAt", todo.DeletedAt);
                    myreader = myCommand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Update Successfull..");
        }

        ////// HttpDelete Delete data ///////////

        [HttpDelete("{id}")]

        public JsonResult Delete(int id)
        {
            string query = @"delete from dbo.TodoItem 
            where Id=@Id";
            DataTable table = new DataTable();
            string sqldatasource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myreader;
            using (SqlConnection mycon = new SqlConnection(sqldatasource))
            {
                mycon.Open();
                using (SqlCommand mycommand = new SqlCommand(query, mycon))
                {
                    mycommand.Parameters.AddWithValue("@Id", id);
                    myreader = mycommand.ExecuteReader();
                    table.Load(myreader);
                    myreader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Delete Successfull..");
        }

    }
}
