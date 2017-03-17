using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnixTerminalSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
                Console.WriteLine(Directory.GetCurrentDirectory() + " : ");
            else
            {
                switch (args[0])
                {
                    case ("echo"):
                        {//Echo text command
                            if (args.Length < 3)
                                Console.WriteLine(args[1]);
                            else
                            {
                                StreamWriter nameOftheFile = new StreamWriter(args[3]);
                                nameOftheFile.WriteLine(args[1]);
                                nameOftheFile.Close();
                            }
                            break;
                        }
                    case ("cd"):
                        {
                            //Cd command
                            if (args[1] == "..")
                            {
                                string nameOfthePath = Directory.GetCurrentDirectory();
                                Console.WriteLine(nameOfthePath = nameOfthePath.Substring(0, nameOfthePath.LastIndexOf('\\')));
                                Directory.SetCurrentDirectory(nameOfthePath);

                            }
                            //absolute path
                            else if (Path.IsPathRooted(args[1]))
                            {
                                Console.WriteLine("Rooted path");
                                Directory.SetCurrentDirectory(args[1]);
                                Console.WriteLine(Directory.GetCurrentDirectory());
                            }
                            //cd file_name
                            else
                            {
                                string cale = Directory.GetCurrentDirectory();
                                cale = cale + '\\' + args[1];
                                Console.WriteLine(cale);
                            }
                            break;
                        }
                    case ("ls"):
                        {
                            //ls command
                            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                            foreach (DirectoryInfo d in dir.GetDirectories())
                            {
                                Console.WriteLine("{0, -50} {1}", d.Name, "directory");
                            }

                            foreach (FileInfo f in dir.GetFiles())
                            {
                                Console.WriteLine("{0, -50} {1}", f.Name, "file");
                            }
                            break;
                        }
                    case ("touch"):
                        {
                            //touch command
                            if (args[0] == "touch")
                            {
                                File.Create(args[1]);
                            }
                            break;
                        }
                    case ("mkdir"):
                        {
                            //mkdir command
                            if (args[0] == "mkdir")
                            {
                                Directory.CreateDirectory(args[1]);
                            }
                            break;
                        }
                    case ("pwd"):
                        {
                            //pwd command
                            if (args[0] == "pwd")
                            {
                                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                                Console.WriteLine(dir);
                            }
                            break;
                        }
                    case ("rm"):
                        {
                            //rm file_name command
                            if (args[0] == "rm")
                            {
                                File.Delete(args[1]);
                            }
                            break;
                        }
                    case ("rmdir"):
                        {
                            //rmdir directory_name command
                            if (args[0] == "rmdir")
                            {
                                Directory.Delete(args[1]);
                            }
                            break;
                        }
                    case ("tree"):
                        {
                            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                            foreach (DirectoryInfo d in dir.GetDirectories())
                            {
                                Console.WriteLine("|-{0}" , d.Name);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(Directory.GetCurrentDirectory() + " : ");
                            break;
                        }
                }
            }
        }
    }
}

