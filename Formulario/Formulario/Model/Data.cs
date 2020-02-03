using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Formulario.Model
{
    class Data
    {
        List<User> users = new List<User>();
  

        public List<User> getList()
        {
            return users;
        }

        public void Read()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("..\\..\\ejemplo.txt");

                line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    String[] info = line.Split(';');
                    users.Add(new User()
                    {
                        Name = info[0],
                        LastName = info[1],
                        Email = info[2],
                        Celphone = info[3]
                    });

                }

                sr.Close();
                //Console.ReadLine();
                Thread.Sleep(4000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void Write (User item)
        {
            try
            {

                StreamWriter sw = new StreamWriter("..\\..\\ejemplo.txt", true);

                

                sw.WriteLine(
                        item.Name + ";" +
                        item.LastName + ";" +
                        item.Email + ";" +
                        item.Celphone);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}

