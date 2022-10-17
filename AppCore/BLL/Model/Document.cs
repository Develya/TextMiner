﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.BLL.Model
{
    public class Document
    {
        public String text { get; set; }

        public IList<Shingle> Shingles { get; set; }

        public Document(string text)
        {
            this.text = text;
            this.Shingles = new List<Shingle>();
        }

        /*
         * NORMALIZATION 
        */

        // Convert all letters to lowercase, remove punctuation, remove extra whitespaces and remove stop words
        public String Normalize()
        {
            StringBuilder buffer = new(this.text.ToLower());
            
            buffer = Document.RemovePunctuation(buffer.ToString());
            buffer = Document.RemoveExtraWhiteSpace(buffer.ToString());
            buffer = new StringBuilder(Document.RemoveStopWords(buffer.ToString()));

            String normalizedText = buffer.ToString();

            this.text = normalizedText;

            return normalizedText;
        }

        private static StringBuilder RemovePunctuation(String text)
        {
            StringBuilder textWithoutPunctuation = new StringBuilder("");

            foreach (char character in text)
                if (!char.IsPunctuation(character))
                    textWithoutPunctuation.Append(character);

            return textWithoutPunctuation;
        }

        private static StringBuilder RemoveExtraWhiteSpace(String text)
        {
            StringBuilder textWithoutExtraWhiteSpace = new StringBuilder("");
            bool lastCharacterIsWhiteSpace = true;
            
            // Remove duplicate white spaces and beginning white space
            foreach (char character in text)
            {
                if (character == ' ')
                {
                    if (lastCharacterIsWhiteSpace)
                        continue;

                    lastCharacterIsWhiteSpace = true;
                    textWithoutExtraWhiteSpace.Append(character);
                    continue;
                }

                textWithoutExtraWhiteSpace.Append(character);
                lastCharacterIsWhiteSpace = false;
            }

            // Remove end whitespace
            char lastCharacterOfText = textWithoutExtraWhiteSpace[^1];

            if (lastCharacterOfText == ' ')
                return textWithoutExtraWhiteSpace.Remove(textWithoutExtraWhiteSpace.Length - 1, 1);
            
            return textWithoutExtraWhiteSpace;
        }

        private static String RemoveStopWords(String text)
        {
            StringBuilder textWithoutStopWords = new StringBuilder("");

            List<String> stopWords = new List<String>
                { "a", "you", "for", "the", "to", "and", "that", "it", "is" };

            // Words that are not stop words
            List<String> allValidWords = new List<string>();

            string[] words = text.Split();

            foreach (string word in words) {
                if (stopWords.Contains(word))
                    continue;
                allValidWords.Add(word);
            }

            return String.Join(" ", allValidWords);
        }

        /*
         * SHINGLIZATION
        */

        public void Shinglize(int k, String level)
        {
            // Reset list of shingles of document
            this.Shingles = new List<Shingle>();
            if (level == "WORD")
                WordBasedShinglization(k);
            else
                CharacterBasedShinglization(k);
        }

        private void WordBasedShinglization(int k)
        {
            string[] parts = this.text.Split();
            // For every word in document
            for (int i = 0; i < parts.Length; i++)
            {
                String temp = "";

                int j = 0;
                // iterates k times as long as it does not exceed the length of the document
                while ((j < k) && (i + k <= parts.Length))
                {
                    // Make sure there is no space added at the beginning of the temp string
                    if (j == 0)
                        temp = parts[i + j];
                    else
                        temp = temp + ' ' + parts[i+j];
                    j++;
                }
                // Verify that the number of words corresponds the number of words needed (ex: if k=2, then we need 2 words)
                if (temp.Split().Length == k)
                    this.Shingles.Add(new Shingle(temp, k));
            }
        }

        private void CharacterBasedShinglization(int k)
        {
            List<char> chars = new List<char>();
            chars.AddRange(Document.RemoveAllWhiteSpaces(this.text));
            // For every character in document
            for (int i = 0; i < chars.Count; i++)
            {
                String temp = "";

                int j = 0;
                // iterates k times as long as it does not exceed the length of the document
                while ((j < k) && (i + k <= chars.Count))
                {
                    temp = temp + chars[i + j];
                    j++;
                }
                // Verify that the number of characters corresponds the number of characters needed (ex: if k=2, then we need 2 characters)
                if (temp.Length == k)
                    this.Shingles.Add(new Shingle(temp, k));
            }
        }

        private static String RemoveAllWhiteSpaces(String text)
        {
            List<char> chars = new List<char>();
            chars.AddRange(text);
            StringBuilder textWithoutWhiteSpace = new();

            foreach (char c in chars)
            {
                if (c == ' ')
                    continue;
                textWithoutWhiteSpace.Append(c);
            }

            return textWithoutWhiteSpace.ToString();
        }


        public override string ToString()
        {
            return this.text;
        }
    }
}