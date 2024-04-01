using Domain.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface ITagService
    {
        Task<IList<TagDTO>> GetAllTags();
        Task<TagDTO> GetTagById(int id);
        Task<TagDTO> GetTagBySlug(string slug);
        Task<bool> AddTag(TagEditModel model);
        Task<bool> DeleteTag(int id);
    }
}
