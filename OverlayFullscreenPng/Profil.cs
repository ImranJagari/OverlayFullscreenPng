using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayFullscreenPng
{
    public class Profil
    {
        public string name { get; set; }
        public string overlay { get; set; }
        public KeyHandler.KeyModifier modifier { get; set; }
        public Keys key { get; set; }
        public int Opacite { get; set; }
        public string application { get; set; }

        public Profil()
        {

        }

        public Profil(string n, string ov,KeyHandler.KeyModifier m, Keys k, int op, string app)
        {
            name = n;
            overlay = ov;
            modifier = m;
            key = k;
            Opacite = op;
            application = app;
        }
    }
}
