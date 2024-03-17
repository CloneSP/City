using System;
using System.Collections.Generic;
using System.Linq;

namespace Slither
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                City city = CreateClasses();

                city.ShowCity();

                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static City CreateClasses()
        {
            List<Character> characters = new List<Character>();
            Character[] OnePiece =
            {
                new Character("Луффи"),
                new Character("Зоро"),
                new Character("Нами"),
                new Character("Усопп"),
                new Character("Санджи"),
                new Character("Нико Робин"),
                new Character("Фрэнки"),
                new Character("Брук"),
                new Character("Чоппер"),
                new Character("Джинбей"),
                new Character("Кинэмон"),
                new Character("Каррот"),
                new Character("Ямато"),
                new Character("Винсмоук"),
                new Character("Монки Д. Драгон"),

            };
            Character[] Naruto =
            {
                new Character("Наруто"),
                new Character("Саске"),
                new Character("Сакура"),
                new Character("Какаши"),
                new Character("Итачи"),
                new Character("Гаара"),
                new Character("Джирайя"),
                new Character("Орочимару"),
                new Character("Обито"),
                new Character("Минато"),
                new Character("Шикамару"),
                new Character("Рок ли"),
                new Character("Нейджи"),
                new Character("Темари"),
                new Character("Дейдара")


            };

            Anime[] animes =
            {
                new Anime("Ван Пис", OnePiece),
                new Anime("Наруто", Naruto)
            };



            City city = new City(animes);

            return city;
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
    public string Name { get; private set; }
    private Character[] _characters;
    public Anime(string name, Character[] characters)
    {
        Name = name;
        _characters = characters;
    }

    public Character GetCharacterByIndex(int index)
    {
        return _characters.ElementAt(index);
    }
    public int GetCharactersCount()
    {
        return _characters.Count();
    }

}
class City
{
    private Anime[] _animes;
    private Random _rand = new Random();
    private Anime _anime;

    private Character[] _characters;
    private Dictionary<string, string> _emptyCity = new Dictionary<string, string>();
    private Dictionary<string, string> _filledCity = new Dictionary<string, string>();
    public City(Anime[] animes)
    {
        _animes = animes;
        SetCityDictionary();
    }


    private Dictionary<string, string> SetCityDictionary()
    {

        _emptyCity.Add("Мэр", "");
        _emptyCity.Add("Полиция", "");
        _emptyCity.Add("Медицина", "");
        _emptyCity.Add("МЧС", "");
        _emptyCity.Add("Образование", "");
        _emptyCity.Add("Уборка", "");
        _emptyCity.Add("Строительство", "");
        _emptyCity.Add("Почта", "");

        foreach (var item in _emptyCity)
        {
            GetAnimeCharacters();
            string character = _characters[_rand.Next(0, _characters.Length)].Name;


            _filledCity.Add(item.Key, character);

            _characters = new Character[0];



        }


        return _filledCity;
    }
    public void ShowCity()
    {
        foreach (var item1 in _filledCity)
        {

            Console.WriteLine($"\n {item1.Key} - {item1.Value} ");
            Console.ReadKey();
        }
    }



    private void GetAnimeCharacters()
    {
        _anime = GetRandomAnime();
        for (int i = 0; i < _anime.GetCharactersCount(); i++)
        {
            Array.Resize(ref _characters, i + 1);
            _characters[i] = _anime.GetCharacterByIndex(i);
        }
    }
    private Anime GetRandomAnime()
    {
        Anime anime = _animes[_rand.Next(0, _animes.Length)];

        return anime;
    }

}

