using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCards
{
    [Serializable]
    public class Words
    {
        public List<Word> words { get; set; } = new List<Word>();
    }
}
