using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using StackTools.Nepenthes.GraphQL.GraphTypes;
using StackTools.Wa2Wrapper;
using StackTools.Wa2Wrapper.wa2Resource;

namespace StackTools.Nepenthes.GraphQL.GraphQL
{
    public class Wa2Query : ObjectGraphType
    {        
        private AlarmFieldArguments _alarmArgs;
        private ApplicationFieldArguments _applicationArgs;
        private BatchFieldArguments _batchArgs;
        private ControllerFieldArguments _controllerArgs;
        private KeyInfoFieldArguments _keyinfoArgs;
        private KeyValueFieldArguments _keyvalueArgs;
        private LocationFieldArguments _locationArgs;

        public Wa2Query(            
            AlarmFieldArguments alarmArgs,
            ApplicationFieldArguments applicationArgs,
            BatchFieldArguments batchArgs,
            ControllerFieldArguments controllerArgs,
            KeyInfoFieldArguments keyinfoArgs,
            KeyValueFieldArguments keyvalueArgs,
            LocationFieldArguments locationArgs)
        {            
            this._alarmArgs = alarmArgs;
            this._applicationArgs = applicationArgs;
            this._batchArgs = batchArgs;
            this._controllerArgs = controllerArgs;
            this._keyinfoArgs = keyinfoArgs;
            this._keyvalueArgs = keyvalueArgs;
            this._locationArgs = locationArgs;

            Name = "wa2query";
            Description = "wa2query";
            
            Field<ListGraphType<GraphAlarm>>(
                name: "alarms",
                description: "",
                arguments: null,
                resolve: alarmArgs.GetResolver());

            //Field<ListGraphType<GraphApplication>>();

            Field<ListGraphType<GraphBatch>>(
                name: "batches",
                description:"",
                resolve: batchArgs.GetResolver());

            Field<ListGraphType<GraphController>>(
                name: "controllers",
                description:"",
                resolve: controllerArgs.GetResolver());


            //Field<ListGraphType<GraphKeyInfo>>();
                
            Field<ListGraphType<GraphKeyValue>>(
                name: "keyvalues",
                description:"",
                arguments: null,
                resolve: keyvalueArgs.GetResolver());

            Field<ListGraphType<GraphLocation>>(
                name: "locations",
                description: "",
                resolve: locationArgs.GetResolver());
    
        }
    }
}
