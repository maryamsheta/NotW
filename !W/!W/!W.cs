
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_EXCLAM        =  4, // '!'
        SYMBOL_PERCENT       =  5, // '%'
        SYMBOL_LPAREN        =  6, // '('
        SYMBOL_RPAREN        =  7, // ')'
        SYMBOL_TIMES         =  8, // '*'
        SYMBOL_TIMESTIMES    =  9, // '**'
        SYMBOL_COMMA         = 10, // ','
        SYMBOL_DIV           = 11, // '/'
        SYMBOL_QUESTION      = 12, // '?'
        SYMBOL_LBRACE        = 13, // '{'
        SYMBOL_RBRACE        = 14, // '}'
        SYMBOL_PLUS          = 15, // '+'
        SYMBOL_AND           = 16, // and
        SYMBOL_DIGIT         = 17, // DIGIT
        SYMBOL_DO            = 18, // do
        SYMBOL_EQUAL         = 19, // equal
        SYMBOL_EQUALS        = 20, // equals
        SYMBOL_FROM          = 21, // from
        SYMBOL_GOODBYE       = 22, // GoodBye
        SYMBOL_GREATER       = 23, // greater
        SYMBOL_HELLO         = 24, // Hello
        SYMBOL_ID            = 25, // ID
        SYMBOL_IS            = 26, // is
        SYMBOL_NO            = 27, // no
        SYMBOL_NOT           = 28, // not
        SYMBOL_OR            = 29, // or
        SYMBOL_RETURN        = 30, // return
        SYMBOL_SMALLER       = 31, // smaller
        SYMBOL_THAN          = 32, // than
        SYMBOL_TO            = 33, // to
        SYMBOL_YES           = 34, // yes
        SYMBOL_ASSIGN        = 35, // <assign>
        SYMBOL_COMP          = 36, // <comp>
        SYMBOL_CONCEPT       = 37, // <concept>
        SYMBOL_CONDITION     = 38, // <condition>
        SYMBOL_DIGIT2        = 39, // <digit>
        SYMBOL_EXPR          = 40, // <expr>
        SYMBOL_FACT          = 41, // <fact>
        SYMBOL_FROM2         = 42, // <from>
        SYMBOL_FUNCTION_CALL = 43, // <function_call>
        SYMBOL_FUNCTION_DEC  = 44, // <function_dec>
        SYMBOL_ID2           = 45, // <id>
        SYMBOL_IS2           = 46, // <is>
        SYMBOL_LOGICAL       = 47, // <logical>
        SYMBOL_PARAMS        = 48, // <params>
        SYMBOL_POWER         = 49, // <power>
        SYMBOL_PROGRAM       = 50, // <program>
        SYMBOL_RETURN2       = 51, // <return>
        SYMBOL_STMT_LIST     = 52, // <stmt_list>
        SYMBOL_TERM          = 53  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_EXCLAM_GOODBYE_EXCLAM_HELLO               =  0, // <program> ::= '!' GoodBye <stmt_list> '!' Hello
        RULE_STMT_LIST                                         =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                        =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                           =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                          =  4, // <concept> ::= <is>
        RULE_CONCEPT3                                          =  5, // <concept> ::= <from>
        RULE_CONCEPT4                                          =  6, // <concept> ::= <function_dec>
        RULE_CONCEPT5                                          =  7, // <concept> ::= <function_call>
        RULE_CONCEPT6                                          =  8, // <concept> ::= <return>
        RULE_ASSIGN_EQUALS                                     =  9, // <assign> ::= <id> equals <expr>
        RULE_ID_ID                                             = 10, // <id> ::= ID
        RULE_EXPR_PLUS                                         = 11, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                        = 12, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                              = 13, // <expr> ::= <term>
        RULE_TERM_TIMES                                        = 14, // <term> ::= <term> '*' <fact>
        RULE_TERM_DIV                                          = 15, // <term> ::= <term> '/' <fact>
        RULE_TERM_PERCENT                                      = 16, // <term> ::= <term> '%' <fact>
        RULE_TERM                                              = 17, // <term> ::= <fact>
        RULE_FACT_TIMESTIMES                                   = 18, // <fact> ::= <fact> '**' <power>
        RULE_FACT                                              = 19, // <fact> ::= <power>
        RULE_POWER_LPAREN_RPAREN                               = 20, // <power> ::= '(' <power> ')'
        RULE_POWER                                             = 21, // <power> ::= <id>
        RULE_POWER2                                            = 22, // <power> ::= <digit>
        RULE_POWER3                                            = 23, // <power> ::= <function_call>
        RULE_DIGIT_DIGIT                                       = 24, // <digit> ::= DIGIT
        RULE_IS_IS_QUESTION_YES_LBRACE_RBRACE                  = 25, // <is> ::= is <condition> '?' yes '{' <stmt_list> '}'
        RULE_IS_IS_QUESTION_YES_LBRACE_RBRACE_NO_LBRACE_RBRACE = 26, // <is> ::= is <condition> '?' yes '{' <stmt_list> '}' no '{' <stmt_list> '}'
        RULE_CONDITION                                         = 27, // <condition> ::= <expr> <comp> <expr>
        RULE_CONDITION2                                        = 28, // <condition> ::= <expr> <comp> <expr> <logical> <condition>
        RULE_COMP_EQUAL_TO                                     = 29, // <comp> ::= equal to
        RULE_COMP_NOT_EQUAL_TO                                 = 30, // <comp> ::= not equal to
        RULE_COMP_SMALLER_THAN                                 = 31, // <comp> ::= smaller than
        RULE_COMP_NOT_SMALLER_THAN                             = 32, // <comp> ::= not smaller than
        RULE_COMP_GREATER_THAN                                 = 33, // <comp> ::= greater than
        RULE_COMP_NOT_GREATER_THAN                             = 34, // <comp> ::= not greater than
        RULE_LOGICAL_AND                                       = 35, // <logical> ::= and
        RULE_LOGICAL_OR                                        = 36, // <logical> ::= or
        RULE_FROM_FROM_TO_DO_LBRACE_RBRACE                     = 37, // <from> ::= from <assign> to <digit> do '{' <stmt_list> '}'
        RULE_FUNCTION_DEC_LPAREN_RPAREN_LBRACE_RBRACE          = 38, // <function_dec> ::= <id> '(' <params> ')' '{' <stmt_list> '}'
        RULE_FUNCTION_CALL_LPAREN_RPAREN                       = 39, // <function_call> ::= <id> '(' <params> ')'
        RULE_PARAMS                                            = 40, // <params> ::= <id>
        RULE_PARAMS_COMMA                                      = 41, // <params> ::= <id> ',' <params>
        RULE_PARAMS2                                           = 42, // <params> ::= 
        RULE_RETURN_RETURN                                     = 43, // <return> ::= return
        RULE_RETURN_RETURN2                                    = 44  // <return> ::= return <expr>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox listbox;

        public MyParser(string filename,ListBox listBox)
        {
            this.listbox = listBox; 
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AND :
                //and
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //DIGIT
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUAL :
                //equal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALS :
                //equals
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM :
                //from
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GOODBYE :
                //GoodBye
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GREATER :
                //greater
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HELLO :
                //Hello
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //ID
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IS :
                //is
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NO :
                //no
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOT :
                //not
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OR :
                //or
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SMALLER :
                //smaller
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THAN :
                //than
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TO :
                //to
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_YES :
                //yes
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMP :
                //<comp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITION :
                //<condition>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACT :
                //<fact>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FROM2 :
                //<from>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_DEC :
                //<function_dec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IS2 :
                //<is>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICAL :
                //<logical>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMS :
                //<params>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POWER :
                //<power>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN2 :
                //<return>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_EXCLAM_GOODBYE_EXCLAM_HELLO :
                //<program> ::= '!' GoodBye <stmt_list> '!' Hello
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <is>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <from>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <function_dec>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <return>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQUALS :
                //<assign> ::= <id> equals <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= ID
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <fact>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACT_TIMESTIMES :
                //<fact> ::= <fact> '**' <power>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACT :
                //<fact> ::= <power>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWER_LPAREN_RPAREN :
                //<power> ::= '(' <power> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWER :
                //<power> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWER2 :
                //<power> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POWER3 :
                //<power> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= DIGIT
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IS_IS_QUESTION_YES_LBRACE_RBRACE :
                //<is> ::= is <condition> '?' yes '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IS_IS_QUESTION_YES_LBRACE_RBRACE_NO_LBRACE_RBRACE :
                //<is> ::= is <condition> '?' yes '{' <stmt_list> '}' no '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION :
                //<condition> ::= <expr> <comp> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITION2 :
                //<condition> ::= <expr> <comp> <expr> <logical> <condition>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_EQUAL_TO :
                //<comp> ::= equal to
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_NOT_EQUAL_TO :
                //<comp> ::= not equal to
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_SMALLER_THAN :
                //<comp> ::= smaller than
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_NOT_SMALLER_THAN :
                //<comp> ::= not smaller than
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_GREATER_THAN :
                //<comp> ::= greater than
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COMP_NOT_GREATER_THAN :
                //<comp> ::= not greater than
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_AND :
                //<logical> ::= and
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICAL_OR :
                //<logical> ::= or
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FROM_FROM_TO_DO_LBRACE_RBRACE :
                //<from> ::= from <assign> to <digit> do '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_DEC_LPAREN_RPAREN_LBRACE_RBRACE :
                //<function_dec> ::= <id> '(' <params> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_LPAREN_RPAREN :
                //<function_call> ::= <id> '(' <params> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS :
                //<params> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS_COMMA :
                //<params> ::= <id> ',' <params>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMS2 :
                //<params> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_RETURN :
                //<return> ::= return
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_RETURN2 :
                //<return> ::= return <expr>
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '" + args.Token.ToString() + "'";
            listbox.Items.Add(message);
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '" + args.UnexpectedToken.ToString() + "in line" + args.UnexpectedToken.Location.LineNr;
            string message2 = "Expected token: " + args.ExpectedTokens.ToString().Replace(" ", ",");
            listbox.Items.Add(message);
            listbox.Items.Add(message2);

        }

    }
}
