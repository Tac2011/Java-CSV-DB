using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCapBasic
{
    public class LoadFromFile
    {
        public string[] HoldInput = new string[20];
        private List<IcapData> getiCapData;

        public LoadFromFile(List<IcapData> getiCapData)
        {
            this.getiCapData = getiCapData;

            int cntr = 0;
            using (TextFieldParser parser = new TextFieldParser("./RAO Associates with Entitlements 6-17-20_CSV.csv"))
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
                    this.getiCapData.Add(new IcapData()
                    {
                        IdentityID = HoldInput[0],
                        Identity = HoldInput[1],
                        ManagerID = HoldInput[2],
                        Manager = HoldInput[3],
                        Application = HoldInput[4],
                        Attribute = HoldInput[5],
                        Entitlement = HoldInput[6],
                        Description = HoldInput[7],
                        AccountName = HoldInput[8],
                        Instance = HoldInput[9],
                        Source = HoldInput[10],
                        Existsonaccount = HoldInput[11],
                        EntitlementType = HoldInput[12],
                        Allowed = HoldInput[13],
                        Assigned = HoldInput[14],
                        Grantedbyarole = HoldInput[15],
                        AssignedBy = HoldInput[16],
                        LastCertification = HoldInput[17],
                        LastCertificationDate = HoldInput[18],
                        RequestID = HoldInput[19],
                        });
                        cntr = 0; // Reset back to zero because there are only 20 fields
                        //HoldInput[cntr] = fields;
                        //cntr++;
                }
            }
            /*
            Console.WriteLine("Write it out ==>" + this.getiCapData[1].IdentityID);
            Console.WriteLine("Write it out ==>" + this.getiCapData[1].Identity);
            Console.WriteLine("Write it out ==>" + this.getiCapData.Count);
            */
        }
    }
}
