using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furkan_Ozturk_Matriks.classes
{
  class Program
  {
    static void Main(string[] args)
    {
      /***
       * input.txt dosyalarını Furkan_Ozturk_Matriks bin/debug klasörünün içerisine konmalı
       * Priority için Factory Method design pattern kullanıldı. Kolaylıkla priority ekleyebilir ve içeriğini değiştirebiliriz
       * Priority için girilen komutlar CommandSys classı içerisinde execute metodu içinde bulunuyor. Kolaylıkla değişiklik yapabiliriz.
       * CommandSys içerisinden Okuma formatını ya da output.txt için yazma formatını kolayca değiştirebiliriz.
       * her değişikliklerden sonra queue düzgünce sıralanır (önce value değeri sonra key değerine göre sıralanır)
       * ***/
      if (args.Length > 0)
      {
        if(args.Length >= 2)
        {
          //command line arguments
          CommandSys.ReadFromFile(args[0]);
          CommandSys.writeToFile(args[1]);
        }else
        {
          Console.WriteLine("Please, write 2 arguments !");
        }
        
      }

      else
      {
        Console.WriteLine("No command line arguments found.");
      }
      
    }
  }
}
