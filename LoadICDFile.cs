using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace iCapBasic
{
    internal class LoadICDFile
    {
        private List<ICDData> myICDData;
        public string[] HoldInput = new string[20];
        public LoadICDFile(List<ICDData> myICDData)
        {
            this.myICDData = myICDData;

            int cntr = 0;
            using (TextFieldParser parser = new TextFieldParser("./UsersReport_101_ICD.csv"))
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
                    this.myICDData.Add(new ICDData()
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
            Console.WriteLine("Write it out ==>" + this.myICDData[1].COMPANY);
            Console.WriteLine("Write it out ==>" + this.myICDData[1].PRODAMID);
            Console.WriteLine("Write it out ==>" + this.myICDData.Count);


        }
    }
}