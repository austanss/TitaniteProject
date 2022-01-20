using System;
using System.Collections.Generic;
using System.Text;

namespace TitaniteProject.Execution.Exceptions
{
    internal class UncanonicalIdentifierException : Exception
    {
        public const string CODE = "TE-001";

        public UncanonicalIdentifierException() : base($"{CODE}: The loaded program attempted to declare a symbol with an uncanonical identifier.") { }

        public UncanonicalIdentifierException(string e) : base(e) { }

        public static string Check(string identifier)
        {
            char[] mutableIdentifier = identifier.ToCharArray();

            for (int i = 0; i < mutableIdentifier.Length; i++)
            {
                if (mutableIdentifier[i] > '9' || mutableIdentifier[i] < '0')
                    if (mutableIdentifier[i] > 'z' || mutableIdentifier[i] < 'a')
                        if (mutableIdentifier[i] > 'Z' || mutableIdentifier[i] < 'A')
                            throw new UncanonicalIdentifierException($"{UncanonicalIdentifierException.CODE}: The identifier ({identifier}) is uncanonical.");
            }

            return identifier;
        }
    }
}
