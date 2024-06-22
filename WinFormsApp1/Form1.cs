namespace WinFormsApp1
{
    /*Naloga 3

	Napiši program, ki ob kliku na "generiraj" generira 100 naključnih števil med -5000 in +5000 in jih 
	zapiše v tekstovno datoteko.
	če datoteka že obstaja, doda te številke na konec (datoteka se ves čas povečuje).
	Ob kliku na "analiziraj" se datoteka prebere & na zaslonu se prikaže:
		- število vseh števil v datoteki
		- največje število v datoteki
		- najmanjše števlo v datoteki
		- povprečna vrednost števil v datoteki
		- suma števil v datoteki
		- zmnožek števil v datoteki
		- izpiši 100 največjih števil
		
	Način prikaza rezultatov je poljuben.
	če je katera od teh vrednosti večja, kot pa jo premore tip bigint izpiši pri analizi "inf". 
	Zaželjeno je, da se zadeve lotiš objektno. Oz. da narediš vsaj razred za analize.

------------------------------------------------------------------------------------------------------------------*/

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string imeDatoteke = "C:\\Users\\alesj\\OneDrive\\Namizje\\stevila.txt";

            if (File.Exists(imeDatoteke))
            {
                string[] vseVrstice = File.ReadAllLines(imeDatoteke);
                int steviloStevil = vseVrstice.Length;
                label1.Text = $"Število vseh števil v datoteki: {steviloStevil}";
            }
            else
            {
                label1.Text = "Datoteka ne obstaja.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imeDatoteke = "C:\\Users\\alesj\\OneDrive\\Namizje\\stevila.txt";
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

            MessageBox.Show("Številke so bile uspešno generirane in dodane v datoteko.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] lines = File.ReadAllLines(@"C:\Users\alesj\OneDrive\Namizje\stevila.txt");
            long max = 0;
            long score = 0;
            foreach (String line in lines)
            {
                if (Int64.TryParse(line, out score))
                {
                    if (score > max)
                        max = score;
                }
            }
            MessageBox.Show("Maximum Score is " + max);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String[] lines = File.ReadAllLines(@"C:\Users\alesj\OneDrive\Namizje\stevila.txt");
            long min = 0;
            long score = 0;
            foreach (String line in lines)
            {
                if (Int64.TryParse(line, out score))
                {
                    if (score < min)
                        min = score;
                }
            }
            MessageBox.Show("Minimum Score is " + min);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to your text file
                string filePath = @"C:\Users\alesj\OneDrive\Namizje\stevila.txt";

                // Read all lines from the file
                String[] lines = File.ReadAllLines(filePath);

                // Initialize sum and count
                long sum = 0;
                int count = 0;
                long score = 0;

                // Iterate through each line
                foreach (String line in lines)
                {
                    // Try to parse the line as a long integer
                    if (Int64.TryParse(line, out score))
                    {
                        // Add the valid number to sum and increment the count
                        sum += score;
                        count++;
                    }
                }

                // Calculate the average
                double average = (count > 0) ? (double)sum / count : 0;

                // Display the average in a message box
                MessageBox.Show("Average number is " + average);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to your text file
                string filePath = @"C:\Users\alesj\OneDrive\Namizje\stevila.txt";

                // Read all lines from the file
                String[] lines = File.ReadAllLines(filePath);

                // Initialize sum
                long sum = 0;
                long score = 0;

                // Iterate through each line
                foreach (String line in lines)
                {
                    // Try to parse the line as a long integer
                    if (Int64.TryParse(line, out score))
                    {
                        // Add the valid number to sum
                        sum += score;
                    }
                }

                // Display the sum in a message box
                MessageBox.Show("The sum of numbers is " + sum);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\alesj\OneDrive\Namizje\stevila.txt";
            String[] lines = File.ReadAllLines(filePath);

            long product = 1;
            long score = 0;
            bool hasValidNumber = false;

            // Iterate through each line
            foreach (String line in lines)
            {
                // Try to parse the line as a long integer
                if (Int64.TryParse(line, out score))
                {
                    // Multiply the valid number to product
                    product *= score;
                    hasValidNumber = true;
                }
            }
            // Check if any valid number was found
            if (!hasValidNumber)
            {
                MessageBox.Show("No valid numbers found in the file.");
            }
            else
            {
                // Display the product in a message box
                MessageBox.Show("The product of numbers is " + product);
            }



        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // Specify the path to your text file
                string filePath = @"C:\Users\alesj\OneDrive\Namizje\stevila.txt";

                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Parse each line to get the numbers
                long[] numbers = new long[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    if (Int64.TryParse(lines[i], out long number))
                    {
                        numbers[i] = number;
                    }
                }

                // Sort the numbers in descending order
                Array.Sort(numbers);
                Array.Reverse(numbers);

                listBox1.Items.Clear();

                for (int i = 0; i < Math.Min(100, numbers.Length); i++)
                {
                    listBox1.Items.Add(numbers[i]);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

    


