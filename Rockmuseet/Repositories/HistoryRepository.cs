using System;
using System.Collections.Generic;
using Rockmuseet.Helpers;
using System.Linq;
using Rockmuseet.Interfaces;
using Rockmuseet.models;

namespace Rockmuseet.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {

        string JsonFileName = @"Data\Histories.json";
        public History History { get; set; }



        public void AddHistory(History history)
        {
            List<History> histories = GetAllHistories().ToList();
            histories.Add(history);
            JsonFileWritter.WriteToJsonHistory(histories, JsonFileName);
        }

        public void DeleteHistory(History history)
        {
            List<History> histories = GetAllHistories().ToList();
            histories.Remove(history);
            JsonFileWritter.WriteToJsonHistory(histories, JsonFileName);
        }
        public List<History> GetAllHistories()
        {
            Console.WriteLine(JsonFileName);
            return JsonFileReader.ReadJsonHistory(JsonFileName);
        }

        //public History GetHistory(string name) {
        //    foreach (var h in GetAllHistories())
        //    {
        //        if (h.Name == name)
        //            return h;
        //    }

        //    return new History();
        //}

        public History GetHistory(int Id)
        {
            foreach (var h in GetAllHistories())
            {
                if (h.Id == Id)
                    return h;
            }
            return new History();
        }



        public void UpdateHistory(History history)
        {

            History h = history;

            if (h.Id == history.Id)
            {
                h.Name = history.Name;
                h.Image = history.Image;
                h.MusicAudioId = history.MusicAudioId;
                h.MusicAudio = history.MusicAudio;
                h.HistoryAudioId = history.HistoryAudioId;
                h.HistoryAudio = history.HistoryAudio;


            }
        }

    }
}
