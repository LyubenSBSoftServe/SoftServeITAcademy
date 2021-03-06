﻿using LMDB.Core.Commands.Contracts;
using LMDB.Core.DataService.Contracts;
using LMDB.CoreServices.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LMDB.Commands
{
    public class SearchWatchListCommand : ICommand, IDataCollector
    {
        private IDataService dataService;
        private IDataCollector dataCollector;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<string> collectedData;

        public SearchWatchListCommand(IDataService dataService, IDataCollector dataCollector, IReader reader, IWriter writer)
        {
            this.dataService = dataService;
            this.dataCollector = dataCollector;
            this.reader = reader;
            this.writer = writer;
            this.collectedData = new List<string>();
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Movie Title: ");
            collectedData.Add(reader.ReadLine());
        }

        public string Execute()
        {
            CollectData();
            string movieTitle = collectedData[0];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //searching for a movie with specific title.
            this.dataService.MovieList = this.dataService.MovieList
                .Where(x => x.Title.IndexOf(movieTitle, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            writer.WriteLine(string.Join("\n", this.dataService.MovieList));

            string movieFound = @"

======================================================================================================================================
Movie(s) Found!
======================================================================================================================================";

            string movieNotFound = @"

======================================================================================================================================
Movie Not Found!
======================================================================================================================================";

            stopwatch.Stop();
            Console.WriteLine(@"
Searching done! Time Elapsed : {0} milisecond(s)", stopwatch.ElapsedMilliseconds.ToString());

            return this.dataService.MovieList.Count == 0 ? movieNotFound : movieFound;
        }
    }
}
