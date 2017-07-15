namespace Shop.Data.Migrations
{
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shop.Data.ShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Shop.Data.ShopDbContext context)
        {
            CreateProductCategorySample(context);
            CreateSlide(context);
            CreatePage(context);
            CreateContactDetail(context);

            CreateConfigTitle(context);
            CreateFooter(context);
            CreateUser(context);
            CreateSize(context);
            CreateColor(context);
            CreateFunction(context);
        }

        private void CreateFunction(ShopDbContext context)
        {
            if (context.Functions.Count() == 0)
            {
                context.Functions.AddRange(new List<Function>()
                {
                    new Function() {ID = "SYSTEM", Name = "Hệ thống",ParentId = null,DisplayOrder = 1,Status = true,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {ID = "ROLE", Name = "Nhóm",ParentId = "SYSTEM",DisplayOrder = 1,Status = true,URL = "/main/role/index",IconCss = "fa-home"  },
                    new Function() {ID = "FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",DisplayOrder = 2,Status = true,URL = "/main/function/index",IconCss = "fa-home"  },
                    new Function() {ID = "USER", Name = "Người dùng",ParentId = "SYSTEM",DisplayOrder =3,Status = true,URL = "/main/user/index",IconCss = "fa-home"  },
                    new Function() {ID = "ACTIVITY", Name = "Nhật ký",ParentId = "SYSTEM",DisplayOrder = 4,Status = true,URL = "/main/activity/index",IconCss = "fa-home"  },
                    new Function() {ID = "ERROR", Name = "Lỗi",ParentId = "SYSTEM",DisplayOrder = 5,Status = true,URL = "/main/error/index",IconCss = "fa-home"  },
                    new Function() {ID = "SETTING", Name = "Cấu hình",ParentId = "SYSTEM",DisplayOrder = 6,Status = true,URL = "/main/setting/index",IconCss = "fa-home"  },

                    new Function() {ID = "PRODUCT",Name = "Sản phẩm",ParentId = null,DisplayOrder = 2,Status = true,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "PRODUCT_CATEGORY",Name = "Danh mục",ParentId = "PRODUCT",DisplayOrder =1,Status = true,URL = "/main/product-category/index",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "PRODUCT_LIST",Name = "Sản phẩm",ParentId = "PRODUCT",DisplayOrder = 2,Status = true,URL = "/main/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {ID = "ORDER",Name = "Hóa đơn",ParentId = "PRODUCT",DisplayOrder = 3,Status = true,URL = "/main/order/index",IconCss = "fa-chevron-down"  },

                    new Function() {ID = "CONTENT",Name = "Nội dung",ParentId = null,DisplayOrder = 3,Status = true,URL = "/",IconCss = "fa-table"  },
                    new Function() {ID = "POST_CATEGORY",Name = "Danh mục",ParentId = "CONTENT",DisplayOrder = 1,Status = true,URL = "/main/post-category/index",IconCss = "fa-table"  },
                    new Function() {ID = "POST",Name = "Bài viết",ParentId = "CONTENT",DisplayOrder = 2,Status = true,URL = "/main/post/index",IconCss = "fa-table"  },

                    new Function() {ID = "UTILITY",Name = "Tiện ích",ParentId = null,DisplayOrder = 4,Status = true,URL = "/",IconCss = "fa-clone"  },
                    new Function() {ID = "FOOTER",Name = "Footer",ParentId = "UTILITY",DisplayOrder = 1,Status = true,URL = "/main/footer/index",IconCss = "fa-clone"  },
                    new Function() {ID = "FEEDBACK",Name = "Phản hồi",ParentId = "UTILITY",DisplayOrder = 2,Status = true,URL = "/main/feedback/index",IconCss = "fa-clone"  },
                    new Function() {ID = "ANNOUNCEMENT",Name = "Thông báo",ParentId = "UTILITY",DisplayOrder = 3,Status = true,URL = "/main/announcement/index",IconCss = "fa-clone"  },
                    new Function() {ID = "CONTACT",Name = "Liên hệ",ParentId = "UTILITY",DisplayOrder = 4,Status = true,URL = "/main/contact/index",IconCss = "fa-clone"  },

                    new Function() {ID = "REPORT",Name = "Báo cáo",ParentId = null,DisplayOrder = 5,Status = true,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "REVENUES",Name = "Báo cáo doanh thu",ParentId = "REPORT",DisplayOrder = 1,Status = true,URL = "/main/report/revenue/index",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "ACCESS",Name = "Báo cáo truy cập",ParentId = "REPORT",DisplayOrder = 2,Status = true,URL = "/main/report/visitor/index",IconCss = "fa-bar-chart-o"  },
                    new Function() {ID = "READER",Name = "Báo cáo độc giả",ParentId = "REPORT",DisplayOrder = 3,Status = true,URL = "/main/report/reader/index",IconCss = "fa-bar-chart-o"  },

                });
                context.SaveChanges();
            }
        }

        private void CreateConfigTitle(ShopDbContext context)
        {
            if (!context.SystemConfigs.Any(x => x.Code == "HomeTitle"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeTitle",
                    ValueString = "Trang chủ Shop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaKeyword"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaKeyword",
                    ValueString = "Trang chủ Shop",
                });
            }
            if (!context.SystemConfigs.Any(x => x.Code == "HomeMetaDescription"))
            {
                context.SystemConfigs.Add(new SystemConfig()
                {
                    Code = "HomeMetaDescription",
                    ValueString = "Trang chủ Shop",
                });
            }
        }

        private void CreateUser(ShopDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new ShopDbContext()));
            if (manager.Users.Count() == 0)
            {
                var roleManager = new RoleManager<AppRole>(new RoleStore<AppRole>(new ShopDbContext()));

                var user = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin@shop.com.vn",
                    EmailConfirmed = true,
                    BirthDay = DateTime.Now,
                    FullName = "Lý Văn Mão",
                    Avatar = "/assets/images/img.jpg",
                    Gender = true,
                    Status = true
                };
                if (manager.Users.Count(x => x.UserName == "admin") == 0)
                {
                    manager.Create(user, "123456");

                    if (!roleManager.Roles.Any())
                    {
                        roleManager.Create(new AppRole { Name = "Admin", Description = "Quản trị viên" });
                        roleManager.Create(new AppRole { Name = "Member", Description = "Người dùng" });
                    }

                    var adminUser = manager.FindByName("admin");

                    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "Member" });
                }
            }
        }

        private void CreateProductCategorySample(Shop.Data.ShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Áo nam",Alias="ao-nam",Status=true },
                    new ProductCategory() { Name="Áo nữ",Alias="ao-nu",Status=true },
                    new ProductCategory() { Name="Giày nam",Alias="giay-nam",Status=true },
                    new ProductCategory() { Name="Giày nữ",Alias="giay-nu",Status=true }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }
        private void CreateSize(Shop.Data.ShopDbContext context)
        {
            if (context.Sizes.Count() == 0)
            {
                List<Size> listSize = new List<Size>()
                {
                    new Size() { Name="XXL" },
                    new Size() { Name="XL"},
                    new Size() { Name="L" },
                    new Size() { Name="M" },
                    new Size() { Name="S" },
                    new Size() { Name="XS" }
                };
                context.Sizes.AddRange(listSize);
                context.SaveChanges();
            }
        }

        private void CreateColor(Shop.Data.ShopDbContext context)
        {
            if (context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color() {Name="Đen", Code="#000000" },
                    new Color() {Name="Trắng", Code="#FFFFFF"},
                    new Color() {Name="Đỏ", Code="#ff0000" },
                    new Color() {Name="Xanh", Code="#1000ff" },
                };
                context.Colors.AddRange(listColor);
                context.SaveChanges();
            }
        }
        private void CreateFooter(ShopDbContext context)
        {
            if (context.Footers.Count(x => x.ID == CommonConstants.DefaultFooterId) == 0)
            {
                string content = "Footer";
                context.Footers.Add(new Footer()
                {
                    ID = CommonConstants.DefaultFooterId,
                    Content = content
                });
                context.SaveChanges();
            }
        }

        private void CreateSlide(ShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        DisplayOrder =1,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag.jpg",
                        Content =@"	<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur
                            adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >
                        <span class=""on-get"">GET NOW</span>" },
                    new Slide() {
                        Name ="Slide 2",
                        DisplayOrder =2,
                        Status =true,
                        Url ="#",
                        Image ="/Assets/client/images/bag1.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>

                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </ p >

                                <span class=""on-get"">GET NOW</span>"},
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePage(ShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                try
                {
                    var page = new Page()
                    {
                        Name = "Giới thiệu",
                        Alias = "gioi-thieu",
                        Content = @"Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium ",
                        Status = true
                    };
                    context.Pages.Add(page);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }

        private void CreateContactDetail(ShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                try
                {
                    var contactDetail = new Shop.Model.Models.ContactDetail()
                    {
                        Name = "Shop thời trang",
                        Address = "22 Lê Hồng Phong, Ngô Quyền, Hải Phòng",
                        Email = "shop@gmail.com",
                        Lat = 20.846046,
                        Lng = 106.708185,
                        Phone = "0313675867",
                        Website = "http://shop.com.vn",
                        Other = "",
                        Status = true
                    };
                    context.ContactDetails.Add(contactDetail);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation error.");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                }
            }
        }
    }
}
