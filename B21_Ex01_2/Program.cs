namespace B21_Ex01_2
{
    using System.Text;

    public class Program 
    {
        public static void Main() 
        {
            ////This is the entry point
            RunSandMachine();
            //// wait for enter
            System.Console.WriteLine("Please press 'Enter' to exit");
            System.Console.ReadLine();
        }

        public static void RunSandMachine() 
        {
            StringBuilder asterisks5SandMachine  = new StringBuilder();
            asterisks5SandMachine = DrawSandMachine(5, 0, asterisks5SandMachine);
            System.Console.WriteLine(asterisks5SandMachine);
        }
        
        public static StringBuilder DrawSandMachine(int i_StratingNumberofAsterisks, int i_NumberOfSpaces, StringBuilder i_SandMachine)
        {
            int halfOfAsterisks = i_StratingNumberofAsterisks / 2;
            if (i_NumberOfSpaces != i_StratingNumberofAsterisks)
            {
                int duplicateNumOfSpaces = 2 * i_NumberOfSpaces;
                if (halfOfAsterisks > i_NumberOfSpaces)
                {
                    i_SandMachine.AppendLine(new string(' ', i_NumberOfSpaces) + new string('*', i_StratingNumberofAsterisks - duplicateNumOfSpaces));
                }
                else
                {
                    i_SandMachine.AppendLine(new string(' ', i_StratingNumberofAsterisks - i_NumberOfSpaces - 1) + new string('*', duplicateNumOfSpaces - i_StratingNumberofAsterisks + 2));
                }

                DrawSandMachine(i_StratingNumberofAsterisks, i_NumberOfSpaces + 1, i_SandMachine);
            }
            
            return i_SandMachine;
        }
    }
}
