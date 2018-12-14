/*
 * Created by SharpDevelop.
 * User: Danang Saputra
 * Date: 05/12/2018
 * Time: 08.11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Merge_sort
{    
    class Program
    {
    	private static List<int> hasil = new List<int>();
		private static List<int> hasil2 = new List<int>();
    	static void Main(string[] args)
        {
            
            List<int> sorted;

//            Random random = new Random();

            Console.Write("Masukkan Panjang Array : ");
            
            int input = int.Parse(Console.ReadLine());
            
            int[] unsortedArray = new int[input];
            
            for(int i=0; i < unsortedArray.Length; i++){
            	Console.Write("Array ["+ i +"] = " );
            	unsortedArray[i] = int.Parse(Console.ReadLine());
            }
            
            List<int> unsorted = unsortedArray.OfType<int>().ToList();
           
            
            Console.WriteLine("Array Tak Terurut :" );
            
            for(int i=0;i<unsortedArray.Length;i++){
            	Console.Write(unsortedArray[i] + " ");
            }
            
//            for(int i = 0; i< 10;i++){
//                unsorted.Add(random.Next(0,100));
//                Console.Write(unsorted[i]+" ");
//            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);
         

            Console.WriteLine("Array yang sudah diurutkan: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            
            Console.WriteLine();
            Console.Write("Left : ");
            foreach(int i in hasil){
            	Console.Write(i + " ");
            	
            }
            Console.Write(" Right : ");
            foreach(int i in hasil2
                   ){
            	Console.Write(i + " ");
            	
            }
            Console.ReadLine();
			Console.WriteLine("Press Enter to Continue...");
			
			Console.ReadLine();
        }
		

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;
			
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle;i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
                
            }
           
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
              //  Console.Write(right[i-1] + " ");
                
            }
			
			 
			 
            left = MergeSort(left);
             Leftw(left);
            right = MergeSort(right);
            Rightw(right);
            return Merge(left, right);
            
        }
        private static List<int> Rightw(List<int> Rightw){
        	foreach(int i in Rightw){
        		hasil2.Add(i);
        	}
        	return hasil2;
        }
        private static List<int> Leftw(List<int> Leftw){
        	
        	foreach(int i in Leftw){
        		hasil.Add(i);
        	}
        	return hasil;
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if(left.Count>0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());    
                }    
            }
            return result;
            
        }
        
       
    }
}
