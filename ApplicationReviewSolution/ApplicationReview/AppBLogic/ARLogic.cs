using ApplicationReview.Interfaces;
using ApplicationReview.Models;
using ApplicationReview.Views;
using ApplicationReview.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Security.Principal;
using System.Diagnostics;

namespace ApplicationReview.AppBLogic
{
    public class ARLogic : ILogin
    {
        private List<user> userList;
        private user selecteduser;
        private List<ApplicationInfo> _applist;
        ARData dataobj = new ARData();
        public  void ProgramStart()
        {
            
           
            userList= dataobj.GetUserData();
            VerifyUserPreferredId();
            if (selecteduser.role == "Manager")
            {
                ARControlUI.WelcomeCustomer(selecteduser.name, "M");

                ManagerMenu();
                MenuActions("M");
            }
            else
            {
                ARControlUI.WelcomeCustomer(selecteduser.name, "B");

                BankerMenu();
                MenuActions("B");
            }
        }
        public void VerifyUserPreferredId()
        {
            bool isCorrectLogin = false;

            user udata = ARControlUI.UserLoginId();

            foreach (user ulist in userList)
            {
                if (ulist.id == udata.id)
                {
                    selecteduser = ulist;
                    isCorrectLogin = true;
                    break;
                }


            }
            if (isCorrectLogin == false)
            {
                ARControlUI.PrintMessage("\nYou entered invalid user/preferred id. Please enter valid id.", false);

            }
           // Console.Clear();
            //throw new NotImplementedException();
        }
        internal static void ManagerMenu()
        {
            //Console.Clear();
            Console.WriteLine("-------Choose Manger Menu Options-------");
           
            Console.WriteLine("1. App Search  ");
            Console.WriteLine("2. App Queue count  ");
            Console.WriteLine("3. Banker Note  ");
            Console.WriteLine("4. Audit Info  ");
            Console.WriteLine("5. Exit ");
            
        }
        internal static void BankerMenu()
        {
            //Console.Clear();
            Console.WriteLine("-------Choose Banker Menu Options-------");
          
            Console.WriteLine("1. App Search ");
            Console.WriteLine("2. Assigned Apps ");
            Console.WriteLine("3. Add Notes ");
            Console.WriteLine("4. Process App  ");
            Console.WriteLine("5. Exit  ");

        }
        private void MenuActions(string role)
        {
            int SelectedOption = ARControlUI.GetSelectedOption();
            if (role == "M")
            {
                switch (SelectedOption)
                {
                    case 1:
                        AppSearch();
                        break;

                    case 2:
                        GetAppQueueCount();
                        break;

                    case 3:
                        GetBankerNotes();
                        break;
                    case 4:
                        GetAuditList();
                        break;
                    case 5:
                        ARControlUI.ExitProcess();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (SelectedOption)
                {
                    case 1:
                        AppSearch();
                        break;

                    case 2:
                        GetAssignedAppsByBanker();
                        break;

                    case 3:
                        AddBankerNotes();
                        break;
                    case 4:
                        ProcessApp();

                        break;
                    case 5:
                        ARControlUI.ExitProcess();
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddBankerNotes()
        {
            BankerNotes INoteData;
            INoteData = ARControlUI.CollectNoteInputs();
            dataobj.AddNotes(INoteData.Appid, INoteData.ManagerId, INoteData.Notes);
            MenuActions("B");
        }
        private void GetBankerNotes()
        {
            List<BankerNotes> Inotes = dataobj.GetNotes();
            ARControlUI.PrintNotes(Inotes.Where(x => x.ManagerId == selecteduser.id ).ToList());
            MenuActions("M");
        }
        private void GetAppQueueCount()
        {
            List<ApplicationInfo> apps = dataobj.GetAppData();
            Console.WriteLine("\n---- Number of Apps by queues----\n");
            foreach (var ap in apps.GroupBy(ap => ap.queue)
                        .Select(s => new {
                            queue = s.Key,
                            Count = s.Count()
                        })
                        .OrderBy(x => x.queue))
            {
                Console.WriteLine("{0} {1}", ap.queue,ap.Count);
            }
            ARControlUI.PressEnterToContinue(); 
            MenuActions("M");
        }
        private void GetAuditList()
        {
            List<AuditList> AuditList = dataobj.GetAuditList(); 
            ARControlUI.DisplayAuditList(AuditList);    
            ARControlUI.PressEnterToContinue();
            MenuActions("M");
        }
        private void GetAssignedAppsByBanker()
        {
            List<ApplicationInfo> apps = dataobj.GetAppData();
            ARControlUI.PrintAppList(apps.Where(x => x.uid == selecteduser.id && x.queue== "Assigned").ToList());
            MenuActions("B");
        }
        private void ProcessApp()
        {
            List<ApplicationInfo> apps = dataobj.GetAppData();
            ARControlUI.ProcessApp(apps.Where(x => x.uid == selecteduser.id && x.queue == "Assigned").ToList().First());
            MenuActions("B");
        }
        private void AppSearch()
        {
            int Iappid;
            try
            {
                List<ApplicationInfo> adata = dataobj.GetAppData();
                Console.WriteLine("Enter ApplicationID :");
                Iappid = Convert.ToInt32(Console.ReadLine());
                foreach (ApplicationInfo app in adata)
                {
                    if (app.appid == Iappid)
                    {
                        ARControlUI.PrintAppData(app);
                    }

                }
            }
            catch
            {
                ARControlUI.PrintMessage("Invalid input. Try again.", false);
            }
             
            if (selecteduser.role == "Manager")
            
                MenuActions("M");
            else
                MenuActions("B");
        }

    }
}
