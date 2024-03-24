namespace APBD1;

class Program
{
    static void Main(string[] args)
    {
        int[] intArray = {1, 2, 6};
        int average = Average(intArray);

        Console.WriteLine(average);
    }

    public static int Average(params int[] intArray)
    {
        int sum = 0;

        for (int i = 0; i < intArray.Length; i++)
        {
            sum += intArray[i];
        }

        return sum / intArray.Length;
    }
}