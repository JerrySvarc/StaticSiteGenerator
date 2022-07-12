﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSiteGenerator
{
    internal class SentencesNewlineParser : ISentencesParser
    {
        public ParagraphNode Parse(List<IToken> tokens)
        {
            List<Node> sentences;
            int consumed;
            MatchAllSentences(tokens, new SentenceParser(), out sentences, out consumed);
            if (tokens != null && (tokens.Count >= consumed + 2) && 
                 tokens[consumed].Type == TokenType.NEWLINE && 
                 tokens[consumed+1].Type == TokenType.NEWLINE)
            {
                return ParagraphNode.ParagraphNodeFactory(sentences, consumed+2);
            }
            return null;
        }

        public void MatchAllSentences(List<IToken> tokens, SentenceParser sentenceParser, out List<Node> sentences, out int consumed)
        {
            sentences = new List<Node>();
            consumed = 0;

            while (true)
            {
                var sentence = sentenceParser.Parse(tokens.GetRange(consumed, tokens.Count));
                if (sentence == null)
                {
                    break;
                }
                sentences.Add(sentence);
                consumed += sentence.Consumed;
            }
        }

    }
}
