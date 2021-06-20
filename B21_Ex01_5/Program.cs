namespace B21_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            ////This is the entry point
            string msg1 = string.Format("Please enter a complete, positive number of size 6: ");
            System.Console.WriteLine(msg1);
            string inputFromUser = System.Console.ReadLine();
            while(!checkIfInputIsValid(inputFromUser))
            {
                string msgNoticeNotValid = string.Format("Notice! your input '{0}' is invalid! {1} Please enter a new positive, 6 figure number which consist only digits!", inputFromUser, System.Environment.NewLine);
                System.Console.WriteLine(msgNoticeNotValid);
                inputFromUser = System.Console.ReadLine();
            }
            
            if(checkIfInputIsValid(inputFromUser))
            {
                int maxDigit = maxDigitInInput(inputFromUser);
                string msg2 = string.Format("The max digit in the input '{0}' is: {1}", inputFromUser, maxDigit);
                System.Console.WriteLine(msg2);

                int minDigit = minDigitInInput(inputFromUser);
                string msg3 = string.Format("The min digit in the input '{0}' is: {1}", inputFromUser, minDigit);
                System.Console.WriteLine(msg3);

                int countOfDigitsDividedByThree = countDigitsDividedByThree(inputFromUser);
                string msg4 = string.Format("The number of digits divided by three in the input '{0}' is: {1}", inputFromUser, countOfDigitsDividedByThree);
                System.Console.WriteLine(msg4);

                int countOfNumberOfDigitsLargerThanUnityDigit = countNumberOfDigitsLargerThanUnityDigit(inputFromUser);
                string msg5 = string.Format("The number of digits which are larger than the unity digit in the input '{0}' is: {1}", inputFromUser, countOfNumberOfDigitsLargerThanUnityDigit);
                System.Console.WriteLine(msg5);
            }
           
            //// Wait for enter
            System.Console.WriteLine("Please press 'Enter' to exit");
            System.Console.ReadLine();
        }
        
        private static int maxDigitInInput(string i_StrFromUser)
        {
            int maxDigit = 0;
            int digitTestingForMax;
            int inputStrToInt;
            bool goodInput = int.TryParse(i_StrFromUser, out inputStrToInt);
            if (goodInput)
            {
                while (inputStrToInt != 0)
                {
                    digitTestingForMax = inputStrToInt % 10;
                    maxDigit = System.Math.Max(maxDigit, digitTestingForMax);
                    inputStrToInt = inputStrToInt / 10;
                }
            }
            
           return maxDigit;
        }
        
        private static int minDigitInInput(string i_StrFromUser)
        {
            int minDigit = 9;
            int digitTestingForMin;
            int inputStrToInt;

            bool goodInput = int.TryParse(i_StrFromUser, out inputStrToInt);
            if (goodInput)
            {
                while (inputStrToInt != 0)
                {
                    digitTestingForMin = inputStrToInt % 10;
                    minDigit = System.Math.Min(minDigit, digitTestingForMin);
                    inputStrToInt = inputStrToInt / 10;
                }
            }

            if (countZerosInStr(i_StrFromUser) != 0)
            {
                minDigit = 0;
            }

            return minDigit;
        }
        
        private static int countZerosInStr(string i_StrFromUser)
        {
            int countOfZerosInStr = 0;
            int iterator = 0;
                while(i_StrFromUser[iterator] == '0' && iterator < i_StrFromUser.Length)
                {
                    countOfZerosInStr++;
                    iterator++;
                }

            return countOfZerosInStr;
        }
        
        private static int countDigitsDividedByThree(string i_StrFromUser)
        {
            int digitTesting;
            int inputStrToInt;
            int countOfDigitsDividedByThree = 0;

            bool goodInput = int.TryParse(i_StrFromUser, out inputStrToInt);
            if (goodInput)
            {
                while (inputStrToInt != 0)
                {
                    digitTesting = inputStrToInt % 10;
                    if (isDigitDividedByThree(digitTesting))
                    {
                        countOfDigitsDividedByThree++;
                    }

                    inputStrToInt = inputStrToInt / 10;
                }
            }

            countOfDigitsDividedByThree += countZerosInStr(i_StrFromUser);
            return countOfDigitsDividedByThree;
        }
        
        private static bool isDigitDividedByThree(int i_DigitFromStr)
        {
            bool isDividedByThree = true;
            if(i_DigitFromStr % 3 != 0)
            {
                isDividedByThree = false;
            }
            
            return isDividedByThree;
        }
        
        private static int countNumberOfDigitsLargerThanUnityDigit(string i_StrFromUser)
        {
            int countOfNumberOfDigitsLargerThanUnityDigit = 0;
            int inputStrToInt;
            bool goodInput = int.TryParse(i_StrFromUser, out inputStrToInt);
            if (goodInput)
            {
                while (inputStrToInt != 0)
                {
                    int inputStrToIntDigit = inputStrToInt % 10;
                    if (isDigitLargerThanUnityDigit(i_StrFromUser, inputStrToIntDigit))
                    {
                        countOfNumberOfDigitsLargerThanUnityDigit++;
                    }

                    inputStrToInt = inputStrToInt / 10;
                }
            }

            return countOfNumberOfDigitsLargerThanUnityDigit;
        }
        
        private static bool isDigitLargerThanUnityDigit(string i_StrFromUser, int i_Digit)
        {
            bool isLargerThanUnity = true;
            int inputStrToInt;
            int unityDigit;
            bool goodInput = int.TryParse(i_StrFromUser, out inputStrToInt);
            if (goodInput)
            {
                unityDigit = inputStrToInt % 10;
                if(i_Digit <= unityDigit)
                {
                    isLargerThanUnity = false;
                }
            }

            return isLargerThanUnity;
        }
        
        private static bool checkIfInputIsValid(string i_StrFromUser)
        {
            bool isValid = true;
            if(!isInputIsOnlyDigits(i_StrFromUser) || !isInputIsSizeOfSix(i_StrFromUser))
            {
                isValid = false;
            }

            return isValid;
        }
 
        private static bool isInputIsSizeOfSix(string i_StrFromUser)
        {
            bool isSizeSix = true;
            int lengthOfInputStr = i_StrFromUser.Length;
            if(lengthOfInputStr != 6)
            {
                isSizeSix = false;
            }

            return isSizeSix;
        }
        
        private static bool isInputIsOnlyDigits(string i_StrFromUser)
        {
            bool isInputOnlyDigits = true;
            for(int i = 0; i < i_StrFromUser.Length; i++)
            {
                if(!char.IsDigit(i_StrFromUser[i]))
                {
                    isInputOnlyDigits = false;
                    break;
                }
            }

            return isInputOnlyDigits;
        }
    }
}
