using System;
using System.Text;
using System.IO;

public class Student1 : IComparable
{
    public string familia;
    public string imia;
    public int nomer_zachetki;

    public Student1(string familia, string imia, int nomer_zachetki)
    {
        this.familia = familia;
        this.imia = imia;
        this.nomer_zachetki = nomer_zachetki;
    }

    public string ToString()
    {
        return string.Format("Фамилия: {0}  Имя: {1} Номер зачетной книжки: {2}", familia, imia, nomer_zachetki);
    }

    public int CompareTo(object o)
    {
        Student1 c = o as Student1;
        if (c != null)
        {
            int result = imia.CompareTo(c.imia);
            if (result != 0)
            {
                return result;
            }
            return nomer_zachetki.CompareTo(c.nomer_zachetki);
        }
        else
        {
            throw new Exception("Невозможно сравнить два объекта");
        }
    }

}

public class Kollege
{
    int cntStudents;
    public Student1[] Students;

    public Kollege(int cntStudents)
    {
        this.cntStudents = cntStudents;
        Students = new Student1[cntStudents];
    }

    public void Fill()
    {
        string familia;
        string imia;
        int nomer_zachetki;
        for (int i = 0; i < this.cntStudents; i++)
        {
            Console.WriteLine("Фамилия:");
            familia = Console.ReadLine();
            Console.WriteLine("Имя:");
            imia = Console.ReadLine();
            Console.WriteLine("Номер зачетной книжки:");
            nomer_zachetki = Convert.ToInt32(Console.ReadLine());
            this.Students[i] = new Student1(familia, imia, nomer_zachetki);
        }
    }

    public void Sort()
    {
        Array.Sort(this.Students);
    }

    public void PrintToFile()
    {
        using (StreamWriter file = new StreamWriter("result.txt", false, Encoding.UTF8))
        {
            foreach (Student1 c in this.Students)
            {
                file.WriteLine(c.ToString());
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Количество студентов:");
        int cntStudents = Convert.ToInt32(Console.ReadLine());
        Kollege kollege = new Kollege(cntStudents);
        kollege.Fill();
        kollege.Sort();
        kollege.PrintToFile();
    }
}