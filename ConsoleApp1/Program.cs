using System;

namespace ConsoleApp1
{
    /// <summary>
    ///сущность данной проги
    /// </summary>
    class colledj 
    {
        static void Main (string [] args)
        {
            Kadrovik kadrovik = new Kadrovik("Каретин Сергей Васильевич");
            Console.WriteLine(kadrovik.PoluchitImia());
            Console.WriteLine(kadrovik.GetDoljnost() + "\n");

            Student student = kadrovik.GetCosdaetStudent("Гусев Даниил Дмитриевич", "3-1П9");
            Console.WriteLine(student.PoluchitImia());
            Console.WriteLine(student.GetZayavlen());
            Console.WriteLine(student.GetGroup() + "\n");

            Teacher newTeacher = kadrovik.GetCosdaetTeacher("Герасимова Анна Владимировна", Rank.Assistant);
            Console.WriteLine(newTeacher.PoluchitImia());
            Console.WriteLine(newTeacher.GetDoljnost() + "\n");

            Teacher teacher = new Teacher("Журавлева Ольга Дмитриевна", Rank.StLecturer);
            Console.WriteLine(teacher.PoluchitImia());
            Console.WriteLine(teacher.GetDoljnost());
            Console.WriteLine(teacher.GetLekcee() + "\n");
        }
    }
}

/// <summary>
/// Перечисление для задания ранга преподавателя
/// </summary>
public enum Rank
{
    Assistant = 0,
    StLecturer = 1
}
/// <summary>
/// Интерфейс, задающий метод для проведения лекций преподавателем
/// </summary>
interface ILekcee : IDoljnost
{
    string GetLekcee();
}
/// <summary>
/// Интерфейс, задающий метод для создания студентов и преподавателей (учителей)
/// </summary>
interface ICosdaet : IDoljnost
{
    Student GetCosdaetStudent(string name, string group);
    Teacher GetCosdaetTeacher(string name, Rank doljnost);
}
/// <summary>
/// Интерфейс, задающий метод для получения должности сотрудника
/// </summary>
interface IDoljnost : Imia
{
    string GetDoljnost();
}

/// <summary>
/// Интерфейс, задающий метод для получения учебной группы студента
/// </summary>
interface IGroup : Imia
{
    string GetGroup();
}

/// <summary>
/// Интерфейс, задающий метод для подания заявления об отчислении студента
/// </summary>
interface IZayava : IGroup
{
    string GetZayavlen();
}
/// <summary>
/// мы здесь получаем имя
/// интерфейс, для получения имени 
/// </summary>
interface Imia
{
    string PoluchitImia();
}
/// <summary>
/// класс описывающий человека
/// </summary>
abstract class Person : Imia
{
    public string Name { get; set;}

    public Person(string name)
    {
        Name = name;
    }
/// <summary>
/// возвращаем строку Name, чтобы получить имя человека
/// </summary>
    public string PoluchitImia()
    {
        return Name; 

    }
}
/// <summary>
/// класс описывающий студента 
/// </summary>

/// <summary>
/// Абстрактный класс, описывающий сотрудников
/// </summary>
abstract class Sotrudnik : Person
{
    public string Doljnost { get; set; }

    public Sotrudnik(string name, string doljnost) : base(name)
    {
        Doljnost = doljnost;
    }

    public string GetDoljnost()
    {
        return Doljnost;
    }
}

class Student : Person, IZayava
{
    public string Group { get; set; }
    /// <summary>
    /// констуктор, который задает имя и группу студента
    /// </summary>
    public Student(string name, string group) : base(name) 
    {
        Group = group;
    }

    public string GetGroup()
    {
        return Group;
    }

    public string GetZayavlen()
    {
        return $"Заявыление на отчисление на имя: {Name}";
    }
}
/// <summary>
/// Класс, описывающий преподавателей (учителей)
/// </summary>
class Teacher : Sotrudnik, ILekcee
{
    static string[] doljnost = new string[] { "Ассистент", "Старший преподаватель" };

    public Teacher(string name, Rank RankOfTheTeacher) : base(name, doljnost[(int)RankOfTheTeacher]) { }

    public string GetLekcee()
    {
        return "Проводит лекции";
    }
}

/// <summary>
/// Класс, описывающий кадровиков
/// </summary>
class Kadrovik : Sotrudnik, ICosdaet
{
    public Kadrovik(string name) : base(name, "кадровик") { }

    public Student GetCosdaetStudent(string name, string group)
    {
        return new Student(name, group);
    }

    public Teacher GetCosdaetTeacher(string name, Rank doljnost)
    {
        return new Teacher(name, doljnost);
    }
}
