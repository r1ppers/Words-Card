using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCards
{
    [Serializable]
    public class Word
    {
        public string word { get; set; }
        public List<string> tranlations = new List<string>();
        public List<string> examples = new List<string>();
    }
}
