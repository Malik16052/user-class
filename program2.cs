using System;

class Program
{
    static void Main()
    {
        User[] users = new User[3];

        for (int i = 0; i < users.Length; i++)
        {
            Console.WriteLine($"\n--- {i + 1}. İstifadəçi məlumatları ---");

            Console.Write("Fullname: ");
            string fullname = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            string password;
            User newUser;

            while (true)
            {
                Console.Write("Password: ");
                password = Console.ReadLine();

                // Şərtləri yoxlayaq
                User tempUser = new User(email, password);

                if (tempUser.PasswordChecker(password))
                {
                    newUser = tempUser;
                    break;
                }
                else
                {
                    Console.WriteLine("Şifrə tələblərə cavab vermir! Yenidən daxil edin.");
                }
            }

            newUser.Fullname = fullname;

            Console.Write("Age: ");
            newUser.Age = int.Parse(Console.ReadLine());

            users[i] = newUser;
        }

        // MENYU hissəsi
        while (true)
        {
            Console.WriteLine("\n--- MENYU ---");
            Console.WriteLine("1. Show all users");
            Console.WriteLine("2. Get info by id");
            Console.WriteLine("0. Quit");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.WriteLine("\nBütün istifadəçilər:");
                foreach (User user in users)
                {
                    Console.WriteLine(user.GetInfo());
                }
            }
            else if (secim == "2")
            {
                Console.Write("Id daxil edin: ");
                int id = int.Parse(Console.ReadLine());
                bool tapildi = false;

                foreach (User user in users)
                {
                    if (user.Id == id)
                    {
                        Console.WriteLine(user.GetInfo());
                        tapildi = true;
                        break;
                    }
                }

                if (!tapildi)
                    Console.WriteLine("Bu id-li istifadəçi tapılmadı!");
            }
            else if (secim == "0")
            {
                Console.WriteLine("Proqram bitdi!");
                break;
            }
            else
            {
                Console.WriteLine("Yanlış seçim!");
            }
        }
    }
}
