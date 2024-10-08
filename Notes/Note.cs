﻿namespace Notes
{
    public abstract record Note
    {
        protected int _id;

        public Note()
        {
            double seconds = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _id = Convert.ToInt32(Math.Floor(seconds));
        }

        public Note(int id)
        {
            double seconds = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            _id = id;
        }

        public int Id { get { return _id;} private set { _id = value; } }

    }
}