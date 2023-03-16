using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
    public class FA1
    {
        public static State zero = new State()
        {
            Name = "zero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        static public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        static public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        static public State fiasko = new State()
        {
            Name = "fiasko",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
         State InitialState = zero;
        public FA1()
        {
            zero.Transitions['0'] = b;
            zero.Transitions['1'] = a;
            a.Transitions['0'] = c;
            a.Transitions['1'] = a;
            b.Transitions['0'] = fiasko;
            b.Transitions['1'] = c;
            c.Transitions['0'] = fiasko;
            c.Transitions['1'] = c;
            fiasko.Transitions['0'] = fiasko;
            fiasko.Transitions['1'] = fiasko;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }
    public class FA2
    {
        public static State zero = new State()
        {
            Name = "zero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        static public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        static public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = zero;
        public FA2()
        {
            zero.Transitions['0'] = a;
            zero.Transitions['1'] = b;
            a.Transitions['0'] = zero;
            a.Transitions['1'] = c;
            b.Transitions['0'] = c;
            b.Transitions['1'] = zero;
            c.Transitions['0'] = b;
            c.Transitions['1'] = a;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }
    public class FA3
    {
        public static State zero = new State()
        {
            Name = "zero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        static public State b = new State()
        {
            Name = "b",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        State InitialState = zero;
        public FA3()
        {
            zero.Transitions['0'] = zero;
            zero.Transitions['1'] = a;
            a.Transitions['0'] = zero;
            a.Transitions['1'] = b;
            b.Transitions['0'] = b;
            b.Transitions['1'] = b;
        }
        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                current = current.Transitions[c];
                if (current == null)
                    return null;
            }
            return current.IsAcceptState;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
