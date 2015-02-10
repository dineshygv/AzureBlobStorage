using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AzureBlobStorageProto
{
    class Program
    {
        static void Main(string[] args)
        {
            var crud = new AzureStorageCRUD();
            var container = crud.GetContainer("testcontainer");
            var file = crud.UploadFile(container, "testfile", @"D:\testfile.txt");
            Console.ReadKey();
        }
    }
}
