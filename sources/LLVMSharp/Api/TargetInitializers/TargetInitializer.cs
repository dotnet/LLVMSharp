namespace LLVMSharp.API.TargetInitializers
{
    public abstract class TargetInitializer
    {
        internal TargetInitializer()
        {
        }

        public void All()
        {
            if (this is ITarget t)
            {
                t.Target();
            }
            if (this is ITargetInfo ti)
            {
                ti.TargetInfo();
            }
            if (this is ITargetMC tmc)
            {
                tmc.TargetMC();
            }
            if (this is IAsmParser apar)
            {
                apar.AsmParser();
            }
            if (this is IAsmPrinter aprnt)
            {
                aprnt.AsmPrinter();
            }
        }
    }
}
