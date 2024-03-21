using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Utility
{
    public static class DataStorage
    {
        public static List<EmployeeInfo> GetAllEmployees() =>
            new List<EmployeeInfo>
            {
                new EmployeeInfo { Name="Mike", LastName="Turner", Age=35, Gender="Male", PresentAddress="Dhaka", PermanentAddress="BAngladesh", Profession="Engineer", MaritalStatus="Single", LastDegree="BSC", BloodGroup="A+", Hobby="Music"},
                new EmployeeInfo { Name="Sonja", LastName="Markus", Age=22, Gender="Female",PresentAddress="Dhaka", PermanentAddress="BAngladesh", Profession="Engineer", MaritalStatus="Single", LastDegree="BSC", BloodGroup="A+", Hobby="Music"},
                new EmployeeInfo { Name="Luck", LastName="Martins", Age=40, Gender="Male",PresentAddress="Dhaka", PermanentAddress="BAngladesh", Profession="Engineer", MaritalStatus="Single", LastDegree="BSC", BloodGroup="A+", Hobby="Music"},
                new EmployeeInfo { Name="Sofia", LastName="Packner", Age=30, Gender="Female",PresentAddress="Dhaka", PermanentAddress="BAngladesh", Profession="Engineer", MaritalStatus="Single", LastDegree="BSC", BloodGroup="A+", Hobby="Music"},
                new EmployeeInfo { Name="John", LastName="Doe", Age=45, Gender="Male",PresentAddress="Dhaka", PermanentAddress="BAngladesh", Profession="Engineer", MaritalStatus="Single", LastDegree="BSC", BloodGroup="A+", Hobby="Music"}
            };
    }
}
