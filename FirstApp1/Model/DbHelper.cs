using FirstApp1.EFCore;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp1.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        //Get
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> response = new List<ProductModel>();
            var dataList = _context.Products.ToList();
            dataList.ForEach(row => response.Add(new ProductModel()
            {
                brand = row.brand,
                Id = row.Id,
                name = row.name,
                price = row.price,
                size = row.size
            }));

            return response;
        }

        //Get by Id
        public ProductModel GetProductById(int id)
        {
            ProductModel response = new ProductModel();
            var row = _context.Products.Where(d => d.Id == (id)).FirstOrDefault();

            return new ProductModel()
            {
                brand = row.brand,
                Id = row.Id,
                name = row.name,
                price = row.price,
                size = row.size
            };


        }

        //post/put/patch
        public void SaveOrder(OrderModel orderModel)
        {
            //put
            //orderModel.product_id = 1;
            var productdetals = _context.Products.Where(f => f.Id == orderModel.productId).FirstOrDefault();
            Order dbTable = new Order();
            {
                dbTable.OrderId = orderModel.OrderId;
                //dbTable.productId = orderModel.productId;
                dbTable.name = orderModel.name;
                dbTable.phoneNumber = orderModel.phoneNumber;
                dbTable.address = orderModel.address;
                dbTable.product = productdetals;
                _context.Orders.Add(dbTable);
                _context.SaveChanges();
            }

        }
        //post
        public List<OrderModel> AddOrder([FromBody] OrderModel orderModel)
        {
            List<OrderModel> response = new List<OrderModel>();
            Order dbTable = new Order();
            {
                //dbTable.OrderId = _context.Orders.Where(d => d.OrderId).FirstOrDefault();
                var OrderId = _context.Orders.Where(s => s.OrderId == (orderModel.OrderId)).Count();
                if (OrderId == 1)
                {
                    return null;

                }
                else
                {
                    dbTable.OrderId = orderModel.OrderId;
                    dbTable.phoneNumber = orderModel.phoneNumber;
                    dbTable.address = orderModel.address;
                    dbTable.name = orderModel.name;
                    dbTable.product = _context.Products.Where(f => f.Id.Equals(orderModel.productId)).FirstOrDefault();
                    _context.Orders.Add(dbTable);
                    _context.SaveChanges();
                }
                return response;
            }
        }



        //Delete
        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Where(d => d.OrderId == id).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}

