using System; 
using static System.Console;
using System.Media;
namespace _10000
{
    internal class Sound
    {
        public void WinningSound()
        {
            if (OperatingSystem.IsWindows())
            {

                using (SoundPlayer player = new SoundPlayer(@"Winning.wav"))
                {
                    player.Load();
                    player.Play(); // PlaySync will block the thread until the sound is complete. Use Play() for asynchronous play.
                }
            }
        }
        public void DiceThrowSound()
        {
            if (OperatingSystem.IsWindows())
            {
                using (SoundPlayer player = new SoundPlayer(@"DiceThrow.wav"))
                {
                    player.Load();
                    player.Play(); // PlaySync will block the thread until the sound is complete. Use Play() for asynchronous play.
                }
            }
        }
    }
}
