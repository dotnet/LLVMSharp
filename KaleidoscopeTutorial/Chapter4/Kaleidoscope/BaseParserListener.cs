namespace Kaleidoscope
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using AST;

    internal sealed class BaseParserListener
    {
        private static readonly Type IParserListenerType = typeof(IParserListener);

        private readonly Stack<string> descentStack = new Stack<string>();

        private readonly Stack<ASTContext> ascentStack = new Stack<ASTContext>();

        private readonly IParserListener listener;

        public BaseParserListener(IParserListener listener)
        {
            this.listener = listener;
        }

        public void EnterRule(string ruleName)
        {
            this.descentStack.Push(ruleName);
        }

        public void ExitRule(ExprAST argument)
        {
            string ruleName = this.descentStack.Pop();
            this.ascentStack.Push(new ASTContext(IParserListenerType.GetMethod("Exit" + ruleName), this.listener, argument));
            this.ascentStack.Push(new ASTContext(IParserListenerType.GetMethod("Enter" + ruleName), this.listener, argument));
        }

        public void Listen()
        {
            if (this.listener != null)
            {
                while (this.ascentStack.Count != 0)
                {
                    var context = this.ascentStack.Pop();
                    context.MethodInfo.Invoke(context.Instance, new object[] { context.Argument });
                }    
            }
        }

        private sealed class ASTContext
        {
            public ASTContext(MethodInfo methodInfo, object instance, ExprAST argument)
            {
                this.MethodInfo = methodInfo;
                this.Instance = instance;
                this.Argument = argument;
            }

            public MethodInfo MethodInfo { get; private set; }

            public ExprAST Argument { get; set; }

            public object Instance { get; private set; }
        }
    }
}