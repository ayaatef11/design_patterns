//when you go to atm the first state is idle (silent)
//if you iinsert the cars=d the state of atm changes to card inserted
namespace statees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public partial class Computer
    {
        private State _state = new Off();

        private void setState(State state)
        {
            _state = state;
        }

        public void pressPowerButton()//action
        {
            _state.pressPowerButton(this);
        }

    }
    public partial class Computer{
        private interface State
    {
            void pressPowerButton(Computer computer);
    }
        private class Off : State
        {
            public void pressPowerButton(Computer computer)
            {
                computer.setState(new On());
            }
        }
        private class On : State
        {
            private bool charging;
            public void pressPowerButton(Computer computer)
            {
                if(charging)
                {
                    computer.setState(new Standby());
                }
                else
                {
                    computer.setState(new Off());
                }
            }
        }
        private class Standby : State
        {
            public void pressPowerButton(Computer computer)
            {
                computer.setState(new On());
            }
        }
    }
    public  class Computer
    {
        private int state = 0;
        private bool charging = true;
        public void PressPowerButton()
        {
            if(state==0)
            {
                state = 1;
                return;
            }
            if (state == 1)
            {
                if (charging)
                {
                    state = 2;
                    return;
                }
                state = 0;
                return;
            }
            state = 1;
        }
    }
}