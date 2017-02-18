using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;


namespace PostcodeValidator
{
    class Program
    {
        private static string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string filename = "import_data.csv";
        private static string filenameValidationErrors = "failed_validation.csv";
        private static string filenameValidationSuccesses = "succeeded_validation.csv";

        static void Main(string[] args)
        {

            string headerLine = "";



            List<Postcode> lstSuccessfulPostcodesSorted = null;
            List<Postcode> lstFailedPostcodesSorted = null;


            //  Begin Task
            BeginTask();


            //  Decompress the .gz file
            DecompressGzFile();


            //  Create validation files
            CreateValidationFiles();


            //  Prcoess imported file from Google Drive
            ProcessImportFile(filename, ref headerLine, ref lstSuccessfulPostcodesSorted, ref lstFailedPostcodesSorted);


            //  Populate succeeded_validation.csv file
            PopulateSuccessfulValidationFile(ref lstSuccessfulPostcodesSorted, ref headerLine);


            //  Populate succeeded_validation.csv file
            PopulateFailedValidationFile(ref lstFailedPostcodesSorted, ref headerLine);


            //  End Task
            EndTask();

        }


        static void BeginTask()
        {
            //  Write to the console
            Console.WriteLine("Task started at " + DateTime.Now);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("");

            if (!File.Exists(directoryPath + filename + ".gz"))
            {
                //  import.gz file missing, write to console and exit
                Console.WriteLine("**** The file:  " + filename + " .gz is missing.  Please add this to the bin folder of your application and try again.");
                Console.WriteLine("");
                Console.Write("Press any key to exit....");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        static void EndTask()
        {
            //  End of task, write to console
            Console.WriteLine("");
            Console.WriteLine("Task complete at " + DateTime.Now);
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("");
            Console.Write('\u003A');
            Console.Write('\u0029');
            Console.Write("  Press any key to exit....");


            Console.ReadKey();
        }


        static void DecompressGzFile()
        {
            //  get directory
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);


            //  decompress any .gz files
            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }
        }


        static void PopulateSuccessfulValidationFile(ref List<Postcode> lstSuccessfulPostcodesSorted, ref string headerLine)
        {

            Byte[] content;
            Byte[] newline;

            using (FileStream fs = File.Create(directoryPath + filenameValidationSuccesses))
            {

                //  create header
                content = new UTF8Encoding(true).GetBytes(headerLine);
                fs.Write(content, 0, content.Length);
                newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);

                //  iterate through successful postcodes to create body
                foreach (Postcode successfulPostcode in lstSuccessfulPostcodesSorted)
                {
                    content = new UTF8Encoding(true).GetBytes(successfulPostcode.RowId + "," + successfulPostcode.Code);
                    fs.Write(content, 0, content.Length);
                    newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(newline, 0, newline.Length);
                }

            }

            Console.WriteLine("5.  Completed population of " + filenameValidationSuccesses);
        }

        static void PopulateFailedValidationFile(ref List<Postcode> lstFailedPostcodesSorted, ref string headerLine)
        {
            Byte[] content;
            Byte[] newline;

            using (FileStream fs = File.Create(directoryPath + filenameValidationErrors))
            {
                //  create header
                content = new UTF8Encoding(true).GetBytes(headerLine);
                fs.Write(content, 0, content.Length);
                newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                fs.Write(newline, 0, newline.Length);

                //  iterate through failed postcodes to create body
                foreach (Postcode failedPostcode in lstFailedPostcodesSorted)
                {
                    content = new UTF8Encoding(true).GetBytes(failedPostcode.RowId + "," + failedPostcode.Code);
                    fs.Write(content, 0, content.Length);
                    newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(newline, 0, newline.Length);
                }

            }

            Console.WriteLine("6.  Completed population of " + filenameValidationErrors);

        }

        static void ProcessImportFile(string filename, ref string headerLine, ref List<Postcode> lstSuccessfulPostcodesSorted, ref List<Postcode> lstFailedPostcodesSorted)
        {
            string line;
            Postcode objPostcode;
            Array arrLine;

            Console.WriteLine("4.  Begun processing import_data.csv");


            //  Create list for failed postcodes
            List<Postcode> lstSuccessfulPostcodes = new List<Postcode>();

            //  Create list for failed postcodes
            List<Postcode> lstFailedPostcodes = new List<Postcode>();


            //  stream the postcode file
            using (StreamReader reader = File.OpenText(directoryPath + filename))
            {

                //  skip header line
                headerLine = reader.ReadLine();

                while ((line = reader.ReadLine()) != null)
                {

                    //  split csv content by comma
                    arrLine = line.Split(',');

                    //  get postcode from second portion of array
                    objPostcode = new Postcode();
                    objPostcode.RowId = Convert.ToInt32(arrLine.GetValue(0));
                    objPostcode.Code = arrLine.GetValue(1).ToString();

                    //postcodeText = arrLine.GetValue(1).ToString();


                    if (Utilities.IsValidPostCode(objPostcode.Code))
                    {
                        //  valid, add to list
                        lstSuccessfulPostcodes.Add(objPostcode);
                    }
                    else
                    {

                        // failed, add to list
                        lstFailedPostcodes.Add(objPostcode);
                    }

                }
            }


            //  Sort records by row ID
            lstSuccessfulPostcodesSorted = lstSuccessfulPostcodes.OrderBy(o => o.RowId).ToList();
            lstFailedPostcodesSorted = lstFailedPostcodes.OrderBy(o => o.RowId).ToList();
        }

        static void CreateValidationFiles()
        {
            // Check if validation error file already exists. If yes, delete it. 
            if (File.Exists(directoryPath + filenameValidationErrors))
            {
                File.Delete(directoryPath + filenameValidationErrors);
            }

            Console.WriteLine("2.  Created file: failed_validation.csv");

            // Check if successes file already exists. If yes, delete it. 
            if (File.Exists(directoryPath + filenameValidationSuccesses))
            {
                File.Delete(directoryPath + filenameValidationSuccesses);
            }
            Console.WriteLine("3.  Created file: succeeded_validation.csv");


        }


        public static void Decompress(FileInfo fileToDecompress)
        {
            //  use GZipStream to decompress to .csv formt
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);

                        Console.WriteLine("1.  Decompressed file: import_data.csv.gz");
                    }
                }
            }
        }

        //public static void Compress(DirectoryInfo directorySelected)
        //{
        //    //  method not used but useful for testing
        //    foreach (FileInfo fileToCompress in directorySelected.GetFiles())
        //    {
        //        using (FileStream originalFileStream = fileToCompress.OpenRead())
        //        {
        //            if ((File.GetAttributes(fileToCompress.FullName) &
        //               FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
        //            {
        //                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
        //                {
        //                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
        //                       CompressionMode.Compress))
        //                    {
        //                        originalFileStream.CopyTo(compressionStream);

        //                    }
        //                }
        //                FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".gz");
        //                Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
        //                fileToCompress.Name, fileToCompress.Length.ToString(), info.Length.ToString());
        //            }

        //        }
        //    }
        //}
    }
}
