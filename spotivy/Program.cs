using System;
using System.Diagnostics;
using static spotivy.Song;

namespace spotivy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {   
            
            List<Artist> artists = [
                new ("artist1"),
                new ("artist2"),
                new ("artist3"),
                new ("artist4")
            ];

            List<Song> songs = new List<Song>();
            List<Album> albums = new List<Album>();

            //the 3 for loop should be able to be changed in one
            for (int i = 0; i < artists.Count; i++)
            {
                songs.Add(new Song(25, "EpicSong"+i, [artists[i]], [(Genre)0,(Genre)1]));
                songs.Add(new Song(20, "EpicSong"+(i+4), [artists[i]], [(Genre)3]));
            }

            for (int i = 0; i < artists.Count; i++)
            {
                artists[i].AddSongs(songs);//because of how AddSongs is made it can only add songs if the artist is in it (still needs testing)
            }

            for (int i = 0; i < artists.Count; i++)
            {
                albums.Add(new Album(artists[i], "epicAlbum"+i,artists[i].SongList));
            }

            List<User> users = [
                new("test0"),
                new("test1"),
                new("test2"),
                new("test3")
            ];

            for (int i = 0; i < users.Count; i++)
            {
                users[i].AddPlaylist("epicPlayList"+i);
                users[i].AddPlaylist("epicPlayList"+(i+4));
                for(int j = 0;j < users[i].Playlists.Count; j++)
                {
                    users[i].Playlists[j].AddSongs(songs); 
                }
            }
            
            Client client = new(users, albums, artists, songs);

            Console.WriteLine("start");
            Console.WriteLine();
            client.Case1();//show all songs
            Console.WriteLine();
            client.Case2();//search song term "1"
            Console.WriteLine();
            client.Case3(); //play
            Console.WriteLine();
            client.Case4(); //play and pause
            Console.WriteLine();
            client.Case5(); //reapeat
            Console.WriteLine();
            client.Case6(); //skip
            Console.WriteLine();
            client.Case7(); //skip and reapeat
            Console.WriteLine();
            client.Case8(); //stop
            Console.WriteLine();
            client.Case9(); //show all songs albums users (not artists currently)
            Console.WriteLine();
            client.Case10(); //searches in all songs albums users (not artists currently)
            Console.WriteLine();
            client.Case11(); //shows all users
            Console.WriteLine();
            client.Case12(); //searches user term "1"
            Console.WriteLine();
            client.Case13(); //shows all albums
            Console.WriteLine();
            client.Case14(); //searches album in cient
            Console.WriteLine();
            client.Case15();
            Console.WriteLine();
            client.Case16();
            Console.WriteLine(); 
            client.Case17();
            Console.WriteLine();
            client.Case18();
            Console.WriteLine(); 
            client.Case19();
            Console.WriteLine(); 
            client.Case20();
            Console.WriteLine(); 
            client.Case21();
            Console.WriteLine(); 
            client.Case22();
            Console.WriteLine(); 
            client.Case23();
            Console.WriteLine(); 
            client.Case24();
            Console.WriteLine(); 
            client.Case25();
            Console.WriteLine(); 
            client.Case26();
            Console.WriteLine(); 
            client.Case27();
            Console.WriteLine();
            Console.WriteLine("end");
        }
    }
}