using System;
using System.IO;
using System.Collections.Generic;


namespace RandomSelector
{
    class Program
    {
        private List<string> TopicsList = new List<string>{};
        private List<string> StudentsList = new List<string>{};
        private List<int> RandomNumbers = new List<int>();
        private List<string> RandomStudents = new List<string>();


        public string  StudentsReader(string str1)
        {
            StreamReader sr = new StreamReader(str1); 
            string data = sr.ReadLine();

            while(data != null)
            {
                StudentsList.Add(data);
                data = sr.ReadLine();
            }
            return data;
        }

        public string TopicReader(string file2){
            StreamReader sr = new StreamReader(file2); 
            string data = sr.ReadLine();

            while(data != null)
            {
                TopicsList.Add(data);
                data = sr.ReadLine();
            }
            return data;
        }

        public void random (int GroupSize){
            Random rng = new Random();

            int n =  StudentsList.Count;   
            int number = 0;
            int number1 = 0;
            
            for (int y = 0; y < GroupSize; y++)
            {
                do {
                    number = rng.Next(0, GroupSize);
                } while (RandomNumbers.Contains(number));
                    RandomNumbers.Add(number);
            }

            for(int i = 0; i < n; i++)
            {
                 do{
                    number1 = rng.Next(0, n);
                }while(RandomStudents.Contains(StudentsList[number1]));
                    RandomStudents.Add(StudentsList[number1]);
            }

        }

        public void Printer(int counter){

            List<string> Finallist = new List<string>{}; 
            int c = RandomStudents.Count - counter;
            int y=0;
            //int con = 0;
           
            /*for(int y = 0; y < RandomNumbers.Count; y++)
            {
                Console.WriteLine("Grupo: " + RandomNumbers[y]);

                for(int i = con; i < StudentsList.Count; i++)
                {
                    
                  Console.WriteLine(RandomStudents[i]);
                   con++;
                   if(i % c == 2){
                        Console.WriteLine();
                       break;
                   }
                    i = con - 1;
                }
            }*/

            for(int i = 0; i < RandomStudents.Count; i++){
                
                if(y < RandomNumbers.Count)
                {
                    Console.WriteLine(RandomStudents[i] +" Grupo: "+RandomNumbers[y]);
                    y++;
                }else{
                    y = 0;
                }
                
            }
           
               
        }

        public void Grupos(){
            for(int i = 0; i < RandomNumbers.Count; i++)
            {
                if(i < 4)
                 Console.Write(RandomNumbers[i]);
            }
        }


        static void Main(string[] args)
        {
            Program prog = new Program(); 
            
            Console.WriteLine(prog.StudentsReader(args[1]));
            Console.WriteLine(prog.TopicReader(args[2]));
            prog.random(int.Parse(args[0]));
            prog.Printer(int.Parse(args[0]));
           
        }
    }
}
 