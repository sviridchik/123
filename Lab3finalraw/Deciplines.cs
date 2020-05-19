namespace Lab3finalraw
{
    public struct Deciplines
    {
        public string nameOfDecipline;
        public int hours;
        public string typeOfOffset;

        public Deciplines(string nameOfDecipline, int hours, string typeOfOffset)
        {
            this.nameOfDecipline = nameOfDecipline;
            this.hours = hours;
            this.typeOfOffset = typeOfOffset;
        }
    }
}