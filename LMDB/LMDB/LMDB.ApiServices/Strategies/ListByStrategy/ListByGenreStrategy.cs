﻿using LMDB.ApiServices.Contratcts;
using LMDB.ApiServices.ObjectConverters;
using LMDB.ObjectModels.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMDB.ApiServices.Strategies.SearchStrategy
{
    public class ListByGenreStrategy :  ICallProcessorStrategy<string>
    {
        private readonly StrategyServices strategyServices;
        private readonly IQueryBuilder<string> queryBuilder;
        private readonly IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>> objectConverter;

        public ListByGenreStrategy(StrategyServices strategyServices, IQueryBuilder<string> queryBuilder, IObjectConverter<ICollection<IResponseObject>, ICollection<IMotionPictureData>> objectConverter) 
        {
            this.strategyServices = strategyServices;
            this.queryBuilder = queryBuilder;
            this.objectConverter = objectConverter;
        }

        public void ExectuteStrategy(string parameter)
        {
            string searchCallQuery = this.queryBuilder.BuildQuery(parameter);

            string responseString = this.strategyServices.ClientCaller.CallClient(searchCallQuery).Result;

            //this.strategyServices.ObjectHandler.HandleObject(responseString);

            //var handledObjects = this.strategyServices.ObjectHandler.HandledResponseObjects;

            //this.objectConverter.Convert(handledObjects);

            var convertedObjects = this.objectConverter.ConvertedObjects;

            this.strategyServices.CollectionCompositor.Composite(convertedObjects);
        }
    }
}