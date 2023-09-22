using System;
using System.Diagnostics;
using System.IO;

namespace ProgramInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь к установщику программы
            string chromeInstallerPath = @"C:\Users\User\Desktop\Application\chrome_setup.exe";
            string wordInstallerPath = @"C:\Users\User\Desktop\Application\word_setup.exe";

            // Имя процесса программы
            string chromeProcessName = "chrome";
            string wordProcessName = "winword";

            // Путь к файлу лога
            string logFilePath = @"C:\Users\User\Desktop\Application\log.txt";

            // Открываем файл лога для записи
            StreamWriter logFile = new StreamWriter(logFilePath, true);

            // Проверяем наличие процесса программы
            if (!IsProcessRunning(chromeProcessName))
            {
                // Программа не запущена, запускаем установщик
                if (File.Exists(chromeInstallerPath))
                {
                    Console.WriteLine("Установка Google Chrome...");
                    logFile.WriteLine(DateTime.Now + " Установка Google Chrome...");
                    Process.Start(chromeInstallerPath);
                    Console.WriteLine("Установка Google Chrome завершена");
                    logFile.WriteLine(DateTime.Now + " Установка Google Chrome завершена");
                }
                else
                {
                    Console.WriteLine("Установщик Google Chrome не найден");
                    logFile.WriteLine(DateTime.Now + " Установщик Google Chrome не найден");
                }
            }
            else
            {
                // Программа запущена, проверяем версию
                string installedVersion = "1.0"; // Получаем версию из файла или реестра
                string serverVersion = "1.1"; // Получаем версию с сервера
                if (installedVersion != serverVersion)
                {
                    // Запускаем процесс обновления
                    string updaterPath = @"C:\Program Files\Google Chrome\updater.exe";
                    if (File.Exists(updaterPath))
                    {
                        Console.WriteLine("Обновление Google Chrome...");
                        logFile.WriteLine(DateTime.Now + " Обновление Google Chrome...");
                        Process.Start(updaterPath);
                        Console.WriteLine("Обновление Google Chrome завершено");
                        logFile.WriteLine(DateTime.Now + " Обновление Google Chrome завершено");
                    }
                    else
                    {
                        Console.WriteLine("Программа обновления Google Chrome не найдена");
                        logFile.WriteLine(DateTime.Now + " Программа обновления Google Chrome не найдена");
                    }
                }
            }

            if (!IsProcessRunning(wordProcessName))
            {
                // Программа не запущена, запускаем установщик
                if (File.Exists(wordInstallerPath))
                {
                    Console.WriteLine("Установка Microsoft Word...");
                    logFile.WriteLine(DateTime.Now + " Установка Microsoft Word...");
                    Process.Start(wordInstallerPath);
                    Console.WriteLine("Установка Microsoft Word завершена");
                    logFile.WriteLine(DateTime.Now + " Установка Microsoft Word завершена");
                }
                else
                {
                    Console.WriteLine("Установщик Microsoft Word не найден");
                    logFile.WriteLine(DateTime.Now + " Установщик Microsoft Word не найден");
                }
            }
            else
            {
                // Программа запущена, проверяем версию
                string installedVersion = "1.0"; // Получаем версию из файла или реестра
                string serverVersion = "1.1"; // Получаем версию с сервера
                if (installedVersion != serverVersion)
                {
                    // Запускаем процесс обновления
                    string updaterPath = @"C:\Program Files\WO01 Soft\updater.exe";
                    if (File.Exists(updaterPath))
                    {
                        Console.WriteLine("Обновление Microsoft Word...");
                        logFile.WriteLine(DateTime.Now + " Обновление Microsoft Word...");
                        Process.Start(updaterPath);
                        Console.WriteLine("Обновление Microsoft Word завершено");
                        logFile.WriteLine(DateTime.Now + " Обновление Microsoft Word завершено");
                    }
                    else
                    {
                        Console.WriteLine("Программа обновления Microsoft Word не найдена");
                        logFile.WriteLine(DateTime.Now + " Программа обновления Microsoft Word не найдена");
                    }
                }
            }

            // Закрываем файл лога
            logFile.Close();
            Console.ReadLine();
        }

        static bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }
    }
}