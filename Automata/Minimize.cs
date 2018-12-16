using System.Collections.Generic;
using System.Linq;

namespace Automata
{
    public class Minimize
    {
        public static Automata MinimizeDFSM(Automata fsm)
        {
            var reversedNDFSM = Reverse(fsm);
            var reversedDFSM = PowersetConstruction(reversedNDFSM);
            //var NDFSM = Reverse(reversedDFSM);            
            //return PowersetConstruction(NDFSM);
            return reversedDFSM;
        }

        private static NDFSM Reverse(Automata d)
        {                        
            var delta = new List<Transicion>();
            foreach (var transition in d.Transicion)
            {
                delta.Add(new Transicion(transition.EstadoFinal, transition.Simbolo, transition.EstadoInicial));
            }
            return new NDFSM(d.Estados, d.Lenguaje, delta, d.EstadoFinal, d.EstadoInicial);
        }

        private static Automata PowersetConstruction(NDFSM ndfsm)
        {
            var Q = new List<string>();
            var Sigma = ndfsm.Sigma.ToList();
            var Delta = new List<Transicion>();
            var Q0 = new List<string> { string.Join(" ", ndfsm.Q0) };
            var F = new List<string>();

            var processed = new List<string>();
            var queue = new Queue<string>();
            queue.Enqueue(string.Join(",", ndfsm.Q0));

            while (queue.Count > 0)
            {
                var setState = queue.Dequeue();
                processed.Add(setState);
                Q.Add(CleanupState(setState));

                var statesInCurrentSetState = setState.Split(',').ToList();
                foreach (var state in statesInCurrentSetState)
                {
                    if (ndfsm.F.Contains(state))
                    {
                        F.Add(CleanupState(setState));
                        break;
                    }
                }
                var symbols = ndfsm.Delta
                   .Where(t => statesInCurrentSetState.Contains(t.EstadoInicial))
                   .Select(t => t.Simbolo)
                   .Distinct();
                foreach (var symbol in symbols)
                {
                    var reachableStates =
                       ndfsm.Delta
                          .Where(t => t.Simbolo == symbol &&
                                      statesInCurrentSetState.Contains(t.EstadoInicial))
                          .OrderBy(t => t.EstadoFinal).
                          Select(t => t.EstadoFinal);
                    var reachableSetState = string.Join(",", reachableStates);

                    Delta.Add(new Transicion(CleanupState(setState), symbol, CleanupState(reachableSetState)));

                    if (!processed.Contains(reachableSetState))
                    {
                        queue.Enqueue(reachableSetState);
                    }
                }
            }
            return new Automata(Q, Sigma, Delta, Q0, F);
        }

        private static string CleanupState(string state)
        {
            return state.Replace(",", " ");
        }
    }
}