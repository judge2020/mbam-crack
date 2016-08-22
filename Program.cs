// Decompiled with JetBrains decompiler
// Type: MB_AM_crack.Program
// Assembly: MB-AM crack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F6582E4-B7CD-45C0-902C-4EFD3F8654B0
// Assembly location: C:\Users\judge2020\Downloads\MB-AM crack.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace MB_AM_crack
{
  internal class Program
  {
    public ConsoleKeyInfo option;
    private static Program.ConsoleEventDelegate handler;

    private static void Main(string[] args)
    {
      Program.handler = new Program.ConsoleEventDelegate(Program.ConsoleEventCallback);
      Program.SetConsoleCtrlHandler(Program.handler, true);
      Console.WriteLine("Enable l33t music? y/n");
      if (Console.ReadLine() == "y")
        new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("MB_AM_crack.khg.wav")).PlayLooping();
      Console.WriteLine(" __  __ ____          _    __  __    ____ ____      _    ____ _  __");
      Console.WriteLine("|  \\/  | __ )        / \\  |  \\/  |  / ___|  _ \\    / \\  / ___| |/ /");
      Console.WriteLine("| |\\/| |  _ \\ _____ / _ \\ | |\\/| | | |   | |_) |  / _ \\| |   | ' / ");
      Console.WriteLine("| |  | | |_) |_____/ ___ \\| |  | | | |___|  _ <  / ___ \\ |___| . \\ ");
      Console.WriteLine("|_|  |_|____/     /_/   \\_\\_|  |_|  \\____|_| \\_\\/_/   \\_\\____|_|\\_\\");
      Console.WriteLine("                                                                   ");
      Console.WriteLine(" ");
      Console.WriteLine(" ");
      Program.mainmenu();
    }

    private static void mainmenu()
    {
      Console.WriteLine(" ");
      Console.WriteLine(" ");
      Console.WriteLine("                                main Menu                           ");
      Console.WriteLine("type the number then press enter. go in order for first use.");
      Console.WriteLine("1. Install MBAM 2.1.8");
      Console.WriteLine("2. Install crack (MBAM 2.1.8 required)");
      Console.WriteLine("3. Block activation key check");
      Console.WriteLine("4. Credits and exit");
      string str1 = Console.ReadLine();
      string str2 = "1";
      if (str1 == str2)
        Program.install();
      string str3 = "2";
      if (str1 == str3)
        Program.crack();
      string str4 = "3";
      if (str1 == str4)
        Program.block();
      string str5 = "4";
      if (str1 == str5)
      {
        Program.reddit();
      }
      else
      {
        Console.WriteLine("Please enter a valid number.");
        Program.mainmenu();
      }
    }

    private static void install()
    {
      string str = "MB_AM_crack.mbam218.exe";
      string tempPath = Path.GetTempPath();
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(str))
      {
        using (FileStream fileStream = new FileStream(Path.Combine(tempPath, str), FileMode.Create))
        {
          for (int index = 0; (long) index < manifestResourceStream.Length; ++index)
            fileStream.WriteByte((byte) manifestResourceStream.ReadByte());
          fileStream.Close();
        }
      }
      Process.Start(tempPath + str);
      Program.mainmenu();
    }

    private static void crack()
    {
      string str = "MB_AM_crack.activation218.exe";
      string tempPath = Path.GetTempPath();
      using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(str))
      {
        using (FileStream fileStream = new FileStream(Path.Combine(tempPath, str), FileMode.Create))
        {
          for (int index = 0; (long) index < manifestResourceStream.Length; ++index)
            fileStream.WriteByte((byte) manifestResourceStream.ReadByte());
          fileStream.Close();
        }
      }
      Process.Start(tempPath + str);
      Program.mainmenu();
    }

    private static void block()
    {
      Console.WriteLine("Now attempting to write to HOST file to block access to the Malwarebytes host server...");
      Thread.Sleep(1000);
      string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
      Console.WriteLine(folderPath);
      string path2 = "drivers\\etc\\hosts";
      using (StreamWriter streamWriter = new StreamWriter(Path.Combine(folderPath, path2), true, Encoding.Default))
      {
        streamWriter.WriteLine("#mb-am crack host setting");
        streamWriter.WriteLine("0.0.0.0 keystone.mwbsys.com");
      }
      Program.mainmenu();
    }

    private static void reddit()
    {
      Process.Start("http://judge2020.com/mbam.html");
      Environment.Exit(0);
    }

    private static bool ConsoleEventCallback(int eventType)
    {
      if (eventType == 2)
        Program.reddit();
      return false;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleCtrlHandler(Program.ConsoleEventDelegate callback, bool add);

    private delegate bool ConsoleEventDelegate(int eventType);
  }
}
