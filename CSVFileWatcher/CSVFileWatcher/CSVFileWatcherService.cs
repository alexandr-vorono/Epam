using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DBLayer;

namespace CSVFileWatcher
{
    partial class CSVFileWatcherService : ServiceBase
    {
        private FileSystemWatcher fileWatcher;
        //Путь к отслеживаемой папке.
        public string Directory { get; set; }
        //Маска отслеживаемых файлов.
        public string FilesMask { get; set; }
        Random random = new Random();
        public CSVFileWatcherService()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод вызываемый при запуске службы
        /// </summary>
        public void Start()
        {
            Console.WriteLine("start");

            try
            {
                this.fileWatcher = new FileSystemWatcher(Directory, FilesMask);
                this.fileWatcher.Created += OnFileCreate;
                this.fileWatcher.EnableRaisingEvents = true;
                //DBModelContainer container = new DBModelContainer();
                //for (int i = 0; i < 10; i++)
                //{
                //    container.ClientSet.Add(new Client()
                //    {
                //        Name = "Name" + i,
                //        TelephoneNumber = random.Next(1000000, 9999999)
                //    }
                //        );

                //    container.ManagerSet.Add(new Manager()
                //    {
                //        Name = "Name" + i
                //    }
                //        );
                //    container.GoodsSet.Add(new Goods()
                //    {
                //        Name = "Name" + i,
                //        Description = "описание" + i
                //    }
                //        );
                //}

                //container.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        //Запуск службы
        protected override void OnStart(string[] args)
        {
            this.Start();
        }
        //ОСтановка службы
        protected override void OnStop()
        {
            this.fileWatcher.EnableRaisingEvents = false;
            this.fileWatcher.Dispose();
        }
        //Обработка события создания нового файла
        private void OnFileCreate(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Обработка файла:"+e.FullPath);
            if (File.Exists(e.FullPath))
            {
                Task.Factory.StartNew(ProcessDataFile, e.FullPath);
            }
        }
        //Обработка нового файла
        private void ProcessDataFile(object parameters)
        {
            if (parameters is string)
            {
                string fileName = parameters as string;
                Parser parser = new Parser();
                DBModelContainer container = new DBModelContainer(); 
                
                if (container.CheckFileName(fileName) == false)
                {
                    try
                    {
                        container.AddOrders(parser.ParseList(fileName));
                        container.AddFileName(fileName);
                        Console.WriteLine("Файл " + fileName + " обработан");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
        }
    }
}
