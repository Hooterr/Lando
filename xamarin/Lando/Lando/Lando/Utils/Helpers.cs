using System;
using System.Collections.Generic;
using System.Text;

namespace Lando.Utils
{
    public static class Helpers
    {
        /// <summary>
        /// Returns correct plural form of a given noun.
        /// </summary>
        /// <param name="count">The count to generate plural form for.</param>
        /// <param name="singularNominative">Singular nominative of the noun. E.g. jedna "gruszka"</param>
        /// <param name="pluralNominative">Plural nominative of the noun. E.g. trzy/cztery "gruszki"</param>
        /// <param name="pluralGenitive">Plural genitive of the noun. E.g. zero/pięć/dziesięć "gruszek"</param>
        /// <returns>Plural form of the noun for the given count.</returns>
        public static string PolishPlural(int count, string singularNominative, string pluralNominative, string pluralGenitive)
        {
            if (count == 1)
            {
                return singularNominative;
            }
            else if (count % 10 >= 2 && count % 10 <= 4 && (count % 100 < 10 || count % 100 >= 20))
            {
                return pluralNominative;
            }
            else
            {
                return pluralGenitive;
            }
        }
    }
}
