﻿using MovieCatalogApp.Core.Providers;
using MovieCatalogApp.Core.Providers.Contracts;
using MovieCatalogApp.DataService.Contracts;
using MovieCatalogApp.DataService.InMemoryDataService;
using MovieCatalogApp.DataService.IOFileService;
using MovieCatalogApp.DataService.IOFileService.Input;
using MovieCatalogApp.IoCNinject;
using MovieCatalogApp.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalogApp
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //initializes a kernal instance/
            IKernel kernel = new StandardKernel(new MovieCatalogModule());

            //loading objects from JSON file.
            JsonInputController dataController = kernel.Get<JsonInputController>();
            dataController.LoadObjects();

            //Starting the application
            var engine = kernel.Get<Engine>();
            engine.DisplayStartScreen();
            engine.Start();
        }
    }
}
