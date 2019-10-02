using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Functions
{
    class IOFile
    {
        public void CreateFile()
        {
            //Create token file; replace if exists
            Windows.Storage.StorageFolder tokenFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = tokenFolder.CreateFileAsync("token.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting).GetAwaiter().GetResult();
        }
       
        public void WriteToFile(String token)
        {
            Windows.Storage.StorageFolder tokenFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = tokenFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            Windows.Storage.FileIO.WriteTextAsync(tokenFile, token).GetAwaiter().GetResult();
            //System.Diagnostics.Debug.WriteLine(tokenFile.Path);
        }

        public string ReadAFile()
        {
            Windows.Storage.StorageFolder tokenFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile tokenFile = tokenFolder.GetFileAsync("token.txt").GetAwaiter().GetResult();
            string token =  Windows.Storage.FileIO.ReadTextAsync(tokenFile).GetAwaiter().GetResult();
            return token;
        }
    }
}
