﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gabriel_Bank_Management_System
{
    public interface ISavings
    {
        void performOperation(CustomersManagement cmgt);
        void customerDeposit(CustomersManagement cmgt);
        void customerWithdrawl(CustomersManagement cmgt);
        void ViewBalance(CustomersManagement cmgt);
    }
}
