using FreshMvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TherapyBoxDemo.PageModels
{
    public class SportsPageModel : FreshBasePageModel
    {
        System.IO.StreamReader reader;
        public SportsPageModel()
        {
            GetCSVFile();
        }
        private async Task GetCSVFile()
        {
            var uri = new Uri(@"http://www.football-data.co.uk/mmz4281/1718/I1.csv");
            var request = (HttpWebRequest)WebRequest.Create(uri);
            WebResponse responseObject = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
            var responseStream = responseObject.GetResponseStream();
            reader = new StreamReader(responseStream);
            List<string> itemsList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');


                itemsList.Add(values[0]);
                
            }
            itemsList.Contains("Juventus");
            TeamList = itemsList;


        }
        private FreshAwaitCommand _searchCommand;
        public FreshAwaitCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new FreshAwaitCommand(async (tcs) =>
                    {
                        await GetCSVFile();
                        tcs.SetResult(true);
                    });
                }
                return _searchCommand;
            }

        }
        private List<string> _teamList;
        public List<string> TeamList
        {
            get
            {
                return _teamList;
            }
            set
            {
                _teamList = value;
                RaisePropertyChanged("TeamList");
            }
        }
        private string _teamNameEntry;
        public string TeamNameEntry
        {
            get
            {
                return _teamNameEntry;
            }
            set
            {
                _teamNameEntry = value;
                RaisePropertyChanged("TeamNameEntry");
            }
        }
        public class Teams
        {
            public string FirstTeam { get; set; }
            public string SecondTeam { get; set; }
            public string Result { get; set; }

        }
    }
}
