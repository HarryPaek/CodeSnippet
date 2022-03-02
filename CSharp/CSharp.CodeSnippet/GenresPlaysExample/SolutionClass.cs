using System;
using System.Collections.Generic;
using System.Linq;

namespace GenresPlaysExample
{
    public class SolutionClass
    {
        public int[] Solution(string[] genres, int[] plays)
        {
            Dictionary<string, List<Song>> playList = new Dictionary<string, List<Song>>(StringComparer.OrdinalIgnoreCase);

            int index = 0;

            foreach (string genre in genres)
            {
                List<Song> songList;

                if (playList.ContainsKey(genre)) {
                    songList = playList[genre];
                }
                else {
                    songList = new List<Song>();
                    playList[genre] = songList;
                }

                songList.Add(new Song { Index = index, Play = plays[index] });
                index++;
            }

            var genreTotalPlayList = playList.Select(p => new { Genre = p.Key, TotalCount = p.Value.Sum(s => s.Play) })
                                             .OrderByDescending(p => p.TotalCount);

            List<int> topSongList = new List<int>();

            foreach (var genreTotalPlay in genreTotalPlayList)
            {
                topSongList.AddRange(playList[genreTotalPlay.Genre].OrderByDescending(s => s.Play)
                                                                   .ThenBy(s => s.Index)
                                                                   .Take(2)
                                                                   .Select(s => s.Index));
            }

            return topSongList.ToArray();
        }

        internal class Song
        {
            public int Index { get; set; }

            public int Play { get; set; }
        }
    }
}
