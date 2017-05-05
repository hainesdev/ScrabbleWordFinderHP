using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace TestApplication
{
    public class WordFinder
    {
        List<string> wordlist = new List<string>();
        List<string> result;
        //List<DataItem> dataList = new List<DataItem>();
        public WordFinder()
        {
            // Read the file and display it line by line.  
            try {
                string resource_data = Properties.Resources.words;
                //List<string> words = 
                wordlist = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                //System.IO.StreamReader file = new System.IO.StreamReader(@".\Resources\words.TXT");
                //new System.IO.StreamReader(@".\\words.txt");
                //while ((line = file.ReadLine()) != null)
            //{
                //wordlist.Add(line);
            //}
            //file.Close();
            wordlist.Sort();
            }
            catch (FileNotFoundException e)
            {
                string line;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.
                string message = "Couldn't open ";
                message += "words.txt";
                message += " please select a dictionary text file.";
                result = MessageBox.Show(message, "File not found", buttons);

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Text Files | *.txt";
                openFile.ShowDialog();
                StreamReader file = File.OpenText(openFile.FileName);
                while ((line = file.ReadLine()) != null)
                {
                    wordlist.Add(line);
                }
                file.Close();
                wordlist.Sort();
                // FileNotFoundExceptions are handled here.  
            }

        }


        public List<DataItem> FindWords(String Tiles)
        {
            Tiles = Tiles.ToUpper();
            char[] query = new char[Tiles.Length];
            Array.Copy(Tiles.ToCharArray(), query, Tiles.Length);
            result = fwords(query, wordlist);

            List<DataItem> dataList = new List<DataItem>();

            foreach (string word in result)
            {
                int score = wordscore(word.ToCharArray(), word.Length);
                DataItem item = new DataItem(word, word.Length, score);
                dataList.Add(item);
            }
            return dataList;
        }
        static bool isNotWild(char n)
        {
            return n != '?';
        }
        public List<DataItem> PatternMatch(String Tiles, String Pattern)
        {
            Tiles = Tiles.ToUpper();
            char[] query = new char[Tiles.Length];
            Array.Copy(Tiles.ToCharArray(), query, Tiles.Length);
            Pattern = Pattern.ToUpper();
            char[] queryp = new char[Pattern.Length];
            Array.Copy(Pattern.ToCharArray(), queryp, Pattern.Length);
            //Add both queries together
            char[] querycom = Array.FindAll(queryp, isNotWild).ToArray();
            int ql = querycom.Length;
            Array.Resize<char>(ref querycom, ql + query.Length);
            Array.Copy(query, 0, querycom, ql, query.Length);

            //textBox2.Text = new string(querycom);

            result = fwords(querycom, wordlist);
            result = pwords(queryp, result);
            List<DataItem> dataList = new List<DataItem>();
            foreach (string word in result)
            {
                DataItem item = new DataItem(word, word.Length, wordscore(word.ToCharArray(), word.Length));
                dataList.Add(item);
            }
            return dataList;
        }
        private List<string> pwords(char[] query, List<string> words)
        {
            //char[] queryletter = Array.FindAll(query, isNotWild).ToArray();
            List<string> results = new List<string>();
            int wordsfound = 0;

            //letter match count
            char[] queryletter = Array.FindAll(query, isNotWild).ToArray();
            int matchcount = queryletter.Length;

            foreach (string word in words)
            {
                //word array
                char[] worda = new char[word.Length];
                Array.Copy(word.ToCharArray(), worda, word.Length);
                //query array
                char[] querya = new char[query.Length];
                Array.Copy(query, querya, query.Length);
                while (true)
                {
                    if (worda.Length > querya.Length)
                    {
                        break;
                    }
                    if (pmatch(worda, querya, matchcount) == true)
                    {
                        results.Add(word);
                        wordsfound++;
                        break;
                    }
                    else if (querya[0] == '?')
                    {
                        //remove character at beggining of querya if wild(linq)
                        querya = querya.Where((source, index) => index != 0).ToArray();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //labelwf.Text = "Words Found:" + wordsfound;
            return results;
        }

        private bool pmatch(char[] word, char[] query, int matchcount)
        {
            int matchp = matchcount;
            for (int i = 0; i < word.Length; i += 1)
            {

                if (word[i] == query[i] || (query[i] == '?'))
                {

                    if (query[i] != '?')
                    {
                        matchp -= 1;
                    }
                    continue;
                }
                break;
            }
            return (matchp == 0);
        }

        private List<string> fwords(char[] query, List<string> words)
        {
            List<string> results = new List<string>();
            //sort the query, symbols to letters.
            Array.Sort(query);
            int wordsfound = 0;
            //for each word in the list
            foreach (string word in words)
            {
                //if the word is too long skip it
                if (word.Length > query.Length)
                {
                    continue;
                }
                //query array
                char[] querya = new char[query.Length];
                Array.Copy(query, querya, query.Length);
                //word array
                char[] worda = new char[word.Length];
                Array.Copy(word.ToCharArray(), worda, word.Length);

                //letter match count
                int match = word.Length;
                //for the length of the word: each letter
                for (int i = 0; i < word.Length; i += 1)
                {
                    //for the lenght of the query
                    //check each letter against word.
                    //do it in reverse so wildcards are matched last
                    for (int j = query.Length - 1; j >= 0; j -= 1)
                    {
                        if ((worda[i] == querya[j] && (querya[j] != '0')) || (querya[j] == '?'))
                        {
                            //change char to a kinda null value
                            //so it's only used once.
                            querya[j] = '0';
                            worda[i] = '0';
                            match -= 1;
                            //if each letter in the word matches a letter in
                            //query add word.
                            if (match == 0)
                            {
                                results.Add(word);
                                wordsfound++;
                                break;
                            }
                        }
                    }
                }
            }
            //labelwf.Text = "Words Found:" + wordsfound;
            return results;
        }

        private int wordscore(char[] worda, int length)
        {
            int score = 0;
            int[] chartable = new int[] {
                1, 3, 3, 2, 1, 4, 2, 4, 1, 8, 5, 1, 3, 1, 1, 3, 10, 1, 1, 1, 1, 4, 4, 8, 4, 10
            };
            for (int j = 0; j < length; j += 1)
            {
                score += chartable[(worda[j] - 'A')];
            }
            return score;
        }
    }
}