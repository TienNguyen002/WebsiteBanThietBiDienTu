using Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    //Tình trạng đơn hàng
    public class Status : IEntity
    {
        //Mã tình trạng
        public int Id { get; set; }

        //Tên tình trạng
        public string Name { get; set; }

        //Mã định danh tình trạng
        public string UrlSlug { get; set; }

        //Danh sách đơn hàng
        public IList<Order> Orders{ get; set; }
    }
}
