/*
 * CompoundParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace CompoundOperations.Grammar {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    internal class CompoundParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
            SUBPRODUCTION_1 = 3001,
            SUBPRODUCTION_2 = 3002,
            SUBPRODUCTION_3 = 3003,
            SUBPRODUCTION_4 = 3004,
            SUBPRODUCTION_5 = 3005,
            SUBPRODUCTION_6 = 3006
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public CompoundParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public CompoundParser(TextReader input, CompoundAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new CompoundTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) CompoundConstants.EXPRESSION,
                                            "Expression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.LOGICAL_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.LOGICAL_EXPRESSION,
                                            "LogicalExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.BOOLEAN_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.BOOLEAN_EXPRESSION,
                                            "BooleanExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.COMPARISON_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.NOT, 1, 1);
            alt.AddProduction((int) CompoundConstants.BOOLEAN_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.COMPARISON_EXPRESSION,
                                            "ComparisonExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.ADDITIVE_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.ADDITIVE_EXPRESSION,
                                            "AdditiveExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.MULTIPLICATIVE_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_3, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.MULTIPLICATIVE_EXPRESSION,
                                            "MultiplicativeExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.NEGATIVE_EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_4, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.NEGATIVE_EXPRESSION,
                                            "NegativeExpression");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.SUB, 0, 1);
            alt.AddProduction((int) CompoundConstants.POWER_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.POWER_EXPRESSION,
                                            "PowerExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.FACTOR, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_5, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.SPECIAL_FUNCTION_EXPRESSION,
                                            "SpecialFunctionExpression");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.DATE_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.IF_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.DATE_EXPRESSION,
                                            "DateExpression");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.DATE, 1, 1);
            alt.AddToken((int) CompoundConstants.LEFT_PAREN, 1, 1);
            alt.AddProduction((int) CompoundConstants.ADDITIVE_EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.COMMA, 1, 1);
            alt.AddProduction((int) CompoundConstants.ADDITIVE_EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.COMMA, 1, 1);
            alt.AddProduction((int) CompoundConstants.ADDITIVE_EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.IF_EXPRESSION,
                                            "IfExpression");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.IF, 1, 1);
            alt.AddToken((int) CompoundConstants.LEFT_PAREN, 1, 1);
            alt.AddProduction((int) CompoundConstants.LOGICAL_EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.COMMA, 1, 1);
            alt.AddProduction((int) CompoundConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.COMMA, 1, 1);
            alt.AddProduction((int) CompoundConstants.EXPRESSION, 1, 1);
            alt.AddToken((int) CompoundConstants.RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.ADDITIVE_OPERATOR,
                                            "AdditiveOperator");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.ADD, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.SUB, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.MULTIPLICATIVE_OPERATOR,
                                            "MultiplicativeOperator");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.MUL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.DIV, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.MOD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.COMPARISON_OPERATOR,
                                            "ComparisonOperator");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.EQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.NE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.LT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.GT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.LE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.GE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.LOGICAL_OPERATOR,
                                            "LogicalOperator");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.AND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.OR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.XOR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.FACTOR,
                                            "Factor");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.ATOM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.LEFT_PAREN, 1, 1);
            alt.AddProduction((int) CompoundConstants.EXPRESSION, 1, 1);
            alt.AddProduction((int) SynteticPatterns.SUBPRODUCTION_6, 0, -1);
            alt.AddToken((int) CompoundConstants.RIGHT_PAREN, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.SPECIAL_FUNCTION_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) CompoundConstants.ATOM,
                                            "Atom");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.INTEGER, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.HEX, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.REAL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.STRING, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.CHAR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.NULL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.DATETIME, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.TRUE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.FALSE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.IDENTIFIER, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_1,
                                            "Subproduction1");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.LOGICAL_OPERATOR, 1, 1);
            alt.AddProduction((int) CompoundConstants.LOGICAL_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_2,
                                            "Subproduction2");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.COMPARISON_OPERATOR, 1, 1);
            alt.AddProduction((int) CompoundConstants.COMPARISON_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_3,
                                            "Subproduction3");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.ADDITIVE_OPERATOR, 1, 1);
            alt.AddProduction((int) CompoundConstants.ADDITIVE_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_4,
                                            "Subproduction4");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) CompoundConstants.MULTIPLICATIVE_OPERATOR, 1, 1);
            alt.AddProduction((int) CompoundConstants.MULTIPLICATIVE_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_5,
                                            "Subproduction5");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.POWER, 1, 1);
            alt.AddProduction((int) CompoundConstants.POWER_EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SynteticPatterns.SUBPRODUCTION_6,
                                            "Subproduction6");
            pattern.Synthetic = true;
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) CompoundConstants.COMMA, 1, 1);
            alt.AddProduction((int) CompoundConstants.EXPRESSION, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
