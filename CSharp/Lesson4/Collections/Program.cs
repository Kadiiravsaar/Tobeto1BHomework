

string[] names = new string[] {"Engin","Murat","Kerem","Halil" };

Console.WriteLine(names[0]);

//names[4] = "Kadir"; // hata verecektir. Sınırları vardır


List<string> names2 = new List<string> { "Engin", "Murat", "Kerem", "Halil" };
Console.WriteLine(names2[0]);

names2.Add("Kadir");

Console.WriteLine(names2[4]);