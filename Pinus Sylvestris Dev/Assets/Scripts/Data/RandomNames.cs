

using UnityEngine;

namespace Data {
    public class RandomNames {
        
        // Random name list for the customer
        private static string[] randomNames = new string[] {
            "Michael Holmes",
            "Laughlin Ross",
            "Michael Harper",
            "Thomas Morales",
            "Spencer Tucker",
            "Esther Hamilton",
            "Caitlin Henderson",
            "Sarah Hunter",
            "Barbara Shaw",
            "Elisabeth Reid",
        };

        // pick a random name from that list
        public static string PickRandomName() {
            return randomNames[Random.Range(0, randomNames.Length)];
        }
    }
}