// Create an online radio station database. It should keep information about all added songs. 
// On the first line you are going to get the number of songs you are going to try to add. 
// On the next lines you will get the songs to be added 
// in the format <artist name>;<song name>;<minutes:seconds>. 
// To be valid, every song should have an artist name, a song name and length. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static List<Song> album = new List<Song>();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            try
            {
                string[] data = Console.ReadLine().Split(';');
                if (data.Length != 3)
                {
                    throw new InvalidSongException("Invalid song.");
                }
                string artistName = data[0];
                string songName = data[1];
                string[] time = data[2].Split(':');
                int minutes = 0;
                int seconds = 0;
                if (time.Length != 2 || !int.TryParse(time[0], out minutes) || !int.TryParse(time[1], out seconds))
                {
                    throw new InvalidSongLengthException("Invalid song length.");
                }                
                Song newSong = new Song(artistName, songName, minutes, seconds);
                album.Add(newSong);
                Console.WriteLine("Song added.");
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
            
        }
        FinalResult();
        
    }

    public static void FinalResult()
    {
        int totalSec = album.Sum(s => s.Seconds);
        int totalMin = album.Sum(s => s.Minutes);
        totalMin += totalSec / 60;
        totalSec = totalSec % 60;
        int totalH = totalMin / 60;
        totalMin = totalMin % 60;
        Console.WriteLine($"Songs added: {album.Count}");
        Console.WriteLine($"Playlist length: {totalH}h {totalMin}m {totalSec}s");
    }
}
