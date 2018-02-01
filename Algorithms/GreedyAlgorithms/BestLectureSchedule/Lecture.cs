namespace Problem_4.Best_Lectures_Schedule
{
    using System;

    public class Lecture : IComparable<Lecture>
    {
        public Lecture(string id, int start, int end)
        {
            this.Id = id;
            this.Start = start;
            this.End = end;
        }

        public string Id { get; private set; }

        public int Start { get; private set; }

        public int End { get; private set; }

        public int CompareTo(Lecture other)
        {
            return this.End.CompareTo(other.End);
        }

        public override string ToString()
        {
            return string.Format("{0}-{1} -> {2}", this.Start, this.End, this.Id);
        }
    }
}
