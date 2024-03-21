using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var employees = DataStorage.GetAllEmployees();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                        <th>PresentAddress</th>
                                        <th>PermanentAddress</th> 
                                        <th>Profession</th>
                                        <th>MaritalStatus</th>
                                        <th>LastDegree</th>
                                        <th>BloodGroup</th> 
                                        <th>Hobby</th> 
                                       
                                    </tr>");
            foreach (var emp in employees)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                    <td>{8}</td>
                                    <td>{9}</td>
                                  </tr>", emp.Name, emp.LastName, emp.Age, emp.Gender, emp.PresentAddress, emp.PermanentAddress, emp.Profession, emp.MaritalStatus, emp.LastDegree, emp.Hobby);
            }
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
