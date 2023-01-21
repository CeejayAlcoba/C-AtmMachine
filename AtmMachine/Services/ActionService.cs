using AtmMachine.Interface;
using AtmMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtmMachine.Services
{
    public class ActionService : IActionService
    {
        private Context _context;
        public ActionService(Context context)
        {
            _context = context;
        }

        public Money Deposit(int userId, float depositMoney)
        {

            var user = _context.Find<User>(userId);
            var money = _context.Find<Money>(user.moneyId);
            money.money = money.money + depositMoney;
            _context.Update<Money>(money);
            _context.SaveChanges();

            return money;
        }
        public Money Withdraw(int userId, float depositMoney)
        {

            var user = _context.Find<User>(userId);
            var money = _context.Find<Money>(user.moneyId);

            if (money.money >= depositMoney)
            {
                money.money = money.money - depositMoney;
                _context.Update<Money>(money);
                _context.SaveChanges();
                return money;
            }
            else
            {
                return null;
            }

        }
        public float CheckBalance(int userId)
        {
            var user = _context.Find<User>(userId);
            var money = _context.Find<Money>(user.moneyId);
            return money.money;
        }
    }
}
