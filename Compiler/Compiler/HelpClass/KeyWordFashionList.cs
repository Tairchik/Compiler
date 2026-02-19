using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerGUI.HelpClass
{
    public class KeyWordFashionList
    {
        public List<KeyWordFashion> keyWordViews;
        public Color baseColor = Color.White;

        public KeyWordFashionList()
        {
            keyWordViews = new List<KeyWordFashion>();
        }

        public KeyWordFashionList(Dictionary<Color, string[]> colorWordsDict)
        {
            keyWordViews = convertFromDict(colorWordsDict);
        }

        public KeyWordFashionList(List<KeyWordFashion> keyWordViews)
        {
            this.keyWordViews = keyWordViews;
        }

        public Color GetColorByKeyWord(string word)
        {
            word = word.ToLower().Trim();
            foreach (var keyWordView in keyWordViews) 
            {
                foreach(var str in keyWordView.KeyWords) 
                {
                    if (string.Compare(str, word) == 0) 
                    {
                        return keyWordView.Color;
                    }
                }
            }

            return baseColor;
        }

        public void Add(string[] keyWords, Color color)
        {
            KeyWordFashion keyWordView = new KeyWordFashion(color, reductionToOneForm(keyWords));
            keyWordViews.Add(keyWordView);
        }

        public void Add(List<string> keyWords, Color color)
        {
            KeyWordFashion keyWordView = new KeyWordFashion(color, reductionToOneForm(keyWords));
            keyWordViews.Add(keyWordView);
        }

        private List<string> reductionToOneForm(string[] keyWords)
        {
            List<string> oneFormStr = new List<string>();

            foreach (string word in keyWords)
            {
                oneFormStr.Add(word.ToLower());
            }
            return oneFormStr;
        }

        private List<string> reductionToOneForm(List<string> keyWords)
        {
            for (int i = 0; i < keyWords.Count; i++)
            {
                keyWords[i] = keyWords[i].ToLower();
            }
            return keyWords;
        }

        private List<KeyWordFashion> convertFromDict(Dictionary<Color, string[]> dict)
        {
            List<KeyWordFashion> result = new List<KeyWordFashion>();
            foreach (Color color in dict.Keys) 
            {
                result.Add(new KeyWordFashion(color, new List<string>(dict[color])));
                foreach (var i in dict[color]) 
                {
                    if (i == "@BASE@") 
                    {
                        baseColor = color;
                    }
                    break;
                }
            }
            return result;
        }

    }
}
