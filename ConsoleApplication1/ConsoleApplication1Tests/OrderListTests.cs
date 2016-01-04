using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class OrderListTests
    {
        OrderList orderList;
        /*
        [ClassInitialize()]
        */
        public void InitializeOrderList()
        {
            orderList = new OrderList();


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
            //orderList.AddOrder(new Order { Id = 12, Cost = 12, Revenue = 22, SellPrice = 32 });
        }
       
        [TestMethod()]
        public void SumTest_Cost_3()
        {
            InitializeOrderList();


            List<int> actual = orderList.Sum("Cost", 3);
            var expected = new List<int>() { 6, 15, 24, 21 };
            CollectionAssert.AreEqual(actual, expected);
             //Assert.Fail();

        }
        public void SumTest_Revenue_4() 
        {
            InitializeOrderList();
            List<int> actual = orderList.Sum("Revenue", 4);
            var expected = new List<int>() { 50, 66, 60 };
            CollectionAssert.AreEqual(actual, expected);
        }
        public void SumTest_SellPrice_1()
        {
            List<int> actual = orderList.Sum("SellPrice", 1);
            var expected = new List<int>() { 50, 66, 60 };
            CollectionAssert.AreEqual(actual, expected);
        }
        public void SumTest_Id_max()
        {
            List<int> actual = orderList.Sum("Id", Int32.MaxValue);
            var expected = new List<int>() { 50, 66, 60 };
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
/*
orderList.Sum("Id", Int32.MaxValue);
orderList.Sum("Cost", 3);
orderList.Sum("Revenue", 4);
orderList.Sum("SellPrice", 1);

orderList.Sum("wrong", 4);
orderList.Sum(null, 4);
orderList.Sum("SellPrice", 0);
orderList.Sum("SellPrice", -100);
orderList.Sum("SellPrice", Int32.MinValue);
*/