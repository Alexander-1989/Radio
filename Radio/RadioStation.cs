namespace Radio
{
    class RadioStation : IRadioStation
    {
        public string Name { get; }
        public string URL { get; }
        public int ID { get; }

        public RadioStation(string name, string url, int id)
        {
            Name = name;
            URL = url;
            ID = id;
        }

        public override string ToString()
        {
            return $"{ID} - {Name}";
        }
    }
}