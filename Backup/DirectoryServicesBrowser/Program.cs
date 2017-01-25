using System;
using System.Collections.Generic;
using System.Text;


namespace DirectoryServicesBrowser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loaded DirectoryServicesBrowserDialog");
            DirectoryServicesBrowserDialog DirectoryBrowser =
                            new DirectoryServicesBrowserDialog(null, null);
            DirectoryBrowser.ShowDialog();

            Console.WriteLine("Name: " + DirectoryBrowser.ObjectName);
            Console.WriteLine("Path: " + DirectoryBrowser.ObjectPath);
            Console.WriteLine("GUID: " + DirectoryBrowser.ObjectGUID);
            DirectoryBrowser.Dispose();

            Console.ReadLine();
        }
    }
}
