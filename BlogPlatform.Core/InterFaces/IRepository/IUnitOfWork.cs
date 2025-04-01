using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPlatform.Core.InterFaces.IRepository
{
        /// <summary>
        /// واجهة Unit of Work المسؤولة عن إدارة جميع الـ Repositories ومعاملات قاعدة البيانات
        /// </summary>
        public interface IUnitOfWork
        {
            /// <summary>
            /// repository خاص بالتدوينات (Posts)
            /// </summary>
            IPostRepository Posts { get; }

            /// <summary>
            /// repository خاص بالمستخدمين (Users)
            /// </summary>
            IUserRepository Users { get; }

            /// <summary>
            /// repository خاص بالتعليقات (Comments)
            /// </summary>
            ICommentRepository Comments { get; }

            /// <summary>
            /// repository خاص بالتصنيفات (Categories)
            /// </summary>
            ICategoryRepository Categories { get; }

            /// <summary>
            /// repository خاص بالوسوم (Tags)
            /// </summary>
            ITagRepository Tags { get; }

            /// <summary>
            /// حفظ جميع التغييرات في قاعدة البيانات
            /// </summary>
            /// <returns>عدد الصفوف المتأثرة</returns>
            Task<int> SaveChangesAsync();

            /// <summary>
            /// بدء معاملة جديدة
            /// </summary>
            void BeginTransaction();

            /// <summary>
            /// إتمام المعاملة بنجاح
            /// </summary>
            void CommitTransaction();

            /// <summary>
            /// التراجع عن المعاملة في حالة حدوث خطأ
            /// </summary>
            void RollbackTransaction();

            /// <summary>
            /// التحقق من وجود معاملة نشطة
            /// </summary>
            bool HasActiveTransaction { get; }
        }
    
}

