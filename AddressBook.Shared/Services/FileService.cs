

using AddressBook.Shared.Interfaces;
using System.Diagnostics;

namespace AddressBook.Shared.Services;

    public class FileService (string filePath)
    {
        private readonly string _filePath = filePath;

    /// <summary>
    /// Save content to file
    /// </summary>
    /// <param name="content">Content to be saved</param>
    /// <returns>Returns true if save is successfull</returns>
    public bool SaveContentToFile(string filePath, string content)
        {
            try
            {
                File.Create(_filePath);
                File.Delete(_filePath);


                using (var sw = new StreamWriter(_filePath))
                {
                    sw.Write(content);
                }
                return true;

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;
        }

    /// <summary>
    /// Get content from file
    /// </summary>
    /// <returns>Returns the text from file if found. Else return null</returns>
    public string GetContentFromFile(string filePath)
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    using var sr = new StreamReader(_filePath); 
                    return sr.ReadToEnd();
                }

            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
        }

        
    }

