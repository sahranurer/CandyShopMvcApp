using CandyShopApp.Data;
using CandyShopApp.Models.ShoppingCartOp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopApp.Models.OrderOp
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var shoppingcartitem in shoppingCartItems)
            {
                var orderdetail = new OrderDetail
                {
                    Amount = shoppingcartitem.Amount,
                    Price = shoppingcartitem.Candy.Price,
                    CandyId = shoppingcartitem.Candy.CandyId,
                    OrderId = order.OrderId
                };
                _appDbContext.OrderDetails.Add(orderdetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
