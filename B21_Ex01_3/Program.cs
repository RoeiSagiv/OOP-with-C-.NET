namespace B21_Ex01_3
{
    using System.Text;

    public class Program
    {
        public static void Main() 
        {
            ////This is the entry point
            string msg = string.Format("Please enter a number: ");
            System.Console.WriteLine(msg);
            string inputFromUser = System.Console.ReadLine();
            int validInput = CheckIfInputGood(inputFromUser);
            while(validInput == 0)
            {
                inputFromUser = System.Console.ReadLine();
                validInput = CheckIfInputGood(inputFromUser);
            }

            if (validInput > 0)
            {
                RunSandMachineByInput(inputFromUser);
            }
            //// Wait for enter
            System.Console.WriteLine("Please press 'Enter' to exit");
            System.Console.ReadLine();
        }
        
        public static int CheckIfInputGood(string i_FromUser) 
        {
            int fixedInput;
            bool goodInput = int.TryParse(i_FromUser, out fixedInput);
            
            if(goodInput) 
            {
                if(fixedInput % 2 == 0) 
                {
                    fixedInput += 1;
                }  
            }
            else
            {
                string msg = string.Format("Notice! your input {0} is invalid{1} Please enter a new number!", i_FromUser, System.Environment.NewLine);
                System.Console.WriteLine(msg);
            }

            return fixedInput;
        }
        
        public static void RunSandMachineByInput(string i_FromUser)
        {
            int validInput = CheckIfInputGood(i_FromUser);
            StringBuilder asterisksByInputSandMachine = new StringBuilder();
            asterisksByInputSandMachine = B21_Ex01_2.Program.DrawSandMachine(validInput, 0, asterisksByInputSandMachine);
            if(validInput > 0)
            {
                string msg = string.Format("This is your sandmachine with the number {0}: {1}", validInput, System.Environment.NewLine);
                System.Console.WriteLine(msg);
                System.Console.WriteLine(asterisksByInputSandMachine);
            }
        }
    }
}
