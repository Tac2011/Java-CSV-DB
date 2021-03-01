using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCapBasic
{
    public struct IcapData
    {
        public string IdentityID;
        public string Identity;
        public string ManagerID;
        public string Manager;
        public string Application;
        public string Attribute;
        public string Entitlement;
        public string Description;
        public string AccountName;
        public string Instance;
        public string Source;
        public string Existsonaccount;
        public string EntitlementType;
        public string Allowed;
        public string Assigned;
        public string Grantedbyarole;
        public string AssignedBy;
        public string LastCertification;
        public string LastCertificationDate;
        public string RequestID;
    };

    public struct EmployeeData
    {
        public string COMPANY;
        public string USERID;
        public string PRODAMID;
        public string ACTIVE;
        public string BRANCHNAME;
        public string BRANCHREPID;
        public string FIRSTNAME;
        public string MIDDLENAME;
        public string LASTNAME;
        public string SUFFIX;
        public string ROLENAME;
        public string EMAILADDRESS;
    }
    public struct RetailData
    {
        public string COMPANY;
        public string USERID;
        public string PRODAMID;
        public string ACTIVE;
        public string BRANCHNAME;
        public string BRANCHREPID;
        public string FIRSTNAME;
        public string MIDDLENAME;
        public string LASTNAME;
        public string SUFFIX;
        public string ROLENAME;
        public string EMAILADDRESS;
    }

    public struct ICDData
    {
        public string COMPANY;
        public string USERID;
        public string PRODAMID;
        public string ACTIVE;
        public string BRANCHNAME;
        public string BRANCHREPID;
        public string FIRSTNAME;
        public string MIDDLENAME;
        public string LASTNAME;
        public string SUFFIX;
        public string ROLENAME;
        public string EMAILADDRESS;
    }


    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<IcapData> GetiCapData = new List<IcapData>();
            //LoadFromFile GetData = new LoadFromFile(GetiCapData);


            List<RetailData> MyRetailDData = new List<RetailData>();
            LoadRetailFile GetRetailData = new LoadRetailFile(MyRetailDData);

            // *****************************************************************************************
            // This is the main comparison file. This is will always be the same. The Calls above 
            // Will change from EMPLOYEES, ICD, REATIL
            //******************************************************************************************
            List<IcapData> GetiCapData = new List<IcapData>();
            LoadFromFile GetData = new LoadFromFile(GetiCapData);

            int i = 0;
            int j = 0;
            int QuitFlag = 0;

            // Deletes file so you can do multiple runs and the file 
            // doesn't get bigger because the StreamWriter appends data


            //********************* Header for FOUND employees FILE **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./SailpointMissing.csv", true))
            {
                file.WriteLine("************** RETAIL Data ****************");
                file.WriteLine("PROD-AM ID \t" + "ROLE \t" + "NAME");
            }


            //********************* Header for EXCEPTIONS employees file **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./SailpointException.csv", true))
            {
                file.WriteLine("************** RETAIL Data ****************");
                file.WriteLine("PROD-AM ID \t" + "ROLE \t" + "NAME");
            }

            // Search the whole file... if you get to the end and you don't find anything 
            // then write it to the exception file 
            while (j <= GetiCapData.Count - 1) 
            {
                while (i <= MyRetailDData.Count - 1)
                {
                    if (GetiCapData[j].IdentityID.ToUpper() == MyRetailDData[i].PRODAMID.ToUpper())
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./SailpointMissing.csv", true))
                        {
                            file.WriteLine(GetiCapData[j].IdentityID + "\t" + GetiCapData[j].Identity);
                            QuitFlag = 1;
                        }
                    }
                    i++;
                }
                if (QuitFlag == 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./SailpointException.csv", true))
                    {
                        file.WriteLine(GetiCapData[j].IdentityID + "\t" + GetiCapData[j].Identity);
                    }
                }
                j++;
                i = 0; //reset inner loop
                QuitFlag = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<EmployeeData> EmployyData = new List<EmployeeData>();
            LoadEmployeeFile GetEmployeeData = new LoadEmployeeFile(EmployyData);

            List<IcapData> GetiCapData = new List<IcapData>();
            LoadFromFile GetData = new LoadFromFile(GetiCapData);
           
            /*
            Console.WriteLine("Employee ID ==>" + EmployyData[1].USERID);
            Console.WriteLine("Prod-AM ==>" + EmployyData[1].PRODAMID);
            Console.WriteLine("Count Employee Data ==>" + EmployyData.Count);
            */
            int i = 0;
            int j = 0;
            int QuitFlag = 0;

            // Deletes file so you can do multiple runs and the file 
            // doesn't get bigger because the StreamWriter appends data

            if(File.Exists("./Employee.csv"))
            {
                File.Delete(@"./Employee.csv");
            }

            if (File.Exists("./EmployeeException.csv"))
            {
                File.Delete(@"./EmployeeException.csv");
            }

            //********************* Header for FOUND employees FILE **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
            {
                file.WriteLine("************** EMPLOYEE Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }


            //********************* Header for EXCEPTIONS employees file **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
            {
                file.WriteLine("************** EMPLOYEE Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }

            // Search the whole file... if you get to the end and you don't find anything 
            // then write it to the exception file 
            while (j <= EmployyData.Count - 1) 
            {
                while (i <= GetiCapData.Count - 1 && QuitFlag != 1)
                {
                    if (GetiCapData[i].IdentityID.ToUpper() == EmployyData[j].PRODAMID.ToUpper())
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
                        {
                            file.WriteLine(EmployyData[j].PRODAMID + "," + EmployyData[j].ROLENAME + "," + EmployyData[j].LASTNAME +
                                "," + EmployyData[j].FIRSTNAME);
                            QuitFlag = 1;
                        }
                    }
                    i++;
                }
                if (QuitFlag == 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
                    {
                        file.WriteLine(EmployyData[j].PRODAMID + "," + EmployyData[j].ROLENAME + "," + EmployyData[j].LASTNAME +
                            "," + EmployyData[j].FIRSTNAME);
                    }
                }
                j++;
                QuitFlag = 0;
                i = 0; //reset inner loop
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            List<ICDData> MyICDData = new List<ICDData>();
            LoadICDFile GetICDData = new LoadICDFile(MyICDData);

            // *****************************************************************************************
            // This is the main comparison file. This is will always be the same. The Calls above 
            // Will change from EMPLOYEES, ICD, REATIL
            //******************************************************************************************
            List<IcapData> GetiCapData = new List<IcapData>();
            LoadFromFile GetData = new LoadFromFile(GetiCapData);

            int i = 0;
            int j = 0;
            int QuitFlag = 0;

            // Deletes file so you can do multiple runs and the file 
            // doesn't get bigger because the StreamWriter appends data


            //********************* Header for FOUND employees FILE **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
            {
                file.WriteLine("************** ICD Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }


            //********************* Header for EXCEPTIONS employees file **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
            {
                file.WriteLine("************** ICD Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }

            // Search the whole file... if you get to the end and you don't find anything 
            // then write it to the exception file 
            while (j <= MyICDData.Count - 1)
            {
                while (i <= GetiCapData.Count - 1 && QuitFlag != 1)
                {
                    if (GetiCapData[i].IdentityID.ToUpper() == MyICDData[j].PRODAMID.ToUpper())
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
                        {
                            file.WriteLine(MyICDData[j].PRODAMID + "," + MyICDData[j].ROLENAME + "," + MyICDData[j].LASTNAME +
                                "," + MyICDData[j].FIRSTNAME);
                            QuitFlag = 1;
                        }
                    }
                    i++;
                }
                if (QuitFlag == 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
                    {
                        file.WriteLine(MyICDData[j].PRODAMID + "," + MyICDData[j].ROLENAME + "," + MyICDData[j].LASTNAME +
                            "," + MyICDData[j].FIRSTNAME);
                    }
                }
                j++;
                i = 0; //reset inner loop
                QuitFlag = 0;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<RetailData> MyRetailDData = new List<RetailData>();
            LoadRetailFile GetRetailData = new LoadRetailFile(MyRetailDData);

            // *****************************************************************************************
            // This is the main comparison file. This is will always be the same. The Calls above 
            // Will change from EMPLOYEES, ICD, REATIL
            //******************************************************************************************
            List<IcapData> GetiCapData = new List<IcapData>();
            LoadFromFile GetData = new LoadFromFile(GetiCapData);

            int i = 0;
            int j = 0;
            int QuitFlag = 0;

            // Deletes file so you can do multiple runs and the file 
            // doesn't get bigger because the StreamWriter appends data


            //********************* Header for FOUND employees FILE **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
            {
                file.WriteLine("************** RETAIL Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }


            //********************* Header for EXCEPTIONS employees file **************************
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
            {
                file.WriteLine("************** RETAIL Data ****************");
                file.WriteLine("PROD-AM ID," + "ROLE," + "NAME");
            }

            // Search the whole file... if you get to the end and you don't find anything 
            // then write it to the exception file 
            while (j <= MyRetailDData.Count - 1)
            {
                while (i <= GetiCapData.Count - 1 && QuitFlag != 1)
                {
                    if (GetiCapData[i].IdentityID.ToUpper() == MyRetailDData[j].PRODAMID.ToUpper())
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./Employee.csv", true))
                        {
                            file.WriteLine(MyRetailDData[j].PRODAMID + "," + MyRetailDData[j].ROLENAME + "," + MyRetailDData[j].LASTNAME +
                                "," + MyRetailDData[j].FIRSTNAME);
                            QuitFlag = 1;
                        }
                    }
                    i++;
                }
                if (QuitFlag == 0)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./EmployeeException.csv", true))
                    {
                        file.WriteLine(MyRetailDData[j].PRODAMID + "," + MyRetailDData[j].ROLENAME + "," + MyRetailDData[j].LASTNAME +
                            "," + MyRetailDData[j].FIRSTNAME);
                    }
                }
                j++;
                i = 0; //reset inner loop
                QuitFlag = 0;
            }
        }
    }
}
