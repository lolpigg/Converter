using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace convert
{
    public class Read
    {
        public static void Reading()
        {
            string path, txt, secondpath;
            List<Figures> figures = new List<Figures>();
            path = Path();
            txt = File.ReadAllText(path);
            if (path[path.Length - 1] == 't')
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i += 3)
                {
                    figures.Add(new Figures(
                        lines[i],
                        Convert.ToInt16(lines[i + 1]),
                        Convert.ToInt16(lines[i + 2])));
                }
            }
            else if (path[path.Length - 1] == 'l')
            {
                using (FileStream filestream = new FileStream(path, FileMode.Open))
                {
                    List<Figures> linesxml = new List<Figures>();
                    var xmlser = new XmlSerializer(typeof (List <Figures>));
                    linesxml = (List<Figures>)xmlser.Deserialize(filestream);
                    figures = linesxml;
                }
            }
            else if (path[path.Length - 1] == 'n')
            {
                figures = JsonConvert.DeserializeObject<List<Figures>>(path);
            }
            Console.WriteLine("F1 - Сохранить в виде txt, json, xml. Esc - Выход из программы.\n");
            foreach (var item in figures)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Height);
                Console.WriteLine(item.Width);
            }
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.F1 && key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите путь до файла вместе с названием.");
                secondpath = Console.ReadLine();
                if (secondpath[secondpath.Length - 1] == 't')
                {
                    foreach (var item in figures)
                    {
                            if (figures.IndexOf(item) == 0)
                            {
                                File.WriteAllText(secondpath, $"{item.Name}\n{item.Height}\n{item.Width}");
                            }
                            else
                            {
                                File.AppendAllText(secondpath, $"\n{item.Name}\n{item.Height}\n{item.Width}");
                            }
                    }
                }
                else if (secondpath[secondpath.Length - 1] == 'l')
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Figures>));
                    using (FileStream fileStream = new FileStream(secondpath, FileMode.OpenOrCreate))
                    {
                        xml.Serialize(fileStream, figures);
                    }
                }
                else if (secondpath[secondpath.Length - 1] == 'n')
                {
                    string json = JsonConvert.SerializeObject(figures);
                    File.WriteAllText(secondpath, json);
                }
                Console.WriteLine("Конвертация прошла успешно. Спасибо за использование нашей программы!");
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Вы вышли из программы.");
                Environment.Exit(0);
            }
        }
        private static string Path()
        {
            string path;
            do
            {
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.WriteLine("Файл не найден. Введите снова.");
                }
            } while (!File.Exists(path));
            Console.Clear();
            return path;
        }
    }
}
