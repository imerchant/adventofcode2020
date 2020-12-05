﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Passwords : IEnumerable<Password>
    {
        public Password this[int k] => Entries[k];

        public List<Password> Entries { get; }

        public Passwords(IEnumerable<string> passwords)
        {
            Entries = new List<Password>(passwords.Select(x => new Password(x)));
        }

        public IEnumerator<Password> GetEnumerator()
        {
            return Entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
