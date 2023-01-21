using AtmMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Interface
{
    public interface IActionService
    {
        Money Deposit(int userId, float depositMoney);
        Money Withdraw(int userId, float depositMoney);
        float CheckBalance(int userId);
    }
}
