﻿using System;
using BankingWebAPI.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BankingWebAPI.Filters;
using BankingWebAPI.Interfaces;
using BankingWebAPI.Models;

namespace BankingWebAPI.Controllers
{
    [LogAction]
    [Log]
    [RoutePrefix("api/ManagerAuthentication")]
    public class ManagerAccountManagerController : ApiController, IManagerAccountManager
    {
        private IList<BankManagers> _managersList;
        public virtual Dictionary<string, BankManagers> dictionaryOfManagers { get; set; }



        public ManagerAccountManagerController()
        {
            using (BankManagementContexts bankContext = new BankManagementContexts())
            {
                dictionaryOfManagers = new Dictionary<string, BankManagers>();
                BankManagers bmgr1 = new BankManagers() { bankmanager_id = "1111", bankmanager_name = "Peterson Jr", bankmanager_address = "23 hillview", bankmanager_dateOfBirth = DateTime.Parse("13 Oct 1992"), bankmanager_designation = "Relationship Manager", bankmanager_yearsOfService = "13", bankmanager_pw = "Peterson12345678$" };
                dictionaryOfManagers.Add("1111", bmgr1);
                bankContext.Managers.Add(bmgr1);
                bankContext.SaveChanges();
            }
            Console.WriteLine("End");     // these writeline readline is essential
            Console.ReadLine();
            _managersList = new List<BankManagers>();
            
            
        }

        [HttpGet]
        [Route("managerlogin")]                         // https://localhost:44360/api/ManagerAuthentication/managerlogin?bankmanager_id="hello"&bankmanager_pw="hello"
        public bool UserLogin(string bankmanager_id, string bankmanager_pw)
        {
            try
            {
                if (dictionaryOfManagers.ContainsKey(bankmanager_id) && dictionaryOfManagers[bankmanager_id].bankmanager_pw == bankmanager_pw)
                {
                    Console.WriteLine($"Congratulations, {dictionaryOfManagers[bankmanager_id].bankmanager_name}, you are now logged in!" + "\nok user found" + $"\nHello your info: { dictionaryOfManagers[bankmanager_id].bankmanager_id} { dictionaryOfManagers[bankmanager_id].bankmanager_name} { dictionaryOfManagers[bankmanager_id].bankmanager_designation} { dictionaryOfManagers[bankmanager_id].bankmanager_yearsOfService}");
                    return true;

                }
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("cannot be null");
            }
            return false;
            

        }
        [HttpPost]
        [Route("Test/Add")]                                 // https://localhost:44360/api/ManagerAuthentication/Test/Add
        public Dictionary<string, BankManagers> ManagerAdd(BankManagers new_user)
        {
            dictionaryOfManagers.Add(new_user.bankmanager_id, new_user);
            return dictionaryOfManagers;

        }
    }
}
