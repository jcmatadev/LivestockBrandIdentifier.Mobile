using System.IO;
using System.Threading.Tasks;

namespace LivestockBrandIdentifier.Mobile.Interfaces
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}
