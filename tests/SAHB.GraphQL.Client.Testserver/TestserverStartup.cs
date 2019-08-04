﻿using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SAHB.GraphQL.Client.Subscription.Integration.Tests.ChatSchema;

namespace SAHB.GraphQL.Client.TestServer
{
    public class TestserverStartup<TSchema>
        where TSchema : Schema
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add GraphQL services and configure options
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            })
            .AddWebSockets() // Add required services for web socket support
            .AddDataLoader(); // Add required services for DataLoader support

            // Add Schema
            services.AddSingleton<TSchema>();

            // Add IChat
            services.AddSingleton<IChat, Chat>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // this is required for websockets support
            app.UseWebSockets();

            // use websocket middleware for TSchema at path /graphql
            app.UseGraphQLWebSockets<TSchema>("/graphql");

            // use websocket middleware for TSchema at path /graphql
            app.UseGraphQL<TSchema>("/graphql");
        }
    }
}
