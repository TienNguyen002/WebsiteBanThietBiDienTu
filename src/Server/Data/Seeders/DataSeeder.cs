using Core.Entities;
using Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly WebDbContext _dbContext;

        public DataSeeder(WebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Products.Any()) return;

            var categories = AddCategories();
            var speCategories = AddSpeCategories();
            var statuses = AddStatus();
            var colors = AddColors();
            var customers = AddCustomers();
            var images = AddImages();
            var staffs = AddStaffs();
            var trademarks = AddTrademarks(categories);
            var specifications = AddSpecifications(speCategories);
            var products = AddProducts(categories, trademarks, colors, specifications, staffs);
            var orders = AddOrders(products, statuses);
            var comments = AddComments(products, customers);
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name = "Điện thoại",
                    UrlSlug = "dien-thoai"
                },
                new()
                {
                    Name = "Tablet",
                    UrlSlug = "tablet"
                },
                new()
                {
                    Name = "Laptop",
                    UrlSlug = "laptop"
                },
                new()
                {
                    Name = "Âm thanh",
                    UrlSlug = "am-thanh"
                },
                new()
                {
                    Name = "Đồng hồ",
                    UrlSlug = "dong-ho"
                },
                new()
                {
                    Name = "Camera",
                    UrlSlug = "camera"
                },
                new()
                {
                    Name = "Smarthome",
                    UrlSlug = "smarthome"
                },
                new()
                {
                    Name = "Phụ kiện",
                    UrlSlug = "phu-kien"
                },
                new()
                {
                    Name = "PC",
                    UrlSlug = "pc"
                },
                new()
                {
                    Name = "Màn hình",
                    UrlSlug = "man-hinh"
                },
                new()
                {
                    Name = "TV",
                    UrlSlug = "tv"
                },
            };
            return categories;
        }

        private IList<Comment> AddComments(
            IList<Product> products,
            IList<Customer> customers)
        {
            var comments = new List<Comment>()
            {
                new()
                {
                    Customer = customers[0],
                    Product = products[0],
                    Detail = "Em rất thích sản phẩm này",
                    CreatedDate = DateTime.Now,
                }
            };
            return comments;
        }

        private IList<Customer> AddCustomers()
        {
            var customers = new List<Customer>()
            {
                new()
                {
                    Name = "Trần Thái Linh",
                    UrlSlug = "tran-thai-linh",
                    Email = "tranthailinh09@gmail.com",
                    Phone = "0876157866",
                    Password = "password",
                },
                new()
                {
                    Name = "Nguyễn Văn Thuận",
                    UrlSlug = "nguyen-van-thuan",
                    Email = "nguyenvanthuan112@gmail.com",
                    Phone = "0963457114",
                    Password = "password",
                },
            };
            return customers;
        }

        private IList<Image> AddImages()
        {
            var images = new List<Image>();
            return images;
        }

        private IList<Order> AddOrders(
            IList<Product> products,
            IList<Status> statuses)
        {
            var orders = new List<Order>()
            {
                new()
                {
                    CustomerName = "Trần Thái Linh",
                    Address = "123 A",
                    Phone = "0876157866",
                    Email = "tranthailinh09@gmail.com",
                    DateOrder = DateTime.Now,
                    Products = new List<Product>()
                    {
                        products[0],
                        products[1]
                    },
                    Quantity = 2,
                    TotalPrice = 70180000,
                    Status = statuses[0]
                }
            };
            return orders;
        }

        private IList<Product> AddProducts(
            IList<Category> categories,
            IList<Trademark> trademarks,
            IList<ProductColor> colors,
            IList<Specification> specifications,
            IList<Staff> staffs)
        {
            var products = new List<Product>()
            {
                new()
                {
                    Name = "iPhone 15 Pro Max 256GB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-256gb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT\r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Tag = "iphone-15-pro-max",
                    Amount = 50,
                    Status = true,
                    Price = 31390000,
                    OrPrice = 34990000,
                    Category = categories[0],
                    Trademark = trademarks[0],
                    Colors = new List<ProductColor>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Specifications = new List<Specification>()
                    {
                        specifications[0],
                        specifications[1],
                        specifications[2],
                    },
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 512GB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-512gb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT\r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Tag = "iphone-15-pro-max",
                    Amount = 50,
                    Status = true,
                    Price = 38790000,
                    OrPrice = 40990000,
                    Category = categories[0],
                    Trademark = trademarks[0],
                    Colors = new List<ProductColor>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Specifications = new List<Specification>()
                    {
                        specifications[0],
                        specifications[1],
                        specifications[2],
                    },
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 1TB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-1tb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT\r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Tag = "iphone-15-pro-max",
                    Amount = 50,
                    Status = true,
                    Price = 44990000,
                    OrPrice = 46990000,
                    Category = categories[0],
                    Trademark = trademarks[0],
                    Specifications = new List<Specification>()
                    {
                        specifications[0],
                        specifications[1],
                        specifications[2],
                    },
                }
            };
            return products;
        }

        private IList<ProductColor> AddColors()
        {
            var colors = new List<ProductColor>()
            {
                new()
                {
                    Color = "Titan đen",
                    UrlSlug = "titan-den",
                },
                new()
                {
                    Color = "Titan trắng",
                    UrlSlug = "titan-trang",
                },
                new()
                {
                    Color = "Titan tự nhiên",
                    UrlSlug = "titan-tu-nhien",
                },
                new()
                {
                    Color = "Titan xanh",
                    UrlSlug = "titan-xanh",
                },
            };
            return colors;
        }

        private IList<Specification> AddSpecifications(IList<SpecificationCategory> speCategories)
        {
            var specifications = new List<Specification>()
            {
                new()
                {
                    Details = "6.7 inches",
                    SpecificationCategory = speCategories[0],
                },
                new()
                {
                    Details = "Super Retina XDR OLED",
                    SpecificationCategory = speCategories[1],
                },
                new()
                {
                    Details = "2796 x 1290-pixel",
                    SpecificationCategory = speCategories[2],
                }
            };
            return specifications;
        }

        private IList<SpecificationCategory> AddSpeCategories()
        {
            var speCategories = new List<SpecificationCategory>()
            {
                new()
                {
                    Name = "Kích thước màn hình",
                    UrlSlug = "kich-thuoc-man-hinh",
                },
                new()
                {
                    Name = "Công nghệ màn hình",
                    UrlSlug = "cong-nghe-man-hinh",
                },
                new()
                {
                    Name = "Độ phân giải màn hình",
                    UrlSlug = "do-phan-giai-man-hinh"
                }
            };
            return speCategories;
        }

        private IList<Staff> AddStaffs()
        {
            var staffs = new List<Staff>()
            {
                new()
                {
                    Name = "Nguyễn Hoàng Nhật Tiến",
                    UrlSlug = "nguyen-hoang-nhat-tien",
                    Email = "2015749@dlu.edu.vn",
                    Phone = "0819104319",
                    Password = "password",
                },
                new()
                {
                    Name = "Trần Trung Hiếu",
                    UrlSlug = "tran-trung-hieu",
                    Email = "2011382@dlu.edu.vn",
                    Phone = "0869820809",
                    Password = "password",
                },
                new()
                {
                    Name = "Nguyễn Ngọc Minh Tiến",
                    UrlSlug = "nguyen-ngoc-minh-tien",
                    Email = "2015840@dlu.edu.vn",
                    Phone = "0868103447",
                    Password = "password",
                },
            };
            return staffs;
        }

        private IList<Status> AddStatus()
        {
            var status = new List<Status>()
            {
                new()
                {
                    Name = "Chờ xác nhận",
                    UrlSlug = "cho-xac-nhan",
                },
                new()
                {
                    Name = "Đã xác nhận",
                    UrlSlug = "da-xac-nhan",
                },
                new()
                {
                    Name = "Đang giao hàng",
                    UrlSlug = "dang-giao-hang",
                },
                new()
                {
                    Name = "Thàng công",
                    UrlSlug = "thanh-cong",
                },
            };
            return status;
        }

        private IList<Trademark> AddTrademarks(IList<Category> categories)
        {
            var trademarks = new List<Trademark>()
            {
                new()
                {
                    Name = "Apple",
                    UrlSlug = "apple",
                    Categories = new List<Category>()
                    {
                        categories[0],
                        categories[1],
                        categories[3],
                        categories[4],
                        categories[7]
                    },
                },
                new()
                {
                    Name = "Samsung",
                    UrlSlug = "samsung",
                    Categories = new List<Category>()
                    {
                        categories[0],
                        categories[1],
                        categories[3],
                        categories[4],
                        categories[9],
                        categories[10]
                    },
                },
            };
            return trademarks;
        }
    }
}
