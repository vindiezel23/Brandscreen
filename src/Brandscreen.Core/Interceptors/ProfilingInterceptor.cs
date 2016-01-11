using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Brandscreen.Core.Settings;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace Brandscreen.Core.Interceptors
{
    [DebuggerStepThrough]
    public class ProfilingInterceptor : IInterceptor
    {
        private readonly ISiteSettings _siteSettings;

        [ThreadStatic]
        private static Stack<int> _stack;

        [ThreadStatic]
        private static StringBuilder _logBuilder;

        public ProfilingInterceptor(ISiteSettings siteSettings)
        {
            _siteSettings = siteSettings;

            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public void Intercept(IInvocation invocation)
        {
            if (!_siteSettings.Profiling)
            {
                invocation.Proceed();
                return;
            }

            if (_stack == null) _stack = new Stack<int>();
            if (_logBuilder == null) _logBuilder = new StringBuilder();
            if (_stack.Count == 0 && _logBuilder.Length > 0) _logBuilder.Clear(); // clean log builder coz same thread can run different function

            // function start
            _logBuilder
                .AppendFormat("{0}{1}.{2}({3})", WriteStartIndent(_stack.Count), invocation.TargetType.Name, invocation.Method.Name, GetArguments(invocation))
                .AppendLine();

            _stack.Push(Environment.TickCount); // push started time
            try
            {
                invocation.Proceed();
            }
            finally
            {
                var usedTime = Environment.TickCount - _stack.Pop();

                // function end
                _logBuilder
                    .AppendFormat("{0}.{1} >> {2} ({3}ms)", WriteEndIndent(_stack.Count), invocation.Method.Name, GetReturnValue(invocation), usedTime)
                    .AppendLine();

                if (_stack.Count == 0 && usedTime > _siteSettings.ProfilingInterval)
                {
                    Logger.WarnFormat("\r\n{0}", _logBuilder);
                }
            }
        }

        private static string WriteStartIndent(int level)
        {
            if (level == 0) return "┌";
            var sb = new StringBuilder();
            while (level > 0)
            {
                sb.Append(level == 1 ? "├────┬" : "│　　");
                level--;
            }
            return sb.ToString();
        }

        private static string WriteEndIndent(int level)
        {
            if (level == 0) return "└";
            var sb = new StringBuilder();
            while (level > 0)
            {
                sb.Append(level == 1 ? "│　　└" : "│　　");
                level--;
            }
            return sb.ToString();
        }

        private static string GetArguments(IInvocation invocation)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < invocation.Arguments.Length; i++)
            {
                var arg = invocation.Arguments[i];
                if (arg == null)
                {
                    sb.AppendFormat("null {0}, ", invocation.Method.GetParameters()[i].ParameterType.Name);
                    continue;
                }

                var argType = arg.GetType();
                if (argType.IsValueType)
                {
                    sb.Append(arg);
                }
                else if (argType == typeof (string))
                {
                    sb.AppendFormat("\"{0}\"", arg);
                }
                else
                {
                    sb.Append(argType.Name);
                }
                sb.Append(", ");
            }

            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.ToString();
        }

        private static string GetReturnValue(IInvocation invocation)
        {
            if (invocation.Method.ReturnType == typeof (void))
            {
                return "void";
            }
            else if (invocation.ReturnValue == null)
            {
                return string.Format("null {0}", invocation.Method.ReturnType.Name);
            }
            else if (invocation.Method.ReturnType.IsValueType)
            {
                return invocation.ReturnValue.ToString();
            }
            else if (invocation.Method.ReturnType == typeof (string))
            {
                return string.Format("\"{0}\"", invocation.ReturnValue);
            }
            else
            {
                return invocation.Method.ReturnType.Name;
            }
        }

        /*
┌ListModules(Func`4)
├────┬FindPsLoadedModuleList()
│    ├────┬GetCache(RuntimeType)
│    │    └GetCache returns ICache`2 using 0ms
│    ├────┬GetCache(RuntimeType)
│    │    └GetCache returns ICache`2 using 0ms
│    ├────┬GetCache(RuntimeType)
│    │    └GetCache returns ICache`2 using 0ms
│    ├────┬Send(2147491880, 0)
│    │    └Send returns False using 16ms
│    ├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, 0)
│    │    └Send returns False using 0ms
│    ├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, 0)
│    │    └Send returns False using 15ms
│    ├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, 0)
│    │    └Send returns False using 0ms
│    ├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, 0)
│    │    └Send returns False using 0ms
│    └FindPsLoadedModuleList returns 0 using 31ms
├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, 0)
│    └Send returns False using 0ms
├────┬Send(2147492240, Ast.Core.IoCtl+ReadMemoryRequest, Ast.Core.Services.PsLoadedModuleListService+LdrDataTableEntry)
│    └Send returns False using 0ms
└ListModules returns void using 47ms
         */
    }
}