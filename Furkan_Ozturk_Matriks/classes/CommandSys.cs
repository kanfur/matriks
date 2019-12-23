using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class CommandSys
  {
    public static string comd;
    public static int index;

    public static Dictionary<int, int> indexPoint = new Dictionary<int, int>();
    //public static Hashtable indexPoint = new Hashtable(); //puanlamayı tutuyor. Ex: (1, 33) (2, 18)
    public static ArrayList output = new ArrayList(); //tüm işlemleri tutuyoruz. Yazma Formatını da kolaylıkla değiştirmemizi sağlıyor

    public static void add(string[] words)
    {
      IPriority pr;
      if (words != null && words.Length != 0)
      {
        int totalScore = 0;
        for (int i = 0; i < words.Length; i += 2)
        {
          pr = PriorityFactory.createPriority("" + words[i], "" + words[i + 1]);
          totalScore += pr.getScore();
        }
        if (!indexPoint.ContainsKey(index)) // aynı index tekrar eklenemez
        {
          indexPoint.Add(index, totalScore);
        }
        
      }
    }
    public static void edit(string[] words)
    {
      IPriority pr;
      if (words != null && words.Length != 0)
      {
        int totalScore = 0;
        for (int i = 0; i < words.Length; i += 2)
        {
          pr = PriorityFactory.createPriority("" + words[i], "" + words[i + 1]);
          totalScore += pr.getScore();
        }
        if (indexPoint.ContainsKey(index)) //bu index daha önce eklenmiş ise editleriz
        {
          indexPoint[index] = totalScore;
        }
      }
    }
    public static void remove()
    {
      try
      {
        indexPoint.Remove(index);
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public static void execute(string line)
    {
      output.Add(line);

      line = line.Trim();//başında ve sonundaki boşlukları sildik
      string[] words = line.Split(' '); //parçaladık
      comd = words[0]; //command tipi A, E, R
      index = int.Parse(words[1]);//command index 1,2,3,4

      if (comd == "A")
      {
        add(words.Skip(2).ToArray());
        pushPointsToOutputArray();
      }
      else if (comd == "E")
      {
        edit(words.Skip(2).ToArray());
        pushPointsToOutputArray();
      }
      else if (comd == "R")
      {
        remove();
        pushPointsToOutputArray();
      }
      else
      {
        throw new System.ArgumentException("Command Type belli değil!");
      }
    }
    public static void ReadFromFile(string inputtxt)
    {
      try
      {
        //string path = @"C:\Users\user\Desktop\Matriks\Furkan_Ozturk_Matriks\Furkan_Ozturk_Matriks\" + inputtxt;
        string path = @".\\" + inputtxt;
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

        StreamReader sw = new StreamReader(fs);
        string line = sw.ReadLine();
        while (line != null)
        {
          execute(line);
          line = sw.ReadLine();
        }
        sw.Close();
        fs.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine(inputtxt+ " the file couldnt be read");
      }
    }
    public static void pushPointsToOutputArray()
    {
      var list = indexPoint.OrderByDescending(e=>e.Value).ThenByDescending(e=>e.Key).ToList();
      //list.Sort();

      foreach (var key in list)
      {
        output.Add(key.Key + " " + key.Value);
      }
    }
    public static void writeToFile(string outputtxt)
    {
      try
      {
        //string path = @"C:\Users\user\Desktop\Matriks\Furkan_Ozturk_Matriks\Furkan_Ozturk_Matriks\" + outputtxt;
        string path = @".\\" + outputtxt;
        FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter sw = new StreamWriter(fs);
        foreach (string line in output) //output arraylisti dosyaya yazma şekline göre doldurulmuştur
        {
          //output arraylist içerisindekileri dosyaya yazıyoruz
          sw.WriteLine(line); 
          //consolea basıyoruz
          Console.WriteLine(line);
        }
        sw.Flush();
        sw.Close();
        fs.Close();
      }
      catch (Exception e)
      {
        Console.WriteLine(outputtxt+" the file couldnt be written");
      }
    }
    
  }
}
