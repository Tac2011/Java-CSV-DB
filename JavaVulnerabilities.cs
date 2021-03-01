using Microsoft.Data.Sqlite;
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
using System.IO.Compression;
using System.Net;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.Remoting.Messaging;

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
    public struct JavaData
    {
        public string PatchingStatus;
        public string DatabasePatches;
        public string AgebyPublishedDate;
        public string AgeBucketsbyPublishedDate;
        public string AgePolicybyPublishedDate;
        public string PatchingSLA;
        public string AgebypolicyCopy;
        public string AppAdjustedFinalScore;
        public string DeviceType;
        public string ApplianceSystems;
        public string ApplicationServiceList;
        public string BusinessRelationshipManagerList;
        public string CveCatalogId;
        public string VulnsCategory;
        public string MaterialityNorAppAdjFinal;
        public string DayssinceScan;
        public string AgeBuckets;
        public string PrimaryKeyUniquevulnerabilityrow;
        public string CountUniqueVulnerabilities;
        public string Criticality;
        public string HostCount;
        public string Age;
        public string AgeGroups;
        public string Agebypolicy;
        public string PublishedDateGreaterOneYear;
        public string ApplicationListCombined;
        public string MaterialityScore;
        public string CountHost;
        public string CategoryBreakdown;
        public string Cloud;
        public string CriticalityupdateFor2020;
        public string CriticalityField;
        public string DISCOVERYDETAILS;
        public string DeviceTypeCopy;
        public string DeviceType2;
        public string QualysID;
        public string ExternalScannerId;
        public string External;
        public string FIXED_DATE;
        public string FinalScore;
        public string FixedDate;
        public string HALO_Application_Name;
        public string HALO_Business_Unitgroup;
        public string HALO_Business_Unit;
        public string HALO_Manage_Product_Data_Login;
        public string HALO_Resolve_Ops_Issues_Login;
        public string HostField;
        public string HostPrimaryIp;
        public string ImportDate;
        public string CategoryBreakdown2;
        public string LAST_SCAN_TIME;
        public string LifecycleStatus;
        public string LocationField;
        public string Materiality_Score;
        public string Materiality_Score_8;
        public string Materiality_Score_9;
        public string ASLAbyFixedDate;
        public string NetworkName;
        public string NumberofRecordspublic;
        public string OSGgroup;
        public string OSGroupsupdated;
        public string OSGroups;
        public string OSField;
        public string Ownername;
        public string PatchableField;
        public string PublishedDatetime;
        public string PatchGroup;
        public string PatchingSLAbyPubdate;
        public string VulnerabilityAgeRanges;
        public string PatchingSLAbyPubdatBLUE;
        public string PatchingSLAbyPubdate2;
        public string QualysIDCcopy;
        public string SERVICE_PORTS;
        public string ServiceProductName;
        public string SeverityField;
        public string SeverityLevel;
        public string SRM_Category_Breakdown;
        public string  ServiceProductNameFilter;
        public string Title;
        public string TitleFromKb;
        public string Tier2SupportDirectorList;
        public string Tier2SupportGroupList;
        public string Tier2SupportManagerList;
        public string Tier3SupportDirectorEmailList;
        public string Tier3SupportDirectorList;
        public string Tier3SupportGroupList;
        public string Tier3SupportManagerEmailList;
        public string Tier3SupportManagerList;
        public string VTMCategory;
        public string VulnType;
        public string VulnerabilityAgeRangesbyPubdate;
        public string VulnsCategorygroup;
        public string age_filter_180;
        public string appliance_filter;
        public string maximumCREATION_TIME;
        public string maximumREPORTED_TIME;
        public string minimumCREATION_TIME;
        public string minimumREPORTED_TIME;
        public string mitigationsiSight;
        public string primary_key;
        public string qid_java_alert;
        public string sladurationdays;
        public string sladurationdaysunchanged;
        public string sla_blue_status;
        public string srm_category_breakdown;
        public string srm_database_category;
        public string srm_os_group;
        public string titleiSight;

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
        // Becasue we are in debug mode the root directory is:  bin\Debug
        // Becasue we are in debug mode the root directory is:  bin\Debug
        // but we refer to it as ./
        static string DataConnection = "Data Source=./TDAJavaVunerable.db;";
        List<JavaData> MyJavaData = new List<JavaData>();

       

        public MainForm()
        {
            InitializeComponent();
        }

        public string MySQL { get; private set; }
        public string MyURL { get; private set; }
        public int WaitStateCnt { get; private set; }

        public string[] GetCSVFields = new string[120];
        public string[] BuldDynamicSQL = new string[120];

        SqliteConnection conn = new SqliteConnection(DataConnection);

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }


        
        private void GetDBCount()
        {
            conn.Open();
            SqliteCommand cmd = new SqliteCommand(MySQL, conn);
            cmd.CommandText = "SELECT count(*) FROM MainDB";
            cmd.CommandType = CommandType.Text;
            int RowCount = 0;
            RowCount = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(RowCount.ToString());
            conn.Close();
        }
       
        private void ClearDB()
        {
            //SqliteConnection conn = new SqliteConnection(DataConnection);
            conn.Open();
            MySQL = "DELETE FROM MainDB";
            SqliteCommand cmd = new SqliteCommand(MySQL, conn);
            SqliteDataReader reader = cmd.ExecuteReader();
            conn.Close();
        }
        private void WriteToMainDB()
        {
            int i = 0;
            //String CheckForTic;
            //String StoreNewPartDescription, StoreNewBrandDescription, StoreNewNoteDescription;
            Cursor.Current = Cursors.WaitCursor;
            using (var cn = new SqliteConnection(DataConnection))
            {
                cn.Open();
                using (var transaction = cn.BeginTransaction())
                {
                    using (var cmd = cn.CreateCommand())
                    {

                        for (i = 0; i <= MyJavaData.Count - 1; i++)
                        {

                            MySQL = "INSERT INTO MainDB(PatchingStatus,DatabasePatches,AgebyPublishedDate,AgeBucketsbyPublishedDate,AgePolicybyPublishedDate,PatchingSLA," +
                                    "AgebypolicyCopy,AppAdjustedFinalScore,DeviceType," +
                                    "titleiSight)" +
                            " VALUES (" +
                                    "'" + MyJavaData[i].PatchingStatus + "'," +
                                    "'" + MyJavaData[i].DatabasePatches + "'," +
                                    "'" + MyJavaData[i].AgebyPublishedDate + "'," +
                                    "'" + MyJavaData[i].AgeBucketsbyPublishedDate + "'," +
                                    "'" + MyJavaData[i].AgePolicybyPublishedDate + "'," +
                                    "'" + MyJavaData[i].PatchingSLA + "'," +
                                    "'" + MyJavaData[i].AgebypolicyCopy + "'," +
                                    "'" + MyJavaData[i].AppAdjustedFinalScore + "'," +
                                    "'" + MyJavaData[i].DeviceType + "'," +
                                    "'" + MyJavaData[i].titleiSight + "')";


                            //Console.WriteLine("Writing to the DB ==>" + this.MyJavaData[i].ServiceProductName + " --> " + i);
                            //Console.WriteLine(MySQL);
                            cmd.CommandText = MySQL;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    Cursor.Current = Cursors.Default;
                }
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
            
            LoadRetailFile GetJAVAData = new LoadRetailFile(MyJavaData);

            WriteToMainDB();
            /*
            List<JavaData> MyJavaData = new List<JavaData>();
            LoadRetailFile GetRetailData = new LoadRetailFile(MyJavaData);

            int j = 1;
            while (j <= MyJavaData.Count - 1)
            {
                Console.WriteLine("******************  Record ************" + j + " - Begin");
                Console.WriteLine("ApplicationServiceList ==>"+  MyJavaData[j].ApplicationServiceList);
                Console.WriteLine("Criticality ==>" + MyJavaData[j].Criticality);
                Console.WriteLine("CriticalityupdateFor2020 ==>" + MyJavaData[j].CriticalityupdateFor2020);
                Console.WriteLine("HostField ==>" + MyJavaData[j].HostField);
                Console.WriteLine("Title ==>" + MyJavaData[j].Title);
                Console.WriteLine("******************  Record ************" + j + " - End");
                j++;
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int TotalCnt = 0;
            conn.Open();
            MySQL = "SELECT * FROM MainDB";
            SqliteCommand cmd = new SqliteCommand(MySQL, conn);
            SqliteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text = reader["PatchingStatus"].ToString();
                textBox2.Text = reader["DatabasePatches"].ToString();
                textBox3.Text = reader["titleiSight"].ToString();
            }
            MessageBox.Show(TotalCnt.ToString());
            conn.Close();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dBCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetDBCount();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDB();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //Load ListBox for Dynamic Build
            int cntr = 0;
            using (TextFieldParser parser = new TextFieldParser("./DBColums.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        GetCSVFields[cntr] = field;
                        cntr++;
                        //Console.WriteLine("DB field-->" + field);
                        listBox1.Items.Add(field);
                    }
                    //Console.WriteLine("Tottal Count-->" + cntr.ToString());
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String strItem;
            int i = 0;
            int j;
            String TempString = "";
            MySQL = "";
            foreach (Object selecteditem in listBox1.SelectedItems)
            {
                strItem = selecteditem as String;
                //System.Diagnostics.Debug.WriteLine(strItem);
                //Console.WriteLine("Selected Items-->" + strItem);
                BuldDynamicSQL[i] = strItem;
                i++;
            }

            TempString = "INSERT INTO MainDB(" + ") VALUES()";
            for (j = 0; j <= i-1; j++)
                {

                MySQL = MySQL + TempString;
                /*
                MySQL = "INSERT INTO MainDB(PatchingStatus,DatabasePatches,AgebyPublishedDate,AgeBucketsbyPublishedDate,AgePolicybyPublishedDate,PatchingSLA," +
                                    "AgebypolicyCopy,AppAdjustedFinalScore,DeviceType," +
                                    "titleiSight)" +
                            " VALUES (" +
                                    "'" + MyJavaData[i].PatchingStatus + "'," +
                                    "'" + MyJavaData[i].DatabasePatches + "'," +
                                    "'" + MyJavaData[i].AgebyPublishedDate + "'," +
                                    "'" + MyJavaData[i].AgeBucketsbyPublishedDate + "'," +
                                    "'" + MyJavaData[i].AgePolicybyPublishedDate + "'," +
                                    "'" + MyJavaData[i].PatchingSLA + "'," +
                                    "'" + MyJavaData[i].AgebypolicyCopy + "'," +
                                    "'" + MyJavaData[i].AppAdjustedFinalScore + "'," +
                                    "'" + MyJavaData[i].DeviceType + "'," +
                                    "'" + MyJavaData[i].titleiSight + "')";
                                    */
            }

            Console.WriteLine("Final SQL select statent-->" + MySQL);


        }
    }
}
