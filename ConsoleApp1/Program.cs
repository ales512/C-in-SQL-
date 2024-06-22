using System;
using System.IO;

class Program
{
    static void Main()
    {

        string imeDatoteke = "C:\\Users\\Ales\\OneDrive\\Desktop\\stevila.txt";
        Random random = new Random();
        int[] stevila = new int[100];
        for (int i = 0; i < 100; i++)
        {
            stevila[i] = random.Next(-5000, 5000);
        }
        using (StreamWriter sw = new StreamWriter(imeDatoteke, true))
        {
            foreach (int stevilo in stevila)
            {
                sw.WriteLine(stevilo);
            }
        }

        Console.WriteLine("Številke so bile uspešno generirane in dodane v datoteko.");

    }
}