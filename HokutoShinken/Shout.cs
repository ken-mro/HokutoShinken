using System.Media;
using System.Windows.Forms;

namespace HokutoShinken
{
    public class Shout
    {
        private SoundPlayer _start;
        private SoundPlayer _middle;
        private SoundPlayer _end;
        private SoundPlayer _hikou;
        private SoundPlayer _catchPhrase;
        private SoundPlayer _blast;
        private SoundPlayer _current;
        private System.Timers.Timer _StopTimer;
        private bool _isShouting = false;

        public Shout()
        {
            _start = new SoundPlayer();
            _start.Stream = Properties.Resources.ata;
            _middle = new SoundPlayer();
            _middle.Stream = Properties.Resources.tatatata;
            _end = new SoundPlayer();
            _end.Stream = Properties.Resources.acha;
            _hikou = new SoundPlayer();
            _hikou.Stream = Properties.Resources.hikou;
            _catchPhrase = new SoundPlayer();
            _catchPhrase.Stream = Properties.Resources.catchphrase;
            _blast = new SoundPlayer();
            _blast.Stream = Properties.Resources.blast;

            _StopTimer = new System.Timers.Timer(275);
            _StopTimer.Elapsed += OnTimedEvent;
            _StopTimer.AutoReset = false;
        }

        public void InitialShout()
        {
            _catchPhrase.PlaySync();
            _hikou.PlaySync();
            _blast.PlaySync();
        }
        public void Shouting(Keys key)
        {
            if (key == Keys.Enter)
            {

                _end.Play();
                return;
            }

            if (key == Keys.Space || ((int)Keys.A <= (int)key && (int)key <= (int)Keys.Z))
            {
                _StopTimer.Enabled = false;
                if (_isShouting)
                {
                    if (_current != _middle)
                    {
                        _middle.PlayLooping();
                        _current = _middle;
                    }
                }
                else
                {
                    _isShouting = true;
                    _start.Play();
                    _current = _start;
                }
                _StopTimer.Enabled = true;
            }
        }

        private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            _current.Stop();
            _isShouting = false;
        }
    }
}
