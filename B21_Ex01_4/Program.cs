namespace B21_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            ////This is the entry point
            string msg1 = string.Format("Please enter a string: ");
            System.Console.WriteLine(msg1);
            string inputFromUser = System.Console.ReadLine();
            while(!checkIfInputValid(inputFromUser)) 
            {
                System.Console.WriteLine(msg1);
                inputFromUser = System.Console.ReadLine();
            }
            
            if(checkIfInputValid(inputFromUser))
            {
                bool isPal = checkIfPal(inputFromUser);
                string msg2 = string.Format("The input '{0}' is palindrom: {1}", inputFromUser, isPal);
                System.Console.WriteLine(msg2);

                bool isDividedByFour = checkIfDividedByFour(inputFromUser);
                string msg3 = string.Format("The input '{0}' is divided by four: {1}", inputFromUser, isDividedByFour);
                System.Console.WriteLine(msg3);

                int countOfUpperCase = countUpperCase(inputFromUser);
                string msg4 = string.Format("The number of upper cases in '{0}' is: {1}", inputFromUser, countOfUpperCase);
                System.Console.WriteLine(msg4);
            }

            //// Wait for enter
            System.Console.WriteLine("Please press 'Enter' to exit");
            System.Console.ReadLine();
        }

        private static bool checkIfPal(string i_StrFromUser)
        {
            bool isPal = true;
            int lengthOfInput = i_StrFromUser.Length;
            if (lengthOfInput != 0)
            {
                isPal = palRecursive(i_StrFromUser, 0, lengthOfInput - 1);
            }

            return isPal;
        }
        
        private static bool palRecursive(string i_StrFromUser, int i_StartIndex, int i_EndIndex)
        {
            bool isPal = true;
            if (i_StrFromUser[i_StartIndex] != i_StrFromUser[i_EndIndex])
            {
                isPal = false;
            }
            else if (i_StartIndex > i_EndIndex)
            {
                isPal = true;
            }
            else
            {
                isPal = palRecursive(i_StrFromUser, i_StartIndex + 1, i_EndIndex - 1);
            }

            return isPal;
        }
        
        private static bool checkIfDividedByFour(string i_StrFromUser)
        {
            bool isDevidedByFour = true;
            if (!checkIfInputIsOnlyNumbers(i_StrFromUser))
            {
                System.Console.WriteLine("To check if the input is divided by four the input need to be only digits");
                isDevidedByFour = false;
            }

            int inputIsNumber;
            bool goodInput = int.TryParse(i_StrFromUser, out inputIsNumber);
            if (goodInput)
            {
                if (inputIsNumber % 4 != 0) 
                {
                    isDevidedByFour = false;
                }
            }

            return isDevidedByFour;
        }
        
        private static int countUpperCase(string i_StrFromUser)
        {
            int countOfUpperCase = 0;
            if (checkIfInputIsOnlyLetters(i_StrFromUser))
            {
                for (int i = 0; i < i_StrFromUser.Length; i++)
                {
                    if (char.IsUpper(i_StrFromUser[i]))
                    {
                        countOfUpperCase++;
                    }
                }
            }

            return countOfUpperCase;
        }
        
        private static bool checkIfInputValid(string i_StrFromUser)
        {
            bool inputValid = true;
            if (!checkIfInputIsSizeTen(i_StrFromUser)) 
            {
                inputValid = false;
                string msg1 = string.Format("Notice! your input '{0}' is invalid! {1} Please enter a new string of size 10!", i_StrFromUser, System.Environment.NewLine);
                System.Console.WriteLine(msg1);
            }
            
            if (!checkIfInputIsOnlyLetters(i_StrFromUser) && !checkIfInputIsOnlyNumbers(i_StrFromUser)) 
            {
                inputValid = false;
                string msg2 = string.Format("Notice! your input '{0}' is invalid! {1} Please enter a new string which consist only letters or only numbers!", i_StrFromUser, System.Environment.NewLine);
                System.Console.WriteLine(msg2);
            }

            return inputValid;
        }
        
        private static bool checkIfInputIsSizeTen(string i_StrFromUser)
        {
            bool isSizeTen = true;
            int lengthOfInputStr = i_StrFromUser.Length;
            if (lengthOfInputStr != 10)
            {
                isSizeTen = false;
            }

            return isSizeTen;
        }
        
        private static bool checkIfInputIsOnlyNumbers(string i_StrFromUser)
        {
            bool isInputOnlyNumbers = true;
            for (int i = 0; i < i_StrFromUser.Length; i++)
            {
                if (!char.IsDigit(i_StrFromUser[i]))
                {
                    isInputOnlyNumbers = false;
                    break;
                }
            }

            return isInputOnlyNumbers;
        }
        
        private static bool checkIfInputIsOnlyLetters(string i_StrFromUser)
        {
            bool isInputOnlyLetters = true;
            for (int i = 0; i < i_StrFromUser.Length; i++)
            {
               if (!char.IsLetter(i_StrFromUser[i])) 
                {
                    isInputOnlyLetters = false;
                    break;
                }
            }

            return isInputOnlyLetters;
        }
    }
}
