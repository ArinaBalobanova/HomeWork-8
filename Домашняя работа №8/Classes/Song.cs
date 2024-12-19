using System;


namespace Домашняя_работа__8.Classes
{
    class Song
    {
        private string name;
        private string author;
        public Song prev;
        public Song(string name, string author, Song prev = null)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }

        public void SetName(string songName)
        {
            name = songName;
        }
        public void SetAuthor(string songAuthor)
        {
            author = songAuthor;
        }
        public void SetPrev(Song previousSong)
        {
            prev = previousSong;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Song other)
            {
                return this.name == other.name && this.author == other.author;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (name, author).GetHashCode();
        }
    }
}
