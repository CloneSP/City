using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Collections;

namespace Slither
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<Character> characters = new List<Character>();
                Character[] OnePiece =
                {
                new Character("Лу ффи"),
                new Character("Зоро"),
                new Character("Нами"),
                new Character("Усопп"),
                new Character("Санджи "),
                new Character("Нико Робин"),
                new Character("Фрэнки "),
                new Character("Брук "),
                new Character("Чоппер "),
                new Character("Джинбей "),
                new Character("Кинэмон "),
                new Character("Каррот "),
                new Character("Ямато  "),
                new Character("Винсмоук  "),
                new Character("Монки Д. Драгон "),

            };
                Character[] Naruto =
                {
                new Character("Наруто "),
                new Character("Саске "),
                new Character("Сакура "),
                new Character("Какаши "),
                new Character("Итачи "),
                new Character("Гаара "),
                new Character("Джирайя "),
                new Character("Орочимару "),
                new Character("Обито "),
                new Character("Минато "),
                new Character("Шикамару "),
                new Character("Рок ли "),
                new Character("Нейджи "),
                new Character("Темари "),
                new Character("Дейдара ")


            };

                Anime[] animes =
                {
                new Anime("Ван Пис", OnePiece),
                new Anime("Наруто", Naruto)
            };

                City city = new City(animes);

                city.SetCityDictionary();
                city.ShowCity();
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }


    }
    class Character
    {
        public string Name { get; private set; }
        public Character(string name)
        {
            Name = name;
        }
    }
    class Anime
    {
        string Name;
        public Character[] Characters;
        public Anime(string name, Character[] characters)
        {
            Name = name;
            Characters = characters;
        }

    }
    class City
    {
        Anime[] Animes;
        Random rand = new Random();
        public Dictionary<string, string> city = new Dictionary<string, string>();
        public Dictionary<string, string> city1 = new Dictionary<string, string>();
        public City(Anime[] animes)
        {
            Animes = animes;
        }
        public Dictionary<string, string> SetCityDictionary()
        {

            city.Add("Мэр", "");
            city.Add("Полиция", "");
            city.Add("Медицина", "");
            city.Add("МЧС", "");
            city.Add("Образование", "");
            city.Add("Уборка", "");
            city.Add("Строительство", "");
            city.Add("Почта", "");

            foreach (var item in city)
            {
                int animeId = ChangeRandomAnime();

                string character = Animes[animeId].Characters[rand.Next(0, Animes[animeId].Characters.Length)].Name;
                string modifiedValue = character + item.Value;

                city1.Add(item.Key, modifiedValue);


            }



            return city1;
        }

        public int ChangeRandomAnime()
        {
            int anime = rand.Next(0, Animes.Length); ;
            return anime;
        }
        public void ShowCity()
        {
            foreach (var item1 in city1)
            {

                Console.WriteLine($" {item1.Key} - {item1.Value} \n");
                Console.ReadKey();
            }
        }
    }
}
