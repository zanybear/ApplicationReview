using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationReview.Models
{
    

        public class user
        {
            //set properties
            public string? id { get; set; }
            public string? name { get; set; }
            public string? role { get; set; }   
            
        }
        public class ApplicationInfo
        {
            public int appid { get; set; }
            public int process { get; set; }
            public string? queue { get; set; }
            public string? uid { get; set; }
        }
    public class BankerNotes
    {
        public int  Appid { get; set; }
       
        public string? ManagerId { get; set; }
        public string? Notes { get; set; }
    }
    public class AuditList
    {
        //set properties
        public int id { get; set; }
        public string? UpdatedBy { get; set; }
        public string? change { get; set; }
        public DateTime Created { get; set; }

    }
}
