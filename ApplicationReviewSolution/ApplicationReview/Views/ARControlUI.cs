using ApplicationReview.Models;
using System.ComponentModel.DataAnnotations;
using ApplicationReview.AppBLogic;
using ApplicationReview.AppData;

namespace ApplicationReview.Views
{
    public class ARControlUI
    {

        internal static void programeInfo()
        {
            //clears the console screen
            Console.Clear();
            //sets the title of the console window
            Console.Title = "Application Review";
            //sets the text color or foreground color to white
            Console.ForegroundColor = ConsoleColor.White;

            //set the welcome message 
            Console.WriteLine("\n\n-----------------Welcome to Application Review Program-----------------\n\n");
           
            Console.WriteLine("This is the program where Mangers and Bankers can review online deposite applications. ");
            PressEnterToContinue();

        }
        public void startprocess()
        {
            ARLogic aRLogic = new ARLogic();
            programeInfo(); 
            aRLogic.ProgramStart();
        }


        public static  void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter to continue...\n");
            Console.ReadLine();
        }
        internal static user UserLoginId()
        {
            user Udetails = new user();
            Console.WriteLine("\n Please enter your preferred ID :");
            Udetails.id = Console.ReadLine();
           
            return Udetails;
        }
        public static void PrintMessage(string msg, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
            PressEnterToContinue();
        }
        internal static void WelcomeCustomer(string? fullName, string? role)
        {
            if(role =="M")
            Console.WriteLine("\n\n-------Manager Portal-------\n");
            else
                Console.WriteLine("\n\n-------Banker Portal-------\n");

            Console.WriteLine($"Welcome  {fullName}");
            //PressEnterToContinue();
        }
        public static int GetSelectedOption()
        {
            Console.WriteLine("\nEnter an option:");
            int menuoption = Convert.ToInt32( Console.ReadLine());
            if (menuoption > 0 && menuoption <= 5)
            { } // return menuoption;
            else
                PrintMessage("Invalid input. Try again.", false);
            return menuoption;   
        }
        internal static void ExitProcess()
        {
            Console.WriteLine("\n\n    You have successfully logged out.");
            PressEnterToContinue();
            Console.Clear();
        }
        internal static void PrintAppData(ApplicationInfo app)
        {
            Console.WriteLine("\n---Selected App info---\n");
            Console.WriteLine($"Application ID :{app.appid}");
            Console.WriteLine($"Queue :{app.queue}");
            PressEnterToContinue();

        }
        internal static BankerNotes CollectNoteInputs()
        {
            BankerNotes notes = new BankerNotes();
            Console.WriteLine("Enter App ID:");
                notes.Appid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Manager ID:");
            notes.ManagerId = Console.ReadLine();
            Console.WriteLine("Enter your notes:");
            notes.Notes = Console.ReadLine();
            return notes;
        }
        internal static void PrintNotes(List<BankerNotes> Nlist)
        {
            Console.Write($" --Appid--    "); Console.Write($"  --Manager id--    "); Console.WriteLine($" --Notes--    ");
            foreach (BankerNotes note in Nlist)
            {
                Console.Write($"{note.Appid}     "); Console.Write($"{note.ManagerId}     "); Console.WriteLine($"{note.Notes}     ");
            }

            PressEnterToContinue();
        }
        internal static void PrintAppList(List<ApplicationInfo> alist)
        {
            Console.Write($"--Appid--    "); Console.Write($"--Queue--    "); Console.WriteLine($"--Assigned User--    ");
            foreach (ApplicationInfo app in alist)
            {
                Console.Write($"{app.appid}     "); Console.Write($"{app.queue}     "); Console.WriteLine($"{app.uid}     ");
            }

            PressEnterToContinue();

        }
        //Display AuditList
        internal static void DisplayAuditList(List<AuditList> alist)
        {
            Console.WriteLine($"\n\nApp Audit List\n");
            foreach (AuditList al in alist)
            {
                Console.Write($"{al.id}-"); Console.Write($"{al.change}  - "); Console.Write($"{al.UpdatedBy}  "); Console.WriteLine($"{al.Created} ");
            }
        }

       //Process App
        internal static void ProcessApp(ApplicationInfo app)
        {
            
            Console.WriteLine($"\n\nYou are now updating Application {app.appid} queue.\n");
            Console.WriteLine("What queue you want to process the app:");
            string? queuename = Console.ReadLine();
            if (queuename == null && (queuename != null || queuename != QueueEnum.Declined.ToString() || queuename != QueueEnum.Withdraw.ToString() || queuename != QueueEnum.Approved.ToString()))
                PrintMessage("Invalid input. Try again.", false);
            else
            {
                Console.WriteLine($"Are you sure you want to {queuename} the app?(yes/no)");
                var yn = Console.ReadLine();
                if (yn == "yes")
                {
                    ARData adata = new ARData();
                    adata.UpdateApp(queuename, app.appid);
                }
            }
            PressEnterToContinue();
        }
    }
}