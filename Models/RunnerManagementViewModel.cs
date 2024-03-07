using MSSaoPauloASP.NET.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSSaoPauloASP.NET.Models
{
    public class RunnerManagementViewModel
    {
        public List<User> RunnerList { get; set; }

        public User SelectedRunner { get; set; }
    }
}