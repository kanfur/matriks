using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class PriorityFactory
  {
    public static IPriority createPriority(string type, string usage)
    {
      if (type.Equals("T"))
      {
        return new TimePriority(int.Parse(usage));
      }
      else if (type.Equals("C"))
      {
        return new ColorPriority(usage);
      }
      else if (type.Equals("A"))
      {
        return new AlphaPriority(char.Parse(usage));
      }
      else
      {
        throw new System.ArgumentException("Priority Type belli değil!");
      }
    }
  }
}
