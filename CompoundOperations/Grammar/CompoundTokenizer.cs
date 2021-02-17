/*
 * CompoundTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace CompoundOperations.Grammar {

    /**
     * <remarks>A character stream tokenizer.</remarks>
     */
    internal class CompoundTokenizer : Tokenizer {

        /**
         * <summary>Creates a new tokenizer for the specified input
         * stream.</summary>
         *
         * <param name='input'>the input stream to read</param>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        public CompoundTokenizer(TextReader input)
            : base(input, false) {

            CreatePatterns();
        }

        /**
         * <summary>Initializes the tokenizer by creating all the token
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            TokenPattern  pattern;

            pattern = new TokenPattern((int) CompoundConstants.ADD,
                                       "ADD",
                                       TokenPattern.PatternType.STRING,
                                       "+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.SUB,
                                       "SUB",
                                       TokenPattern.PatternType.STRING,
                                       "-");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.MUL,
                                       "MUL",
                                       TokenPattern.PatternType.STRING,
                                       "*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DIV,
                                       "DIV",
                                       TokenPattern.PatternType.STRING,
                                       "/");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.POWER,
                                       "POWER",
                                       TokenPattern.PatternType.STRING,
                                       "^");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.MOD,
                                       "MOD",
                                       TokenPattern.PatternType.STRING,
                                       "%");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.LEFT_PAREN,
                                       "LEFT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.RIGHT_PAREN,
                                       "RIGHT_PAREN",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.LEFT_BRACE,
                                       "LEFT_BRACE",
                                       TokenPattern.PatternType.STRING,
                                       "[");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.RIGHT_BRACE,
                                       "RIGHT_BRACE",
                                       TokenPattern.PatternType.STRING,
                                       "]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.EQ,
                                       "EQ",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.NE,
                                       "NE",
                                       TokenPattern.PatternType.STRING,
                                       "<>");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.LT,
                                       "LT",
                                       TokenPattern.PatternType.STRING,
                                       "<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.GT,
                                       "GT",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.LE,
                                       "LE",
                                       TokenPattern.PatternType.STRING,
                                       "<=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.GE,
                                       "GE",
                                       TokenPattern.PatternType.STRING,
                                       ">=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.AND,
                                       "AND",
                                       TokenPattern.PatternType.REGEXP,
                                       "AND|and");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.OR,
                                       "OR",
                                       TokenPattern.PatternType.REGEXP,
                                       "OR|or");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.XOR,
                                       "XOR",
                                       TokenPattern.PatternType.REGEXP,
                                       "XOR|xor");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.NOT,
                                       "NOT",
                                       TokenPattern.PatternType.REGEXP,
                                       "NOT|not");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IN,
                                       "IN",
                                       TokenPattern.PatternType.REGEXP,
                                       "IN|in");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DOT,
                                       "DOT",
                                       TokenPattern.PatternType.STRING,
                                       ".");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.COMMA,
                                       "COMMA",
                                       TokenPattern.PatternType.STRING,
                                       ",");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\s+");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.INTEGER,
                                       "INTEGER",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\d+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.HEX,
                                       "HEX",
                                       TokenPattern.PatternType.REGEXP,
                                       "0[Xx][0-9a-f]+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.REAL,
                                       "REAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\d+\\.\\d+([Ee][+-]?\\d+)?");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.STRING,
                                       "STRING",
                                       TokenPattern.PatternType.REGEXP,
                                       "\"([^\"\\r\\n\\\\]|\\\\u[0-9a-f]{4}|\\\\[\\\\\"'trn])*\"");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.CHAR,
                                       "CHAR",
                                       TokenPattern.PatternType.REGEXP,
                                       "'([^'\\r\\n\\\\]|\\\\u[0-9a-f]{4}|\\\\[\\\\\"'trn])'");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.TRUE,
                                       "TRUE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[Tt]rue");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.FALSE,
                                       "FALSE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[Ff]alse");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.NULL,
                                       "NULL",
                                       TokenPattern.PatternType.REGEXP,
                                       "[Nn]ull");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DATETIME,
                                       "DATETIME",
                                       TokenPattern.PatternType.REGEXP,
                                       "#[^#]+#");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IF,
                                       "IF",
                                       TokenPattern.PatternType.REGEXP,
                                       "IF|if");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IFS,
                                       "IFS",
                                       TokenPattern.PatternType.REGEXP,
                                       "IFS|ifs");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DATE,
                                       "DATE",
                                       TokenPattern.PatternType.REGEXP,
                                       "DATE|date");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IDENTIFIER,
                                       "IDENTIFIER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[a-zA-Z_]\\w*");
            AddPattern(pattern);
        }
    }
}
