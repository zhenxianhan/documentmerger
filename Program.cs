using System;
using System.IO;


namespace Documentmerger
{
    class Program
    {
        static void Main(string[] args)
        {


            void check()
            {
                Console.WriteLine("Document Merger\n");

                String firstdocument = " ";
                String seconddocument = " ";
                bool check1 = true;
                do
                {
                    if (check1)
                    {
                        check1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename. Pleasea enter again");
                    }
                    Console.WriteLine("Please enter the first filename to be merge:");
                    firstdocument = Console.ReadLine();
                } while (firstdocument.Length == 0 || !File.Exists(firstdocument));
                check1 = true;
                do
                {
                    if (check1)
                    {
                        check1 = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid filename, Pleasea enter again.");
                    }
                    Console.WriteLine("Please enter the second filename to be merge:");
                    seconddocument = Console.ReadLine();
                } while (seconddocument.Length == 0 || !File.Exists(seconddocument));

                String merged = firstdocument.Substring(0, firstdocument.Length - 4) + seconddocument;

                StreamWriter writer = null;
                StreamReader reader = null; 
                StreamReader reader2 = null; 

    

                int count = 0;

                try
                {
                    writer = new StreamWriter(merged);
                    reader = new StreamReader(firstdocument); 
                    reader2 = new StreamReader(seconddocument);

                    string line = null;
                    while ((line = reader.ReadLine()) != null) 
                    {

                        count += line.Length;
                        writer.WriteLine(line);
                    }

                    while ((line = reader2.ReadLine()) != null) 
                    {

                        count += line.Length;
                        writer.WriteLine(line);
                    }

                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                    if (reader != null)
                        reader.Close();
                    if (reader2 != null)
                        reader2.Close();

                        Console.WriteLine(merged + " was successfully saved. The document contains " + count + " characters."); 
                }
            }




            do
            {
                check();
                Console.WriteLine("Would you like to merge two more files? (y/n)");
                char more = Console.ReadLine()[0];
                if (more == 'n')
                    break;
            } while (true);
        }
    }
}