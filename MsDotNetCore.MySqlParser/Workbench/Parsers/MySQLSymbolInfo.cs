using System;
using System.Collections.Generic;
using System.Text;

namespace Workbench.Parsers
{
    public static partial class MySQLSymbolInfo
    {
        static HashSet<string> empty = new HashSet<string>();
        static Dictionary<MySQLVersion, HashSet<string>> keywords = new Dictionary<MySQLVersion, HashSet<string>>();
        static Dictionary<MySQLVersion, HashSet<string>> reservedKeywords = new Dictionary<MySQLVersion, HashSet<string>>();

        public static HashSet<string> systemFunctionsForVersion(MySQLVersion version)
        {
            switch (version)
            {
                case MySQLVersion.MySQL56:
                    return SystemFunctions.systemFunctions56;
                case MySQLVersion.MySQL57:
                    return SystemFunctions.systemFunctions57;
                case MySQLVersion.MySQL80:
                    return SystemFunctions.systemFunctions80;
                default:
                    return empty;
            }
        }
        public static HashSet<string> keywordsForVersion(MySQLVersion version)
        {
            if (!keywords.ContainsKey(version))
            {
                HashSet<string> list = new HashSet<string>();
                HashSet<string> reservedList = new HashSet<string>();
                switch (version)
                {
                    case MySQLVersion.MySQL56:
                        {

                            int listSize = KeywordLists.keyword_list56.Count;
                            for (int i = 0; i < listSize; ++i)
                            {
                                string word = KeywordLists.keyword_list56[i].word;
                                list.Add(word);
                                if (KeywordLists.keyword_list56[i].reserved != 0)
                                    reservedList.Add(word);
                            }
                            break;
                        }

                    case MySQLVersion.MySQL57:
                        {
                            int listSize = KeywordLists.keyword_list57.Count;
                            for (int i = 0; i < listSize; ++i)
                            {
                                string word = KeywordLists.keyword_list57[i].word;
                                list.Add(word);
                                if (KeywordLists.keyword_list57[i].reserved != 0)
                                    reservedList.Add(word);
                            }
                            break;
                        }

                    case MySQLVersion.MySQL80:
                        {
                            int listSize = KeywordLists.keyword_list80.Count;
                            for (int i = 0; i < listSize; ++i)
                            {
                                string word = KeywordLists.keyword_list80[i].word;
                                list.Add(word);
                                if (KeywordLists.keyword_list80[i].reserved != 0)
                                    reservedList.Add(word);
                            }
                            break;
                        }

                    default:
                        break;
                }
                keywords[version] = list;
            }

            return keywords[version];
        }

        public static bool isReservedKeyword(string identifier, MySQLVersion version)
        {
            keywordsForVersion(version);
            return reservedKeywords[version].Contains(identifier);
        }


        public static bool isKeyword(string identifier, MySQLVersion version)
        {
            var keywords = keywordsForVersion(version);
            return keywords.Contains(identifier);
        }

        public static MySQLVersion numberToVersion(long version)
        {
            long major = version / 10000, minor = (version / 100) % 100;

            if (major < 5 || major > 8)
                return MySQLVersion.Unknown;

            if (major == 8)
                return MySQLVersion.MySQL80;

            if (major != 5)
                return MySQLVersion.Unknown;

            switch (minor)
            {
                case 6:
                    return MySQLVersion.MySQL56;
                case 7:
                    return MySQLVersion.MySQL57;
                default:
                    return MySQLVersion.Unknown;
            }
        }

    }
}