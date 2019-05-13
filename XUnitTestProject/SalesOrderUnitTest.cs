using System;
using Xunit;
using HarperCollinsWebApi.Controllers;
using HarperCollinsWebApi.Data;
using System.Linq;
using HarperCollinsWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject
{
    public class SalesOrderUnitTest
    {
        SaleOrderController _myController;
        private readonly string ConnectionString = "Server=tcp:hc-poc.database.windows.net,1433;Initial Catalog=HC;Persist Security Info=False;User ID=HCAdmin;Password=Pa$$word99;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [Fact]
        public void UpdateTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HarperCollinsWebApiDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            var _myContext = new HarperCollinsWebApiDbContext(optionsBuilder.Options);

            _myController = new SaleOrderController(_myContext);

            var mySalesOrder = _myController.GetSaleOrders().FirstOrDefault();
            var mySalesOrderId = mySalesOrder.Id;
            var mySalesOrderQuantity = mySalesOrder.Quantity;

            Assert.NotEqual(0, mySalesOrderId);
            Assert.NotEqual(0, mySalesOrderQuantity);

            if (mySalesOrderId > 0)
            {
                mySalesOrderQuantity = mySalesOrderQuantity + 10;

                Assert.NotEqual(0, mySalesOrderQuantity);
                Assert.NotEqual(mySalesOrder.Quantity, mySalesOrderQuantity);

                mySalesOrder.Quantity = mySalesOrderQuantity;

                _myController.PutSaleOrder(mySalesOrderId, mySalesOrder).Wait();

                var mySalesOrderById = _myController.GetSaleOrders().Where(so => so.Id == mySalesOrderId).FirstOrDefault();

                Assert.Equal(mySalesOrderQuantity, mySalesOrderById.Quantity);
                Assert.Equal(mySalesOrder.Id, mySalesOrderById.Id);
                Assert.Equal(mySalesOrder.Quantity, mySalesOrderById.Quantity);
            }
            else
            {
                Assert.True(false, "Error! No Id");
            }
        }

        [Fact]
        public void CreateTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HarperCollinsWebApiDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            var _myContext = new HarperCollinsWebApiDbContext(optionsBuilder.Options);

            _myController = new SaleOrderController(_myContext);

            CustomerController _myCustomerController = new CustomerController(_myContext);
            TitleController _myTitleController = new TitleController(_myContext);

            var myCustomer = _myCustomerController.GetCustomers().FirstOrDefault();
            var myTitle = _myTitleController.GetTitles().FirstOrDefault();
            var myMaxSalesOrder = _myController.GetSaleOrders().OrderByDescending(so => so.Id).FirstOrDefault();

            Assert.NotNull(myCustomer);
            Assert.NotNull(myTitle);
            Assert.NotNull(myMaxSalesOrder);

            int myQuantity = 999;
            var myCustomerId = myCustomer.Id;
            var myTitleId = myTitle.Id;
            var myMaxSalesOrderId = myMaxSalesOrder.Id;

            var todaysDate = DateTime.Now;

            Assert.NotEqual(0, myCustomerId);
            Assert.NotEqual(0, myTitleId);
            Assert.NotEqual(0, myMaxSalesOrderId);

            SaleOrder mySaleOrder = new SaleOrder
            {
                CustomerId = myCustomerId,
                TitleId = myTitleId,
                ReleaseDate = todaysDate.Date,
                Quantity = myQuantity,
                IsActive = true
            };

            _myController.PostSaleOrder(mySaleOrder).Wait();

            var mySalesOrder = _myController.GetSaleOrders(mySaleOrder.CustomerId, mySaleOrder.TitleId, mySaleOrder.ReleaseDate.ToShortDateString()).OrderByDescending(so => so.Id).FirstOrDefault();

            Assert.NotNull(mySalesOrder);
            Assert.Equal(myQuantity, mySalesOrder.Quantity);
            Assert.True(mySalesOrder.Id > myMaxSalesOrderId);
        }

        [Fact]
        public void DeleteTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HarperCollinsWebApiDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            var _myContext = new HarperCollinsWebApiDbContext(optionsBuilder.Options);

            _myController = new SaleOrderController(_myContext);

            var mySalesOrder = _myController.GetSaleOrders().OrderByDescending(so => so.Id).FirstOrDefault();
            var mySalesOrderId = mySalesOrder.Id;

            Assert.NotEqual(0, mySalesOrderId);

            if (mySalesOrderId > 0)
            {
                _myController.DeleteSaleOrder(mySalesOrderId).Wait();

                var mySalesOrderById = _myController.GetSaleOrders().Where(so => so.Id == mySalesOrderId).FirstOrDefault();

                Assert.Null(mySalesOrderById);
            }
            else
            {
                Assert.True(false, "Error! No Id");
            }
        }
    }
}
