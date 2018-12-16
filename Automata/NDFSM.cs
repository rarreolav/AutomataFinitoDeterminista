using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automata
{
    public class NDFSM
    {
        private readonly List<string> Q = new List<string>();
        public readonly List<char> Sigma = new List<char>();
        public readonly List<Transicion> Delta = new List<Transicion>();
        public List<string> Q0 = new List<string>();
        public readonly List<string> F = new List<string>();        

        public NDFSM(IEnumerable<string> q, IEnumerable<char> sigma, IEnumerable<Transicion> delta, IEnumerable<string> q0, IEnumerable<string> f)
        {
            Q = q.ToList();
            Sigma = sigma.ToList();
            AddTransitions(delta);
            AddInitialStates(q0);            
            AddFinalStates(f);
        }

        private void AddTransitions(IEnumerable<Transicion> transitions)
        {
            foreach (var transition in transitions.Where(ValidTransition))
            {
                Delta.Add(transition);
            }
        }

        private bool ValidTransition(Transicion transition)
        {
            return Q.Contains(transition.EstadoInicial) &&
                   Q.Contains(transition.EstadoFinal) &&
                   Sigma.Contains(transition.Simbolo);
        }

        private void AddInitialStates(IEnumerable<string> q0)
        {
            try
            {
                foreach (var startingState in q0.Where(q => q != null && Q.Contains(q)))
                {
                    Q0.Add(startingState);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private void AddFinalStates(IEnumerable<string> finalStates)
        {
            foreach (var finalState in finalStates.Where(finalState => Q.Contains(finalState)))
            {
                F.Add(finalState);
            }
        }

        public void Accepts(string input)
        {
            //ConsoleWriter.Success("Trying to accept: " + input);
            if (Q0.Any(q0 => Accepts(q0, input, new StringBuilder())))
            {
                return;
            }
            //ConsoleWriter.Failure("Could not accept the input: " + input);
        }

        private bool Accepts(string currentState, string input, StringBuilder steps)
        {
            if (input.Length > 0)
            {
                var transitions = GetAllTransitions(currentState, input[0]);
                foreach (var transition in transitions)
                {
                    var currentSteps = new StringBuilder(steps.ToString() + transition);
                    if (Accepts(transition.EstadoFinal, input.Substring(1), currentSteps))
                    {
                        return true;
                    }
                }
                return false;
            }
            if (F.Contains(currentState))
            {
                //ConsoleWriter.Success("Successfully accepted the input " + input + " " +
                //                       "in the final state " + currentState +
                //                       " with steps:\n" + steps);
                Automata.resMinimizacion = " " + steps;
                return true;
            }
            return false;
        }

        private IEnumerable<Transicion> GetAllTransitions(string currentState, char symbol)
        {
            return Delta.FindAll(t => t.EstadoInicial == currentState &&
                                      t.Simbolo == symbol);
        }
    }
}