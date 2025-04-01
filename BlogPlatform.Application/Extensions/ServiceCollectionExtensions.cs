using BlogPlatform.Application.Interfaces;
using BlogPlatform.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BlogPlatform.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Services
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();

            return services;
        }
    }
} 