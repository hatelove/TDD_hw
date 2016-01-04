using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderList = new OrderList();


            orderList.AddOrder(new Order { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            orderList.AddOrder(new Order { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            orderList.AddOrder(new Order { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            orderList.AddOrder(new Order { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            orderList.AddOrder(new Order { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            orderList.AddOrder(new Order { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            orderList.AddOrder(new Order { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            orderList.AddOrder(new Order { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            orderList.AddOrder(new Order { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            orderList.AddOrder(new Order { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            orderList.AddOrder(new Order { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });
            orderList.AddOrder(new Order { Id = 12, Cost = 12, Revenue = 22, SellPrice = 32 });

            orderList.Sum("Id", Int32.MaxValue);
            orderList.Sum("Cost", 3);
            orderList.Sum("Revenue", 4);
            orderList.Sum("SellPrice", 1);

            orderList.Sum("wrong", 4);
            orderList.Sum(null, 4);
            orderList.Sum("SellPrice", 0);
            orderList.Sum("SellPrice", -100);
            orderList.Sum("SellPrice", Int32.MinValue);

            var expected = new List<int>(){100,200,300};
            Console.ReadKey();
        }
    }

    // production code 的部分寫得比較複雜一點，雖然這樣封裝有一定的好處，但相對起來比較沒這麼直覺跟好維護。
    // 建議參考一下我的 sample code，或許會激發您更多的設計靈感: http://bit.ly/91-tdd-day1-homework-solution
    // 重點還是在彈性、易讀、好維護
    public class OrderList
    {
        public OrderList()
        {
             _OrderList= new List<Order>();
        }
        public int AddOrder(Order order)
        {
            //Id should be unique
            _OrderList.Add(order);

            return 0;
        }
        public List<int> Sum(string name, int groupCount)
        {
            Console.WriteLine("###########################");

            var result = new List<int>();

            if (0 >= groupCount)
            {
                Console.WriteLine("bad groupCount.");
                return result;
            }

            if (null == name)
            {
                Console.WriteLine("no such name.");
                return result;
            }
            Type myType = typeof(Order);
            PropertyInfo myPropInfo = myType.GetProperty(name);
            if (null == myPropInfo) {
                Console.WriteLine("no such name.");
                return result;
            }
            int index = 1;
            int temp = 0;
            foreach (var order in _OrderList)
            {
                temp += order.getValueByName(name);
                if ((1 < index || 1== groupCount) && 0 == ((index) % groupCount))
                {
                    result.Add(temp);
                    Console.WriteLine(temp);
                    temp = 0;
                }
                index++;
            }
            if (0 != ((index - 1) % groupCount))
            {
                result.Add(temp);
                Console.WriteLine(temp);
                   
            }
            return result;
        }


        private List<Order> _OrderList { get; set; }
    }
    public class Order
    {

        public int Id { get; set; }

        public int Cost { get; set; }
        public int Revenue { get; set; }

        public int SellPrice { get; set; }

        public int getValueByName(string propertyName)
        {
            Type myType = typeof(Order);
            PropertyInfo myPropInfo = myType.GetProperty(propertyName);
            if (null == myPropInfo) return 0;

            var value =  myPropInfo.GetValue(this, null);

            string str = null==value ? "" : value.ToString();
            int j=0;
            if (Int32.TryParse(str, out j))
            {
                //Console.WriteLine(j);
            }
            else
                Console.WriteLine("String could not be parsed.");

            return j;
        }
    }

}
