using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace Client
{
    class csvFile
    {
        public csvFile(string nameFile){
            this.fileName = nameFile;
        }

        private List<record> dataToSave = new List<record>();
        private string fileName = null;
        public class record
        {
            public Int64 currentData { get; set; }
            public Int64 speed { get; set; }
        }

      

        public sealed class FooMap : ClassMap<record>
        {
            public FooMap()
            {
                Map(m => m.currentData);
                Map(m => m.speed);
            }
        }


        public void addToData(int CurrentData,  int Speed ) {

            if(CurrentData != null && Speed != null)dataToSave.Add(new record { currentData = CurrentData, speed = Speed });

        }

        public void saveToCSV()
        {
            string filename = String.Format("{0:yyyy-MM-dd-hh-mm-ss}__{1}", DateTime.Now, this.fileName+".txt");
            using (var writer = new StreamWriter(filename))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<FooMap>();
            
                csv.WriteRecords(this.dataToSave);
            }
        }




        }
}
