using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using A1.Model;
using A1.Data;
using A1.Dtos;
using System.Net;
using System.IO;
using System.Drawing;
using A1.Helper;
using System.Drawing.Imaging;


using System.IO;


namespace A1.Controllers
{
    [Route("api")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IWebAPIRepo _repository;

        public StaffController(IWebAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAllStaff")]
        public ActionResult<IEnumerable<StaffOutDto>> GetAllStaff()
        {
            IEnumerable<Staff> staffs = _repository.GetAllStaff();
            IEnumerable<StaffOutDto> s = staffs.Select(e => new StaffOutDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                Email = e.Email,
                Tel = e.Tel,
                Url = e.Url,
                Research = e.Research
            });
            return Ok(s);
        }

        [HttpGet("GetVersion")]

        public string GetVersion()
        {
            return "V1";
        }

        [HttpGet("GetItems")]

        public ActionResult<IEnumerable<ProductOutDto>> GetItems()
        {
            IEnumerable<Product> products = _repository.GetItems();
            IEnumerable<ProductOutDto> s = products.Select(e => new ProductOutDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,

            });
            return Ok(s);
        }

        [HttpGet("GetItems/{name}")]
        public ActionResult GetItemByName(string name)
        {
            Product item = _repository.GetItemByName(name);
            IEnumerable<Product> products = _repository.GetItems();
            IEnumerable<string> n1 = products.Select(e => e.Name);

            List<ProductOutDto> myList = new List<ProductOutDto>();
            if (string.IsNullOrWhiteSpace(name))
            {
                return NotFound();
            }
            foreach (string name1 in n1)
            {
                Product name2 = _repository.GetItemByName(name1);

                if (name1.ToLower().Contains(name.ToLower()))
                {

                    ProductOutDto c = new ProductOutDto { Id = name2.Id, Name = name2.Name, Description = name2.Description, Price = name2.Price };
                    myList.Add(c);
                }

            }

            return Ok(myList);
        }
        

        [HttpGet("GetCommentByID/{ID}")]
        public ActionResult<commentOutDto> GetCommentByID(int id)
        {
            Comment comment = _repository.GetCommentByID(id);
            string remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (comment == null)
                return NotFound();
            else
            {
                commentOutDto c = new commentOutDto { Id = comment.Id, Comments = comment.Comments, Name = comment.Name, IP = remoteIpAddress, Time = DateTime.Now };
                return Ok(c);
            }

        }
        [HttpPost("WriteComment")]
        public ActionResult<commentOutDto> WriteComment(commentInputDto customer)
        {
            string remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            Comment c = new Comment { Comments = customer.Comment, Name = customer.Name };
            Comment addedCustomer = _repository.WriteComment(c);
            commentOutDto co = new commentOutDto { Id = addedCustomer.Id, Comments = addedCustomer.Comments, Name = addedCustomer.Name, IP = remoteIpAddress, Time = DateTime.Now };
            return CreatedAtAction(nameof(GetCommentByID), new { id = co.Id }, co);
        }

