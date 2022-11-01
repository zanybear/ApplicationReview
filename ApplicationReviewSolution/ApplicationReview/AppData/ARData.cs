using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ApplicationReview.Models;

namespace ApplicationReview.AppData
{
    public class ARData
    {
        List<BankerNotes>  bankerNotes;
        List<ApplicationInfo> appData;
        List<AuditList> auditlist;

        // Create a class constructor for the ARData class
        public ARData()
        {
            bankerNotes = GetNotes();
            appData = GetAppData();
            auditlist = GetAuditList();
        }
        //Fill user data
        public List<user> GetUserData()
        {
            List<user>? userList = new List<user>
            {
                new user{id="mgr1",name="Pete",role="Manager"},
                new user{id="mgr2",name="Jeff",role="Manager"},
                new user{id="bnkr1",name="Donna",role="Banker"},
                new user{id="bnkr2",name="Joe",role="Banker"},
                
            };
            return userList;
        }
        //Fill app data
        public List<ApplicationInfo> GetAppData()
        {
           appData = new List<ApplicationInfo>
            {
                //Fill bnkr1 apps
                new ApplicationInfo{appid=2022110201,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110202,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110203,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110204,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110205,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110206,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110207,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110208,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110209,process=1,queue="Withdraw",uid="bnkr1"},
                new ApplicationInfo{appid=2022110210,process=1,queue="Withdraw",uid="bnkr1"},
                new ApplicationInfo{appid=2022110211,process=1,queue="Withdraw",uid="bnkr1"},
                new ApplicationInfo{appid=2022110212,process=1,queue="Withdraw",uid="bnkr1"},
                new ApplicationInfo{appid=2022110213,process=1,queue="Declined",uid="bnkr1"},
                new ApplicationInfo{appid=2022110214,process=1,queue="Declined",uid="bnkr1"},
                new ApplicationInfo{appid=2022110215,process=1,queue="Declined",uid="bnkr1"},
                new ApplicationInfo{appid=2022110216,process=1,queue="Declined",uid="bnkr1"},
                new ApplicationInfo{appid=2022110217,process=0,queue="Assigned",uid="bnkr1"},
                new ApplicationInfo{appid=2022110218,process=1,queue="Approved",uid="bnkr1"},
                new ApplicationInfo{appid=2022110219,process=1,queue="Approved",uid="bnkr1"},
                new ApplicationInfo{appid=2022110220,process=1,queue="Approved",uid="bnkr1"},
                new ApplicationInfo{appid=2022110221,process=1,queue="Assigned",uid="bnkr1"},

                
                //Fill bnkr2 apps
                new ApplicationInfo{appid=2022110101,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110102,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110103,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110104,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110105,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110106,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110107,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110108,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110109,process=1,queue="Withdraw",uid="bnkr2"},
                new ApplicationInfo{appid=2022110110,process=1,queue="Withdraw",uid="bnkr2"},
                new ApplicationInfo{appid=2022110111,process=1,queue="Withdraw",uid="bnkr2"},
                new ApplicationInfo{appid=2022110112,process=1,queue="Withdraw",uid="bnkr2"},
                new ApplicationInfo{appid=2022110113,process=1,queue="Declined",uid="bnkr2"},
                new ApplicationInfo{appid=2022110114,process=1,queue="Declined",uid="bnkr2"},
                new ApplicationInfo{appid=2022110115,process=1,queue="Declined",uid="bnkr2"},
                new ApplicationInfo{appid=2022110116,process=1,queue="Declined",uid="bnkr2"},
                new ApplicationInfo{appid=2022110117,process=0,queue="Assigned",uid="bnkr2"},
                new ApplicationInfo{appid=2022110118,process=1,queue="Approved",uid="bnkr2"},
                new ApplicationInfo{appid=2022110119,process=1,queue="Approved",uid="bnkr2"},
                new ApplicationInfo{appid=2022110120,process=1,queue="Approved",uid="bnkr2"},
                new ApplicationInfo{appid=2022110121,process=1,queue="Assigned",uid="bnkr2"},

            };
            return appData;
        }
        public List<AuditList> GetAuditList()
        {
            auditlist = new List<AuditList>
            {
                new AuditList{id=2022110110,UpdatedBy="bnkr2",change="app moved to Withdraw queue.",Created=System.DateTime.Now.AddDays(-2)},
                new AuditList{id=2022110216,UpdatedBy="bnkr1",change="app moved to Declined queue.",Created=System.DateTime.Now},
                new AuditList{id=2022110219,UpdatedBy="bnkr1",change="app moved to Approved queue.",Created=System.DateTime.Now.AddDays(-4)},
                new AuditList{id=2022110118,UpdatedBy="bnkr2",change="app moved to Approved queue.",Created=System.DateTime.Now.AddDays(-1)},
            };
            return auditlist;
        }
        //Fill Banker Notes
        public List<BankerNotes> GetNotes()
        {
            bankerNotes = new List<BankerNotes>
            {
                new BankerNotes{Appid=2022110116,ManagerId="mgr2",Notes="DOB does not match."},
                new BankerNotes{Appid=2022110119,ManagerId="mgr2",Notes="Driver's License received and matched."},
                new BankerNotes{Appid=2022110215,ManagerId="mgr1",Notes="Fraud reported."},
                new BankerNotes{Appid=2022110220,ManagerId="mgr1",Notes="Valid records reported from vendor."},
                new BankerNotes{Appid=2022110210,ManagerId="mgr2",Notes="Re-enter application and provide customer details."},

            };
            return bankerNotes;
        }
       //add banker note
        public void AddNotes(int appid, string? managerid, string? notes)
        {
            var bnotes = new BankerNotes()
            {
                Appid = appid,
                ManagerId = managerid,
                Notes = notes
            };
            bankerNotes.Add(bnotes);
            Console.WriteLine("Successfully added BankerNote.");
        }
       //Update app by id
        public void UpdateApp( string?  qu, int appid)
        {
            foreach (var app in appData.Where(w => w.appid == appid))
            {
                app.queue = qu;
            }
            Console.WriteLine($"Successfully Updatded app- {appid} in to queue {qu}.");
        }

    }
}
