using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class ColorPriority : IPriority
  {
    private string color;

    public ColorPriority(string color)
    {
      this.color = color;
    }
    public string getColor()
    {
      return color;
    }

    public string getPriorityType()
    {
      return "*** Color Priority ***";
    }

    public int getScore()
    {
      if (color == "Blue")
      {
        return 18;
      }
      else if (color == "Red")
      {
        return 20;
      }
      else if (color == "Green")
      {
        return 4;
      }
      else
      {
        throw new System.ArgumentException("Color belli değil!");
        return 0;
      }
    }
  }
}
