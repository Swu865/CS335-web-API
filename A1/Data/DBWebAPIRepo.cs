using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using A1.Model;

namespace A1.Data
{
    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly StaffDbContext _dbContext;


        public DBWebAPIRepo(StaffDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IEnumerable<Staff> GetAllStaff()
        {
            IEnumerable<Staff> staffs = _dbContext.Staff.ToList<Staff>();
            return staffs;
        }

        public Staff GetStaffByID(int id)
        {
            Staff staff = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            return staff;

        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public IEnumerable<Product> GetItems()
        {
            IEnumerable<Product> items = _dbContext.Product.ToList<Product>();
            return items;
        }

        public Product GetItemByName(string name)
        {
            Product product_name = _dbContext.Product.FirstOrDefault(e => e.Name == name);
            return product_name;


        }
        public Comment GetCommentByID(int id)
        {
            Comment comment = _dbContext.Comment.FirstOrDefault(e => e.Id == id);
            return comment;
        }
        public Comment WriteComment(Comment comment)
        {
            EntityEntry<Comment> e = _dbContext.Comment.Add(comment);
            Comment c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public IEnumerable<Comment> GetComments()
        {
            IEnumerable<Comment> comments = _dbContext.Comment.ToList<Comment>();
            return comments;
        }
        public Staff GetCard(int id)
        {
            Staff staff = _dbContext.Staff.FirstOrDefault(e => e.Id == id);
            return staff;
        }

    }
}
