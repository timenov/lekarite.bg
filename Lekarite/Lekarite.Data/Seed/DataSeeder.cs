namespace Lekarite.Data.Seed
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Lekarite.Data.Interfaces;

    public abstract class DataSeeder
    {
        private ICollection<string> dataAllLines;
        private string pathToFile;

        public DataSeeder(string pathToCsvFile)
        {
            this.pathToFile = pathToCsvFile;
            this.LoadDataFromFile();
        }

        protected ICollection<string> DataAllLines
        {
            get { return this.dataAllLines; }
        }

        protected virtual void LoadDataFromFile()
        {
            this.dataAllLines = File.ReadAllLines(this.pathToFile, Encoding.GetEncoding("windows-1251"));
        }
    }
}
