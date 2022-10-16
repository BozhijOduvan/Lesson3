using System.Text.RegularExpressions;

class Program
{
    public static int sc, size, result;
    public static List<int> list = new List<int>(size = 5);
    static void Recordinglements(int a)
    {
        if (sc == 5)
        {
            sc = 0;
            list.Clear();
        }
        {
            list.Insert(sc, a);
            ++sc;
        }
    }
    public static decimal Сompare(string expr)
    {
        var tk = Regex.Match(expr, @"^(?<leftOpr>\d+)(?<opr>[+-/*])(?<rigthOpr>\d+)$");
        var leftOpr = tk.Groups["leftOpr"];
        var opr = tk.Groups["opr"];
        var rigthOpr = tk.Groups["rigthOpr"];
        if (!leftOpr.Success)
        {
            throw new FormatException("левый операнд не удалось разобрать");
        }
        if (!opr.Success)
        {
            throw new FormatException("оператор не может быть проанализирован");
        }
        if (!rigthOpr.Success)
        {
            throw new FormatException("не удалось проанализировать правый операнд");
        }
        var left = int.Parse(leftOpr.Value);
        var right = int.Parse(rigthOpr.Value);
        switch (opr.Value)
        {
            case "*":
                result = left * right;
                break;
            case "/":
                if (right != 0)
                {
                    result = left / right;
                }
                else
                {
                    Console.WriteLine($"Деление на ноль невозможно!");
                }
                break;
            case "-":
                result = left - right;
                break;
            case "+":
                result = left + right;
                break;
            default:
                throw new FormatException(opr.Value + " является недопустимым оператором");
        }
        return result;
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"Данный мини калькулятор позволяет записывать выражения в одну строчку:");
        Console.WriteLine($"Пример использования: 6+6 или 7*5 и.т.д ");
        char restart;
        do
        {
            Console.WriteLine("Введите выражение:");
            string k;
            k = Console.ReadLine();
            Console.WriteLine(Сompare(k));
            Recordinglements(result);
            if (sc == 5)
            {
                Console.WriteLine("Вывод последних 5 результатов:");
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine(list[i]);
            }
            Console.WriteLine("Продолжим? (Y/N)");
            restart = Convert.ToChar(Console.ReadLine());
            restart = char.ToUpper(restart);
        }
        while (restart == 'Y');
    }
}

