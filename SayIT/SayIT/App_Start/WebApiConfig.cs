using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OData.Edm;
using System.Web.OData;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using Models;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using System.Web.Http.Cors;

namespace SayIT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			var cors = new EnableCorsAttribute(
			origins: "*",
			headers: "*",
			methods: "*");

			config.EnableCors(cors);
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            builder.EnableLowerCamelCase();
            builder.EntitySet<Translation>("Translations");
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<QuizQuestion>("QuizQuestions");
            builder.EntitySet<LearningType>("LearningTypes");
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