        [HttpGet("GetLogo")]
        public ActionResult GetLogo()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName1 = Path.Combine(imgDir, "logo" + ".png");
            string respHeader = "image/png";
            return PhysicalFile(fileName1, respHeader);
        }

        [HttpGet("GetStaffPhoto/{ID}")]
        public ActionResult GetStaffPhoto(int id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "StaffPhotos");
            string fileName1 = Path.Combine(imgDir, id + ".png");
            string fileName2 = Path.Combine(imgDir, id + ".jpg");
            string fileName3 = Path.Combine(imgDir, id + ".gif");
            string fileName4 = Path.Combine(imgDir, "default" + ".png");
            string respHeader = "";
            string respHeader1 = "image/png";
            string fileName = "";
            if (System.IO.File.Exists(fileName1))
            {
                respHeader = "image/png";
                fileName = fileName1;
            }
            else if (System.IO.File.Exists(fileName2))
            {
                respHeader = "image/jpeg";
                fileName = fileName2;
            }
            else if (System.IO.File.Exists(fileName3))
            {
                respHeader = "image/gif";
                fileName = fileName3;
            }
            else
                return PhysicalFile(fileName4, respHeader1);
            return PhysicalFile(fileName, respHeader);
        }
        [HttpGet("GetItemPhoto/{ID}")]
        public ActionResult GetItemPhoto(int id)
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "ItemsImages");
            string imgDir1 = Path.Combine(path, "StaffPhotos");
            string fileName1 = Path.Combine(imgDir, id + ".png");
            string fileName2 = Path.Combine(imgDir, id + ".jpg");
            string fileName3 = Path.Combine(imgDir, id + ".gif");
            string fileName4 = Path.Combine(imgDir1, "default" + ".png");
            string respHeader = "";
            string respHeader1 = "image/png";
            string fileName = "";
            if (System.IO.File.Exists(fileName1))
            {
                respHeader = "image/png";
                fileName = fileName1;
            }
            else if (System.IO.File.Exists(fileName2))
            {
                respHeader = "image/jpeg";
                fileName = fileName2;
            }
            else if (System.IO.File.Exists(fileName3))
            {
                respHeader = "image/gif";
                fileName = fileName3;
            }
            else
                return PhysicalFile(fileName4, respHeader1);
            return PhysicalFile(fileName, respHeader);
        }

        [HttpGet("GetComments")]
        public ContentResult GetComments()
        {
            int a = 5;
            int b = 5;
            IEnumerable<Comment> comments = _repository.GetComments();
            List<commentOutDto1> myList1 = new List<commentOutDto1>();
            IEnumerable<string> name = comments.Select(e => e.Name);
            IEnumerable<string> comment = comments.Select(e => e.Comments);

            List<string> name_list = new List<string>();
            List<string> comment_list = new List<string>();

            foreach (string x in name.Reverse())
            {
                   if (a  >0)
                {                       
                    name_list.Add(x);
                    a--;
                }
            }
            foreach (string x in comment.Reverse())
            {
                if (b > 0)
                {
                    comment_list.Add(x);
                    b--;
                }
            }
            

            ContentResult c = new ContentResult
            {
                Content = "<html><body>"+"<p>" + comment_list[0]+ " &mdash; "+ name_list[0]+"</p>"+
                "<p>" + comment_list[1] + " &mdash; " + name_list[1] + "</p>"+
                "<p>" + comment_list[2] + " &mdash; " + name_list[2] + "</p>" +
                "<p>" + comment_list[3] + " &mdash; " + name_list[3] + "</p>" +
                "<p>" + comment_list[4] + " &mdash; " + name_list[4] + "</p>" +
                "</body></html>",
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,

            };


            return c;
            }
        [HttpGet("GetCard/{id}")]
        public ActionResult GetCard(int id)
        {
            Staff staff = _repository.GetCard(id);
            string path = Directory.GetCurrentDirectory();
            string fileName = Path.Combine(path, "StaffPhotos/" + id + ".jpg");
            string photoString, photoType;
            ImageFormat imageFormat;
            if (System.IO.File.Exists(fileName))
            {
                Image image = Image.FromFile(fileName);
                imageFormat = image.RawFormat;
                image = ImageHelper.Resize(image, new Size(100, 100), out photoType);
                photoString = ImageHelper.ImageToString(image, imageFormat);
            }
            else
                return NotFound();
            StaffCardOut cardOut = new StaffCardOut();
            cardOut.Name = staff.Title + " " + staff.FirstName + " " + staff.LastName;
            cardOut.Uid = staff.Id;
            cardOut.Photo = photoString;
            cardOut.PhotoType = photoType;
            cardOut.Categories = Helper.HobbiesFilter.Filter(staff.Research);
            Response.Headers.Add("Content-Type", "text/vcard");
            return Ok(cardOut);
        }




    }

}
        


    

