using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    class Account : IAccount
    {
        //Событие возникающее при добавлении на счет
        protected internal event AccountStateHandler Added;
        //Событие возникающее при снятии со счета
        protected internal event AccountStateHandler Withdrawed;
        //Событие возникающее при открытии счета
        protected internal event AccountStateHandler Opened;
        //Событие возникающее при закрытии счета
        protected internal event AccountStateHandler Closed;
        //Событие возникающее при начислении процентов
        protected internal event AccountStateHandler Calculated;


        protected int _id; //ID-уникальный номер каждого экземпляра класса Account
        static int counter; // Статический счетчик, используемый для получения ID каждым экземпляром метода Account
        protected decimal _sum; // Переменная для хранения суммы
        protected int _percentage; //Переменная для хранения процента
        protected int _days; //Переменная для хранения количества дней с открытия счета

        public Account(decimal sum,int percentage)
        {
            _sum = sum;
            _percentage = percentage;
            _id = ++counter;

           
        }
        //Текущая сумма на счету
        public decimal CurrentSum { get { return _sum; } } //Свойство которое можно только получить
        //Текущий процент
        public int Percentage { get { return _percentage; } }//Свойство которое можно только получить
        //Текущий ID
        public int Id { get { return _id; } }//Свойство которое можно только получить

        //ВЫЗОВ СОБЫТИЙ
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (handler != null && e != null )
            {
                handler(this, e);
            }
        }
        //Вызов отдельных событий
        protected virtual void OnOpen(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public void Put(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccountEventArgs($"На счет поступило: {sum}", sum));
            
        }

        public decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (_sum > sum)
            {
                OnWithdrawed(new AccountEventArgs($"Со счета снято: {sum}", sum));
            }
            return result;
        }
    }
}
