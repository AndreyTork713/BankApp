using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
//Файл программы содержащий делегат и вспомогательный метод
{
    public delegate void AccountStateHandler(object sender);

    public class AccountEventArgs //Класс содержащий аргументы (наполнение) для СОБЫТИЙ(event)
        {
        //СООБЩЕНИЕ
        public string Message{ get; private set; }

        //СУММА, НА КОТОРУЮ ИЗМЕНИЛСЯ СЧЕТ
        public decimal Sum { get; private set; }

        public AccountEventArgs(string mess, decimal _sum)
        {
            Message = mess;
            Sum = _sum;
        }


    }

}