namespace InveonCourseApp.Backend.DataAccess.Concrete.SeedDatas
{
    internal static class DataSeeder
    {
        internal static async Task AddAsync(UserManager<IdentityUser> userManager, IOptions<ConnectionOptions> iOptionsConnectionOptions)
        {
            var connectionOptions = iOptionsConnectionOptions.Value;
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<InveonCourseAppDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionOptions.MssqlServer);

            using InveonCourseAppDbContext db = new(dbContextOptionsBuilder.Options);

            var roles = Enum.GetValues<Role>().Cast<Role>().ToList();
            foreach (var role in roles)
            {
                if (await db.Roles.AnyAsync(dbRole => dbRole.Name == role.ToString())) continue;

                await AddIdentityRoleAsync(db, role);
            }

            var admins = new List<Admin>()
            {
                new() { Name = "Felipe", Surname = "Anderson", Email = "felipe.anderson@admincourseapp.com" }
            };
            foreach (var admin in admins)
            {
                if (await db.Admins.AnyAsync(dbAdmin => dbAdmin.Email == admin.Email)) continue;

                admin.Name = $"{admin.Name.ToUpperInvariant().Substring(0, 1)}{admin.Name.ToLower().Substring(1, admin.Name.Length - 1)}";
                admin.Surname = $"{admin.Surname.ToUpperInvariant().Substring(0, 1)}{admin.Surname.ToLower().Substring(1, admin.Surname.Length - 1)}";
                await AddAdminAsync(db, userManager, admin);
            }

