using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace iCapBasic
{
    internal class LoadRetailFile
    {
        public List<JavaData> myRetailDData;
        public string[] HoldInput = new string[120];

        public LoadRetailFile(List<JavaData> myRetailDData)
        {
            this.myRetailDData = myRetailDData;

            int cntr = 1;
            using (TextFieldParser parser = new TextFieldParser("./RAO Items no filter-CSV.csv"))
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
                    this.myRetailDData.Add(new JavaData()
                    {
                        PatchingStatus = HoldInput[1],
                        DatabasePatches = HoldInput[2],
                        AgebyPublishedDate = HoldInput[3],
                        AgeBucketsbyPublishedDate = HoldInput[4],
                        AgePolicybyPublishedDate = HoldInput[5],
                        PatchingSLA = HoldInput[6],
                        AgebypolicyCopy = HoldInput[7],
                        AppAdjustedFinalScore = HoldInput[8],
                        DeviceType = HoldInput[9],
                        ApplianceSystems = HoldInput[10],
                        ApplicationServiceList = HoldInput[11],
                        BusinessRelationshipManagerList = HoldInput[12],
                        CveCatalogId = HoldInput[13],
                        VulnsCategory = HoldInput[14],
                        MaterialityNorAppAdjFinal = HoldInput[15],
                        DayssinceScan = HoldInput[16],
                        AgeBuckets = HoldInput[17],
                        PrimaryKeyUniquevulnerabilityrow = HoldInput[18],
                        CountUniqueVulnerabilities = HoldInput[19],
                        Criticality = HoldInput[20],
                        HostCount = HoldInput[21],
                        Age = HoldInput[22],
                        AgeGroups = HoldInput[23],
                        Agebypolicy = HoldInput[24],
                        PublishedDateGreaterOneYear = HoldInput[25],
                        ApplicationListCombined = HoldInput[26],
                        MaterialityScore = HoldInput[27],
                        CountHost = HoldInput[28],
                        CategoryBreakdown = HoldInput[29],
                        Cloud = HoldInput[30],
                        CriticalityupdateFor2020 = HoldInput[31],
                        CriticalityField = HoldInput[32],
                        DISCOVERYDETAILS = HoldInput[33],
                        DeviceTypeCopy = HoldInput[34],
                        DeviceType2 = HoldInput[35],
                        QualysID = HoldInput[36],
                        ExternalScannerId = HoldInput[37],
                        External = HoldInput[38],
                        FIXED_DATE = HoldInput[39],
                        FinalScore = HoldInput[40],
                        FixedDate = HoldInput[41],
                        HALO_Application_Name = HoldInput[42],
                        HALO_Business_Unitgroup = HoldInput[43],
                        HALO_Business_Unit = HoldInput[44],
                        HALO_Manage_Product_Data_Login = HoldInput[45],
                        HALO_Resolve_Ops_Issues_Login = HoldInput[46],
                        HostField = HoldInput[47],
                        HostPrimaryIp = HoldInput[48],
                        ImportDate = HoldInput[49],
                        CategoryBreakdown2 = HoldInput[50],
                        LAST_SCAN_TIME = HoldInput[51],
                        LifecycleStatus = HoldInput[52],
                        LocationField = HoldInput[53],
                        Materiality_Score = HoldInput[54],
                        Materiality_Score_8 = HoldInput[55],
                        Materiality_Score_9 = HoldInput[56],
                        ASLAbyFixedDate = HoldInput[57],
                        NetworkName = HoldInput[58],
                        NumberofRecordspublic = HoldInput[59],
                        OSGgroup = HoldInput[60],
                        OSGroupsupdated = HoldInput[61],
                        OSGroups = HoldInput[62],
                        OSField = HoldInput[63],
                        Ownername = HoldInput[64],
                        PatchableField = HoldInput[65],
                        PublishedDatetime = HoldInput[66],
                        PatchGroup = HoldInput[67],
                        PatchingSLAbyPubdate = HoldInput[68],
                        VulnerabilityAgeRanges = HoldInput[69],
                        PatchingSLAbyPubdatBLUE = HoldInput[70],
                        PatchingSLAbyPubdate2 = HoldInput[71],
                        QualysIDCcopy = HoldInput[72],
                        SERVICE_PORTS = HoldInput[73],
                        ServiceProductName = HoldInput[74],
                        SeverityField = HoldInput[75],
                        SeverityLevel = HoldInput[76],
                        SRM_Category_Breakdown = HoldInput[77],
                        ServiceProductNameFilter = HoldInput[78],
                        Title = HoldInput[79],
                        TitleFromKb = HoldInput[80],
                        Tier2SupportDirectorList = HoldInput[81],
                        Tier2SupportGroupList = HoldInput[82],
                        Tier2SupportManagerList = HoldInput[83],
                        Tier3SupportDirectorEmailList = HoldInput[84],
                        Tier3SupportDirectorList = HoldInput[85],
                        Tier3SupportGroupList = HoldInput[86],
                        Tier3SupportManagerEmailList = HoldInput[87],
                        Tier3SupportManagerList = HoldInput[88],
                        VTMCategory = HoldInput[89],
                        VulnType = HoldInput[90],
                        VulnerabilityAgeRangesbyPubdate = HoldInput[91],
                        VulnsCategorygroup = HoldInput[92],
                        age_filter_180 = HoldInput[93],
                        appliance_filter = HoldInput[94],
                        maximumCREATION_TIME = HoldInput[95],
                        maximumREPORTED_TIME = HoldInput[96],
                        minimumCREATION_TIME = HoldInput[97],
                        minimumREPORTED_TIME = HoldInput[98],
                        mitigationsiSight = HoldInput[99],
                        primary_key = HoldInput[100],
                        qid_java_alert = HoldInput[101],
                        sladurationdays = HoldInput[102],
                        sladurationdaysunchanged = HoldInput[103],
                        sla_blue_status = HoldInput[104],
                        srm_category_breakdown = HoldInput[105],
                        srm_database_category = HoldInput[106],
                        srm_os_group = HoldInput[107],
                        titleiSight = HoldInput[108]

    });
                    cntr = 1; // Reset back to zero because there are only 20 fields
                              //HoldInput[cntr] = fields;
                              //cntr++;
                }
            }

            //Console.WriteLine("Write it out ==>" + this.myRetailDData[1].ApplicationServiceList);
            //Console.WriteLine("Write it out ==>" + this.myRetailDData[1].PRODAMID);
            //Console.WriteLine("Write it out ==>" + this.myRetailDData.Count);
            
        }
    }
}