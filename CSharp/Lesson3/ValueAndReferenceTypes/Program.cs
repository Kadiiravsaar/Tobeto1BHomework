int number1 = 10; // 30 
int number2 = 30; // 65

number1 = number2;
number2 = 65;


Console.WriteLine(number1);


int[] numbers1 = new int[] { 10, 20, 3 };
int[] numbers2 = new int[] { 100, 200, 300 };
numbers1 = numbers2;
numbers2[0] = 999;
Console.WriteLine(numbers1[0]); //999