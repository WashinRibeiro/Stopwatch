using System;
using System.Threading;

namespace Stopwatch
{

    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Selecione o tipo de cronômetro desejado: ");
            Console.WriteLine("1 - Cronômetro regressivo");
            Console.WriteLine("2 - Cronômetro progressivo");
            Console.WriteLine("--------------------------");
            short option = short.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("S = Segundos (Ex.: 10s = 10segundos)");
            Console.WriteLine("M = Minutos (Ex: 1m = 1minuto)");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Quanto tempo deseja contar?");

            // Conversão para minúsculo	
            string data = Console.ReadLine().ToLower();

            // Pegar o caracter da ultima posição da string
            char type = char.Parse(data.Substring(data.Length - 1, 1));

            // Pegar o tempo que foi digitado pelo usuário sem o caracter type
            int time = int.Parse(data.Substring(0, data.Length - 1));

            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;

            if (time == 0 || (type != 's' && type != 'm'))
                System.Environment.Exit(0);

            Console.Clear();
            Console.WriteLine("Valores selecionados:");
            Console.WriteLine("Tipo de cronômetro: " + (option == 1 ? "Regressivo" : "Progressivo"));
            Console.WriteLine("Tempo: " + time + (type == 's' ? "segundos" : "minutos"));
            
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Aperte enter para iniciar");
            Console.ReadKey();

            PreStart(time * multiplier, option);
        }

        static void PreStart(int time, short option)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            if (option == 1) StartRegressive(time);
            if (option == 2) StartProgressive(time);
        }
        static void StartProgressive(int time)
        {
            int currentTime = 0;

            while (currentTime < time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);

                // O Thread é o processo atual da máquina e o Sleep é o tempo que ele vai esperar para executar a próxima linha
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado!");
            Thread.Sleep(2000);
        }

        static void StartRegressive(int time)
        {
            int currentTime = 0;

            while (time > currentTime)
            {
                Console.Clear();
                time--;
                Console.Write(time);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado!");
            Thread.Sleep(2000);
        }
    }
}