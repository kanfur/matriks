using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class TimePriority : IPriority
  {
    private int time;

    public TimePriority(int time)
    {

      this.time = time;
    }
    public int getTime()
    {
      return time;
    }
    public string getPriorityType()
    {
      return "*** Time Priority ***";
    }
    public int getScore()
    {
      if (time <= 4)
      {
        return 10;
      }
      else if (time <= 30)
      {
        return 3;
      }
      else
      {
        return 1;
      }
      throw new System.ArgumentException("Time priority belli değil!");
    }
  }
}
