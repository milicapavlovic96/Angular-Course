﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http;
using WebApi.Models; 
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    public class DepartmentController : ApiController
    {

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select DepartmentID,DepartmentName from dbo.Departments";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Post(Department dep)
        {
            try
            {
                

                DataTable table = new DataTable();
                string query = @"insert into dbo.Departments values ('"+dep.DepartmentName+ @"')";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Added Successfully";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }

        [HttpPut]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Put(Department dep)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"update dbo.Departments set DepartmentName= '" + dep.DepartmentName + @"' where DepartmentID=" +dep.DepartmentID+@"";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Updated Successfully";
            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"delete from dbo.Departments where DepartmentID=" + id;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString))

                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }


                return "Delete Successfull";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
    }
}
