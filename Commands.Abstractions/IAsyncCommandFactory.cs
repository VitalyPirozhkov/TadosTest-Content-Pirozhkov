﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Abstractions
{
    public interface IAsyncCommandFactory
    {
        IAsyncCommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext;
    }
}
