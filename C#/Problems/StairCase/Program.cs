using System;

namespace StairCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //StairCase(5);
            int[] x = { 1, 2, 3, -1, -2, 0, -3 };
            reverseSign(ref x);
            foreach (var num in x)
            {
                Console.WriteLine(num);
            }
            
        }
        
        public static void reverseSign(ref int[] nums){
            for (int i = 0; i < nums.Length; i++){
                nums[i] = nums[i] * -1;
            }
        }
       
       public static void StairCase(int size){
            for (int i = 1; i <= size; i++)
            {
                for(int j = size; j > size-i+1; j--){
                    Console.Write(' ');
                }
                for(int j = 0; j <= size-i; j++){
                    Console.Write('#');
                }


                Console.WriteLine();
            }
       }
    }
}
