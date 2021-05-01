using BlogPlatformApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPlatformApp.Repositories
{
    public interface IDataRepository<T> where T : class
    {
        void Add(T entity);
        Task<BlogPost> Update(BlogPost post);
        void Delete(T entity);
        Task<T> SaveAsync(T entity);
        Task<BlogPostViewModel> GetViewModel(string slug);
        Task<IEnumerable<BlogPostViewModel>> Search(string tag);
        Task<BlogPostViewModel> Create(BlogPost post);
        Task<BlogPost> Get(int id);
        Task<TagViewModel> GetAllTags();
        Task<BlogPost> GetBySlug(string slug);
    }
}