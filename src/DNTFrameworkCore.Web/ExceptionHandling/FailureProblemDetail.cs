﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using DNTFrameworkCore.Validation;
using Microsoft.AspNetCore.Http;

namespace DNTFrameworkCore.Web.ExceptionHandling
{
    public class FailureProblemDetail
    {
        private Dictionary<string, string[]> _failures;
        [JsonPropertyName("traceId")] 
        public string TraceId { get; set; }
        [JsonPropertyName("message")] 
        public string Message { get; set; }
        [JsonPropertyName("development_message")]
        public string DevelopmentMessage { get; set; }
        [JsonPropertyName("path")] 
        public string Path { get; set; }
        [JsonPropertyName("failures")] 
        public IReadOnlyDictionary<string, string[]> Failures => _failures;

        public FailureProblemDetail WithFailures(IEnumerable<ValidationFailure> failures)
        {
            if (failures == null) throw new ArgumentNullException(nameof(failures));

            _failures = failures.GroupBy(failure => failure.MemberName, failure => failure.Message)
                .ToDictionary(group => group.Key, group => group.ToArray());

            return this;
        }

        public FailureProblemDetail WithFailures(Dictionary<string, string[]> failures)
        {
            _failures = failures ?? throw new ArgumentNullException(nameof(failures));
            return this;
        }

        public static FailureProblemDetail FromHttpContext(HttpContext context, string message = null)
        {
            return new()
            {
                Message = message,
                TraceId = Activity.Current?.Id ?? context.TraceIdentifier,
                Path = context.Request.Path
            };
        }
    }
}