using System.IO;
using System.Threading.Tasks;

namespace ShoeStore.ViewModel
{
    public interface IForumFile
    {
        string FileName { get; }

        Task CopyToAsync(FileStream fileStream);
    }
}