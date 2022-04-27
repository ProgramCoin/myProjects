using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Globalization;


namespace FileSearch
{
    public class fileSearch : fileSearchClass
    {
        public static void Main(string[] args)
        {
            fileSearchClass fileSearchClass = new fileSearchClass();

            fileSearchClass.driveMethod();

            fileSearchClass.folderMethod();

        }
    }

    public class fileSearchClass
    {
        string emptyString = string.Empty;
        string[] driveInfo = System.IO.Directory.GetLogicalDrives();

        public void driveMethod()
        {
            try
            {
                Console.WriteLine("You have " + (driveInfo.Length) + " drives " + driveInfo[0] + " and " + driveInfo[1]);

                //int sizeDisk = System.IO.Directory.GetLogicalDrives(driveInfo[0]);

                //Console.WriteLine(driveInfo[0] + " has a total of " + sizeDisk + " memory used");

                Console.WriteLine("Searching folders and files under " + driveInfo[0] + " drive:");

                Console.WriteLine("NOTE: The '$' symbol indicates that it is a file not a folder");

                Console.WriteLine(emptyString);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void folderMethod()
        {
            try
            {

                float folderSize = 0.0f;

                string[] CInfo = System.IO.Directory.GetDirectories(driveInfo[0]);

                string[] DInfo = System.IO.Directory.GetDirectories(driveInfo[1]);

                foreach (var folder in CInfo)   //Print all folders from C drive
                {
                    //if (folder.StartsWith("$"))
                    //{
                    //    folder.Replace("$", "File name:");

                    //}
                    Console.WriteLine(folder);
                }
                Console.WriteLine(emptyString);
                Console.WriteLine("D drive folders: ");


                foreach (var folder in DInfo)   //Print all folders from D Drive
                {
                    Console.WriteLine(folder);
                }

                Console.WriteLine(emptyString);
                Console.WriteLine("Enter one of the folder names shown above to see files under that folder");
                Console.WriteLine("Or hit Spacebar to end the program");
                Console.WriteLine(emptyString);

                string userFolder = Console.ReadLine();

                Console.WriteLine(emptyString);

                if (userFolder != null)
                {
                    var FilePath = Path.Combine(driveInfo[0], userFolder);  

                    var DFilePath = Path.Combine(driveInfo[1], userFolder);

                    string[] filesInfo = Directory.GetFiles(FilePath);

                    string[] DfilesInfo = Directory.GetFiles(DFilePath);

                    if (FileInfo.ReferenceEquals(userFolder, filesInfo))
                    {
                        foreach (string file in Directory.GetFiles(FilePath))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);    //To get size
                                folderSize += finfo.Length;             //Folder size += size

                                Console.WriteLine("From Drive {0}, this is the folder you are looking for:", CInfo);

                                Console.WriteLine(finfo + " size: " + folderSize + " KB");

                                foreach (var InFolderFiles in file)
                                {
                                    Console.WriteLine(InFolderFiles);
                                }
                            }
                        }
                    }

                    else if (FileInfo.ReferenceEquals(userFolder, DfilesInfo))
                    {
                        foreach (string file in Directory.GetFiles(DFilePath))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);    //To get size
                                folderSize += finfo.Length;             //Folder size += size

                                Console.WriteLine("From Drive {0}, this is the folder you are looking for:", DInfo);

                                Console.WriteLine(finfo + " size: " + folderSize + " KB");

                                foreach (var InFolderFiles in file)
                                {
                                    Console.WriteLine(InFolderFiles);
                                }
                            }
                        }
                    }

                    //foreach (var files in filesInfo)
                    //{
                    //    Console.WriteLine(files + "... size: ");

                    //}
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
