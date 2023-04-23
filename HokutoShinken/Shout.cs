using System;
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
        private const Int32 LENTH_OF_ATA = 275;
        private const Int32 LENTH_OF_ACHA = 1102;

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

            _StopTimer = new System.Timers.Timer(LENTH_OF_ATA);
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
                _isShouting = true;
                _end.Play();
                _StopTimer.Interval = LENTH_OF_ACHA;
                _StopTimer.Enabled = false;
                _current = _end;
                return;
            }

            if (key == Keys.Space || ((int)Keys.D0 <= (int)key && (int)key <= (int)Keys.Z))
            {
                _StopTimer.Interval = LENTH_OF_ATA;
                _StopTimer.Enabled = false;
                if (_isShouting)
                {
                    if (_current == _start)
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
