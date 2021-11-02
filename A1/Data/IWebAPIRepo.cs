using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A1.Model;

namespace A1.Data
{
    public interface IWebAPIRepo
    {


        IEnumerable<Staff> GetAllStaff();
        Staff GetStaffByID(int id);
        void SaveChanges();

        IEnumerable<Product> GetItems();
        Product GetItemByName(string Name);

        Comment GetCommentByID(int id);
        Comment WriteComment(Comment customer);

        IEnumerable<Comment>  GetComments();

        Staff GetCard(int id);
    }

}
