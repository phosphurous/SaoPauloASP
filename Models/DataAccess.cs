using MSSaoPauloASP.NET.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MSSaoPauloASP.NET.Models
{
    public class DataAccess
    {

        public static RunnerManagementViewModel GetRunnerManagementViewModel()
        {
            using (var ctx = new DBModel())
            {
                var runnerList = ctx.Users
                    .Include(i => i.Runners)
                    .Select(i => i).ToList();

                //var lookupList = new List<string>()
                //{
                //    //<string> needs to be in encapsulation.
                //    "Last Name",
                //    "First Name",
                //    "RunnerId",
                //    "CountryCode",
                //};

                RunnerManagementViewModel model = new RunnerManagementViewModel()
                {
                    RunnerList = runnerList,
                    SelectedRunner = runnerList.First(),
                };

                return model;
            }

        }
    }
}