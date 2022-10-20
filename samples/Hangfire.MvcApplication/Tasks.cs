﻿using System;
using Hangfire.Server;
using Hangfire.Tags;
using Hangfire.Tags.Attributes;

namespace Hangfire.MvcApplication
{
    [Tag("task")]
    internal class Tasks
    {
        [Tag("success", "This is a really long tag, in order to create a tag which has more than the specified amount of characters. Tags longer than a specific amount of characters won't fit in the key column of table HangFire.Set.")]
        public void SuccessTask(PerformContext context, IJobCancellationToken token)
        {
            TextBuffer.WriteLine("Recurring Job completed successfully!");
            context.AddTags("finished");
        }

        [Tag("fail")]
        [AutomaticRetry(Attempts = 0)] // Disable retry
        public void FailedTask(PerformContext context, IJobCancellationToken token)
        {
            context.AddTags("throw");
            throw new Exception("Fail please!");
        }
    }
}