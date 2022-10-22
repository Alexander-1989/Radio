using System;
using System.Collections.Generic;

namespace Radio
{
    public enum StationSort : byte
    {
        Default,
        Name,
        PlayCount
    }

    [Serializable]
    public class RadioStation : IRadioStation, IComparable<RadioStation>
    {
        private class SortByNameHelper : IComparer<RadioStation>
        {
            public int Compare(RadioStation x, RadioStation y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        private class SortByPlayingCountHelper : IComparer<RadioStation>
        {
            public int Compare(RadioStation x, RadioStation y)
            {
                return y.PlayCount.CompareTo(x.PlayCount);
            }
        }

        public string Name { get; set; }
        public string URL { get; set; }
        public int ID { get; set; }
        public uint PlayCount { get; set; }

        public RadioStation() : this("", "", 0) { }

        public RadioStation(string name, string url) : this(name, url, 0) { }

        public RadioStation(string name, string url, int id)
        {
            Name = name;
            URL = url;
            ID = id;
            PlayCount = 0;
        }

        public string GetInfo
        {
            get
            {
                return $"ID: {ID}\nName: {Name}\nURL: {URL}\nPlay Count: {PlayCount}";
            }
        }

        public override string ToString()
        {
            return $"{ID} - {Name}";
        }

        public int CompareTo(RadioStation other)
        {
            return ID.CompareTo(other.ID);
        }

        public static IComparer<RadioStation> SortByName => new SortByNameHelper();

        public static IComparer<RadioStation> SortByPlayingCount => new SortByPlayingCountHelper();
    }
}