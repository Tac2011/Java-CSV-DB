using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace iCapBasic
{
    public class LoadEmployeeFile
    {
        public List<EmployeeData> employyData;
        public string[] HoldInput = new string[20];

        public LoadEmployeeFile(List<EmployeeData> employyData)
        {
            this.employyData = employyData;

            int cntr = 0;
            using (TextFieldParser parser = new TextFieldParser("./UsersReport_149_Employees.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        HoldInput[cntr] = field;
                        cntr++;
                    }
                    this.employyData.Add(new EmployeeData()
                    {
                        COMPANY = HoldInput[0],
                        USERID = HoldInput[1],
                        PRODAMID = HoldInput[2],
                        ACTIVE = HoldInput[3],
                        BRANCHNAME = HoldInput[4],
                        BRANCHREPID = HoldInput[5],
                        FIRSTNAME = HoldInput[6],
                        MIDDLENAME = HoldInput[7],
                        LASTNAME = HoldInput[8],
                        SUFFIX = HoldInput[9],
                        ROLENAME = HoldInput[10],
                        EMAILADDRESS = HoldInput[11]
                    });
                    cntr = 0; // Reset back to zero because there are only 20 fields
                              //HoldInput[cntr] = fields;
                              //cntr++;
                }
            }
            /*
            Console.WriteLine("Write it out ==>" + this.employyData[1].USERID);
            Console.WriteLine("Write it out ==>" + this.employyData[1].PRODAMID);
            Console.WriteLine("Write it out ==>" + this.employyData.Count);
            */


        }
    }
}