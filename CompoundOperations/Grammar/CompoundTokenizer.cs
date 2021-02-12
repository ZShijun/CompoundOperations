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
                                       TokenPattern.PatternType.STRING,
                                       "AND");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.OR,
                                       "OR",
                                       TokenPattern.PatternType.STRING,
                                       "OR");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.XOR,
                                       "XOR",
                                       TokenPattern.PatternType.STRING,
                                       "XOR");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.NOT,
                                       "NOT",
                                       TokenPattern.PatternType.STRING,
                                       "NOT");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IN,
                                       "IN",
                                       TokenPattern.PatternType.STRING,
                                       "in");
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

            pattern = new TokenPattern((int) CompoundConstants.IDENTIFIER,
                                       "IDENTIFIER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[a-z_]\\w*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.INTEGER,
                                       "INTEGER",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\d*(u|l|ul|lu)?");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.HEX,
                                       "HEX",
                                       TokenPattern.PatternType.REGEXP,
                                       "0x[0-9a-f]+(u|l|ul|lu)?");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.REAL,
                                       "REAL",
                                       TokenPattern.PatternType.REGEXP,
                                       "\\d+\\.\\d+([e][+-]\\d{1,3}?f?)");
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
                                       TokenPattern.PatternType.STRING,
                                       "True");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.FALSE,
                                       "FALSE",
                                       TokenPattern.PatternType.STRING,
                                       "False");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.NULL,
                                       "NULL",
                                       TokenPattern.PatternType.STRING,
                                       "NULL");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DATETIME,
                                       "DATETIME",
                                       TokenPattern.PatternType.REGEXP,
                                       "#[^#]+#");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IF,
                                       "IF",
                                       TokenPattern.PatternType.STRING,
                                       "if");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.IFS,
                                       "IFS",
                                       TokenPattern.PatternType.STRING,
                                       "ifs");
            AddPattern(pattern);

            pattern = new TokenPattern((int) CompoundConstants.DATE,
                                       "DATE",
                                       TokenPattern.PatternType.STRING,
                                       "date");
            AddPattern(pattern);
        }
    }
}
