using ShopSphere.Models;

namespace ShopSphere.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Products.Any()) return;
            var db = context.Database;
            var rng = new Random(99);
            var list = new List<Product>();

            double R() => Math.Round(3.2 + rng.NextDouble() * 1.8, 1);
            int S() => rng.Next(8, 300);

            void Add(string cat, string name, decimal price, decimal orig, string img, string seller)
                => list.Add(new Product
                {
                    Category = cat,
                    Name = name,
                    Description = $"{name} — Premium quality. Best in class performance and reliability. Genuine product with full warranty.",
                    Price = price,
                    OriginalPrice = orig,
                    ImageUrl = img,
                    SellerName = seller,
                    IsApproved = true,
                    Stock = S(),
                    Rating = R()
                });

            string m1 = "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=400";
            string m2 = "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=400";
            Add("Mobiles", "Apple iPhone 15 Pro Max 256GB", 380000, 430000, m1, "Apple Pakistan");
            Add("Mobiles", "Apple iPhone 15 Pro 128GB", 320000, 360000, m2, "Apple Pakistan");
            Add("Mobiles", "Apple iPhone 15 128GB", 275000, 310000, m1, "Apple Pakistan");
            Add("Mobiles", "Apple iPhone 14 Pro 256GB", 250000, 290000, m2, "Apple Pakistan");
            Add("Mobiles", "Apple iPhone 13 128GB", 190000, 220000, m1, "Apple Pakistan");
            Add("Mobiles", "Samsung Galaxy S24 Ultra 512GB", 295000, 340000, m2, "Samsung Official");
            Add("Mobiles", "Samsung Galaxy S24+ 256GB", 220000, 260000, m1, "Samsung Official");
            Add("Mobiles", "Samsung Galaxy A54 5G 128GB", 85000, 99000, m2, "Samsung Official");
            Add("Mobiles", "Samsung Galaxy A34 128GB", 65000, 78000, m1, "Samsung Official");
            Add("Mobiles", "OnePlus 12 5G 256GB", 175000, 200000, m2, "OnePlus Pakistan");
            Add("Mobiles", "OnePlus Nord CE3 128GB", 75000, 90000, m1, "OnePlus Pakistan");
            Add("Mobiles", "Oppo Reno 11 Pro 256GB", 120000, 145000, m2, "Oppo Official");
            Add("Mobiles", "Xiaomi 14 Pro 512GB", 160000, 185000, m1, "Xiaomi Pakistan");
            Add("Mobiles", "Xiaomi Redmi Note 13 Pro 256GB", 72000, 88000, m2, "Xiaomi Pakistan");
            Add("Mobiles", "Realme GT Neo 5 256GB", 95000, 115000, m1, "Realme Pakistan");
            Add("Mobiles", "Tecno Camon 20 Pro 256GB", 55000, 68000, m2, "Tecno Official");
            Add("Mobiles", "Infinix Hot 40 Pro 256GB", 38000, 48000, m1, "Infinix Pakistan");
            Add("Mobiles", "Nokia G42 5G 128GB", 42000, 52000, m2, "Nokia Pakistan");
            Add("Mobiles", "Motorola Edge 40 Pro 256GB", 110000, 135000, m1, "Motorola Pakistan");
            Add("Mobiles", "Vivo V30 Pro 256GB", 98000, 120000, m2, "Vivo Pakistan");

            string e1 = "https://images.unsplash.com/photo-1606229365485-93a3b8ee0385?w=400";
            string e2 = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400";
            Add("Electronics", "Sony WH-1000XM5 Headphones", 55000, 68000, e1, "Sony Pakistan");
            Add("Electronics", "Sony WH-1000XM4 Headphones", 42000, 55000, e2, "Sony Pakistan");
            Add("Electronics", "JBL Flip 6 Bluetooth Speaker", 22000, 28000, e1, "JBL Official");
            Add("Electronics", "JBL Charge 5 Portable Speaker", 35000, 44000, e2, "JBL Official");
            Add("Electronics", "Canon EOS R50 Mirrorless Camera", 120000, 145000, e1, "Canon Pakistan");
            Add("Electronics", "Sony Alpha A7 III Camera Kit", 285000, 330000, e2, "Sony Pakistan");
            Add("Electronics", "LG 27UK850 4K Monitor 27 inch", 85000, 102000, e1, "LG Pakistan");
            Add("Electronics", "Samsung 32 inch Smart Monitor M8", 72000, 88000, e2, "Samsung Official");
            Add("Electronics", "Anker 65W GaN Fast Charger", 8000, 11000, e1, "Anker Pakistan");
            Add("Electronics", "Samsung Galaxy Tab S9 FE 128GB", 75000, 92000, e2, "Samsung Official");
            Add("Electronics", "Apple iPad Air 5th Gen 64GB", 145000, 168000, e1, "Apple Pakistan");
            Add("Electronics", "Bose QuietComfort 45 Headphones", 62000, 78000, e2, "Bose Pakistan");
            Add("Electronics", "DJI Mini 3 Pro Drone Fly More Combo", 185000, 220000, e1, "DJI Pakistan");
            Add("Electronics", "GoPro Hero 12 Black", 95000, 115000, e2, "GoPro Pakistan");
            Add("Electronics", "Logitech MX Keys Mini Keyboard", 18000, 23000, e1, "Logitech Pakistan");
            Add("Electronics", "Samsung T7 Shield 1TB SSD", 25000, 31000, e2, "Samsung Official");
            Add("Electronics", "TP-Link AX3000 WiFi 6 Router", 18000, 24000, e1, "TP-Link Pakistan");
            Add("Electronics", "Xiaomi Smart Band 8 Pro", 12000, 16000, e2, "Xiaomi Pakistan");
            Add("Electronics", "Anker PowerCore 20000mAh Bank", 9500, 13000, e1, "Anker Pakistan");
            Add("Electronics", "Amazon Echo Dot 5th Gen", 8500, 11000, e2, "Amazon Pakistan");

            string l1 = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=400";
            string l2 = "https://images.unsplash.com/photo-1544731612-de7f96afe55f?w=400";
            Add("Laptops", "Apple MacBook Air M3 13 inch", 340000, 390000, l1, "Apple Pakistan");
            Add("Laptops", "Apple MacBook Pro M3 14 inch", 480000, 550000, l2, "Apple Pakistan");
            Add("Laptops", "Dell XPS 15 Core i7 RTX 4060", 380000, 440000, l1, "Dell Pakistan");
            Add("Laptops", "Dell Inspiron 15 Core i5 12th Gen", 145000, 175000, l2, "Dell Pakistan");
            Add("Laptops", "HP Spectre x360 14 Core i7", 320000, 375000, l1, "HP Pakistan");
            Add("Laptops", "HP Pavilion Gaming i5 RTX 3050", 185000, 220000, l2, "HP Pakistan");
            Add("Laptops", "HP Victus 15 Core i5 RTX 3050", 175000, 210000, l1, "HP Pakistan");
            Add("Laptops", "Lenovo ThinkPad X1 Carbon Gen 11", 420000, 495000, l2, "Lenovo Pakistan");
            Add("Laptops", "Lenovo IdeaPad Gaming 3 RTX 3060", 215000, 255000, l1, "Lenovo Pakistan");
            Add("Laptops", "ASUS ROG Strix G15 RTX 4070 Ti", 380000, 445000, l2, "ASUS Pakistan");
            Add("Laptops", "ASUS ZenBook 14 OLED Core i7", 220000, 265000, l1, "ASUS Pakistan");
            Add("Laptops", "Acer Nitro 5 RTX 4060 Core i7", 235000, 280000, l2, "Acer Pakistan");
            Add("Laptops", "Acer Aspire 5 Core i5 12th Gen", 125000, 152000, l1, "Acer Pakistan");
            Add("Laptops", "MSI Katana 15 RTX 4060 Core i7", 265000, 315000, l2, "MSI Pakistan");
            Add("Laptops", "Microsoft Surface Pro 9 Core i5", 295000, 345000, l1, "Microsoft Pakistan");

            string f1 = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=400";
            string f2 = "https://images.unsplash.com/photo-1523398002811-999ca8dec234?w=400";
            Add("Fashion", "Nike Air Max 270 React White", 18000, 24000, f1, "Sports Zone PK");
            Add("Fashion", "Nike Air Force 1 Low White", 15000, 20000, f2, "Sports Zone PK");
            Add("Fashion", "Nike React Infinity Run FK 3", 20000, 26000, f1, "Nike Pakistan");
            Add("Fashion", "Adidas Ultraboost 22 Running Shoe", 22000, 29000, f2, "Adidas Official");
            Add("Fashion", "Adidas Stan Smith OG White", 14000, 19000, f1, "Adidas Official");
            Add("Fashion", "Adidas NMD R1 Primeknit", 18500, 24000, f2, "Adidas Official");
            Add("Fashion", "Puma RS-X3 Puzzle Sneakers", 16000, 21000, f1, "Puma Pakistan");
            Add("Fashion", "New Balance 574 Classic Grey", 19000, 25000, f2, "New Balance PK");
            Add("Fashion", "Converse Chuck Taylor All Star OX", 12000, 16000, f1, "Converse PK");
            Add("Fashion", "Vans Old Skool Classic Black", 11000, 15000, f2, "Vans Pakistan");
            Add("Fashion", "Timberland 6 Inch Premium Boot Wheat", 28000, 36000, f1, "Timberland PK");
            Add("Fashion", "Skechers Go Walk 7 Slip-On", 9500, 13000, f2, "Skechers PK");
            Add("Fashion", "Under Armour HOVR Phantom 3", 20000, 26000, f1, "UA Pakistan");
            Add("Fashion", "Reebok Club C 85 Vintage White", 13000, 18000, f2, "Reebok PK");
            Add("Fashion", "New Balance 990v6 Made in USA", 55000, 68000, f1, "New Balance PK");

            string cl1 = "https://images.unsplash.com/photo-1490481651871-ab68de25d43d?w=400";
            string cl2 = "https://images.unsplash.com/photo-1584917865442-de89df76afd3?w=400";
            Add("Clothing", "Levi's 501 Original Fit Jeans", 8500, 12000, cl1, "Levi's PK");
            Add("Clothing", "Tommy Hilfiger Classic Hoodie Navy", 12000, 17000, cl2, "Tommy PK");
            Add("Clothing", "Ralph Lauren Classic Polo Shirt", 7500, 11000, cl1, "Polo Official");
            Add("Clothing", "Calvin Klein Slim Fit Chinos", 7000, 10500, cl2, "CK Pakistan");
            Add("Clothing", "Zara Premium Cotton T-Shirt", 4500, 6500, cl1, "Zara Pakistan");
            Add("Clothing", "Zara Slim Fit Blazer Charcoal", 18000, 26000, cl2, "Zara Pakistan");
            Add("Clothing", "H&M Basic Crew Neck Sweatshirt", 5500, 8000, cl1, "H&M Pakistan");
            Add("Clothing", "Nike Dri-Fit Training T-Shirt", 5500, 8000, cl2, "Nike Pakistan");
            Add("Clothing", "Adidas Essentials Track Suit", 9500, 14000, cl1, "Adidas Official");
            Add("Clothing", "North Face Nuptse 700 Down Jacket", 55000, 72000, cl2, "North Face PK");
            Add("Clothing", "Stone Island Reflective Jacket", 45000, 62000, cl1, "Stone Island PK");
            Add("Clothing", "Uniqlo Heat Tech Inner Shirt", 3500, 5500, cl2, "Uniqlo PK");
            Add("Clothing", "Lee Cooper Cargo Pants", 6500, 9500, cl1, "Lee Cooper PK");
            Add("Clothing", "Lacoste Classic Polo L.12.12", 9500, 14000, cl2, "Lacoste PK");
            Add("Clothing", "Gucci Oversize T-Shirt", 35000, 48000, cl1, "Gucci Pakistan");

            string a1 = "https://images.unsplash.com/photo-1606229365485-93a3b8ee0385?w=400";
            string a2 = "https://images.unsplash.com/photo-1511467687858-23d96c32e4ae?w=400";
            Add("Accessories", "Apple AirPods Pro 2nd Gen USB-C", 35000, 43000, a1, "Apple Pakistan");
            Add("Accessories", "Apple AirPods 3rd Gen Lightning", 22000, 29000, a2, "Apple Pakistan");
            Add("Accessories", "Samsung Galaxy Buds2 Pro", 28000, 36000, a1, "Samsung Official");
            Add("Accessories", "Sony WF-1000XM5 Earbuds", 42000, 52000, a2, "Sony Pakistan");
            Add("Accessories", "JBL Tune 760NC Headphones", 15000, 20000, a1, "JBL Official");
            Add("Accessories", "Logitech G502 X Plus Gaming Mouse", 9500, 13000, a2, "Logitech PK");
            Add("Accessories", "Razer DeathAdder V3 HyperSpeed", 12000, 16000, a1, "Razer Pakistan");
            Add("Accessories", "Corsair K95 RGB Platinum Keyboard", 25000, 33000, a2, "Corsair PK");
            Add("Accessories", "iPhone 15 Pro Magsafe Silicone Case", 4500, 7000, a1, "Apple Pakistan");
            Add("Accessories", "Samsung S24 Ultra S-Pen Leather Case", 4000, 6000, a2, "Samsung Official");
            Add("Accessories", "Anker 543 USB-C Hub 7-in-1", 8500, 12000, a1, "Anker Pakistan");
            Add("Accessories", "Belkin MagSafe 2-in-1 Charger", 8000, 11000, a2, "Belkin PK");
            Add("Accessories", "Peak Design Everyday Backpack 20L", 28000, 38000, a1, "Peak Design PK");
            Add("Accessories", "Spigen Tempered Glass Screen Guard", 2500, 4000, a2, "Spigen PK");
            Add("Accessories", "Ugreen 100W USB-C Braided Cable 2m", 3500, 5500, a1, "Ugreen PK");

            string w1 = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=400";
            string w2 = "https://images.unsplash.com/photo-1434493789847-2f02dc6ca35d?w=400";
            Add("Watches", "Apple Watch Series 9 GPS 45mm", 78000, 95000, w1, "Apple Pakistan");
            Add("Watches", "Apple Watch Ultra 2 GPS 49mm", 125000, 150000, w2, "Apple Pakistan");
            Add("Watches", "Apple Watch SE 2nd Gen 40mm", 52000, 65000, w1, "Apple Pakistan");
            Add("Watches", "Samsung Galaxy Watch 6 Classic 47mm", 62000, 78000, w2, "Samsung Official");
            Add("Watches", "Samsung Galaxy Watch 6 44mm", 48000, 60000, w1, "Samsung Official");
            Add("Watches", "Garmin Fenix 7X Pro Solar Sapphire", 155000, 185000, w2, "Garmin Pakistan");
            Add("Watches", "Garmin Forerunner 955 Solar", 98000, 120000, w1, "Garmin Pakistan");
            Add("Watches", "Fossil Gen 6 Smartwatch 44mm", 42000, 55000, w2, "Fossil Pakistan");
            Add("Watches", "Casio G-Shock DW-5600 Classic Black", 18000, 24000, w1, "Casio Pakistan");
            Add("Watches", "Casio Edifice EFR-573 Chronograph", 22000, 30000, w2, "Casio Pakistan");
            Add("Watches", "Seiko Presage Automatic SRPD37", 28000, 38000, w1, "Seiko Pakistan");
            Add("Watches", "Seiko 5 Sports Automatic SRPG35", 18000, 25000, w2, "Seiko Pakistan");
            Add("Watches", "Orient Mako II Automatic Diver", 22000, 30000, w1, "Orient Pakistan");
            Add("Watches", "Citizen Eco-Drive Promaster BN0150", 28000, 38000, w2, "Citizen Pakistan");
            Add("Watches", "Timex Expedition Ranger TW4B14300", 8500, 13000, w1, "Timex Pakistan");

            string h1 = "https://images.unsplash.com/photo-1574269909862-7e1d70bb8078?w=400";
            string h2 = "https://images.unsplash.com/photo-1584568694244-14fbdf83bd30?w=400";
            Add("Home Appliances", "Haier HRF-522 Refrigerator 18 CFT", 112000, 135000, h1, "Haier Pakistan");
            Add("Home Appliances", "PEL PRGD-22350 Refrigerator 22 CFT", 135000, 162000, h2, "PEL Official");
            Add("Home Appliances", "Samsung RT34 Twin Cooling Refrigerator", 145000, 175000, h1, "Samsung Official");
            Add("Home Appliances", "Dawlance DW-9300 Microwave 30L", 22000, 28000, h2, "Dawlance PK");
            Add("Home Appliances", "Samsung MG28 Microwave Grill 28L", 28000, 36000, h1, "Samsung Official");
            Add("Home Appliances", "LG FHM1408BDL Washing Machine 8KG", 78000, 95000, h2, "LG Pakistan");
            Add("Home Appliances", "Haier HW80-B14636 Washer 8KG", 68000, 84000, h1, "Haier Pakistan");
            Add("Home Appliances", "Gree GS-18PITH Inverter AC 1.5 Ton", 88000, 108000, h2, "Gree Pakistan");
            Add("Home Appliances", "Dawlance INVERON 15 Plus AC 1.5 Ton", 82000, 102000, h1, "Dawlance PK");
            Add("Home Appliances", "Orient DC Inverter AC 1 Ton", 72000, 90000, h2, "Orient Pakistan");
            Add("Home Appliances", "Philips HD9252 Air Fryer 4.1L", 18000, 24000, h1, "Philips PK");
            Add("Home Appliances", "Kenwood BL237 Blender 1.5L", 5500, 8000, h2, "Kenwood PK");
            Add("Home Appliances", "Anex AG-3074 Stand Mixer 1000W", 12000, 16000, h1, "Anex Pakistan");
            Add("Home Appliances", "National EM-925 Pressure Cooker 5L", 9000, 12500, h2, "National PK");
            Add("Home Appliances", "Dyson V12 Detect Slim Cordless Vacuum", 145000, 175000, h1, "Dyson Pakistan");

            string sp1 = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=400";
            string sp2 = "https://images.unsplash.com/photo-1518611012118-696072aa579a?w=400";
            Add("Sports", "Wilson Pro Staff RF97 Tennis Racket", 28000, 36000, sp1, "Wilson Sports");
            Add("Sports", "Adidas Predator Elite FG Football Boots", 22000, 30000, sp2, "Adidas Official");
            Add("Sports", "Nike Mercurial Vapor 15 Elite FG", 28000, 38000, sp1, "Nike Pakistan");
            Add("Sports", "Adidas Champions League Match Ball", 8500, 12000, sp2, "Adidas Official");
            Add("Sports", "Decathlon 30KG Rubber Dumbbell Set", 18000, 25000, sp1, "Decathlon PK");
            Add("Sports", "Garmin Edge 540 Cycling Computer", 85000, 105000, sp2, "Garmin Pakistan");
            Add("Sports", "Yonex Astrox 88S Pro Badminton Racket", 18000, 25000, sp1, "Yonex PK");
            Add("Sports", "Speedo Fastskin Pure Focus Goggles", 5500, 8000, sp2, "Speedo PK");
            Add("Sports", "Fitbit Charge 6 Fitness Tracker", 32000, 42000, sp1, "Fitbit Pakistan");
            Add("Sports", "Nike Pro Dri-Fit Training Shorts", 4500, 7000, sp2, "Nike Pakistan");
            Add("Sports", "TRX Pro Kit Suspension Trainer", 22000, 30000, sp1, "TRX Pakistan");
            Add("Sports", "Coleman Sundome 4-Person Camping Tent", 22000, 30000, sp2, "Coleman PK");
            Add("Sports", "Salomon X Ultra 4 GTX Hiking Boot", 38000, 50000, sp1, "Salomon PK");

            string be1 = "https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=400";
            string be2 = "https://images.unsplash.com/photo-1620916566398-39f1143ab7be?w=400";
            Add("Beauty", "Dyson Supersonic Hair Dryer", 75000, 92000, be1, "Dyson Pakistan");
            Add("Beauty", "GHD Platinum+ Professional Styler", 65000, 80000, be2, "GHD Pakistan");
            Add("Beauty", "Philips Norelco OneBlade Pro", 12000, 17000, be1, "Philips PK");
            Add("Beauty", "Braun Series 7 7071cc Electric Shaver", 32000, 42000, be2, "Braun Pakistan");
            Add("Beauty", "L'Oreal Paris Revitalift Serum 30ml", 3500, 5500, be1, "L'Oreal PK");
            Add("Beauty", "CeraVe AM Facial Moisturising SPF 30", 3200, 4800, be2, "CeraVe PK");
            Add("Beauty", "The Ordinary Niacinamide 10% Zinc 1%", 2200, 3500, be1, "Ordinary PK");
            Add("Beauty", "MAC Ruby Woo Retro Matte Lipstick", 4500, 6500, be2, "MAC Pakistan");
            Add("Beauty", "Dior Sauvage Eau de Parfum 100ml", 22000, 30000, be1, "Dior Pakistan");
            Add("Beauty", "Chanel Bleu de Chanel EDT 100ml", 25000, 34000, be2, "Chanel PK");
            Add("Beauty", "Oral-B iO Series 9 Electric Toothbrush", 28000, 38000, be1, "Oral-B PK");
            Add("Beauty", "Kerastase Nutritive Masquintense 200ml", 8500, 12000, be2, "Kerastase PK");

            string bk1 = "https://images.unsplash.com/photo-1544947950-fa07a98d237f?w=400";
            string bk2 = "https://images.unsplash.com/photo-1512820790803-83ca734da794?w=400";
            Add("Books", "Atomic Habits by James Clear", 1800, 2500, bk1, "Book World PK");
            Add("Books", "The Psychology of Money — Morgan Housel", 1600, 2200, bk2, "Book World PK");
            Add("Books", "Rich Dad Poor Dad — Robert Kiyosaki", 1400, 2000, bk1, "Book World PK");
            Add("Books", "Thinking Fast and Slow — Daniel Kahneman", 1900, 2800, bk2, "Book World PK");
            Add("Books", "Zero to One — Peter Thiel", 1500, 2200, bk1, "Book World PK");
            Add("Books", "The Alchemist — Paulo Coelho", 1200, 1800, bk2, "Book World PK");
            Add("Books", "Sapiens — Yuval Noah Harari", 2000, 2900, bk1, "Book World PK");
            Add("Books", "Deep Work — Cal Newport", 1600, 2300, bk2, "Book World PK");
            Add("Books", "Start with Why — Simon Sinek", 1500, 2200, bk1, "Book World PK");
            Add("Books", "Ikigai — Hector Garcia", 1400, 2000, bk2, "Book World PK");

            string to1 = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=400";
            string to2 = "https://images.unsplash.com/photo-1566576912321-d58ddd7a6088?w=400";
            Add("Toys", "LEGO Technic Bugatti Chiron 42083", 85000, 105000, to1, "LEGO Pakistan");
            Add("Toys", "LEGO City Police Station 60316", 22000, 30000, to2, "LEGO Pakistan");
            Add("Toys", "LEGO Star Wars Millennium Falcon 75192", 185000, 225000, to1, "LEGO Pakistan");
            Add("Toys", "Hot Wheels Ultimate Garage Playset", 12000, 17000, to2, "Mattel Pakistan");
            Add("Toys", "Barbie Dreamhouse 3-Story Playset", 18000, 26000, to1, "Mattel Pakistan");
            Add("Toys", "Nerf Elite 2.0 Turbine CS-18 Blaster", 8500, 13000, to2, "Nerf Pakistan");
            Add("Toys", "PlayStation 5 DualSense Controller White", 18000, 24000, to1, "Sony Pakistan");
            Add("Toys", "Xbox Series X|S Controller Carbon Black", 12000, 17000, to2, "Microsoft PK");
            Add("Toys", "Nintendo Switch OLED White", 82000, 100000, to1, "Nintendo PK");
            Add("Toys", "Remote Control Lamborghini 1:14 Scale", 8500, 13000, to2, "Bburago PK");

            context.Products.AddRange(list);
            context.SaveChanges();
        }
    }
}