using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly DeviceWebDbContext _dbContext;

        public DataSeeder(DeviceWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Products.Any()) return;

            var categories = AddCategories();
            var colors = AddColors();
            var statuses = AddStatuses();
            var roles = AddRoles();
            var tags = AddTags();
            var branches = AddBranches();
            var paymentMethods = AddPaymentMethods();

            var users = AddUsers(roles);
            var products = AddProducts(categories, branches, colors, tags);
            var discounts = AddDiscounts(products);
            var images = AddImages(products);
            var comments = AddComments(products, users);
            var orders = AddOrders(users, paymentMethods, statuses);
            var orderItems = AddOrderItems(products, orders);
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
            var categoryAdd = new List<Category>();
            foreach (var item in categories)
            {
                if (!_dbContext.Categories.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    categoryAdd.Add(item);
                }
            }
            _dbContext.AddRange(categoryAdd);
            _dbContext.SaveChanges();
            return categories;
        }

        private IList<Color> AddColors()
        {
            var colors = new List<Color>()
            {
                new()
                {
                    Name = "Titan đen",
                    UrlSlug = "titan-den",
                },
                new()
                {
                    Name = "Titan trắng",
                    UrlSlug = "titan-trang",
                },
                new()
                {
                    Name = "Titan tự nhiên",
                    UrlSlug = "titan-tu-nhien",
                },
                new()
                {
                    Name = "Titan xanh",
                    UrlSlug = "titan-xanh",
                },
            };
            var colorAdd = new List<Color>();
            foreach (var item in colors)
            {
                if (!_dbContext.Colors.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    colorAdd.Add(item);
                }
            }
            _dbContext.AddRange(colorAdd);
            _dbContext.SaveChanges();
            return colors;
        }

        private IList<Comment> AddComments(
            IList<Product> products,
            IList<User> users)
        {
            var comments = new List<Comment>()
            {
                new()
                {
                    User = users[0],
                    Product = products[0],
                    Detail = "Em rất thích sản phẩm này",
                    CommentDate = DateTime.Now,
                }
            };
            _dbContext.AddRange(comments);
            _dbContext.SaveChanges();
            return comments;
        }

        private IList<Image> AddImages(IList<Product> products)
        {
            var images = new List<Image>()
            {
                new()
                {
                    ImageUrl = "Hinh 1",
                    Product = products[0],
                },
                new()
                {
                    ImageUrl = "Hinh 2",
                    Product = products[0],
                },
                new()
                {
                    ImageUrl = "Hinh 3",
                    Product = products[0],
                }
            };
            var imageAdd = new List<Image>();
            foreach (var item in images)
            {
                if (!_dbContext.Images.Any(s => s.ImageUrl == item.ImageUrl))
                {
                    imageAdd.Add(item);
                }
            }
            _dbContext.AddRange(imageAdd);
            _dbContext.SaveChanges();
            return images;
        }

        private IList<Order> AddOrders(
            IList<User> users,
            IList<PaymentMethod> paymentMethods,
            IList<Status> statuses)
        {
            var orders = new List<Order>()
            {
                new()
                {
                    User = users[0],
                    DateOrder = DateTime.Now,
                    Quantity = 2,
                    TotalPrice = 70180000,
                    Status = statuses[0],
                    PaymentMethod = paymentMethods[0]
                }
            };
            _dbContext.AddRange(orders);
            _dbContext.SaveChanges();
            return orders;
        }

        private IList<Product> AddProducts(
            IList<Category> categories,
            IList<Branch> branches,
            IList<Color> colors,
            IList<Tag> tags)
        {
            var products = new List<Product>()
            {
                new()
                {
                    Name = "iPhone 15 Pro Max 256GB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-256gb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT8r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Specification = "Kích thước màn hình: 6.7 inches\nCông nghệ màn hình: Super Retina XDR OLED",
                    Amount = 50,
                    Status = true,
                    Price = 31390000,
                    OrPrice = 34990000,
                    Category = categories[0],
                    Branch = branches[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Tag = tags[0],
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 512GB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-512gb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT\r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Specification = "Kích thước màn hình: 6.7 inches\nCông nghệ màn hình: Super Retina XDR OLED",
                    Amount = 50,
                    Status = true,
                    Price = 31390000,
                    OrPrice = 34990000,
                    Category = categories[0],
                    Branch = branches[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Tag = tags[0],
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 1TB | Chính hãng VN/A",
                    UrlSlug = "iphone-15-pro-max-1tb",
                    Description = "ĐẶC ĐIỂM NỔI BẬT\r\nThiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn\r\niPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                    Specification = "Kích thước màn hình: 6.7 inches\nCông nghệ màn hình: Super Retina XDR OLED",
                    Amount = 50,
                    Status = true,
                    Price = 31390000,
                    OrPrice = 34990000,
                    Category = categories[0],
                    Branch = branches[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Tag = tags[0],
                },
            };
            var productAdd = new List<Product>();
            foreach (var item in products)
            {
                if (!_dbContext.Products.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    productAdd.Add(item);
                }
            }
            _dbContext.AddRange(productAdd);
            _dbContext.SaveChanges();
            return products;
        }

        private IList<Role> AddRoles()
        {
            var roles = new List<Role>()
            {
                new()
                {
                    Name = "User",
                    UrlSlug = "user",
                },
                new()
                {
                    Name = "Admin",
                    UrlSlug = "admin",
                },
            };
            var roleAdd = new List<Role>();
            foreach (var item in roles)
            {
                if (!_dbContext.Roles.Any(s => s.UrlSlug == item.UrlSlug))
                { 
                    roleAdd.Add(item);
                }
            }
            _dbContext.AddRange(roleAdd);
            _dbContext.SaveChanges();
            return roles;
        }

        private IList<Status> AddStatuses()
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
            var statusAdd = new List<Status>();
            foreach (var item in status)
            {
                if (!_dbContext.Statuses.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    statusAdd.Add(item);
                }
            }
            _dbContext.AddRange(statusAdd);
            _dbContext.SaveChanges();
            return status;
        }

        private IList<Branch> AddBranches()
        {
            var branches = new List<Branch>()
            {
                new()
                {
                    Name = "Apple",
                    UrlSlug = "apple",
                },
                new()
                {
                    Name = "Samsung",
                    UrlSlug = "samsung",
                },
            };
            var branchAdd = new List<Branch>();
            foreach (var item in branches)
            {
                if (!_dbContext.Branches.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    branchAdd.Add(item);
                }
            }
            _dbContext.AddRange(branchAdd);
            _dbContext.SaveChanges();
            return branches;
        }

        private IList<User> AddUsers(
            IList<Role> roles)
        {
            var users = new List<User>()
            {
                new()
                {
                    Name = "Trần Thái Linh",
                    UrlSlug = "tran-thai-linh",
                    Email = "tranthailinh09@gmail.com",
                    Phone = "0876157866",
                    Password = "password",
                    Address = "123 A",
                    Role = roles[0],
                },
                new()
                {
                    Name = "Nguyễn Văn Thuận",
                    UrlSlug = "nguyen-van-thuan",
                    Email = "nguyenvanthuan112@gmail.com",
                    Phone = "0963457114",
                    Password = "password",
                    Address = "123 A",
                    Role = roles[0],
                },
                new()
                {
                    Name = "Nguyễn Hoàng Nhật Tiến",
                    UrlSlug = "nguyen-hoang-nhat-tien",
                    Email = "2015749@dlu.edu.vn",
                    Phone = "0819104319",
                    Password = "password",
                    Address = "123 A",
                    Role = roles[1],
                },
                new()
                {
                    Name = "Trần Trung Hiếu",
                    UrlSlug = "tran-trung-hieu",
                    Email = "2011382@dlu.edu.vn",
                    Phone = "0869820809",
                    Password = "password",
                    Address = "123 A",
                    Role = roles[1],
                },
                new()
                {
                    Name = "Nguyễn Ngọc Minh Tiến",
                    UrlSlug = "nguyen-ngoc-minh-tien",
                    Email = "2015840@dlu.edu.vn",
                    Phone = "0868103447",
                    Password = "password",
                    Address = "123 A",
                    Role = roles[1],
                },
            };
            var userAdd = new List<User>();
            foreach (var item in users)
            {
                if (!_dbContext.Users.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    userAdd.Add(item);
                }
            }
            _dbContext.AddRange(userAdd);
            _dbContext.SaveChanges();
            return users;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new()
                {
                    Name = "IPhone 15 Pro Max",
                    UrlSlug = "iphone-15-pro-max",
                },
            };
            var tagAdd = new List<Tag>();
            foreach (var item in tags)
            {
                if (!_dbContext.Tags.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    tagAdd.Add(item);
                }
            }
            _dbContext.AddRange(tagAdd);
            _dbContext.SaveChanges();
            return tags;
        }

        private IList<Discount> AddDiscounts(IList<Product> products)
        {
            var discounts = new List<Discount>()
            {
                new()
                {
                    DiscountPrice = 29130000,
                    StartDate = DateTime.Now,
                    EndDate = (DateTime.Now).AddDays(7),
                    Status = true,
                    Product = products[0],
                },
            };
            var discountAdd = new List<Discount>();
            foreach (var item in discounts)
            {
                if (!_dbContext.Discounts.Any(s => s.Id == item.Id))
                {
                    discountAdd.Add(item);
                }
            }
            _dbContext.AddRange(discountAdd);
            _dbContext.SaveChanges();
            return discounts;
        }

        private IList<OrderItem> AddOrderItems(IList<Product> products, IList<Order> orders)
        {
            var r = new Random();
            var orderItems = new List<OrderItem>();
            for(int i = 0; i < orders.Count; i ++)
            {
                foreach(var item in products)
                {
                    orderItems.Add(new OrderItem()
                    {
                        OrderId = orders[i].Id,
                        ProductId = item.Id,
                        Quantity = i + r.Next(1, 10),
                        Price = item.Price + r.Next(2900000, 3200000),
                    });
                }
            };
            _dbContext.AddRange(orderItems);
            _dbContext.SaveChanges();
            return orderItems;
        }

        private IList<PaymentMethod> AddPaymentMethods()
        {
            var paymentMethods = new List<PaymentMethod>()
            {
                new()
                {
                    Name = "QR Pay",
                    Description = "Thanh toán bằng QR",
                },
                new()
                {
                    Name = "Thanh toán trực tiếp",
                    Description = "Thanh toán trực tiếp khi nhận hàng",
                },
            };
            var paymentMethodAdd = new List<PaymentMethod>();
            foreach (var item in paymentMethods)
            {
                if (!_dbContext.PaymentMethods.Any(s => s.Name == item.Name))
                {
                    paymentMethodAdd.Add(item);
                }
            }
            _dbContext.AddRange(paymentMethodAdd);
            _dbContext.SaveChanges();
            return paymentMethods;
        }
    }
}
