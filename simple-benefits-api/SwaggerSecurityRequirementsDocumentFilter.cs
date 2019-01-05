﻿using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace simple_benefits_api
{
    public class SwaggerSecurityRequirementsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument document, DocumentFilterContext context)
        {
            document.Security = new List<IDictionary<string, IEnumerable<string>>>()
            {
                new Dictionary<string,IEnumerable<string>>()
                {
                    {"Bearer", new string[]{}},
                    {"Basic", new string[] { }},
                }
            };
        }
    }
}
