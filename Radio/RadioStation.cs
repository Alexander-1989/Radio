using System;
using System.Collections.Generic;

namespace Radio
{
    class RadioStation : IRadioStation, IComparable<RadioStation>
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
                return y.PlayingCount.CompareTo(x.PlayingCount);
            }
        }

        private readonly string _name;
        private readonly string _url;
        private readonly int _id;
        private int _playCount;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string URL
        {
            get
            {
                _playCount++;
                return _url;
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }
        }

        public int PlayingCount
        {
            get
            {
                return _playCount;
            }
        }

        public RadioStation(string name, string url, int id)
        {
            _name = name;
            _url = url;
            _id = id;
            _playCount = 0;
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