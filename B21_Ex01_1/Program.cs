namespace B21_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
        ////This is the entry point
            string msg1 = string.Format("Please enter the {0} binary number with 7: ", "first");
            System.Console.WriteLine(msg1);
            string firstBinaryNum = System.Console.ReadLine();
            string msg2 = string.Format("Please enter the {0} binary number with 7: ", "second");
            System.Console.WriteLine(msg2);
            string secondBinaryNum = System.Console.ReadLine();
            string msg3 = string.Format("Please enter the {0} binary number with 7: ", "third");
            System.Console.WriteLine(msg3);
            string thirdBinaryNum = System.Console.ReadLine();

            while(!checkIfInputIsValid(firstBinaryNum) || !checkIfInputIsValid(secondBinaryNum) || !checkIfInputIsValid(thirdBinaryNum))
            {
                string msgNoticeNotValid = string.Format("Notice! your input is invalid! {0} Please enter a new binary, 7 figure number!", System.Environment.NewLine);
                System.Console.WriteLine(msgNoticeNotValid);
                System.Console.WriteLine(msg1);
                firstBinaryNum = System.Console.ReadLine();
                System.Console.WriteLine(msg2);
                secondBinaryNum = System.Console.ReadLine();
                System.Console.WriteLine(msg3);
                thirdBinaryNum = System.Console.ReadLine();
            }

            if(checkIfInputIsValid(firstBinaryNum) && checkIfInputIsValid(secondBinaryNum) && checkIfInputIsValid(thirdBinaryNum))
            {
                RunBinarySeries(firstBinaryNum, secondBinaryNum, thirdBinaryNum);

                float averageUnity = averageForUnity(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg4 = string.Format("The average of the unity in all the 3 numbers you entered is: {0}{1}", averageUnity, System.Environment.NewLine);
                System.Console.WriteLine(msg4);

                float averageZeros = averageForZeros(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg5 = string.Format("The average of the zeros in all the 3 numbers you entered is: {0}{1}", averageZeros, System.Environment.NewLine);
                System.Console.WriteLine(msg5);

                int countPowerOfTwo = countOfPowerOfTwo(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg6 = string.Format("The number of decimal representation which is power of two is: {0}{1}", countPowerOfTwo, System.Environment.NewLine);
                System.Console.WriteLine(msg6);

                int countAscendingSeries = countOfAscendingSeriesInDecimalNumber(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg7 = string.Format("The number of decimal representation which is ascending series is: {0}{1}", countAscendingSeries, System.Environment.NewLine);
                System.Console.WriteLine(msg7);

                int maxNum = maxNumber(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg8 = string.Format("The maximum number is: {0}{1}", maxNum, System.Environment.NewLine);
                System.Console.WriteLine(msg8);

                int minNum = minNumber(firstBinaryNum, secondBinaryNum, thirdBinaryNum);
                string msg9 = string.Format("The minimum number is: {0}{1}", minNum, System.Environment.NewLine);
                System.Console.WriteLine(msg9);
            }
            //// wait for enter

            System.Console.WriteLine("Please press 'Enter' to exit");
            System.Console.ReadLine();
        }

        public static void RunBinarySeries(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int resultedDecimalNum1 = binaryStringToDecimal(i_FirstBinaryNum);
            string msg1 = string.Format("The first binary number in decimal: {0}{1}", resultedDecimalNum1, System.Environment.NewLine);
            System.Console.WriteLine(msg1);
            int resultedDecimalNum2 = binaryStringToDecimal(i_SecondBinaryNum);
            string msg2 = string.Format("The second binary number in decimal: {0}{1}", resultedDecimalNum2, System.Environment.NewLine);
            System.Console.WriteLine(msg2);
            int resultedDecimalNum3 = binaryStringToDecimal(i_ThirdBinaryNum);
            string msg3 = string.Format("The third binary number in decimal: {0}{1}", resultedDecimalNum3, System.Environment.NewLine);
            System.Console.WriteLine(msg3);
        }

        private static int binaryStringToDecimal(string i_BinaryNum)
        {
            int sumDecimalNum = 0;

            for (int i = 0; i < i_BinaryNum.Length; i++)
            {
                char charFromBinaryNum = i_BinaryNum[i];
                sumDecimalNum += (int)System.Math.Pow(2, i_BinaryNum.Length - 1 - i) * (int)(charFromBinaryNum - '0');
            }

            return sumDecimalNum;
        }

        private static float averageForUnity(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int countUnity = 0;
            float averageUnity;
            int lengthBinaryNum = i_FirstBinaryNum.Length;

            for (int i = 0; i < lengthBinaryNum; i++)
            {
                char charFromBinaryNum1 = i_FirstBinaryNum[i];
                char charFromBinaryNum2 = i_SecondBinaryNum[i];
                char charFromBinaryNum3 = i_ThirdBinaryNum[i];
                if (charFromBinaryNum1 == '1')
                {
                    countUnity++;
                }

                if (charFromBinaryNum2 == '1')
                {
                    countUnity++;
                }

                if (charFromBinaryNum3 == '1')
                {
                    countUnity++;
                }
            }

            averageUnity = countUnity / 3f;

            return averageUnity;
        }

        private static float averageForZeros(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            float averageUnity = averageForUnity(i_FirstBinaryNum, i_SecondBinaryNum, i_ThirdBinaryNum);
            float totalUnity = averageUnity * 3;

            float totalZeros = 21 - totalUnity;
            float averageZeros = totalZeros / 3f;

            return averageZeros;
        }

        private static int countOfPowerOfTwo(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int countPowerOfTwo = 0;

            int decimalNum1 = binaryStringToDecimal(i_FirstBinaryNum);
            int decimalNum2 = binaryStringToDecimal(i_SecondBinaryNum);
            int decimalNum3 = binaryStringToDecimal(i_ThirdBinaryNum);
            if (isPowerOfTwo(decimalNum1))
            {
                countPowerOfTwo++;
            }

            if (isPowerOfTwo(decimalNum2))
            {
                countPowerOfTwo++;
            }

            if (isPowerOfTwo(decimalNum3))
            {
                countPowerOfTwo++;
            }

            return countPowerOfTwo;
        }

        private static bool isPowerOfTwo(int i_DecimalNum)
        {
            bool isPowerOfTwo = true;
            if (i_DecimalNum == 0)
            {
                isPowerOfTwo = false;
            }

            while (i_DecimalNum != 1)
            {
                if (i_DecimalNum % 2 != 0)
                {
                    isPowerOfTwo = false;
                }

                i_DecimalNum /= 2;
            }
               
            return isPowerOfTwo;
        }

        private static int countOfAscendingSeriesInDecimalNumber(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int countAscendingSeries = 0;

            int decimalNum1 = binaryStringToDecimal(i_FirstBinaryNum);
            int decimalNum2 = binaryStringToDecimal(i_SecondBinaryNum);
            int decimalNum3 = binaryStringToDecimal(i_ThirdBinaryNum);

            string strNum1 = decimalNum1.ToString();
            string strNum2 = decimalNum2.ToString();
            string strNum3 = decimalNum3.ToString();
            if (isAscendingDecimalNumber(strNum1))
            {
                countAscendingSeries++;
            }

            if (isAscendingDecimalNumber(strNum2))
            {
                countAscendingSeries++;
            }

            if (isAscendingDecimalNumber(strNum3))
            {
                countAscendingSeries++;
            }

            return countAscendingSeries;
        }

        private static bool isAscendingDecimalNumber(string i_StrDecimalNum)
        {
            bool isAscendingSeries = true;
            for (int i = 0; i < i_StrDecimalNum.Length - 1; i++)
            {
                if (i_StrDecimalNum[i] >= i_StrDecimalNum[i + 1])
                {
                    isAscendingSeries = false;
                }
            }

            return isAscendingSeries;
        }

        private static int maxNumber(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int decimalNum1 = binaryStringToDecimal(i_FirstBinaryNum);
            int decimalNum2 = binaryStringToDecimal(i_SecondBinaryNum);
            int decimalNum3 = binaryStringToDecimal(i_ThirdBinaryNum);

            int maxForNow = System.Math.Max(decimalNum1, decimalNum2);
            int maxNum = System.Math.Max(maxForNow, decimalNum3);

            return maxNum;
        }

        private static int minNumber(string i_FirstBinaryNum, string i_SecondBinaryNum, string i_ThirdBinaryNum)
        {
            int decimalNum1 = binaryStringToDecimal(i_FirstBinaryNum);
            int decimalNum2 = binaryStringToDecimal(i_SecondBinaryNum);
            int decimalNum3 = binaryStringToDecimal(i_ThirdBinaryNum);

            int minForNow = System.Math.Min(decimalNum1, decimalNum2);
            int minNum = System.Math.Min(minForNow, decimalNum3);

            return minNum;
        }

        private static bool checkIfInputIsValid(string i_StrFromUser)
        {
            bool isValid = true;
            if (!isInputIsBinary(i_StrFromUser) || !isInputIsSizeOfSeven(i_StrFromUser))
            {
                isValid = false;
            }

            return isValid;
        }

        private static bool isInputIsSizeOfSeven(string i_StrFromUser)
        {
            bool isSizeSeven = true;
            int lengthOfInputStr = i_StrFromUser.Length;
            if (lengthOfInputStr != 7)
            {
                isSizeSeven = false;
            }

            return isSizeSeven;
        }

        private static bool isInputIsBinary(string i_StrFromUser)
        {
            bool isInputBinary = true;
            for (int i = 0; i < i_StrFromUser.Length; i++)
            {
                if (i_StrFromUser[i] != '0' && i_StrFromUser[i] != '1')
                {
                    isInputBinary = false;
                    break;
                }
            }

            return isInputBinary;
        }
    }
}