using System.Media;
namespace _10000
{
    internal class Sound
    {
        public void PlaySound(string sound)
        {
            if (OperatingSystem.IsWindows())
            {
                using (SoundPlayer player = new SoundPlayer(sound + ".wav"))
                {
                    player.Load();
                    player.Play(); // PlaySync will block the thread until the sound is complete. Use Play() for asynchronous play.
                }
            }
        }
    }
}

