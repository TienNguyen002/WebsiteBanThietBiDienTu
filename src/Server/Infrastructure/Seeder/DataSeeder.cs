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
            var branches = AddBranches();
            var paymentMethods = AddPaymentMethods();
            var discounts = AddDiscounts();
            var sales = AddSales();
            var series = AddSeries();

            var users = AddUsers(roles);
            var products = AddProducts(categories, branches, colors, sales, series);
            var orders = AddOrders(users, paymentMethods, statuses, discounts);
            var orderItems = AddOrderItems(products, orders);
            var images = AddImages(series);
            var comments = AddComments(series, users);
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new()
                {
                    Name = "Điện thoại",
                    UrlSlug = "dien-thoai",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842352/Category/l40ilemu0cq78s23laxp.png"
                },
                new()
                {
                    Name = "Tablet",
                    UrlSlug = "tablet",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842351/Category/ivknfnvj2nelgsbv3dn6.png"
                },
                new()
                {
                    Name = "Laptop",
                    UrlSlug = "laptop",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842352/Category/wxjk4omwfk5buc6oi4ny.png"
                },
                new()
                {
                    Name = "Âm thanh",
                    UrlSlug = "am-thanh",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842353/Category/oikkqn60jhzrf9g4t3pa.png"
                },
                new()
                {
                    Name = "Đồng hồ",
                    UrlSlug = "dong-ho",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842353/Category/o2rwvmrmmblxxxh5ipch.png"
                },
                new()
                {
                    Name = "Camera",
                    UrlSlug = "camera",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842353/Category/hdxv1amhpkalljnnayf6.png"
                },
                new()
                {
                    Name = "Phụ kiện",
                    UrlSlug = "phu-kien",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842352/Category/ddpw3x1rvevxtpsjeqw9.png"
                },
                new()
                {
                    Name = "PC",
                    UrlSlug = "pc",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842352/Category/zp2st2ewfebdr9ojc96i.png"
                },
                new()
                {
                    Name = "Màn hình",
                    UrlSlug = "man-hinh",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842352/Category/tehoclh9iahedaxxauaf.png"
                },
                new()
                {
                    Name = "TV",
                    UrlSlug = "tv",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713842351/Category/y2bhwglebxkvkztxv4ue.png"
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
                    Name = "Đỏ"
                },
                new()
                {
                    Name = "Xanh nước"
                },
                new()
                {
                    Name = "Xanh lá"
                },
                new()
                {
                    Name = "Cam"
                },
            };
            var colorAdd = new List<Color>();
            foreach (var item in colors)
            {
                if (!_dbContext.Colors.Any(s => s.Name == item.Name))
                {
                    colorAdd.Add(item);
                }
            }
            _dbContext.AddRange(colorAdd);
            _dbContext.SaveChanges();
            return colors;
        }

        private IList<Comment> AddComments(
            IList<Serie> series,
            IList<User> users)
        {
            var comments = new List<Comment>()
            {
                new()
                {
                    User = users[0],
                    Serie = series[0],
                    Detail = "Em rất thích sản phẩm này",
                    Rating = 5,
                    CommentDate = DateTime.Now,
                    Status = true,
                }
            };
            _dbContext.AddRange(comments);
            _dbContext.SaveChanges();
            return comments;
        }

        private IList<Image> AddImages(IList<Serie> series)
        {
            var images = new List<Image>()
            {
                new()
                {
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/p/iphone-15-pro-max_3.png",
                    Serie = series[0],
                },
                new()
                {
                    ImageUrl = "https://cdn2.cellphones.com.vn/x/media/catalog/product/v/n/vn_iphone_15_pro_black_titanium_pdp_image_position-1a_black_titanium_color.jpg",
                    Serie = series[0],
                },
                new()
                {
                    ImageUrl = "https://cdn2.cellphones.com.vn/x/media/catalog/product/v/n/vn_iphone_15_pro_blue_titanium_pdp_image_position-1a_blue_titanium_color.jpg",
                    Serie = series[0],
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
            IList<Status> statuses,
            IList<Discount> discounts)
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
                    PaymentMethod = paymentMethods[0],
                    Discount = discounts[0]
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
            IList<Sale> sales,
            IList<Serie> series)
        {
            var products = new List<Product>()
            {
                new()
                {
                    Name = "iPhone 15 Pro Max 256GB | Chính hãng VN/A",
                    ShortName = "256GB",
                    UrlSlug = "iphone-15-pro-max-256gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_iphone_15_pro_black_titanium_pdp_image_position-1a_black_titanium_color.jpg",
                    ShortDescription = "Thiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn",
                    Specification = "Kích thước màn hình: 6.7 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 20,
                    Category = categories[0],
                    Branch = branches[0],
                    Serie = series[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                    Sale = sales[1]
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 512GB | Chính hãng VN/A",
                    ShortName = "512GB",
                    UrlSlug = "iphone-15-pro-max-512gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_iphone_15_pro_black_titanium_pdp_image_position-1a_black_titanium_color.jpg",
                    ShortDescription = "Thiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn",
                    Specification = "Kích thước màn hình: 6.7 inches",
                    Amount = 30,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[0],
                    Branch = branches[0],
                    Serie = series[0],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    },
                },
                new()
                {
                    Name = "iPhone 15 Pro Max 1TB | Chính hãng VN/A",
                    ShortName = "1TB",
                    UrlSlug = "iphone-15-pro-max-1tb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_iphone_15_pro_black_titanium_pdp_image_position-1a_black_titanium_color.jpg",
                    ShortDescription = "Thiết kế khung viền từ titan chuẩn hàng không vũ trụ - Cực nhẹ, bền cùng viền cạnh mỏng cầm nắm thoải mái\r\nHiệu năng Pro chiến game thả ga - Chip A17 Pro mang lại hiệu năng đồ họa vô cùng sống động và chân thực\r\nThoả sức sáng tạo và quay phim chuyên nghiệp - Cụm 3 camera sau đến 48MP và nhiều chế độ tiên tiến\r\nNút tác vụ mới giúp nhanh chóng kích hoạt tính năng yêu thích của bạn",
                    Specification = "Kích thước màn hình: 6.7 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[0],
                    Branch = branches[0],
                    Serie = series[0],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                        colors[2],
                        colors[3],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy S24 Ultra 12GB 256GB",
                    ShortName = "12GB 256GB",
                    UrlSlug = "samsung-galaxy-s24-ultra-12gb-256gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/s/ss-s24-timultra-22_1.png",
                    ShortDescription = "Mở khoá giới hạn tiềm năng với AI - Hỗ trợ phiên dịch cuộc gọi, khoanh vùng tìm kiếm, Trợ lí Note và chình sửa anh\r\nTuyệt tác thiết kế bền bỉ và hoàn hảo - Vỏ ngoài bằng titan mới cùng màu sắc lấy cảm hứng từ chất liệu đá tự nhiên\r\nTích hợp S-Pen cực nhạy - Thoải mát viết, chạm thật chính xác trên màn hình cùng nhiều tính năng tiện ích\r\nNắm trong tay trọn bộ chi tiết chân thực nhất - Camera 200MP hỗ trợ khả năng xử lý AI cải thiện độ nét và tông màu",
                    Specification = "Kích thước màn hình 6.8 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 20,
                    Category = categories[1],
                    Branch = branches[0],
                    Serie = series[1],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    },
                    Sale = sales[1]
                },
                new()
                {
                    Name = "Samsung Galaxy S24 Ultra 12GB 512GB",
                    ShortName = "12GB 512GB",
                    UrlSlug = "samsung-galaxy-s24-ultra-12gb-512gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/s/ss-s24-timultra-22_1.png",
                    ShortDescription = "Mở khoá giới hạn tiềm năng với AI - Hỗ trợ phiên dịch cuộc gọi, khoanh vùng tìm kiếm, Trợ lí Note và chình sửa anh\r\nTuyệt tác thiết kế bền bỉ và hoàn hảo - Vỏ ngoài bằng titan mới cùng màu sắc lấy cảm hứng từ chất liệu đá tự nhiên\r\nTích hợp S-Pen cực nhạy - Thoải mát viết, chạm thật chính xác trên màn hình cùng nhiều tính năng tiện ích\r\nNắm trong tay trọn bộ chi tiết chân thực nhất - Camera 200MP hỗ trợ khả năng xử lý AI cải thiện độ nét và tông màu",
                    Specification = "Kích thước màn hình 6.8 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[0],
                    Branch = branches[1],
                    Serie = series[1],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy S24 Ultra 12GB 1TB",
                    ShortName = "12GB 1TB",
                    UrlSlug = "samsung-galaxy-s24-ultra-12gb-1tb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/s/ss-s24-timultra-22_1.png",
                    ShortDescription = "Mở khoá giới hạn tiềm năng với AI - Hỗ trợ phiên dịch cuộc gọi, khoanh vùng tìm kiếm, Trợ lí Note và chình sửa anh\r\nTuyệt tác thiết kế bền bỉ và hoàn hảo - Vỏ ngoài bằng titan mới cùng màu sắc lấy cảm hứng từ chất liệu đá tự nhiên\r\nTích hợp S-Pen cực nhạy - Thoải mát viết, chạm thật chính xác trên màn hình cùng nhiều tính năng tiện ích\r\nNắm trong tay trọn bộ chi tiết chân thực nhất - Camera 200MP hỗ trợ khả năng xử lý AI cải thiện độ nét và tông màu",
                    Specification = "Kích thước màn hình 6.8 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[0],
                    Branch = branches[1],
                    Serie = series[1],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    },
                    Sale = sales[1]
                },
                new()
                {
                    Name = "Macbook Pro 14 M3 Pro 18GB - 512GB | Chính hãng Apple Việt Nam",
                    ShortName = "18GB - 512GB",
                    UrlSlug = "macbook-pro-14-m3-pro-18gb-512gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_macbook_pro_14_in_m3_pro_max_silver_pdp_image_position-1.jpg",
                    ShortDescription = "Thiết kế sang trọng, thời thượng với mặt lưng nhôm cùng trọng lượng chỉ 1.55kg\r\nXử lý moi tác vụ với con chip M3 cùng 18 nhân GPU\r\nChất lượng hiển thị hàng đầu - màn hình 14.2 inch tấm nền retina\r\nBàn phím trang bị Touch ID cho phép mở khoá chỉ với 1 chạm\r\nTận hưởng chất lượng âm thanh chân thật với hệ thống 6 loa cùng công nghệ Dolby Atmos",
                    Specification = "Loại card đồ họa 14 nhân Neural Engine 16 nhân",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 20,
                    Category = categories[2],
                    Branch = branches[0],
                    Serie = series[2],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Macbook Pro 14 M3 Pro 18GB - 1TB | Chính hãng Apple Việt Nam",
                    ShortName = "18GB - 1TB",
                    UrlSlug = "macbook-pro-14-m3-pro-18gb-1tb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_macbook_pro_14_in_m3_pro_max_silver_pdp_image_position-1.jpg",
                    ShortDescription = "Thiết kế sang trọng, thời thượng với mặt lưng nhôm cùng trọng lượng chỉ 1.55kg\r\nXử lý moi tác vụ với con chip M3 cùng 18 nhân GPU\r\nChất lượng hiển thị hàng đầu - màn hình 14.2 inch tấm nền retina\r\nBàn phím trang bị Touch ID cho phép mở khoá chỉ với 1 chạm\r\nTận hưởng chất lượng âm thanh chân thật với hệ thống 6 loa cùng công nghệ Dolby Atmos",
                    Specification = "Loại card đồ họa 14 nhân Neural Engine 16 nhân",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 20,
                    Category = categories[2],
                    Branch = branches[0],
                    Serie = series[2],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    },
                    Sale = sales[1]
                },
                new()
                {
                    Name = "Macbook Pro 14 M3 Pro 36GB - 512GB | Chính hãng Apple Việt Nam",
                    ShortName = "36GB - 512GB",
                    UrlSlug = "macbook-pro-14-m3-pro-36gb-512gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_macbook_pro_14_in_m3_pro_max_silver_pdp_image_position-1.jpg",
                    ShortDescription = "Thiết kế sang trọng, thời thượng với mặt lưng nhôm cùng trọng lượng chỉ 1.55kg\r\nXử lý moi tác vụ với con chip M3 cùng 18 nhân GPU\r\nChất lượng hiển thị hàng đầu - màn hình 14.2 inch tấm nền retina\r\nBàn phím trang bị Touch ID cho phép mở khoá chỉ với 1 chạm\r\nTận hưởng chất lượng âm thanh chân thật với hệ thống 6 loa cùng công nghệ Dolby Atmos",
                    Specification = "Loại card đồ họa 14 nhân Neural Engine 16 nhân",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 20,
                    Category = categories[2],
                    Branch = branches[0],
                    Serie = series[2],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Laptop ASUS TUF Gaming F15 FX506HF-HN078W",
                    ShortName = "i5-11260H 16GB - 512GB RTX2050",
                    UrlSlug = "laptop-asus-tuf-gaming-f15-fx506hf-hn078w",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/e/text_ng_n_12__4_18.png",
                    ShortDescription = "CPU Intel Core i5 11260H đáp ứng tốt các tác vụ, mang lại trải nghiệm sử dụng tuyệt vời trong cả công việc lẫn giải trí, chiến game.\r\nCard đồ họa NVIDIA GeForce RTX 2050 đáp ứng tốt nhu cầu chơi game cấu hình cao và xử lý các file thiết kế nặng.\r\nRAM 16 GB cho bạn tận hưởng những giây phút chiến game đỉnh cao khi có thể mở nhiều ứng dụng cùng lúc.\r\nỔ cứng SSD 512 GB cho tốc độ khởi động nhanh chóng cùng khả năng tải ứng dụng mượt mà.\r\nMàn hình 15.6 inch Full HD và tần số quét 144 Hz mang lại hình ảnh sắc nét và mượt mà, cho trải nghiệm chơi game tuyệt vời,với tốc độ khung hình cao.",
                    Specification = "Loại card đồ họa NVIDIA GeForce RTX 2050 4GB GDDR6 Intel UHD Graphics",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[2],
                    Branch = branches[6],
                    Serie = series[3],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Laptop ASUS TUF GAMING F15 FX506HF-HN014W",
                    ShortName = "i5-11400H 8GB - 512GB RTX 2050",
                    UrlSlug = "laptop-asus-tuf-gaming-f15-fx506hf-hn014w",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/e/text_ng_n_12__4_18.png",
                    ShortDescription = "CPU Intel Core i5 11260H đáp ứng tốt các tác vụ, mang lại trải nghiệm sử dụng tuyệt vời trong cả công việc lẫn giải trí, chiến game.\r\nCard đồ họa NVIDIA GeForce RTX 2050 đáp ứng tốt nhu cầu chơi game cấu hình cao và xử lý các file thiết kế nặng.\r\nRAM 16 GB cho bạn tận hưởng những giây phút chiến game đỉnh cao khi có thể mở nhiều ứng dụng cùng lúc.\r\nỔ cứng SSD 512 GB cho tốc độ khởi động nhanh chóng cùng khả năng tải ứng dụng mượt mà.\r\nMàn hình 15.6 inch Full HD và tần số quét 144 Hz mang lại hình ảnh sắc nét và mượt mà, cho trải nghiệm chơi game tuyệt vời,với tốc độ khung hình cao.",
                    Specification = "Loại card đồ họa NVIDIA GeForce RTX 2050 4GB",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[2],
                    Branch = branches[6],
                    Serie = series[3],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Laptop ASUS TUF Gaming F15 FX507ZC4-HN099W",
                    ShortName = "I7-12700H 8GB - 512GB RTX3050",
                    UrlSlug = "laptop-asus-tuf-gaming-f15-fx507zc4-hn099w",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/e/text_ng_n_12__4_18.png",
                    ShortDescription = "Trang bị CPU Intel Core i7-12700H dễ dàng xử lý các tác vụ nặng, chơi game AAA ở mức cấu hình cao\r\nCard rời RTX 3050 cải thiện hiệu suất xử lý đồ họa, hỗ trợ chỉnh sửa video cũng như các tác vụ đồ họa phức tạp\r\nRAM 8 GB đảm bảo hiệu suất mượt mà ngay cả khi chạy nhiều ứng dụng\r\nỔ SSD dung lượng 512 GB rút ngắn thời gian khởi động máy và lưu trữ dữ liệu nhanh chóng\r\nMàn hình 15.6 inch Full HD và tốc độ làm mới 144 Hz đem lại trải nghiệm mượt mà và sống động",
                    Specification = "Loại card đồ họa NVIDIA GeForce RTX 3050 4GB GDDR6 Intel Iris Xe Graphics",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[2],
                    Branch = branches[6],
                    Serie = series[3],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    },
                    Sale = sales[1]
                },
                new()
                {
                    Name = "iPad Pro 11 inch 2022 M2 Wifi 128GB | Chính hãng Apple Việt Nam",
                    ShortName = "WIFI 128GB",
                    UrlSlug = "ipad-pro-11-inch-2022-m2-wifi-128gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/p/ipad-pro-13-select-wifi-silver-202210-01.jpg",
                    ShortDescription = "Thiết kế phẳng mạnh mẽ - Gia công từ kim loại bền bỉ, phong cách hiện đại, sang trọng\r\nHiệu năng mạnh mẽ với CPU thế hệ mới - chip Apple M2 trong đó có 8 lõi cùng RAM 8 GB\r\nMàn hình sáng hơn, hỗ trợ nội dung HDR tốt hơn - 11 inch LCD, 120hz\r\nThoải mái sáng tạo và thiết kế - Nhận diện bút Apple Pencil 2 siêu nhanh và nhạy",
                    Specification = "Kích thước màn hình 11 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[0],
                    Serie = series[4],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "iPad Pro 11 inch 2022 M2 Wifi 256GB | Chính hãng Apple Việt Nam",
                    ShortName = "WIFI 256GB",
                    UrlSlug = "ipad-pro-11-inch-2022-m2-wifi-256gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/p/ipad-pro-13-select-wifi-silver-202210-01.jpg",
                    ShortDescription = "Thiết kế phẳng mạnh mẽ - Gia công từ kim loại bền bỉ, phong cách hiện đại, sang trọng\r\nHiệu năng mạnh mẽ với CPU thế hệ mới - chip Apple M2 trong đó có 8 lõi cùng RAM 8 GB\r\nMàn hình sáng hơn, hỗ trợ nội dung HDR tốt hơn - 11 inch LCD, 120hz\r\nThoải mái sáng tạo và thiết kế - Nhận diện bút Apple Pencil 2 siêu nhanh và nhạy",
                    Specification = "Kích thước màn hình 11 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[0],
                    Serie = series[4],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "iPad Pro 11 inch 2022 M2 Wifi 512GB | Chính hãng Apple Việt Nam",
                    ShortName = "WIFI 512GB",
                    UrlSlug = "ipad-pro-11-inch-2022-m2-wifi-512gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/p/ipad-pro-13-select-wifi-silver-202210-01.jpg",
                    ShortDescription = "Thiết kế phẳng mạnh mẽ - Gia công từ kim loại bền bỉ, phong cách hiện đại, sang trọng\r\nHiệu năng mạnh mẽ với CPU thế hệ mới - chip Apple M2 trong đó có 8 lõi cùng RAM 8 GB\r\nMàn hình sáng hơn, hỗ trợ nội dung HDR tốt hơn - 11 inch LCD, 120hz\r\nThoải mái sáng tạo và thiết kế - Nhận diện bút Apple Pencil 2 siêu nhanh và nhạy",
                    Specification = "Kích thước màn hình 11 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[0],
                    Serie = series[4],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Tab S9 FE 5G 6GB 128GB",
                    ShortName = "Tab S9 FE 5G 128GB",
                    UrlSlug = "samsung-galaxy-tab-s9-fe-5g-6gb-128gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-galaxy-tab-s9-fe-mint-13_1.jpg",
                    ShortDescription = "Sở hữu chipset Exynos cho khả năng xử lý đa nhiệm các tác vụ mượt mà hơn.\r\nMàn hình rộng 10.9 inch với độ phân giải 2K+ và hỗ trợ HDR10+ - Chất lượng hình ảnh sắc nét và chân thực.\r\nThiết kế nhỏ gọn, vuông vức và rất hợp thời trang và sang trọng.\r\nKết hợp với bút S - Pen siêu tiện lợi - Giúp người dùng tăng cường năng suất làm việc.",
                    Specification = "Kích thước màn hình 10.9 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[1],
                    Serie = series[5],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Tab S9 FE Plus WIFI 8GB 128GB",
                    ShortName = "Tab S9 FE Plus WIFI 8GB 128GB",
                    UrlSlug = "tab-s9-fe-plus-wifi-8gb-128gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-galaxy-tab-s9-fe-mint-13_1.jpg",
                    ShortDescription = "Sở hữu chipset Exynos cho khả năng xử lý đa nhiệm các tác vụ mượt mà hơn.\r\nMàn hình rộng 10.9 inch với độ phân giải 2K+ và hỗ trợ HDR10+ - Chất lượng hình ảnh sắc nét và chân thực.\r\nThiết kế nhỏ gọn, vuông vức và rất hợp thời trang và sang trọng.\r\nKết hợp với bút S - Pen siêu tiện lợi - Giúp người dùng tăng cường năng suất làm việc.",
                    Specification = "Kích thước màn hình 10.9 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[1],
                    Serie = series[5],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Tab S9 FE Plus WIFI 12GB 256GB",
                    ShortName = "Tab S9 FE Plus Wifi 12GB 256GB",
                    UrlSlug = "samsung-galaxy-tab-s9-fe-plus-wifi-12gb-256gb",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-galaxy-tab-s9-fe-mint-13_1.jpg",
                    ShortDescription = "Sở hữu chipset Exynos cho khả năng xử lý đa nhiệm các tác vụ mượt mà hơn.\r\nMàn hình rộng 10.9 inch với độ phân giải 2K+ và hỗ trợ HDR10+ - Chất lượng hình ảnh sắc nét và chân thực.\r\nThiết kế nhỏ gọn, vuông vức và rất hợp thời trang và sang trọng.\r\nKết hợp với bút S - Pen siêu tiện lợi - Giúp người dùng tăng cường năng suất làm việc.",
                    Specification = "Kích thước màn hình 10.9 inches",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[1],
                    Branch = branches[1],
                    Serie = series[5],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Tai nghe Bluetooth Apple AirPods Pro 2 2023 USB-C",
                    ShortName = "USB-C",
                    UrlSlug = "tai-nghe-bluetooth-apple-airpods-pro-2-2023-usb-c",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/a/p/apple-airpods-pro-2-usb-c_8_.png",
                    ShortDescription = "Tích hợp chip Apple H2 mang đến chất âm sống động cùng khả năng tái tạo âm thanh 3 chiều vượt trội\r\nCông nghệ Bluetooth 5.3 kết nối ổn định, mượt mà, tiêu thụ năng lượng thấp, giúp tiết kiệm pin đáng kể\r\nChống ồn chủ động loại bỏ tiếng ồn hiệu quả gấp đôi thế hệ trước, giúp nâng cao trải nghiệm nghe nhạc\r\nChống nước chuẩn IP54 trên tai nghe và hộp sạc, giúp bạn thỏa sức tập luyện không cần lo thấm mồ hôi",
                    Specification = "Thời lượng pin Tai nghe: Dùng 6 giờ Hộp sạc: Dùng 30 giờ",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[3],
                    Branch = branches[0],
                    Serie = series[6],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Tai nghe Bluetooth Apple AirPods Pro 2022",
                    ShortName = "Lightning",
                    UrlSlug = "tai-nghe-bluetooth-apple-airpods-pro-2-2022",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/a/p/apple-airpods-pro-2-usb-c_8_.png",
                    ShortDescription = "Tích hợp chip Apple H2 mang đến chất âm sống động cùng khả năng tái tạo âm thanh 3 chiều vượt trội\r\nCông nghệ Bluetooth 5.3 kết nối ổn định, mượt mà, tiêu thụ năng lượng thấp, giúp tiết kiệm pin đáng kể\r\nChống ồn chủ động loại bỏ tiếng ồn hiệu quả gấp đôi thế hệ trước, giúp nâng cao trải nghiệm nghe nhạc\r\nChống nước chuẩn IP54 trên tai nghe và hộp sạc, giúp bạn thỏa sức tập luyện không cần lo thấm mồ hôi",
                    Specification = "Thời lượng pin Tai nghe: Dùng 6 giờ Hộp sạc: Dùng 30 giờ",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[3],
                    Branch = branches[0],
                    Serie = series[6],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Tai nghe Bluetooth True Wireless JBL Wave Beam",
                    ShortName = "Wave Beam",
                    UrlSlug = "tai-nghe-bluetooth-true-wireless-jbl-wave-beam",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-khong-day-jbl-wave-beam_4_.png",
                    ShortDescription = "Công nghệ JBL Deep Bass Sound và driver 8mm cho chất âm vượt trội\r\nTổng thời lượng nghe lên đến 32 giờ cho trải nghiệm không lo gián đoạn\r\nKháng nước chuẩn IPX2 cho hộp sạc và kháng nước IP54 cho tai nghe\b\r\nĐiều khiển qua ứng dụng JBL Headphones App giúp bạn thao tác dễ dàng",
                    Specification = "Thời lượng pin Tai nghe: 8 giờ Hộp sạc: 24 giờ",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[3],
                    Branch = branches[27],
                    Serie = series[7],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Tai nghe Bluetooth True Wireless JBL Tune Flex",
                    ShortName = "Tune Flex",
                    UrlSlug = "tai-nghe-bluetooth-true-wireless-jbl-tune-flex",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-khong-day-jbl-wave-beam_4_.png",
                    ShortDescription = "Công nghệ JBL Deep Bass Sound và driver 8mm cho chất âm vượt trội\r\nTổng thời lượng nghe lên đến 32 giờ cho trải nghiệm không lo gián đoạn\r\nKháng nước chuẩn IPX2 cho hộp sạc và kháng nước IP54 cho tai nghe\b\r\nĐiều khiển qua ứng dụng JBL Headphones App giúp bạn thao tác dễ dàng",
                    Specification = "Thời lượng pin Tai nghe: 8 giờ Hộp sạc: 24 giờ",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[3],
                    Branch = branches[27],
                    Serie = series[7],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Tai nghe Bluetooth True Wireless JBL Tune Beam",
                    ShortName = "Tune Beam",
                    UrlSlug = "tai-nghe-bluetooth-true-wireless-jbl-tune-beam",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-khong-day-jbl-wave-beam_4_.png",
                    ShortDescription = "Công nghệ JBL Deep Bass Sound và driver 8mm cho chất âm vượt trội\r\nTổng thời lượng nghe lên đến 32 giờ cho trải nghiệm không lo gián đoạn\r\nKháng nước chuẩn IPX2 cho hộp sạc và kháng nước IP54 cho tai nghe\b\r\nĐiều khiển qua ứng dụng JBL Headphones App giúp bạn thao tác dễ dàng",
                    Specification = "Thời lượng pin Tai nghe: 8 giờ Hộp sạc: 24 giờ",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[3],
                    Branch = branches[27],
                    Serie = series[7],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Apple Watch Series 9 45mm (GPS) viền nhôm dây cao su",
                    ShortName = "45mm",
                    UrlSlug = "apple-watch-series-9-45mm",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_apple_watch_series_9_gps_41mm_pink_aluminum_light_pink_sport_band_pdp_image_position-1_1_2.jpg",
                    ShortDescription = "Trang bị chip S9 SiP mạnh mẽ hỗ trợ xử lý mọi tác vụ nhanh chóng với nhiều tiện ích\r\nDễ dàng kết nối, nghe gọi, trả lời tin nhắn ngay trên cổ tay\r\nTrang bị nhiều tính năng sức khỏe như: Đo nhịp tim, điện tâm đồ, đo chu kỳ kinh nguyệt,...\r\nĐộ sáng tối đa lên tới 2000 nit, dễ xem màn hình ngay dưới ánh nắng gắt\r\nTích hợp nhiều chế độ tập luyện với các môn thể thao như: Bơi lội, chạy bộ, đạp xe,...",
                    Specification = "Công nghệ màn hình Retina",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[0],
                    Serie = series[8],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Apple Watch Series 9 41mm (GPS) viền nhôm dây vải | Chính hãng Apple Việt Nam",
                    ShortName = "41mm dây vải",
                    UrlSlug = "apple-watch-series-9-41mm-gps-vien-nhom-day-vai",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_apple_watch_series_9_gps_41mm_pink_aluminum_light_pink_sport_band_pdp_image_position-1_1_2.jpg",
                    ShortDescription = "Trang bị chip S9 SiP mạnh mẽ hỗ trợ xử lý mọi tác vụ nhanh chóng với nhiều tiện ích\r\nDễ dàng kết nối, nghe gọi, trả lời tin nhắn ngay trên cổ tay\r\nTrang bị nhiều tính năng sức khỏe như: Đo nhịp tim, điện tâm đồ, đo chu kỳ kinh nguyệt,...\r\nĐộ sáng tối đa lên tới 2000 nit, dễ xem màn hình ngay dưới ánh nắng gắt\r\nTích hợp nhiều chế độ tập luyện với các môn thể thao như: Bơi lội, chạy bộ, đạp xe,...",
                    Specification = "Công nghệ màn hình Retina",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[0],
                    Serie = series[8],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Apple Watch Series 9 41mm (GPS) viền nhôm dây cao su | Chính hãng Apple Việt Nam",
                    ShortName = "41mm dây cao su",
                    UrlSlug = "apple-watch-series-9-41mm-gps-vien-nhom-day-cao-su",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/v/n/vn_apple_watch_series_9_gps_41mm_pink_aluminum_light_pink_sport_band_pdp_image_position-1_1_2.jpg",
                    ShortDescription = "Trang bị chip S9 SiP mạnh mẽ hỗ trợ xử lý mọi tác vụ nhanh chóng với nhiều tiện ích\r\nDễ dàng kết nối, nghe gọi, trả lời tin nhắn ngay trên cổ tay\r\nTrang bị nhiều tính năng sức khỏe như: Đo nhịp tim, điện tâm đồ, đo chu kỳ kinh nguyệt,...\r\nĐộ sáng tối đa lên tới 2000 nit, dễ xem màn hình ngay dưới ánh nắng gắt\r\nTích hợp nhiều chế độ tập luyện với các môn thể thao như: Bơi lội, chạy bộ, đạp xe,...",
                    Specification = "Công nghệ màn hình Retina",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[0],
                    Serie = series[8],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Watch6 40mm Bluetooth",
                    ShortName = "Watch6 40mm Bluetooth",
                    UrlSlug = "samsung-galaxy-watch6-40mm-bluetooth",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/m/sm-r930_002_front2_graphite_1.png",
                    ShortDescription = "Tính năng theo dõi giấc ngủ giúp bạn có thể phân tích và hiểu rõ hơn về thói quen ngủ của mình\r\nĐột phá công nghệ theo dõi sức khoẻ với khả năng phân tích thành phần cơ thể, đo huyết áp\r\nCảm biến hiện đại với khả năng đo và cảnh báo nhịp tim bất thường\r\nThiết kế hoàn hảo với viền benzel siêu mỏng, kích thước màn hình tăng 20%",
                    Specification = "Công nghệ màn hình Super Amoled",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[1],
                    Serie = series[9],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Watch6 Classic 43mm Bluetooth",
                    ShortName = "Classic 43mm Bluetooth",
                    UrlSlug = "samsung-galaxy-watch6-classic-43mm-bluetooth",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/m/sm-r930_002_front2_graphite_1.png",
                    ShortDescription = "Tính năng theo dõi giấc ngủ giúp bạn có thể phân tích và hiểu rõ hơn về thói quen ngủ của mình\r\nĐột phá công nghệ theo dõi sức khoẻ với khả năng phân tích thành phần cơ thể, đo huyết áp\r\nCảm biến hiện đại với khả năng đo và cảnh báo nhịp tim bất thường\r\nThiết kế hoàn hảo với viền benzel siêu mỏng, kích thước màn hình tăng 20%",
                    Specification = "Công nghệ màn hình Super Amoled",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[1],
                    Serie = series[9],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Samsung Galaxy Watch6 Classic 47mm Bluetooth",
                    ShortName = "Classic 47mm Bluetooth",
                    UrlSlug = "samsung-galaxy-watch6-classic-47mm-bluetooth",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/m/sm-r930_002_front2_graphite_1.png",
                    ShortDescription = "Tính năng theo dõi giấc ngủ giúp bạn có thể phân tích và hiểu rõ hơn về thói quen ngủ của mình\r\nĐột phá công nghệ theo dõi sức khoẻ với khả năng phân tích thành phần cơ thể, đo huyết áp\r\nCảm biến hiện đại với khả năng đo và cảnh báo nhịp tim bất thường\r\nThiết kế hoàn hảo với viền benzel siêu mỏng, kích thước màn hình tăng 20%",
                    Specification = "Công nghệ màn hình Super Amoled",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[4],
                    Branch = branches[1],
                    Serie = series[9],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Camera GoPro Hero 11",
                    ShortName = "Gopro Hero 11",
                    UrlSlug = "camera-gopro-hero-11",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/c/a/camera-hanh-trinh-gopro-hero-11_3_.png",
                    ShortDescription = "Camera độ phân giải đến 27MP cho những bức ảnh mượt mà, tuyệt đẹp với màu sắc sống động\r\nHệ thống chống rung hình ảnh Hyper Smooth 5.0 cho chất lượng ảnh và video mượt mà, ổn định\r\nChống nước độ sâu lên đến 10m, thích hợp để quay dưới nước hoặc trong điều kiện thời tiết xấu\r\nTrang bị màn hình LCD kép giúp thuận tiện hơn trong việc theo dõi và căn chỉnh sao cho phù hợp",
                    Specification = "Dòng camera Camera hành động",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[5],
                    Branch = branches[41],
                    Serie = series[10],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Camera GoPro Hero 11 Creator Edition",
                    ShortName = "GoPro Hero 11 Creator Edition",
                    UrlSlug = "camera-gopro-hero-11-creator-edition",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/c/a/camera-hanh-trinh-gopro-hero-11_3_.png",
                    ShortDescription = "Camera độ phân giải đến 27MP cho những bức ảnh mượt mà, tuyệt đẹp với màu sắc sống động\r\nHệ thống chống rung hình ảnh Hyper Smooth 5.0 cho chất lượng ảnh và video mượt mà, ổn định\r\nChống nước độ sâu lên đến 10m, thích hợp để quay dưới nước hoặc trong điều kiện thời tiết xấu\r\nTrang bị màn hình LCD kép giúp thuận tiện hơn trong việc theo dõi và căn chỉnh sao cho phù hợp",
                    Specification = "Dòng camera Camera hành động",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[5],
                    Branch = branches[41],
                    Serie = series[10],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Camera GoPro Hero 11 Mini",
                    ShortName = "Gopro Hero 11 Mini",
                    UrlSlug = "camera-gopro-hero-11-mini",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/c/a/camera-hanh-trinh-gopro-hero-11_3_.png",
                    ShortDescription = "Camera độ phân giải đến 27MP cho những bức ảnh mượt mà, tuyệt đẹp với màu sắc sống động\r\nHệ thống chống rung hình ảnh Hyper Smooth 5.0 cho chất lượng ảnh và video mượt mà, ổn định\r\nChống nước độ sâu lên đến 10m, thích hợp để quay dưới nước hoặc trong điều kiện thời tiết xấu\r\nTrang bị màn hình LCD kép giúp thuận tiện hơn trong việc theo dõi và căn chỉnh sao cho phù hợp",
                    Specification = "Dòng camera Camera hành động",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[5],
                    Branch = branches[41],
                    Serie = series[10],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Camera Xiaomi MI Home Security C200 (BHR6766GL)",
                    ShortName = "Home Security C200",
                    UrlSlug = "camera-xiaomi-mi-home-security-c200-bhr6766gl",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/m/image_277.png",
                    ShortDescription = "Quan sát bao quát tốt với góc quay 360 độ theo chiều ngang và 106 độ theo chiều dọc\r\nCung cấp hình ảnh quan sát sắc nét với độ phân giải Full HD (1080P)\r\nĐèn hồng ngoại 940mm cho tầm nhìn lên tới 9m\r\nHỗ trợ đàm thoại 2 chiều để trò chuyện qua camera tiện lợi\r\nQuản lý hoạt động qua ứng dụng Mi Home",
                    Specification = "Độ phân giải 1920×1080 Full HD",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[5],
                    Branch = branches[2],
                    Serie = series[11],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Dịch vụ AppleCare+ cho iPad Pro 12.9 icnh 2020",
                    ShortName = "AppleCare+ cho iPad Pro",
                    UrlSlug = "dich-vu-applecare-cho-ipad-pro-129-icnh-2020",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/a/p/apple-care_1_1_1_1_1_2_1_1_1_1_1_1_1_1_1_1_2_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1_1.jpeg",
                    ShortDescription = "Chỉ áp dụng cho máy đã được kích hoạt trong vòng 7 ngày\r\nThêm 1 năm bảo hành chính hãng (tổng 2 năm)\r\nBảo hành rơi vỡ, rớt nước không giới hạn\r\nBảo hành phần cứng tất cả các lỗi NSX\r\nBảo hành cả phụ kiện đi kèm máy\r\nƯu tiên hỗ trợ kỹ thuật qua tổng đài 24/7",
                    Specification = "Hãng sản xuất Apple Chính hãng",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[6],
                    Branch = branches[0],
                    Serie = series[12],
                    Sale = sales[0],
                },
                new()
                {
                    Name = "Gói 2 năm Samsung Care+ điện thoại Samsung Galaxy A14",
                    ShortName = "Samsung Care+ Samsung Galaxy A14",
                    UrlSlug = "samsung-care-djien-thoai-samsung-galaxy-a14",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/s/a/samsung-care-heart-mobile_4_1_2_1_1_1_1_1_1_1_1_1_1_2.png",
                    ShortDescription = "Được bán kèm trong vòng 55 ngày kể từ ngày mua thiết bị\r\nGia hạn thêm 2 năm bảo hành chính hãng cho điện thoại Galaxy A14\r\nBảo vệ rơi vỡ, vào nước với dịch vụ và linh kiện hoàn toàn chính hãng\r\nNhận thiết bị hoàn toàn khi chi phí sửa chữa lớn hơn hoặc bằng 85%\r\nBảo vệ lên đến 55 ngày tại các trung tâm chăm sóc khách hàng Samsung Care+ toàn cầu",
                    Specification = "Hãng sản xuất Samsung Chính hãng",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[6],
                    Branch = branches[1],
                    Serie = series[13],
                    Sale = sales[0],
                },
                new()
                {
                    Name = "CPU Intel Core i5 12400F",
                    ShortName = "i5 12400F",
                    UrlSlug = "cpu-intel-core-i5-12400f",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/c/p/cpu-intel-core-i5-12400f.jpg",
                    ShortDescription = "CPU Intel Core i5 12400F là một trong những dòng chip Intel được tích hợp một hiệu năng mạnh mẽ cùng với bộ nhớ đệm lớn góp phần đáp ứng đầy đủ các tác vụ nặng, các tác vụ quan trọng cho người dùng",
                    Specification = "Chipset Intel",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[7],
                    Branch = branches[50],
                    Serie = series[14],
                    Sale = sales[0],
                },
                new()
                {
                    Name = "Mainboard ASRock B450M HDV R4",
                    ShortName = "ASRock B450M",
                    UrlSlug = "mainboard-asrock-b450m-hdv-r4",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/b/4/b450m-hdv_r4.0m1.png",
                    ShortDescription = "Tốc độ truyền nhanh chóng",
                    Specification = "Chipset AMD",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[7],
                    Branch = branches[51],
                    Serie = series[15],
                    Sale = sales[0],
                },
                new()
                {
                    Name = "Màn hình Gaming ASUS TUF VG246H1A 24 inch",
                    ShortName = "ASUS TUF VG246H1A",
                    UrlSlug = "man-hinh-gaming-asus-tuf-vg246h1a-24-inch",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/m/a/man-hinh-asus-tuf-gaming-vg246h1a-24-inch-1.png",
                    ShortDescription = "Trang bị tấm nền IPS với kích thước 24 inch FHD cho góc nhìn rộng\r\nPhản xạ cực nhanh trước đối thủ khi chơi game với tốc độ chỉ 0.5ms\r\nĐộ phủ màu sRGB 110% tái hiện chính xác màu sắc của mọi nội dung\r\nTần số 100Hz + AMD FreeSync cho hình ảnh chuyển động liền mạch",
                    Specification = "Tần số quét 100 Hz",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[8],
                    Branch = branches[6],
                    Serie = series[16],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Màn hình Samsung LU28R550UQEXXV 28 inch",
                    ShortName = "Samsung 28 inch",
                    UrlSlug = "man-hinh-samsung-lu28r550uqexxv-28-inch",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/m/a/man-hinh-samsung-28-inch-lu28r550uqexxv-7_2.jpg",
                    ShortDescription = "Tận hưởng từng chi tiết khung hình với chất lượng 4K Ultra HD ấn tượng\r\nTấm nền IPS siêu việt giúp tái hiện hình ảnh rõ ràng với sắc màu sống động\r\nCông nghệ HDR ưu việt giúp hình ảnh trở nên rõ ràng, sắc nét đến từng chi tiết phức tạp nhất\r\nTính năng hạn chế tối đa phát xạ ánh sáng xanh dễ gây ra tình trạng mỏi mắt\r\nCông nghệ AMD FreeSync chuyển động mượt mà sắc nét, nâng tầm giải trí\r\nThiết kế 3 cạnh không viền thời thượng mở rộng tối đa không gian",
                    Specification = "Tần số quét 60 Hz",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[8],
                    Branch = branches[1],
                    Serie = series[17],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Smart Tivi Samsung Crystal UHD 4K 50 inch UA50AU7700KXXV",
                    ShortName = "50 inch",
                    UrlSlug = "smart-tivi-samsung-crystal-uhd-4k-50-inch-ua50au7700kxxv",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/4/0/40_1_31.jpg",
                    ShortDescription = "Khung hình rực rỡ, ấn tượng với dải màu rộng từ công nghệ PurColor\r\nTăng cường tương phản, hình ảnh sâu thẳm chân thực nhờ công nghệ HDR10+ và Contrast Enhancer\r\nHình ảnh chuyển động mượt mà với công nghệ Motion Xcelerator\r\nÂm thanh bùng nổ cùng Dolby Digital Plus, lan tỏa mạnh mẽ qua công nghệ Q-Symphony",
                    Specification = "Kích cỡ màn hình 50 inch",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[9],
                    Branch = branches[1],
                    Serie = series[18],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
                },
                new()
                {
                    Name = "Smart Tivi Khung Tranh The Frame 4K Samsung LTV 55 inch 55LS03BA",
                    ShortName = "55 inch",
                    UrlSlug = "smart-tivi-khung-tranh-the-frame-4k-samsung-ltv-55-inch-55ls03ba",
                    Rating = 5,
                    ImageUrl = "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/4/0/40_1_31.jpg",
                    ShortDescription = "Khả năng hiển thị màu sắc và ánh sáng được tối ưu, truyền tải trọn vẹn hình ảnh với công nghệ Quantum Dot\r\nThiết kế sáng tạo đem lại cảm giác trải nghiệm khác biệt, hướng đến nghệ thuật\r\nÂm thanh được tinh chỉnh nhờ công nghệ Adaptive Sound phù hợp với nội dung giải trí\r\nTích hợp trợ lý ảo Google Tiếng Việt, Bixby và Tìm kiếm bằng giọng nói Tiếng Việt trên YouTube",
                    Specification = "Kích cỡ màn hình 55 inch",
                    Amount = 50,
                    SalePrice = 30129000,
                    Price = 31390000,
                    OrPrice = 34990000,
                    SoldQuantity = 10,
                    Category = categories[9],
                    Branch = branches[1],
                    Serie = series[19],
                    Sale = sales[0],
                    Colors = new List<Color>()
                    {
                        colors[0],
                        colors[1],
                    }
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
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/h552xhgmarwowoylwmpn.png"
                },
                new()
                {
                    Name = "Samsung",
                    UrlSlug = "samsung",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/xhrn4zcm49dqxpgkqk42.png"
                },
                new()
                {
                    Name = "Xiaomi",
                    UrlSlug = "xiaomi",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/dyigjjljbvkxmlmhfhgy.png"
                },
                new()
                {
                    Name = "OPPO",
                    UrlSlug = "oppo",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/bmonqugwogag8j89esed.png"
                },
                new()
                {
                    Name = "Realme",
                    UrlSlug = "realme",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/phnmofzwzsjum9gfnbpr.png"
                },
                new()
                {
                    Name = "Vivo",
                    UrlSlug = "vivo",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/cfd4wshchptdz9pv18go.png"
                },
                new()
                {
                    Name = "ASUS",
                    UrlSlug = "asus",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/gzknywqicnf9nxelly0r.png"
                },
                new()
                {
                    Name = "Infinix",
                    UrlSlug = "infinix",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/xijwifreht6s2kh87qou.png"
                },
                new()
                {
                    Name = "Nokia",
                    UrlSlug = "nokia",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/n1zxkugiak3zfkbvgkoc.png"
                },
                new()
                {
                    Name = "TECNO",
                    UrlSlug = "tecno",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845929/Branch/vafwkxd6lpehlpa4yz06.png"
                },
                new()
                {
                    Name = "Nubia",
                    UrlSlug = "nubia",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/htlnflcyvxpqdsni2xhg.png"
                },
                new()
                {
                    Name = "OnePlus",
                    UrlSlug = "one-plus",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/djd7lhqukrgedymms5fm.png"
                },
                new()
                {
                    Name = "Benco",
                    UrlSlug = "benco",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/zbegaqeyuzmvbiftuds8.png"
                },
                new()
                {
                    Name = "Masstel",
                    UrlSlug = "masstel",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/o0xvskdflh42gaicgnzu.png"
                },
                new()
                {
                    Name = "Itel",
                    UrlSlug = "itel",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/wwazmqb4zq5cfuqv8yha.png"
                },
                new()
                {
                    Name = "INOI",
                    UrlSlug = "inoi",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/zvdtolzgndgqir4uf2wk.jpg"
                },
                new()
                {
                    Name = "SONY",
                    UrlSlug = "sony",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/ymkopwvmavuzygqdv1d3.png"
                },
                new()
                {
                    Name = "Lenovo",
                    UrlSlug = "lenovo",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/fly70zug098bfdxlmmbl.png"
                },
                new()
                {
                    Name = "Dell",
                    UrlSlug = "dell",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/kygfzet23j24mgnt05th.png"
                },
                new()
                {
                    Name = "HP",
                    UrlSlug = "hp",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845928/Branch/etekdgcrb4jvqdoydiub.png"
                },
                new()
                {
                    Name = "Acer",
                    UrlSlug = "acer",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/bxlrllr1fldmht3x9aka.png"
                },
                new()
                {
                    Name = "LG",
                    UrlSlug = "lg",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/qdvmqfrcmkgesxrmk3yi.png"
                },
                new()
                {
                    Name = "Huawei",
                    UrlSlug = "huawei",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/myaarbgemk4ji66ydvj0.png"
                },
                new()
                {
                    Name = "MSI",
                    UrlSlug = "msi",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/ifpcsibqziiiejihyj4l.png"
                },
                 new()
                {
                    Name = "Gigabyte",
                    UrlSlug = "gigabyte",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/vmgsdppejukxlyxszco8.png"
                },
                new()
                {
                    Name = "Vaio",
                    UrlSlug = "vaio",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/fw9ebjfzvrihjilyxooy.png"
                },
                new()
                {
                    Name = "Microsoft Surface",
                    UrlSlug = "microsoft-surface",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/dbmog8id18rfwb0tb4oj.png"
                },
                new()
                {
                    Name = "JBL",
                    UrlSlug = "jbl",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/ufpgidlnora1k615mgak.png"
                },
                new()
                {
                    Name = "Marshall",
                    UrlSlug = "marshall",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845927/Branch/dbkpmltytzfvt23jlilr.png"
                },
                new()
                {
                    Name = "Soundpeats",
                    UrlSlug = "soundpeats",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/ucrjdfqwlk6kqwhtre0h.png"
                },
                 new()
                {
                    Name = "Sennheiser",
                    UrlSlug = "sennheiser",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/u97pl1fjmngl933zyo1u.png"
                },
                new()
                {
                    Name = "Soul",
                    UrlSlug = "soul",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/wrb3n9cf4acxyeocvjwx.png"
                },
                new()
                {
                    Name = "Havit",
                    UrlSlug = "havit",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/fp7ulqzzhez8ywkhzq5f.png"
                },
                new()
                {
                    Name = "Edifier",
                    UrlSlug = "edifier",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/ouhwxvlherzhewro5tek.png"
                },
                new()
                {
                    Name = "Coros",
                    UrlSlug = "coros",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/ngyvmzzkiccbllkhxl5n.png"
                },
                new()
                {
                    Name = "Garmin",
                    UrlSlug = "garmin",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/ln92pbrmpsqnbqrjeidv.png"
                },
                new()
                {
                    Name = "Kieslect",
                    UrlSlug = "kieslect",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/kcfg7mufrmmqamxyvtxv.png"
                },
                new()
                {
                    Name = "Amazlfit",
                    UrlSlug = "amazlfit",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/tnzkrlpoci8c83h35xou.png"
                },
                new()
                {
                    Name = "Imou",
                    UrlSlug = "imou",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845926/Branch/r5lxyyp0bpidkynp7zqf.png"
                },
                new()
                {
                    Name = "Ezviz",
                    UrlSlug = "ezviz",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/hq5xi6kwv283kytwanfd.png"
                },
                new()
                {
                    Name = "TP-Link",
                    UrlSlug = "tp-link",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/jundccyz1hjs9gcd6g9q.png"
                },
                new()
                {
                    Name = "Gopro",
                    UrlSlug = "go-pro",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/inkk8ltynpdoiej2obzj.png"
                },
                new()
                {
                    Name = "DJI",
                    UrlSlug = "dji",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/vgxtq4avvrmsfdf0gx63.png"
                },
                new()
                {
                    Name = "Insta360",
                    UrlSlug = "insta-360",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/cagql0fwbgeim9rolmay.png"
                },
                 new()
                {
                    Name = "Canon",
                    UrlSlug = "canon",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845931/Branch/bou1yjrco356leodzivv.png"
                },
                new()
                {
                    Name = "Fujifilm",
                    UrlSlug = "fujifilm",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/snpus2xcgtmfd0uwflnh.png"
                },
                new()
                {
                    Name = "PlayStation",
                    UrlSlug = "play-station",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845924/Branch/hxil5n0w5pqnmo3dkzp1.png"
                },
                new()
                {
                    Name = "ViewSonic",
                    UrlSlug = "view-sonic",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845924/Branch/cjuar0o06xsmid1aa4ty.png"
                },
                new()
                {
                    Name = "Philips",
                    UrlSlug = "philips",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/noqtjqhmap78p9lqtxi4.png"
                },
                 new()
                {
                    Name = "AOC",
                    UrlSlug = "aoc",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845924/Branch/vt9ng5rdv17iv1c4izrq.png"
                },
                new()
                {
                    Name = "Intel",
                    UrlSlug = "intel",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845925/Branch/ny1ypwfzjxa3hyjemz0e.png"
                },
                 new()
                {
                    Name = "AMD",
                    UrlSlug = "amd",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845924/Branch/tubikg6bh8hgyhirvibj.png"
                },
                new()
                {
                    Name = "NVIDIA",
                    UrlSlug = "nvidia",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845931/Branch/cd4yjtq93dpr1w68jvzr.png"
                },
                 new()
                {
                    Name = "Coocaa",
                    UrlSlug = "coocaa",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/dcxbhckz7h4awolp2h25.png"
                },
                new()
                {
                    Name = "Toshiba",
                    UrlSlug = "toshiba",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845931/Branch/vkc6q3ujljolukde0cdn.png"
                },
                 new()
                {
                    Name = "TCL",
                    UrlSlug = "tcl",
                    ImageUrl = "https://res.cloudinary.com/dbq0kdjln/image/upload/v1713845930/Branch/cz01z2f7lxzgz4prgsbb.png"
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

        private IList<Discount> AddDiscounts()
        {
            var discounts = new List<Discount>()
            {
                new()
                {
                    CodeName = "Fki0umx3Dpg5eqR",
                    DiscountPercent = 10,
                    StartDate = DateTime.Now,
                    EndDate = (DateTime.Now).AddDays(7),
                    Status = true,
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
            for (int i = 0; i < orders.Count; i++)
            {
                foreach (var item in products)
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

        private IList<Serie> AddSeries()
        {
            var series = new List<Serie>()
            {
                new()
                {
                    Name = "Iphone 15 Series",
                    UrlSlug = "iphone-15-series",
                    Description = "iPhone 15 Pro Max thiết kế mới với chất liệu titan chuẩn hàng không vũ trụ bền bỉ, trọng lượng nhẹ, đồng thời trang bị nút Action và cổng sạc USB-C tiêu chuẩn giúp nâng cao tốc độ sạc. Khả năng chụp ảnh đỉnh cao của iPhone 15 bản Pro Max đến từ camera chính 48MP, camera UltraWide 12MP và camera telephoto có khả năng zoom quang học đến 5x. Bên cạnh đó, iPhone 15 ProMax sử dụng chip A17 Pro mới mạnh mẽ. Xem thêm chi tiết những điểm nổi bật của sản phẩm qua thông tin sau!",
                },
                new()
                {
                    Name = "Galaxy S24 Series",
                    UrlSlug = "galaxy-s24-series",
                    Description = "Samsung S24 Ultra là siêu phẩm smartphone đỉnh cao mở đầu năm 2024 đến từ nhà Samsung với chip Snapdragon 8 Gen 3 For Galaxy mạnh mẽ, công nghệ tương lai Galaxy AI cùng khung viền Titan đẳng cấp hứa hẹn sẽ mang tới nhiều sự thay đổi lớn về mặt thiết kế và cấu hình. SS Galaxy S24 bản Ultra sở hữu màn hình 6.8 inch Dynamic AMOLED 2X tần số quét 120Hz. Máy cũng sở hữu camera chính 200MP, camera zoom quang học 50MP, camera tele 10MP và camera góc siêu rộng 12MP.",
                },
                new()
                {
                    Name = "Macbook Pro 2023",
                    UrlSlug = "macbook-pro-2023",
                    Description = "Macbook Pro 14 inch M3 Pro 2023 18GB/512GB có độ phân giải 3.024 x 1.964 pixels, độ sáng lên tới 1.600 nits, hỗ trợ tần số quét 120Hz xử lý hình ảnh cực mượt. Đặc biệt, sản phẩm Macbook Pro M3 năm 2023 trang bị con chip Apple M3 Pro, đi kèm với 18GB RAM và 512GB bộ nhớ trong. ",
                },
                new()
                {
                    Name = "ASUS Gaming",
                    UrlSlug = "asus-gaming",
                    Description = "Laptop Asus Tuf Gaming F15 FX506HF-HN078W với thiết kế năng động, mang vẻ đẹp thu hút với CPU core intel i5, GPU GeForce RTX™ 2050 và RAM 8 GB. Kết hợp là màn hiển thị FHD IPS 144Hz cực kỳ rõ nét. Ngoài ra laptop Asus Gaming cũng có thêm hệ thống âm thanh đỉnh cao nhờ vào công nghệ tiên tiến để phục vụ tối đa người dùng.",
                },
                new()
                {
                    Name = "Ipad Pro",
                    UrlSlug = "ipad-pro",
                    Description = "So sánh iPad Pro 2022 và iPad Pro 2021\r\nRa mắt với nhiều cải tiến và hiệu năng mạnh mẽ, iPad Pro 2022 mang đến nhiều trải nghiệm thú vị cho người dùng. Vậy sản phẩm này có gì khác so với thế hệ trước. Xem bảng so sánh chi tiết sau đây nhé!",
                },
                new()
                {
                    Name = "Tab S9 Series",
                    UrlSlug = "tab-s9-series",
                    Description = "Máy tính bảng Samsung Galaxy Tab S9 FE được trang bị màn hình 10.9 inch với tấm nền LCD cùng tần số quét 90Hz giúp mang lại trải nghiệm hiển thị sống động. Máy được trang bị chuẩn kháng nước và bụi bẩn IP68 cùng với dung lượng pin tới 8000 mAh. Cấu hình máy với chipset Exynos 1380 cùng RAM 6GB mang lại trải nghiệm dùng ổn định.",
                },
                new()
                {
                    Name = "Airpod",
                    UrlSlug = "airpod",
                    Description = "Airpods Pro 2 Type-C với công nghệ khử tiếng ồn chủ động mang lại khả năng khử ồn lên gấp 2 lần mang lại trải nghiệm nghe - gọi và trải nghiệm âm nhạc ấn tượng. Cùng với đó, điện thoại còn được trang bị công nghệ âm thanh không gian giúp trải nghiệm âm nhạc thêm phần sống động. Airpods Pro 2 Type-C với cổng sạc Type C tiện lợi cùng viên pin mang lại thời gian trải nghiệm lên đến 6 giờ tiện lợi.",
                },
                new()
                {
                    Name = "JBL",
                    UrlSlug = "jbl",
                    Description = "Tai nghe JBL Wave Beam được trang bị trình điều kiển 8mm mang lại âm thanh vượt trội với âm bass sâu kết hợp với thiết kế đóng kín giúp tăng cường hiệu suất âm thanh. Tai nghe được trang bị thiết kế khá vừa vặn cùng với đó là bộ sưu tập màu sắc đa dạng như xanh, đen, trắng và vàng. JBL Wave Beam với công nghệ Smart Ambient cho phép người dùng dễ dàng dễ dàng nghe được âm thanh xung quanh, cùng với đó là tính năng TalkThru hỗ trợ tạm dừng âm nhạc nhanh chóng để tham gia các cuộc trò chuyện với bạn bè.",
                },
                new()
                {
                    Name = "Apple Watch Series 9",
                    UrlSlug = "apple-watch-series-9",
                    Description = "Đồng hồ Apple Watch Series 9 45mm sở hữu on chip S9 SiP - CPU với 5,6 tỷ bóng bán dẫn giúp mang lại hiệu năng cải thiện hơn 60% so với thế hệ S8. Màn hình thiết bị với kích thước 45mm cùng độ sáng tối đa lên 2000 nit mang lại trải nghiệm hiển thị vượt trội. Cùng với đó, đồng hồ Apple Watch s9 này còn được trang bị nhiều tính năng hỗ trợ theo dõi sức khỏe và tập luyện thông minh.",
                },
                new()
                {
                    Name = "Galaxy Watch 6",
                    UrlSlug = "galaxy-watch-6",
                    Description = "Đồng hồ Samsung Galaxy Watch 6 trang bị màn hình Sapphire cứng cáp, bền bỉ với khả năng chống nước đạt chuẩn IP68 và 5ATM, giúp người dùng thoải mái sử dụng trong nhiều môi trường khác nhau. Bên cạnh đó, dung lượng pin 300mAh cùng khả năng sạc nhanh có thể nạp đến 45% trong vòng 30 phút, cho thời gian sử dụng lên đến nhiều giờ liền.",
                },
                new()
                {
                    Name = "GoPro",
                    UrlSlug = "gopro",
                    Description = "Camera hành trình Gopro Hero 11 là siêu phẩm tiếp theo của Gopro đạt chất lượng hình ảnh cao chuyên biệt dành cho các tín đồ du lịch. Sản phẩm còn là người bạn đồng hành dành cho các phượt thủ không thể thiếu đó là một chiếc máy ảnh hành trình.",
                },
                new()
                {
                    Name = "Xiaomi",
                    UrlSlug = "xiaomi",
                    Description = "Camera Xiaomi Mi Home Security C200 (BHR6766GL) hỗ trợ giám sát tối ưu với hình ảnh sắc nét và góc nhìn rộng. Chiếc camera an ninh Xiaomi sẽ là người bạn đồng hành tuyệt vời giúp không gian nhà và văn phòng của bạn được đảm bảo an toàn tối đa. Nhờ tích hợp công nghệ tiên tiến, sản phẩm cũng giúp bạn tiết kiệm băng thông kết nối và bộ nhớ hiệu quả.",
                },
                new()
                {
                    Name = "Apple Care",
                    UrlSlug = "apple-care",
                    Description = "Dịch vụ AppleCare+ cho iPad Pro 12.9 icnh 2020 – Gia tăng thời gian bảo hành iPad chính hãng",
                },
                new()
                {
                    Name = "Samsung Care",
                    UrlSlug = "samsung-care",
                    Description = "Gói 2 năm Samsung Care + cho điện thoại Samsung Galaxy A14 với tổng giá trị bằng 200% giá trị thiết bị trong vòng 2 năm bao gồm cả bị rơi vỡ, vào nước. Hơn thế, cách thức đăng ký Samsung Care Plus dễ dàng, bảo vệ toàn cầu, nhận và giao hàng miễn phí giúp bạn thoải mái hơn trong quá trình sử dụng.",
                },
                new()
                {
                    Name = "CPU",
                    UrlSlug = "cpu",
                    Description = "Bộ vi xử lý Intel Core i5 12400F khi mới ra mắt trên thị trường đã được người dùng săn lùng thông tin khắp nơi. Từ đó sản phẩm được rất nhiều khách hàng, đặt biệt là các game thủ tin dùng, bởi thế được coi như đối thủ nặng ký của nhiều thiết bị cùng chức năng khác.",
                },
                new()
                {
                    Name = "Main",
                    UrlSlug = "main",
                    Description = "Mainboard Asrock B450M HDV R4 là bo mạch chủ đáng để bạn bỏ tiền ra trang bị cho bộ PC của mình. Sở hữu những ưu điểm tuyệt vời về đường truyền cũng như vẻ ngoài, sản phẩm mainboard Asrock sẽ giúp cho bạn có trải nghiệm hài lòng nhất. ",
                },
                new()
                {
                    Name = "Asus",
                    UrlSlug = "asus",
                    Description = "Màn hình gaming Asus TUF VG246H1A 24 inch là mẫu màn hình được sản xuất dành riêng cho các game thủ. Sản phẩm màn hình Asus này được bị tốc độ làm mới tới 100 hz cùng với nhiều công nghệ tối ưu cho các trải nghiệm gaming.",
                },
                new()
                {
                    Name = "Samsung",
                    UrlSlug = "samsung",
                    Description = "Màn hình Samsung LU28R550UQEXXV 28 inch siêu mỏng ấn tượng, sở hữu hình ảnh UHD rõ nét sống động. Nếu bạn đang có nhu cầu thay thế hoặc mua thêm cho mình một chiếc màn hình để đáp ứng nhu cầu công việc, học tập thì chắc chắn không thể bỏ qua sản phẩm này.",
                },
                new()
                {
                    Name = "50 inch",
                    UrlSlug = "50-inch",
                    Description = "Smart tivi Samsung Crystal UHD 4K 50 inch UA50AU7700KXXV được đánh giá cao bởi thiết kế hiện đại, tính năng nổi bật và hình ảnh ấn tượng. Xem ngay thông tin chi tiết tivi Samsung dưới đây!",
                },
                new()
                {
                    Name = "55 inch",
                    UrlSlug = "55-inch",
                    Description = "Tivi Khung Samsung 55LS03B là dòng sản phẩm có lối thiết kế mới, độc đáo. Hãy cùng CellphoneS tìm hiểu thêm về mẫu tivi thông minh Samsung mới này trong bài viết dưới đây nhé!",
                },
            };
            var serieAdd = new List<Serie>();
            foreach (var item in series)
            {
                if (!_dbContext.Series.Any(s => s.UrlSlug == item.UrlSlug))
                {
                    serieAdd.Add(item);
                }
            }
            _dbContext.AddRange(serieAdd);
            _dbContext.SaveChanges();
            return series;
        }

        private IList<Sale> AddSales()
        {
            var sales = new List<Sale>()
            {
                new()
                {
                    EndDate = new DateTime(2024, 4, 24),
                    Status = false,
                },
                new()
                {
                    EndDate = new DateTime(2024, 5, 11),
                    Status = true,
                },
            };
            var saleAdd = new List<Sale>();
            foreach (var item in sales)
            {
                if (!_dbContext.Sales.Any(s => s.EndDate == item.EndDate))
                {
                    saleAdd.Add(item);
                }
            }
            _dbContext.AddRange(saleAdd);
            _dbContext.SaveChanges();
            return sales;
        }
    }
}

