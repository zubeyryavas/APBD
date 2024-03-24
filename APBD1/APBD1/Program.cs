namespace APBD1;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = {1, 2, 5, 6, 5, 5};
     

        Console.WriteLine("Average value is " + Average(intArray));
        Console.WriteLine("Max value is " + FindMax(intArray));
    }

    public static int Average(params int[] intArray)
    {
        int total = 0;

        for (int i = 0; i < intArray.Length; i++)
        {
            total += intArray[i];
        }

        return total / intArray.Length;
    }

    public static int FindMax(params int[] intArray)
    {
        int maxInt = Int32.MinValue;

        for (int i = 0; i < intArray.Length; i++)
        {
            int value = intArray[i];
            if (value > maxInt)
            {
                maxInt = value;
            }
        }
        return maxInt;
    }
}
