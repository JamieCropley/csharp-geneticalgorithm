using System;

public class MyProgram
{
    private static Random random = new Random();
    
    public static void Main(string[] args)
    {
        string[] population = new string[4];
        
        population[0] = "00000000";
        population[1] = "00000010";
        population[2] = "00001000";
        population[3] = "00100001";
        int generation;
        
        generation = 0;
        bool maximumFitnessReached;
        
        maximumFitnessReached = false;
        while (!maximumFitnessReached)
        {
            Console.WriteLine(generation.ToString() + "    " + PrintArray(population));
            double bestFitness;
            
            bestFitness = 0;
            int bestIndex;
            
            bestIndex = 0;
            int secondBestIndex;
            
            secondBestIndex = 0;
            int i;
            
            for (i = 0; i <= population.Length - 1; i++)
            {
                double currentFitness;
                
                currentFitness = fitness(population[i]);
                if (currentFitness == 1.0)
                {
                    maximumFitnessReached = true;
                }
                else
                {
                    if (currentFitness >= bestFitness)
                    {
                        bestFitness = currentFitness;
                        secondBestIndex = bestIndex;
                        bestIndex = i;
                    }
                }
            }
            for (i = 0; i <= population.Length - 1; i++)
            {
                population[i] = Mutate(Crossover(population[bestIndex], population[secondBestIndex]));
            }
            generation = generation + 1;
        }
    }
    
    public static string Crossover(string parentA, string parentB)
    {
        string child;
        int splitLength;

        //splitLength = random.Next((int)Math.Floor((double)parentA.Length - 1));
        splitLength = random.Next(parentA.Length - 1);
        child = substring(parentA, 0, splitLength) + substring(parentB, splitLength, parentB.Length);
        
        return child;
    }
    
    public static double fitness(string individual)
    {
        double fitness;
        int countOfOnes;
        
        countOfOnes = 0;
        int i;
        
        for (i = 0; i <= individual.Length - 1; i++)
        {
            if (individual[i] == '1')
            {
                countOfOnes = countOfOnes + 1;
            }
        }
        fitness = (double) countOfOnes / individual.Length;
        
        return fitness;
    }
    
    public static string Mutate(string individual)
    {
        if (random.Next(2) == 0)
        {
        }
        else
        {
            int changeIndex;
            
            changeIndex = random.Next(individual.Length);
            string changedCharacter;
            
            if (individual[changeIndex] == '0')
            {
                changedCharacter = "1";
            }
            else
            {
                changedCharacter = "0";
            }
            individual = substring(individual, 0, changeIndex) + changedCharacter + substring(individual, changeIndex + 1, individual.Length);
        }
        
        return individual;
    }
    
    public static string PrintArray(string[] array)
    {
        string returnString;
        
        returnString = "";
        int i;
        
        for (i = 0; i <= array.Length - 1; i++)
        {
            returnString = returnString + array[i] + "    ";
        }
        
        return returnString;
    }
    
    public static string substring(string s, int start, int end)
    {
        string substring;
        
        substring = "";
        if (start < s.Length)
        {
            if (end > s.Length)
            {
                end = s.Length;
            }
            int index;
            
            for (index = start; index <= end - 1; index++)
            {
                substring = substring + s[index];
            }
        }
        
        return substring;
    }
}
