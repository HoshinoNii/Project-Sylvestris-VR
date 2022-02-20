

using UnityEngine;

namespace Data {
    public class RandomNames {
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
            "Terry",
            "Hamzehhhh",
        };

        public static string PickRandomName() {
            return randomNames[Random.Range(0, randomNames.Length)];
        }
    }
}