using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class AlphaPriority : IPriority
  {
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private char alpha;

    public AlphaPriority(char alpha)
    {
      this.alpha = alpha;
    }
    public char getAlpha()
    {
      return alpha;
    }
    public int getIndex()
    {
      char searchAlpha = getAlpha();
      int index = Array.IndexOf(alphabet, Char.ToLower(searchAlpha));
      return index + 1;
    }

    public string getPriorityType()
    {
      return "*** Alpha Priority ***";
    }

    public int getScore()
    {
      if (alpha != null || alpha != ' ')
      {
        return getIndex();
      }
      return 0;
    }
  }
}
