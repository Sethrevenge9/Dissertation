using System.Diagnostics;

namespace Assets.Scripts
{
    public interface IHear
    {
        void RespondToSound(Sound sound)
        {

            Debug.Print("Responding to sound at " + sound.pos);

        }

    }
}