

using System.Diagnostics;

namespace AddressBook.Shared.Interfaces
{
    public interface IFileService
    {
        bool SaveContentToFile(string content);
        string GetContentFromFile();

    }

   

}
