namespace CourseApp.Backend.DataAccess.Context
{
    public class CourseAppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public CourseAppDbContext(DbContextOptions<CourseAppDbContext> options) : base(options) { }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseOrder> CourseOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IEntityConfiguration).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetBaseProperties()
        {
            var entityEntries = ChangeTracker.Entries<AuditableBaseEntity>();
            foreach (var entityEntry in entityEntries)
            {
                SetIfAdded(entityEntry);
                SetIfModified(entityEntry);
                SetIfDeleted(entityEntry);
            }
        }

        private void SetIfAdded(EntityEntry<AuditableBaseEntity> entityEntry)
        {
            if (entityEntry.State is not EntityState.Added) return;

            var auditableBaseEntity = entityEntry.Entity;
            auditableBaseEntity.EntityStatus = EntityStatus.Added;
            auditableBaseEntity.CreatedDate = DateTime.Now;

            if (auditableBaseEntity is AuditablePersonBaseEntity)
            {
                var auditablePersonBaseEntity = (AuditablePersonBaseEntity)auditableBaseEntity;
                if (auditablePersonBaseEntity is Admin)
                {
                    auditablePersonBaseEntity.CreatedBy = "super admin";
                    auditablePersonBaseEntity.AccountStatus = AccountStatus.Active;
                }
                else if (auditablePersonBaseEntity is Trainer)
                {
                    if (auditablePersonBaseEntity.CreatedBy is not "super admin")
                    {
                        auditablePersonBaseEntity.AccountStatus = AccountStatus.Passive;
                        auditablePersonBaseEntity.VerificationCode = HelperVerification.CodeGenerator();
                    }
                    else auditablePersonBaseEntity.AccountStatus = AccountStatus.Active;
                }
                else if (auditablePersonBaseEntity is Student)
                {
                    if (auditablePersonBaseEntity.CreatedBy is not "super admin")
                    {
                        auditablePersonBaseEntity.CreatedBy = $"{auditablePersonBaseEntity.IdentityId}";
                        auditablePersonBaseEntity.AccountStatus = AccountStatus.Passive;
                        auditablePersonBaseEntity.VerificationCode = HelperVerification.CodeGenerator();
                    }
                    else auditablePersonBaseEntity.AccountStatus = AccountStatus.Active;
                }
            }
            else
            {
                if (auditableBaseEntity is Category) auditableBaseEntity.CreatedBy = "super admin";
                else if (auditableBaseEntity is Course)
                {
                    var course = (Course)auditableBaseEntity;
                    course.CreatedBy = course.TrainerId.ToString();
                }
                else if (auditableBaseEntity is CourseOrder)
                {
                    var courseOrder = (CourseOrder)auditableBaseEntity;
                    courseOrder.CreatedBy = "super admin";
                }
                else if (auditableBaseEntity is Order)
                {
                    var order = (Order)auditableBaseEntity;
                    order.CreatedBy = order.StudentId.ToString();
                    order.ShoppingStatus = ShoppingStatus.Continues;
                }
                else if (auditableBaseEntity is Payment)
                {
                    var payment = (Payment)auditableBaseEntity;
                    payment.CreatedBy = payment.StudentId.ToString();
                }
                else if (auditableBaseEntity is StudentCourse)
                {
                    var studentCourse = (StudentCourse)auditableBaseEntity;
                    studentCourse.CreatedBy = "super admin";
                }
            }
        }

        private void SetIfModified(EntityEntry<AuditableBaseEntity> entityEntry)
        {
            if (entityEntry.State is not EntityState.Modified) return;

            var auditableBaseEntity = entityEntry.Entity;
            auditableBaseEntity.EntityStatus = EntityStatus.Modified;
            entityEntry.Entity.ModifiedDate = DateTime.Now;

            if (auditableBaseEntity is AuditablePersonBaseEntity)
            {
                var auditablePersonBaseEntity = (AuditablePersonBaseEntity)auditableBaseEntity;
                auditablePersonBaseEntity.ModifiedBy = $"{auditablePersonBaseEntity.IdentityId}";
            }
            else
            {
                if (auditableBaseEntity is Category) auditableBaseEntity.ModifiedBy = "super admin";
                else if (auditableBaseEntity is Course)
                {
                    var course = (Course)auditableBaseEntity;
                    course.ModifiedBy = course.TrainerId.ToString();
                }
                else if (auditableBaseEntity is CourseOrder)
                {
                    var courseOrder = (CourseOrder)auditableBaseEntity;
                    courseOrder.ModifiedBy = "super admin";
                }
                else if (auditableBaseEntity is Order)
                {
                    var order = (Order)auditableBaseEntity;
                    order.ModifiedBy = order.StudentId.ToString();
                }
                else if (auditableBaseEntity is Payment)
                {
                    var payment = (Payment)auditableBaseEntity;
                    payment.ModifiedBy = payment.StudentId.ToString();
                }
                else if (auditableBaseEntity is StudentCourse)
                {
                    var studentCourse = (StudentCourse)auditableBaseEntity;
                    studentCourse.ModifiedBy = "super admin";
                }
            }
        }

        private void SetIfDeleted(EntityEntry<AuditableBaseEntity> entityEntry)
        {
            if (entityEntry.State is not EntityState.Deleted) return;

            entityEntry.State = EntityState.Modified;

            var auditableBaseEntity = entityEntry.Entity;
            auditableBaseEntity.EntityStatus = EntityStatus.Deleted;
            auditableBaseEntity.DeletedDate = DateTime.Now;

            if (auditableBaseEntity is AuditablePersonBaseEntity)
            {
                var auditablePersonBaseEntity = (AuditablePersonBaseEntity)auditableBaseEntity;
                auditablePersonBaseEntity.DeletedBy = $"{auditablePersonBaseEntity.IdentityId}";
                auditablePersonBaseEntity.AccountStatus = AccountStatus.Passive;
            }
            else
            {
                if (auditableBaseEntity is Category) auditableBaseEntity.DeletedBy = "super admin";
                else if (auditableBaseEntity is Course)
                {
                    var course = (Course)auditableBaseEntity;
                    course.DeletedBy = course.TrainerId.ToString();
                }
                else if (auditableBaseEntity is CourseOrder)
                {
                    var courseOrder = (CourseOrder)auditableBaseEntity;
                    courseOrder.DeletedBy = "super admin";
                }
                else if (auditableBaseEntity is Order)
                {
                    var order = (Order)auditableBaseEntity;
                    order.DeletedBy = order.StudentId.ToString();
                    order.ShoppingStatus = ShoppingStatus.Cancelled;
                }
                else if (auditableBaseEntity is Payment)
                {
                    var payment = (Payment)auditableBaseEntity;
                    payment.DeletedBy = payment.StudentId.ToString();
                }
                else if (auditableBaseEntity is StudentCourse)
                {
                    var studentCourse = (StudentCourse)auditableBaseEntity;
                    studentCourse.DeletedBy = "super admin";
                }
            }
        }
    }
}