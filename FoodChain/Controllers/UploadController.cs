using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Demo.Controllers
{
    

    [Route("api/upload")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UploadController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public UploadController(IConfiguration configuration) {
            _configuration = configuration;
        }




        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


        [HttpPost("uploadAndImport"), DisableRequestSizeLimit]
        public IActionResult UploadAndImport()  
        {
            try
            {
                string conString = string.Empty;
                string sheetName = string.Empty;
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    string extension = Path.GetExtension(fileName);
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fullPath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fullPath + ";Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }

                    DataTable dt = new DataTable();
                    conString = string.Format(conString, fullPath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {
                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                 sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    conString = _configuration.GetConnectionString("sqlConnection");

                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name.

                            var checkTableIfExistsCommand = new SqlCommand("IF EXISTS (SELECT 1 FROM sysobjects WHERE name =  '" + sheetName.Trim('$') + "') SELECT 1 ELSE SELECT 0", con);
                            con.Open();
                            var exists = checkTableIfExistsCommand.ExecuteScalar().ToString().Equals("1");
                            con.Close();
                            if (!exists)
                            {
                                var createTableBuilder = new StringBuilder("CREATE TABLE [" + sheetName.Trim('$') + "]");
                                createTableBuilder.AppendLine("(");

                                // selecting each column of the datatable to create a table in the database
                                foreach (DataColumn col in dt.Columns)
                                {
                                    createTableBuilder.AppendLine("  [" + col.ColumnName.ToLower() + "] VARCHAR(MAX),");
                                }

                                createTableBuilder.Remove(createTableBuilder.Length - 1, 1);
                                createTableBuilder.AppendLine(")");

                                var createTableCommand = new SqlCommand(createTableBuilder.ToString(), con);
                                con.Open();
                                createTableCommand.ExecuteNonQuery();
                                con.Close();
                            }
                            else {
                                return StatusCode(406, "Duplicate Entity Fou");
                            }

                            sqlBulkCopy.DestinationTableName = "dbo."+ sheetName.Trim('$');

                            // Map the Excel columns with that of the database table, this is optional but good if you do
                            // 

                            foreach (DataColumn col in dt.Columns)
                            {
                                sqlBulkCopy.ColumnMappings.Add(col.ColumnName.ToLower(), col.ColumnName.ToLower());
                                // Console.WriteLine("ok\n");
                            }


                            //sqlBulkCopy.ColumnMappings.Add("Id", "Id");
                            //sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                            //sqlBulkCopy.ColumnMappings.Add("Email", "Email");
                            //sqlBulkCopy.ColumnMappings.Add("Class", "Class");

                            con.Open();
                            sqlBulkCopy.WriteToServer(dt);
                            con.Close();
                        }
                    }

                    return Ok("File Imported and excel data saved into database") ;
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //[HttpPost, DisableRequestSizeLimit]
        //public IActionResult Upload()   // For multiple files upload
        //{
        //    try
        //    {
        //        var files = Request.Form.Files;
        //        var folderName = Path.Combine("StaticFiles", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (files.Any(f => f.Length == 0))
        //        {
        //            return BadRequest();
        //        }

        //        foreach (var file in files)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //        }

        //        return Ok("All the files are successfully uploaded.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
