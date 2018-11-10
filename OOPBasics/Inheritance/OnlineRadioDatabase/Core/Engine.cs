using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>();
        }
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                    if (input.Length < 3)
                    {
                        throw new InvalidSongException();
                    }
                    string artist = input[0];
                    string songName = input[1];
                    string[] lenght = input[2].Split(':');


                    bool isMinutes = int.TryParse(lenght[0], out int minutes);
                    bool isSeconds = int.TryParse(lenght[1], out int seconds);

                    if (!isMinutes)
                    {
                        throw new InvalidSongLengthException();
                    }
                    if (!isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }

                    Song song = new Song(artist, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Print();
        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            int totalSeconds = songs.Sum(x => (x.Minutes * 60) + x.Seconds);

            TimeSpan t = TimeSpan.FromSeconds(totalSeconds);
            

            Console.WriteLine($"Playlist length: {t.Hours}h {t.Minutes}m {t.Seconds}s");
        }
    }
}

