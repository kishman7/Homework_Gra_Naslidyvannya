using System;

namespace Gra_Naslidyvannya
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            const int n = 3; // кількість гравців в команді
            int gamer = default;// учасник гри

            Unit [] green_team = new Unit[n]; //команда зелених
            Unit[] red_team = new Unit[n]; //команда червоних

            Teams(green_team, n, "Green"); // створення команди зелених
            Console.WriteLine("Team Greens.");
            for (int i = 0; i < n; i++)
            {
                green_team[i].ShowGamer(); // вивід команди зелених на екран
            }

            Teams(red_team, n, "Red");  // створення команди червені
            Console.WriteLine("Team Reds.");
            for (int i = 0; i < n; i++)
            {
                red_team[i].ShowGamer();
            }

            char space = 'y';
            int green_gamer = default;
            int red_gamer = default;
            int block = default;
            int count_dead_green = 0;
            int count_dead_red = 0;
            bool enter = true;
            while(enter)
            {
                Console.WriteLine();
                Console.WriteLine("Press the key \"y\" to start the battle");
                space = char.Parse(Console.ReadLine()); // розпарсуємо введені дані до типу char
                if (space == 'y')
                {
                    char team = default;
                    Console.WriteLine();
                    Console.WriteLine("Who will attack first? (g - green, r - red): ");
                    team = char.Parse(Console.ReadLine());
                    if (team == 'g')
                    {
                        Console.WriteLine("Attack team green!");
                        green_gamer = new Random().Next(1, 3);

                        Console.WriteLine("Choose which player of the red team you want to attack(1 - first, 2 - second, 3 - third): ");
                        int i = 0;
                        i = int.Parse(Console.ReadLine());
                        if (i >= 1 && i <= 3)
                        {
                            Draka(green_team[green_gamer], red_team[i-1]);  // емулюється бій
                            for (int j = 0; j < n; j++)
                            {
                                red_team[j].ShowGamer();
                            }
                            if (red_team[i-1].Hp <= 0)
                            {
                                count_dead_red++;
                                if (count_dead_red == 3)
                                {
                                    Console.WriteLine($"Win team green!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have chosen the wrong player number !!! Repeat your choice.");
                        }
                    }
                    if (team == 'r')
                    {
                        Console.WriteLine("Attack team red!");
                        red_gamer = new Random().Next(1, 3);

                        Console.WriteLine("Choose which player of the green team you want to attack(1 - first, 2 - second, 3 - third): ");
                        int i = 0;
                        i = int.Parse(Console.ReadLine());
                        if (i >= 1 && i <= 3)
                        {
                            Draka(red_team[red_gamer], green_team[i-1]);  // емулюється бій
                            for (int j = 0; j < n; j++)
                            {
                                green_team[j].ShowGamer();
                            }
                            if (green_team[i - 1].Hp <= 0)
                            {
                                count_dead_green++;
                                if (count_dead_green == 3)
                                {
                                    Console.WriteLine($"Win team red!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have chosen the wrong player number !!! Repeat your choice.");
                        }
                    }


                }


            }

        }

        static void Draka(Unit  green_team, Unit  red_team) // функція по веденню бою
        {
            Console.WriteLine($"{green_team.ShowUnit()} team {green_team.Teams} attack {red_team.ShowUnit()} team {red_team.Teams}");
            Console.WriteLine($"{green_team.ShowUnit()} team {green_team.Teams} to strike!");
            int block = new Random().Next(1, 10);
            if (block >= 1 && block <= 6)
            {
                Console.WriteLine($"{red_team.ShowUnit()} team {red_team.Teams} dodged the attack!");
            }
            else if (block >= 7 && block <= 10)
            {
                red_team.Hp -= green_team.Dmg;
                if (red_team.Hp <= 0)
                {
                    red_team.Death();
                }
                else
                {
                    Console.WriteLine($"{red_team.ShowUnit()} team {red_team.Teams} was injured and his life was reduced by {green_team.Dmg}");
                }
            }

        }

        static void Teams(Unit[] green_team, int n, string teams) // функція по створенню команд
        {
            int gamer = new Random().Next(1, 3); //рандомимо число від 1 до 3
            if (n==0)
            {
                return;
            }
            if (gamer==1)
            {
                green_team[n - 1] = new Swordsman(teams);
            }
            if (gamer == 2)
            {
                green_team[n - 1] = new Archer(teams);
            }
            if (gamer == 3)
            {
                green_team[n - 1] = new Mage(teams);
            }
            Teams(green_team, n - 1, teams);
        }

    }
}
