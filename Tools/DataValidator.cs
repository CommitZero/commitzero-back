using System.Collections.Generic;
using System;

namespace CommitZeroBack.Tools {
    public static class ValidData {
        private static List<string> InvalidValues = new() {
            "DELETE", "WHERE", "FROM", "*", "SELECT", "DROP", "DATABASE", "UPDATE", "SET"
        };

        public static bool IsValid(string data) {
            if (InvalidValues.Contains(data)) {
                return false;
            }

            foreach (char c in data)
            {
                if (!Char.IsLetterOrDigit(c) && c != '_' && c != ' ')
                    return false;
            }

            return true;
        }
    }
}