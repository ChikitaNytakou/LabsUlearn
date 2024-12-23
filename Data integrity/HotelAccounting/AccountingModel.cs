using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    public class AccountingModel : ModelBase
    {
        private double _price;
        private int _nightsCount;
        private double _discount;
        private double _total;
        public double Price
        { 
            get { return _price; }
            set
            {
                if (value < 0) throw new ArgumentException("Price can't be negative");
                _price = value;
                _total = UpdateTotal();
                Notify(nameof(Price));
                Notify(nameof(Total));
            } 
        }
        public int NightsCount
        {
            get
            {
                return _nightsCount;
            }
            set 
            { 
                if (value < 1) throw new ArgumentException("Nights count should be positive");
                _nightsCount = value;
                _total = UpdateTotal();
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                if (value > 100) throw new ArgumentException();
                _discount = value;
                _total = UpdateTotal();
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }
        public double Total
        {
            get
            {
                return _total;
            }
            set 
            {
                if (value < 0) throw new ArgumentException("Total can't be negative");
                _total = value;
                _discount = (1 - _total / (_price * _nightsCount)) * 100;
                Notify(nameof(Total));
                Notify(nameof(Discount));
            } 
        }
        private double UpdateTotal()
        {
            return _price * _nightsCount * (1 - _discount / 100);
        }
    }     
}