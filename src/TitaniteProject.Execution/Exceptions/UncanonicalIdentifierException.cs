using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class UncanonicalIdentifierException : Exception
    {
        public const string CODE = "TE01";

        public UncanonicalIdentifierException() : base($"{CODE}: The identifier {"({undefined})"} is uncanonical.") { }

        public UncanonicalIdentifierException(string e) : base(e) { }

        public static string Check(string identifier)
        {
            char[] mutableIdentifier = identifier.ToCharArray();

            for (int i = 0; i < mutableIdentifier.Length; i++)
            {
                if (mutableIdentifier[i] > '9' || mutableIdentifier[i] < '0')
                    if (mutableIdentifier[i] > 'z' || mutableIdentifier[i] < 'a')
                        if (mutableIdentifier[i] > 'Z' || mutableIdentifier[i] < 'A')
                            throw new UncanonicalIdentifierException($"{UncanonicalIdentifierException.CODE}: The identifier ({identifier}) contained incorrect syntax.");
            }

            return identifier;
        }
    }
}