            var students = new List<Student>()
            {
                new() { Id = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9"), Name = "Kevin", Surname = "Debruyne", Email = "kevin.debruyne@studentcourseapp.com", Birthdate = new DateTime(1991, 6, 28), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), Name = "Erling", Surname = "Haaland", Email = "erling.haaland@studentcourseapp.com", Birthdate = new DateTime(2000, 7, 21), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), Name = "Lamine", Surname = "Yamal", Email = "lamine.yamal@studentcourseapp.com", Birthdate = new DateTime(2007, 7, 13), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32"), Name = "Mo", Surname = "Salah", Email = "mo.salah@studentcourseapp.com", Birthdate = new DateTime(1992, 6, 15), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("b04b4e19-1097-4a80-852c-1c5f02fc4f78"), Name = "Kobbie", Surname = "Mainoo", Email = "kobbie.mainoo@studentcourseapp.com", Birthdate = new DateTime(2005, 4, 19), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("b94dcd23-44b3-4e6e-913b-56bdfc90450c"), Name = "Pau", Surname = "Cubarsi", Email = "pau.cubarsi@studentcourseapp.com", Birthdate = new DateTime(2007, 1, 22), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("511419d3-7bdb-4736-ab1e-b75cb0eac338"), Name = "Jude", Surname = "Bellingham", Email = "jude.bellingham@studentcourseapp.com", Birthdate = new DateTime(2003, 6, 29), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), Name = "Phil", Surname = "Foden", Email = "phil.foden@studentcourseapp.com", Birthdate = new DateTime(2000, 5, 28), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("8d194302-f431-41da-9926-dbe3157c867b"), Name = "Khvicha", Surname = "Kvaratskhelia", Email = "khvicha.kvaratskhelia@studentcourseapp.com", Birthdate = new DateTime(2001, 2, 12), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("a5fd161d-6a2a-4ddd-a98c-5fc1ac6a520b"), Name = "Lautaro", Surname = "Martinez", Email = "lautaro.martinez@studentcourseapp.com", Birthdate = new DateTime(1997, 8, 22), CreatedBy = "super admin" }
            };
            foreach (var student in students)
            {
                if (await db.Students.AnyAsync(dbStudent => dbStudent.Email == student.Email)) continue;

                student.Name = $"{student.Name.ToUpperInvariant().Substring(0, 1)}{student.Name.ToLower().Substring(1, student.Name.Length - 1)}";
                student.Surname = $"{student.Surname.ToUpperInvariant().Substring(0, 1)}{student.Surname.ToLower().Substring(1, student.Surname.Length - 1)}";
                await AddStudentAsync(db, userManager, student);
            }

            var trainers = new List<Trainer>()
            {
                new() { Id = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9"), Name = "Kevin", Surname = "Debruyne", Email = "kevin.debruyne@studentcourseapp.com", Birthdate = new DateTime(1991, 6, 28), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("a5fd161d-6a2a-4ddd-a98c-5fc1ac6a520b"), Name = "Lautaro", Surname = "Martinez", Email = "lautaro.martinez@studentcourseapp.com", Birthdate = new DateTime(1997, 8, 22), CreatedBy = "super admin" },
                new() { Id = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32"), Name = "Mo", Surname = "Salah", Email = "mo.salah@studentcourseapp.com", Birthdate = new DateTime(1992, 6, 15), CreatedBy = "super admin" }
            };
            foreach (var trainer in trainers)
            {
                if (await db.Trainers.AnyAsync(dbTrainer => dbTrainer.Email == trainer.Email)) continue;

                trainer.Name = $"{trainer.Name.ToUpperInvariant().Substring(0, 1)}{trainer.Name.ToLower().Substring(1, trainer.Name.Length - 1)}";
                trainer.Surname = $"{trainer.Surname.ToUpperInvariant().Substring(0, 1)}{trainer.Surname.ToLower().Substring(1, trainer.Surname.Length - 1)}";
                await AddTrainerAsync(db, userManager, trainer);
            }

            var categories = new List<Category>()
            {
                new() { Id = Guid.Parse("ef70ecd1-7986-4022-9f9e-e14914ba7377"), Name = "AI & Data Science"},
                new() { Id = Guid.Parse("6ae0ba29-976e-4669-b9f7-18db70db11cc"), Name = "Art and Design"},
                new() { Id = Guid.Parse("68e35f23-55fc-4496-bd26-15ff69f48932"), Name = "Backend Development"},
                new() { Id = Guid.Parse("25e78b37-127f-4771-981d-2522fcf22ecd"), Name = "Business"},
                new() { Id = Guid.Parse("951e47d6-e8b4-4de5-8ce6-768c20f83b81"), Name = "Database Design and Development"},
                new() { Id = Guid.Parse("feaeedb5-6b1f-4f0d-804a-224a7bba6c7f"), Name = "Education and Academics"},
                new() { Id = Guid.Parse("1dc6ee55-751f-48d2-8244-be641b1440b2"), Name = "Engineering"},
                new() { Id = Guid.Parse("40172f77-5d10-4387-99e7-2bfb79a308c9"), Name = "Finance and Accounting"},
                new() { Id = Guid.Parse("f96025bc-f134-4c4c-b3f0-5438e532eb3f"), Name = "Game Development"},
                new() { Id = Guid.Parse("79e9b27e-6d30-452a-ae60-8980f47b3a8b"), Name = "Hardware"},
                new() { Id = Guid.Parse("5b64a3d7-795b-4f85-98eb-db1a091480c5"), Name = "Health and Fitness"},
                new() { Id = Guid.Parse("483b5c7a-d93f-49aa-bb17-8af2ab0d08e1"), Name = "IT Certifications"},
                new() { Id = Guid.Parse("60d52a39-ac77-4bf8-802b-1eec8d08147f"), Name = "Language Learning"},
                new() { Id = Guid.Parse("cfaef454-cb08-4e5c-8763-1cdf1cd47245"), Name = "Marketing"},
                new() { Id = Guid.Parse("2d4d0f33-5bf7-43d5-839c-0a81764bafed"), Name = "Mobile Development"},
                new() { Id = Guid.Parse("ac66d022-6ff2-43d8-8159-8efde4919d72"), Name = "Music"},
                new() { Id = Guid.Parse("a7f43129-9649-46d2-be2e-6e3223de1f3c"), Name = "Network & Security"},
                new() { Id = Guid.Parse("b456cb97-d032-45e3-bb32-46522fd5070b"), Name = "Office Productivity"},
                new() { Id = Guid.Parse("06c439c8-8b11-48c5-a33a-a2bc6e12ee50"), Name = "Personal Development"},
                new() { Id = Guid.Parse("9f4794f3-1e3e-48af-9f1f-850418cd98d4"), Name = "Photography & Video"},
                new() { Id = Guid.Parse("91c0db70-fa04-4aa9-813f-8d1b78d1aa3d"), Name = "Software Testing"},
                new() { Id = Guid.Parse("d919e085-e960-4cb0-884c-41e907965686"), Name = "Web Development"}
            };
            foreach (var category in categories)
            {
                if (await db.Categories.AnyAsync(dbCategory => dbCategory.Name == category.Name)) continue;

                category.Name = category.Name.ToUpperInvariant();
                await AddCategoryAsync(db, category);
            }

            var courses = new List<Course>()
            {
                new() { Id = Guid.Parse("5dc951df-3dab-4672-8115-def665f84737"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/1384236_0d3c_3.jpg", Name = "Uygulama Geliştirerek C# Öğrenin: A'dan Z'ye Eğitim Seti", Description = "192 Ders ~ C# programlama mantığını modüler bir müfredat aracılığıyla projeler geliştirerek öğrenin!", Price = decimal.Parse("549,99"), Currency = Currency.TL, CategoryId = Guid.Parse("68e35f23-55fc-4496-bd26-15ff69f48932"), TrainerId = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9") },
                new() { Id = Guid.Parse("72112159-e851-42c8-a5ae-aceeb4b4f959"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/3212581_7d32_3.jpg", Name = "Unity C# | Sıfırdan Profesyonelliğe | 3D | 2D Oyun Yapımı", Description = "2023 | 155+SAAT | Sıfırdan başlayarak oyun geliştiricisi olmaya Hazır mısın ? Hayallerine çok yakınsın, HAYDİ BAŞLAYALIM", Price = decimal.Parse("299,99"), Currency = Currency.TL, CategoryId = Guid.Parse("f96025bc-f134-4c4c-b3f0-5438e532eb3f"), TrainerId = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9") },
                new() { Id = Guid.Parse("ca4608d0-6620-469d-901d-2a7b5ed691e6"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/5044338_0008.jpg", Name = "React JS : Uygulamalı React JS -Redux Eğitimi (2024)", Description = "React 18 - React Component - React State - React Hooks - React Router 6 - React Typescript - Redux Toolkit - Context Api", Price = decimal.Parse("499,99"), Currency = Currency.TL, CategoryId = Guid.Parse("d919e085-e960-4cb0-884c-41e907965686"), TrainerId = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9") },
                new() { Id = Guid.Parse("836a27e1-1d5c-4e16-9ff9-c7f9e0e26292"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/2847136_fccf.jpg", Name = "Unit Test Yazma-Asp.Net Core MVC/API(Sıfırdan)", Description = "Sıfırdan Asp.Net Core Mvc ve API projeleriniz için xUnit kütüphanesi ile unit test yazmayı öğreneceksiniz.", Price = decimal.Parse("399,99"), Currency = Currency.TL, CategoryId = Guid.Parse("91c0db70-fa04-4aa9-813f-8d1b78d1aa3d"), TrainerId = Guid.Parse("2e6103d0-718c-436b-95f6-eb86e54ecaa9") },
                new() { Id = Guid.Parse("747e7c3b-2cc5-40a1-8499-7bdd9a3f9da7"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/988524_8235_7.jpg", Name = "Management Skills Training for New & Experienced Managers", Description = "Management & Leadership Skills Certification in Developing People, Leading Teams & Improving Processes", Price = decimal.Parse("269,99"), Currency = Currency.TL, CategoryId = Guid.Parse("06c439c8-8b11-48c5-a33a-a2bc6e12ee50"), TrainerId = Guid.Parse("a5fd161d-6a2a-4ddd-a98c-5fc1ac6a520b") },
                new() { Id = Guid.Parse("f21a9e2b-8d50-4368-8046-db4a78a8613f"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/4050808_4be0_5.jpg", Name = "Etkin İletişim Becerileri ve Beden Dili - Sertifikalı", Description = "Uluslararası Geçerli Başarı Sertifikalı / Her Zaman Bir Adım Önde Olacaksınız", Price = decimal.Parse("249,99"), Currency = Currency.TL, CategoryId = Guid.Parse("06c439c8-8b11-48c5-a33a-a2bc6e12ee50"), TrainerId = Guid.Parse("a5fd161d-6a2a-4ddd-a98c-5fc1ac6a520b") },
                new() { Id = Guid.Parse("5d2ebe5f-9196-42c8-8f73-be4395e4e36a"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/6217585_37e9.jpg", Name = "The Complete Online MBA (2025)", Description = "Become A Top 1% Business Leader", Price = decimal.Parse("249,99"), Currency = Currency.TL, CategoryId = Guid.Parse("25e78b37-127f-4771-981d-2522fcf22ecd"), TrainerId = Guid.Parse("a5fd161d-6a2a-4ddd-a98c-5fc1ac6a520b") },
                new() { Id = Guid.Parse("23c2c74e-387f-4145-8ccc-85431fa5459a"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/117490_5ea3_13.jpg", Name = "Become a Calculus 1 Master", Description = "Learn everything from Calculus 1, then test your knowledge with 600+ practice questions", Price = decimal.Parse("299,99"), Currency = Currency.TL, CategoryId = Guid.Parse("feaeedb5-6b1f-4f0d-804a-224a7bba6c7f"), TrainerId = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32") },
                new() { Id = Guid.Parse("9dd6f8ff-1763-47ca-868f-6fd7f34d799e"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/128298_f05a_7.jpg", Name = "Become a Calculus 2 Master", Description = "Learn everything from Calculus 2, then test your knowledge with 830+ practice questions", Price = decimal.Parse("269,99"), Currency = Currency.TL, CategoryId = Guid.Parse("feaeedb5-6b1f-4f0d-804a-224a7bba6c7f"), TrainerId = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32") },
                new() { Id = Guid.Parse("b826f297-6aeb-4079-b7ac-790a399f4866"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/128300_2f33_6.jpg", Name = "Become a Calculus 3 Master", Description = "Learn everything from Calculus 3, then test your knowledge with 780+ practice questions", Price = decimal.Parse("249,99"), Currency = Currency.TL, CategoryId = Guid.Parse("feaeedb5-6b1f-4f0d-804a-224a7bba6c7f"), TrainerId = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32") },
                new() { Id = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1"), ImageUrl = "https://img-c.udemycdn.com/course/240x135/4849126_3676_2.jpg", Name = "Math for Data Science Masterclass", Description = "Learn about probability, statistics, and more using the mathematics that are foundational to the field of data science.", Price = decimal.Parse("269,99"), Currency = Currency.TL, CategoryId = Guid.Parse("ef70ecd1-7986-4022-9f9e-e14914ba7377"), TrainerId = Guid.Parse("144a72d4-2403-4f88-b4e1-c1b22b692d32") }
            };
            foreach (var course in courses)
            {
                if (await db.Courses.AnyAsync(dbCourse => dbCourse.Id == course.Id)) continue;

                course.Name = course.Name.ToUpperInvariant();
                await AddCourseAsync(db, course);
            }

            var studentCourses = new List<StudentCourse>()
            {
                new() { Id = Guid.Parse("ec9923b5-d9e7-4bf9-8e97-f1f6a13517f9"), StudentId = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), CourseId = Guid.Parse("5dc951df-3dab-4672-8115-def665f84737") },
                new() { Id = Guid.Parse("e5bf39a0-8832-4cc9-9e20-22958ae5cfeb"), StudentId = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), CourseId = Guid.Parse("ca4608d0-6620-469d-901d-2a7b5ed691e6") },
                new() { Id = Guid.Parse("c2eac9bf-3de6-4104-a235-46bd495e3d08"), StudentId = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), CourseId = Guid.Parse("836a27e1-1d5c-4e16-9ff9-c7f9e0e26292") },
                new() { Id = Guid.Parse("1e5b7604-8387-4a4d-a1e4-ae6b53c72949"), StudentId = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), CourseId = Guid.Parse("23c2c74e-387f-4145-8ccc-85431fa5459a") },
                new() { Id = Guid.Parse("6f32d2d7-3c4c-42a6-89d6-4c966e5a4e6c"), StudentId = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), CourseId = Guid.Parse("9dd6f8ff-1763-47ca-868f-6fd7f34d799e") },
                new() { Id = Guid.Parse("ebd5f886-0278-4e6c-9d33-b77eb00b22e5"), StudentId = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), CourseId = Guid.Parse("b826f297-6aeb-4079-b7ac-790a399f4866") },
                new() { Id = Guid.Parse("49c6fe95-3d46-4435-b9c8-720d39014a4c"), StudentId = Guid.Parse("b04b4e19-1097-4a80-852c-1c5f02fc4f78"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1") },
                new() { Id = Guid.Parse("8cead844-678a-44bc-884d-56676802cf01"), StudentId = Guid.Parse("b94dcd23-44b3-4e6e-913b-56bdfc90450c"), CourseId = Guid.Parse("747e7c3b-2cc5-40a1-8499-7bdd9a3f9da7") },
                new() { Id = Guid.Parse("bad9cfde-e58c-496a-94bd-4488037415ac"), StudentId = Guid.Parse("b94dcd23-44b3-4e6e-913b-56bdfc90450c"), CourseId = Guid.Parse("5d2ebe5f-9196-42c8-8f73-be4395e4e36a") },
                new() { Id = Guid.Parse("3eea9034-0890-4ef6-b4a1-01ec0ecb5fe3"), StudentId = Guid.Parse("511419d3-7bdb-4736-ab1e-b75cb0eac338"), CourseId = Guid.Parse("f21a9e2b-8d50-4368-8046-db4a78a8613f") },
                new() { Id = Guid.Parse("60e88feb-a2ff-41d1-8d24-ded832663ea3"), StudentId = Guid.Parse("511419d3-7bdb-4736-ab1e-b75cb0eac338"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1") },
                new() { Id = Guid.Parse("47d06cfe-05eb-4db8-b9d4-f91eea0bd720"), StudentId = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), CourseId = Guid.Parse("5dc951df-3dab-4672-8115-def665f84737") },
                new() { Id = Guid.Parse("5188ed92-107a-4445-8398-80ebf3e725a9"), StudentId = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), CourseId = Guid.Parse("72112159-e851-42c8-a5ae-aceeb4b4f959") },
                new() { Id = Guid.Parse("70ca7482-fed6-4242-a579-1747e4b554b9"), StudentId = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), CourseId = Guid.Parse("836a27e1-1d5c-4e16-9ff9-c7f9e0e26292") },
                new() { Id = Guid.Parse("ad90bebe-fb4d-47e7-abea-180ab15e3baa"), StudentId = Guid.Parse("8d194302-f431-41da-9926-dbe3157c867b"), CourseId = Guid.Parse("ca4608d0-6620-469d-901d-2a7b5ed691e6") },
                new() { Id = Guid.Parse("592fbbd4-fa30-4602-94df-83d8e3a49ffd"), StudentId = Guid.Parse("8d194302-f431-41da-9926-dbe3157c867b"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1") }
            };
            foreach (var studentCourse in studentCourses)
            {
                if (await db.StudentCourses.AnyAsync(dbStudentCourses => dbStudentCourses.Id == studentCourse.Id)) continue;

                await AddStudentCourseAsync(db, studentCourse);
            }

            var orders = new List<Order>()
            {
                new() { Id = Guid.Parse("25cb7632-f2df-44e9-8a51-e7700ab56d94"), StudentId = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), TotalCourseAmount = 3, TotalCoursePrice = decimal.Parse("1.449,97"), Currency = Currency.TL },
                new() { Id = Guid.Parse("541d6de7-9887-4a9d-8143-37ae927ec4ae"), StudentId = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), TotalCourseAmount = 3, TotalCoursePrice = decimal.Parse("819,97"), Currency = Currency.TL },
                new() { Id = Guid.Parse("52942f1b-2d5f-4d94-8032-6ba4e4c5bbb7"), StudentId = Guid.Parse("b04b4e19-1097-4a80-852c-1c5f02fc4f78"), TotalCourseAmount = 1, TotalCoursePrice = decimal.Parse("269,99"), Currency = Currency.TL },
                new() { Id = Guid.Parse("a4db6257-c517-4d09-bc02-c79b69e10871"), StudentId = Guid.Parse("b94dcd23-44b3-4e6e-913b-56bdfc90450c"), TotalCourseAmount = 2, TotalCoursePrice = decimal.Parse("519,98"), Currency = Currency.TL },
                new() { Id = Guid.Parse("ae29299d-7aec-438e-b6fd-7c76b1c2b80a"), StudentId = Guid.Parse("511419d3-7bdb-4736-ab1e-b75cb0eac338"), TotalCourseAmount = 2, TotalCoursePrice = decimal.Parse("519,98"), Currency = Currency.TL },
                new() { Id = Guid.Parse("d32f73c5-8191-43fb-a00b-6cd38c48b145"), StudentId = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), TotalCourseAmount = 3, TotalCoursePrice = decimal.Parse("1.249,97"), Currency = Currency.TL},
                new() { Id = Guid.Parse("a20f8847-5418-48bb-be39-f9a47a88772f"), StudentId = Guid.Parse("8d194302-f431-41da-9926-dbe3157c867b"), TotalCourseAmount = 2, TotalCoursePrice = decimal.Parse("769,98"), Currency = Currency.TL }
            };
            foreach (var order in orders)
            {
                if (await db.Orders.AnyAsync(dbOrder => dbOrder.Id == order.Id)) continue;

                await AddOrderAsync(db, order);
            }

            var courseOrders = new List<CourseOrder>()
            {
                new() { Id = Guid.Parse("fe810c83-27c8-42a5-ac90-c748a8228c27"), CourseId = Guid.Parse("5dc951df-3dab-4672-8115-def665f84737"), OrderId = Guid.Parse("25cb7632-f2df-44e9-8a51-e7700ab56d94")},
                new() { Id = Guid.Parse("0353f252-0a72-49c7-b098-c98713b9629e"), CourseId = Guid.Parse("ca4608d0-6620-469d-901d-2a7b5ed691e6"), OrderId = Guid.Parse("25cb7632-f2df-44e9-8a51-e7700ab56d94")},
                new() { Id = Guid.Parse("a6a93b81-e06c-432e-8cc4-011cf115ff3c"), CourseId = Guid.Parse("836a27e1-1d5c-4e16-9ff9-c7f9e0e26292"), OrderId = Guid.Parse("25cb7632-f2df-44e9-8a51-e7700ab56d94")},
                new() { Id = Guid.Parse("4cca7c0d-05cd-4e57-b9b2-2a2a5ddad06d"), CourseId = Guid.Parse("23c2c74e-387f-4145-8ccc-85431fa5459a"), OrderId = Guid.Parse("541d6de7-9887-4a9d-8143-37ae927ec4ae")},
                new() { Id = Guid.Parse("0ad99e46-22b1-4f56-85a8-4e6b3f7d7237"), CourseId = Guid.Parse("9dd6f8ff-1763-47ca-868f-6fd7f34d799e"), OrderId = Guid.Parse("541d6de7-9887-4a9d-8143-37ae927ec4ae")},
                new() { Id = Guid.Parse("665c74ea-238e-43bf-a539-17ddd8097138"), CourseId = Guid.Parse("b826f297-6aeb-4079-b7ac-790a399f4866"), OrderId = Guid.Parse("541d6de7-9887-4a9d-8143-37ae927ec4ae")},
                new() { Id = Guid.Parse("dbbe4056-aa32-4d62-a089-2c8dac4f52e1"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1"), OrderId = Guid.Parse("52942f1b-2d5f-4d94-8032-6ba4e4c5bbb7")},
                new() { Id = Guid.Parse("a5afc1a1-d105-421f-85cb-6daab6ad80be"), CourseId = Guid.Parse("747e7c3b-2cc5-40a1-8499-7bdd9a3f9da7"), OrderId = Guid.Parse("a4db6257-c517-4d09-bc02-c79b69e10871")},
                new() { Id = Guid.Parse("b176e3be-faf0-4497-a3e3-611ddd78ee04"), CourseId = Guid.Parse("5d2ebe5f-9196-42c8-8f73-be4395e4e36a"), OrderId = Guid.Parse("a4db6257-c517-4d09-bc02-c79b69e10871")},
                new() { Id = Guid.Parse("00167845-0380-4be7-965a-09d78686029d"), CourseId = Guid.Parse("f21a9e2b-8d50-4368-8046-db4a78a8613f"), OrderId = Guid.Parse("ae29299d-7aec-438e-b6fd-7c76b1c2b80a")},
                new() { Id = Guid.Parse("0b21a916-2547-4512-8877-39ccdf136fbf"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1"), OrderId = Guid.Parse("ae29299d-7aec-438e-b6fd-7c76b1c2b80a")},
                new() { Id = Guid.Parse("6f2b2c80-e1a6-4a6c-8efe-91c3adc65a29"), CourseId = Guid.Parse("5dc951df-3dab-4672-8115-def665f84737"), OrderId = Guid.Parse("d32f73c5-8191-43fb-a00b-6cd38c48b145")},
                new() { Id = Guid.Parse("f5aa91df-db35-441f-bd6e-fa4f71a4f850"), CourseId = Guid.Parse("72112159-e851-42c8-a5ae-aceeb4b4f959"), OrderId = Guid.Parse("d32f73c5-8191-43fb-a00b-6cd38c48b145")},
                new() { Id = Guid.Parse("a86fda84-fc6e-47a1-af7f-9fa6edf2c6a5"), CourseId = Guid.Parse("836a27e1-1d5c-4e16-9ff9-c7f9e0e26292"), OrderId = Guid.Parse("d32f73c5-8191-43fb-a00b-6cd38c48b145")},
                new() { Id = Guid.Parse("b6c6470e-8975-4192-857f-4cbf7c30c301"), CourseId = Guid.Parse("ca4608d0-6620-469d-901d-2a7b5ed691e6"), OrderId = Guid.Parse("a20f8847-5418-48bb-be39-f9a47a88772f")},
                new() { Id = Guid.Parse("65461904-d9bf-4721-be7f-24b00d478ab6"), CourseId = Guid.Parse("3301584a-fa6b-4d93-92a2-70c0a770a8b1"), OrderId = Guid.Parse("a20f8847-5418-48bb-be39-f9a47a88772f")}
            };
            foreach (var courseOrder in courseOrders)
            {
                if (await db.CourseOrders.AnyAsync(dbCourseOrders => dbCourseOrders.Id == courseOrder.Id)) continue;

                await AddCourseOrderAsync(db, courseOrder);
            }

            var payments = new List<Payment>()
            {
                new() { OrderId = Guid.Parse("25cb7632-f2df-44e9-8a51-e7700ab56d94"), StudentId = Guid.Parse("c86c1035-993f-4730-ad34-0b514be3ac17"), Price = decimal.Parse("1.449,97"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("541d6de7-9887-4a9d-8143-37ae927ec4ae"), StudentId = Guid.Parse("277b2f28-62cb-4604-98f3-34c9bd315a69"), Price = decimal.Parse("819,97"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("52942f1b-2d5f-4d94-8032-6ba4e4c5bbb7"), StudentId = Guid.Parse("b04b4e19-1097-4a80-852c-1c5f02fc4f78"), Price = decimal.Parse("269,99"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("a4db6257-c517-4d09-bc02-c79b69e10871"), StudentId = Guid.Parse("b94dcd23-44b3-4e6e-913b-56bdfc90450c"), Price = decimal.Parse("519,98"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("ae29299d-7aec-438e-b6fd-7c76b1c2b80a"), StudentId = Guid.Parse("511419d3-7bdb-4736-ab1e-b75cb0eac338"), Price = decimal.Parse("519,98"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("d32f73c5-8191-43fb-a00b-6cd38c48b145"), StudentId = Guid.Parse("331081a5-ded4-420d-9f63-e71399216c45"), Price = decimal.Parse("1.249,97"), Currency = Currency.TL },
                new() { OrderId = Guid.Parse("a20f8847-5418-48bb-be39-f9a47a88772f"), StudentId = Guid.Parse("8d194302-f431-41da-9926-dbe3157c867b"), Price = decimal.Parse("769,98"), Currency = Currency.TL }
            };
            foreach (var payment in payments)
            {
                if (await db.Payments.AnyAsync(dbPayment => dbPayment.OrderId == payment.OrderId)) continue;

                await AddPaymentAsync(db, payment);
            }
        }

        private static async Task AddIdentityRoleAsync(InveonCourseAppDbContext db, Role role)
        {
            await db.Roles.AddAsync(new IdentityRole { Name = role.ToString(), NormalizedName = role.ToString().ToUpperInvariant() });
            await db.SaveChangesAsync();
        }

        private static async Task AddAdminAsync(InveonCourseAppDbContext db, UserManager<IdentityUser> userManager, Admin admin)
        {
            var identityUser = new IdentityUser
            {
                EmailConfirmed = true,
                Email = admin.Email,
                UserName = $"{admin.Name}{admin.Surname}".Substring(0, 5).ToLowerInvariant(),
                NormalizedEmail = admin.Email.ToUpperInvariant(),
                NormalizedUserName = $"{admin.Name}{admin.Surname}".Substring(0, 5).ToUpperInvariant()
            };

            identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, $"{admin.Name}{admin.Surname}2024+-!?");
            await userManager.CreateAsync(identityUser);
            await userManager.AddToRoleAsync(identityUser, Role.Admin.ToString());

            var dbAdmin = new Admin
            {
                Name = admin.Name,
                Surname = admin.Surname,
                Email = admin.Email,
                IdentityId = Guid.Parse(identityUser.Id)
            };

            await db.Admins.AddAsync(dbAdmin);
            await db.SaveChangesAsync();
        }

        private static async Task AddStudentAsync(InveonCourseAppDbContext db, UserManager<IdentityUser> userManager, Student student)
        {
            var identityUser = new IdentityUser
            {
                EmailConfirmed = true,
                Email = student.Email,
                UserName = $"{student.Name}{student.Surname}".Substring(0, 5).ToLowerInvariant(),
                NormalizedEmail = student.Email.ToUpperInvariant(),
                NormalizedUserName = $"{student.Name}{student.Surname}".Substring(0, 5).ToUpperInvariant()
            };

            identityUser.PasswordHash = userManager.PasswordHasher.HashPassword(identityUser, $"{student.Name}{student.Surname}2024+-!?");
            await userManager.CreateAsync(identityUser);
            await userManager.AddToRoleAsync(identityUser, Role.Student.ToString());

            var dbStudent = new Student
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Email = student.Email,
                Birthdate = student.Birthdate,
                CreatedBy = student.CreatedBy,
                IdentityId = Guid.Parse(identityUser.Id)
            };

            await db.Students.AddAsync(dbStudent);
            await db.SaveChangesAsync();
        }

        private static async Task AddTrainerAsync(InveonCourseAppDbContext db, UserManager<IdentityUser> userManager, Trainer trainer)
        {
            var identityUser = await db.Users.FirstOrDefaultAsync(identityUser => identityUser.Email == trainer.Email);
            if (identityUser is null) return;

            var trainerRoleId = db.Roles.FirstOrDefault(role => role.Name == Role.Trainer.ToString())!.Id;
            await db.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = identityUser.Id, RoleId = trainerRoleId });

            var dbTrainer = new Trainer
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Surname = trainer.Surname,
                Email = trainer.Email,
                Birthdate = trainer.Birthdate,
                CreatedBy = trainer.CreatedBy,
                IdentityId = Guid.Parse(identityUser.Id)
            };

            await db.Trainers.AddAsync(dbTrainer);
            await db.SaveChangesAsync();
        }

        private static async Task AddCategoryAsync(InveonCourseAppDbContext db, Category category)
        {
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
        }

        private static async Task AddCourseAsync(InveonCourseAppDbContext db, Course course)
        {
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
        }

        private static async Task AddStudentCourseAsync(InveonCourseAppDbContext db, StudentCourse studentCourse)
        {
            await db.StudentCourses.AddAsync(studentCourse);
            await db.SaveChangesAsync();
        }

        private static async Task AddOrderAsync(InveonCourseAppDbContext db, Order order)
        {
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
        }

        private static async Task AddCourseOrderAsync(InveonCourseAppDbContext db, CourseOrder courseOrder)
        {
            await db.CourseOrders.AddAsync(courseOrder);
            await db.SaveChangesAsync();
        }

        private static async Task AddPaymentAsync(InveonCourseAppDbContext db, Payment payment)
        {
            await db.Payments.AddAsync(payment);
            await db.SaveChangesAsync();
        }
    }
}