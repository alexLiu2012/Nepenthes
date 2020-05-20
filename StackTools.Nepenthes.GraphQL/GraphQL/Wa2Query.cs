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
            
            // query alarms
            Field<ListGraphType<GraphAlarm>>(
                name: "alarms",
                description: "",
                arguments: alarmArgs.GetArguments(),
                resolve: alarmArgs.GetResolver());

            // query applications
            Field<ListGraphType<GraphApplication>>(
                name: "applications",
                description: "",
                arguments: applicationArgs.GetArguments(),
                resolve: applicationArgs.GetResolver());

            // query batches
            Field<ListGraphType<GraphBatch>>(
                name: "batches",
                description: "",
                arguments: batchArgs.GetArguments(),
                resolve: batchArgs.GetResolver());

            // query controllers
            Field<ListGraphType<GraphController>>(
                name: "controllers",
                description:"",
                arguments: controllerArgs.GetArguments(),
                resolve: controllerArgs.GetResolver());

            // query keyinfos
            //Field<ListGraphType<GraphKeyInfo>>();
            
            // query keyvalues
            Field<ListGraphType<GraphKeyValue>>(
                name: "keyvalues",
                description:"",
                arguments: keyvalueArgs.GetArguments(),
                resolve: keyvalueArgs.GetResolver());

            // query locations
            Field<ListGraphType<GraphLocation>>(
                name: "locations",
                description: "",
                arguments: locationArgs.GetArguments(),
                resolve: locationArgs.GetResolver());
    
        }
    }
}
