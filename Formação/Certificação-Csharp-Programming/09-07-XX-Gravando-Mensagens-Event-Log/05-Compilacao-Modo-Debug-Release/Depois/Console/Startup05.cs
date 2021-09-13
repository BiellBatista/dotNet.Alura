using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _09_07_XX_Gravando_Mensagens_Event_Log.Depois
{
    public class Startup05 : IAulaItem
    {
        private const string DatabaseServer = "(LocalDB)\\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        public async void Executar()
        {
            if (CinemaPerformance05.ConfigurarCategoria())
                return;

            CinemaPerformance05.CriarContadores();

            TraceListener traceListener = new EventLogTraceListener("Cinema");
            Trace.Listeners.Add(traceListener);

            Trace.AutoFlush = true;

            TraceSource traceSource = new TraceSource("Cinema", SourceLevels.All);
            traceSource.Listeners.Add(traceListener);

            traceSource.TraceEvent(TraceEventType.Information, 1001, "A aplicação iniciou.");

            CinemaDB05 cinemaDB = await CriarBanco();

            while (true)
            {
                await GerarRelatorio(cinemaDB);
            }
            //traceListener.Flush();

            Console.CancelKeyPress += (source, e) =>
            {
                traceSource.TraceEvent(TraceEventType.Warning, 1003, "Control + C foi acionado");
                e.Cancel = true;
            };

            Console.ReadLine();

            traceSource.TraceEvent(TraceEventType.Information, 1002, "A aplicação terminou.");

            if (!EventLog.SourceExists("MinhaFonte"))
            {
                EventLog.CreateEventSource("MinhaFonte", "Application");
            }
            EventLog eventLog = new EventLog();
            eventLog.Source = "MinhaFonte";
            eventLog.WriteEntry("A aplicação terminou.", EventLogEntryType.Information, 1002);

            foreach (EventLogEntry entrada in eventLog.Entries)
            {
                Console.WriteLine($"Fonte: {entrada.Source}\nTipo: {entrada.EntryType}\nHora: {entrada.TimeWritten}\nMensagem: {entrada.Message}\n");
            }

            eventLog.Close();
            Console.ReadLine();
        }

        private static async Task GerarRelatorio(CinemaDB05 cinemaDB)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            IList<Filme05> filmes = await cinemaDB.GetFilmes();

            Console.WriteLine("RELATÓRIO DE FILMES");
            Console.WriteLine(new string('=', 50));
            foreach (var filme in filmes)
            {
                Console.WriteLine("Diretor: {0}\n Titulo: {1}", filme.Diretor, filme.Titulo);
                Console.WriteLine(new string('-', 50));
            }

            stopwatch.Stop();

            var tempoDecorrido = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Tempo decorrido: {tempoDecorrido} milissegundos.");

            CinemaPerformance05.ContadorAverageTimer32.IncrementBy(stopwatch.ElapsedTicks);
            CinemaPerformance05.ContadorAverageTimer32Base.Increment();
        }

        private static async Task<CinemaDB05> CriarBanco()
        {
            var cinemaDB = new CinemaDB05(DatabaseServer, MasterDatabase, DatabaseName);

            await cinemaDB.CriarBancoDeDadosAsync();
            return cinemaDB;
        }
    }
}