﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using LearningDiary_DB_test.Models;


namespace Oppimispaivakirja

{
    class Program
    {

        public static void Main(string[] args)
        {

            DateTime dateTime = DateTime.UtcNow.Date;

            Console.WriteLine("Today is: " + dateTime.ToString("d"));

            Console.WriteLine("\n" + "Tervetuloa Oppimispäiväkirja -sovellukseen!" + "\n");

            /*using (LearningDiaryContext testiYhteys = new LearningDiaryContext())

            {
                var taulu = testiYhteys.Topics.Select(topikki => topikki);

                Topic uusi = new Topic()

                {
                    Id = 1,
                    Description = "Testi",
                    Title = "Title",
                    TimeToMaster = 2,
                    TimeSpent = 3,
                    StartLearningDate = DateTime.Now,
                    InProgress = false,
                    EndLearninfDate = DateTime.Now

                };

                testiYhteys.Topics.Add(uusi);
                testiYhteys.SaveChanges();

                taulu = testiYhteys.Topics.Select(topikki => topikki);

                foreach (var rivi in taulu)
                {
                    Console.WriteLine(rivi.Description);
                }

                //Console.WriteLine(taulu);

            }*/


            List<test> test = new List<test>();

            string status = "yes";

            using (LearningDiaryContext testiYhteys = new LearningDiaryContext())

            {
                var taulu = testiYhteys.Topics.Select(topikki => topikki);

                while (status == "yes") //Asking user for parameters.

                {

                    Topic Topic = new Topic();

                    Console.WriteLine("Enter the topic title:");
                    Topic.Title = ReadStringMethod();

                    Console.WriteLine("Enter a short description:");
                    Topic.Description = ReadStringMethod();

                    Console.WriteLine("Enter estimated time to master the topic in hours:");
                    Topic.TimeToMaster = ReadDoubleMethod();

                    Console.WriteLine("Time spent in hours:");
                    Topic.TimeSpent = ReadDoubleMethod();

                    Console.WriteLine("Enter the studying source:");
                    Topic.Source = ReadStringMethod();

                    Console.WriteLine("Enter starting learning date:");
                    Topic.StartLearningDate = ReadDateTimeMethod();

                    Console.WriteLine("When is the completion date?");
                    Topic.CompletionDate = ReadDateTimeMethod();

                    Topic.InProgress = ReadBoolMethod(Topic.CompletionDate); //This is not asked from user, but start/finnish day compared.

                    Console.WriteLine("yes - Add new studying topic, no - quit programm.");
                    status = Console.ReadLine();

                    testiYhteys.Topics.Add(Topic);
                    testiYhteys.SaveChanges();

                }

                foreach (var aihe in test) //User's answers written to the console.
                {
                    Console.WriteLine(aihe);
                }

                Console.Write("\nEnter topic to search: ");
                string input = Console.ReadLine().Trim();

                var search = testiYhteys.Topics.Where(x => x.Title == input).FirstOrDefault();

                if (search == null)

                {
                    Console.WriteLine("\nNothing was found.");
                    Environment.Exit(0);

                }

                else
                {

                    Console.WriteLine("\nWe have found: " + search.Id + " | " + search.Title + " | " + search.Description + " | " + search.StartLearningDate + " | " + search.CompletionDate + " | " + search.InProgress);

                }


                Console.WriteLine("What would you like to do? D - delete; R - replace."); //Asking user to choose action.
                string inputChoice = Console.ReadLine();


                if (inputChoice == "D") //User chooses Delete.
                {
                    
                    testiYhteys.Topics.Remove(search);
                    testiYhteys.SaveChanges();
                    Console.WriteLine("\n" + search.Title  + " have been removed.");

                }

                else

                {

                    //var itemToModify = search;
                    Console.WriteLine("Replacement text: ");
                    string inputReplacement = Console.ReadLine().Trim();
                    search.Title = inputReplacement;
                    //test.ForEach(Console.WriteLine);
                    testiYhteys.SaveChanges();
                    Console.WriteLine("\n Topic have been changed to " + inputReplacement + ".");
                }





            }

            static string ReadStringMethod()
            {
                return Console.ReadLine();
            }

            static double ReadDoubleMethod()
            {
                return double.Parse(Console.ReadLine());
            }

            static DateTime ReadDateTimeMethod()
            {
                return DateTime.Parse(Console.ReadLine());
            }

            static bool ReadBoolMethod(DateTime? CompletionDate)
            {

                return (CompletionDate > DateTime.Now);

            }

        }
    }


    public class test

    {

        public test()
        {

        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double EstimatedTimeToMaster { get; set; }
        public double TimeSpent { get; set; }
        public string Source { get; set; }
        public DateTime StartLearningDate { get; set; }
        public bool InProgress { get; set; }
        public DateTime CompletionDate { get; set; }


        public override string ToString()
        {
            string Result = "";
            String Separator = ",";
            Result += Id + Separator;
            Result += Title + Separator;
            Result += Description + Separator;
            Result += +EstimatedTimeToMaster + Separator;
            Result += TimeSpent + Separator;
            Result += Source + Separator;
            Result += StartLearningDate + Separator;
            Result += InProgress + Separator;
            Result += CompletionDate;

            return Result;

        }

    }

}



