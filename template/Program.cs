//used to determine the order of steps ignoring what is executed in a step

namespace template
{
    internal class Program
    {
       
		//template method
            public void Start()
            {
                A();
                B();
                C();
            }

            public void A() => "".Dump();
            public void B() => "".Dump();
            public void C() => "".Dump();
        }

        public class Process_Configured
        {
            // more state === harder to understand
            public void Start(int a)
            {
                A();
                B();
                if (a == 0)
                {
                    C();
                }
                else
                {
                    D();
                }
            }

            public void A() => "".Dump();
            public void B() => "".Dump();
            public void C() => "".Dump();
            public void D() => "".Dump();
        }


        public class Process_Strategy
        {
            // use strategy to supply the algorithm, DO NOT vary it
            Action strategy;
            public Process_Strategy(Action strategy) => this.strategy = strategy;

            public void Start()
            {
                A();
                B();
                strategy();
            }

            public void A() => "".Dump();
            public void B() => "".Dump();
    }/*<Query Kind="Program" />

void Main()
{
	new Process().Start();
	"--".Dump();
	new Variation1().Start();
	"--".Dump();
	new Variation2().Start();
	"--".Dump();
	new Variation3().Start();
}

public class Process
{
	// template method
	public void Start()
	{
		Step1();
		Step2();
		Step3();
	}

	protected virtual void Step1() => "Step 1".Dump();
	protected virtual void Step2() => "Step 2".Dump();
	protected virtual void Step3() => "Step 3".Dump();
}

public class Variation1 : Process
{
	protected override void Step1() => "Step 1 Adapted".Dump();
}

public class Variation2 : Process
{
	protected override void Step3() => "Step 3 Adapted".Dump();
}

public class Variation3 : Process
{
	protected override void Step1() => "Step 1 Mega Adapted".Dump();

	protected override void Step2() => "Step 2 Adapted".Dump();
}*/







    /*
     <Query Kind="Program" />

void Main()
{
	new Variation1().Start();
	"--".Dump();
	new Variation2().Start();
	"--".Dump();
	new Variation3().Start();
}

public abstract class Process
{
	public void Start()
	{
		var word = FactoryMethod();
		// do something with word
	}

	protected abstract string FactoryMethod();
}

public class Variation1 : Process
{
	protected override string FactoryMethod() => "FactoryMethod Variation1".Dump();
}

public class Variation2 : Process
{
	protected override string FactoryMethod() => "FactoryMethod Variation2".Dump();
}

public class Variation3 : Process
{
	protected override string FactoryMethod() => "FactoryMethod Variation3".Dump();
}*/





    /*<Query Kind="Program" />

void Main()
{
}

public abstract class Process
{

	public void Start()
	{
		AbstractHook();
		DefaultHook();
	}
	
	public abstract void AbstractHook();
	
	public virtual void DefaultHook() {
		// default func
	}

}

public class A : Process
{
	public override void AbstractHook()
	{
		// override
	}
	
	public override void DefaultHook() {
		// prepend
		base.DefaultHook();
		// extend
	}
}*/
}
