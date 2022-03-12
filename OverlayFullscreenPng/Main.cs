using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OverlayFullscreenPng.KeyHandler;

namespace OverlayFullscreenPng
{
    public partial class Main : Form
    {
        public const string SaveFilename = "save.txt";

        private List<Keys> _modifers = new List<Keys>() { Keys.ControlKey, Keys.Alt, Keys.Menu, Keys.LWin, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey, Keys.LControlKey, Keys.RControlKey };

        private KeyModifier _modifier;
        private Keys _key;
        private string currentApp;

        private bool drag;
        private Point startPoint;

        private OverlayForm _overlay;

        private List<Profil> Profils = new List<Profil>();
        private bool close = false;
        public bool desactived = false;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();


        public Main()
        {
            InitializeComponent();

            this.startPoint = this.Location;

            Shown += Form1_Shown;
            this.titleBarPicture.MouseUp += Title_MouseUp;
            this.titleBarPicture.MouseDown += Title_MouseDown;
            this.titleBarPicture.MouseMove += Title_MouseMove;

            this.opacityNum.Controls[0].BackColor = this.opacityNum.Controls[1].BackColor;
            
        }

        void Title_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;
        }

        void Title_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
            this.drag = true;
        }

        void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            { // if we should be dragging it, we need to figure out some movement
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);
                this.Location = p3;
            }
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            if (File.Exists(SaveFilename))
            {
                var dataLines = File.ReadAllLines(SaveFilename);

                foreach (string l in dataLines)
                {
                    var profilName = l.Split('?')[0];
                    var st = l.Split('?')[1].Split('|');

                   Profil p = new Profil(profilName, st[0], (KeyModifier)Enum.Parse(typeof(KeyModifier), st[1]), 
                        (Keys)Enum.Parse(typeof(Keys), st[2]), int.Parse(st[3]), st.Length<4 ? "": st[4]);
                    Profils.Add(p);
                }
            }
            else
            {
                Profils.Add(new Profil("Default", filePathTxt.Text, _modifier, _key, (int)opacityNum.Value, ""));
            }
            ProfilSelector.Items.AddRange(Profils.Select(x => x.name).ToArray());
            ProfilSelector.SelectedIndex = 0;
            if (!CultureInfo.CurrentUICulture.Name.Contains("FR"))
                SwitchLang("ENG");
            if (!string.IsNullOrEmpty(Profils[0].overlay))
            {
                StartOverlay();
            }
            new Thread(new ThreadStart(ProcessSpy)).Start();
        }

        private Keys getmodifier(KeyModifier km)
        {
            switch (km)
            {
                case KeyModifier.WinKey:
                    return Keys.LWin;
                case KeyModifier.Shift:
                    return Keys.Shift;
                case KeyModifier.Control:
                    return Keys.Control;
                case KeyModifier.Alt:
                    return Keys.Alt;
                default:
                    return Keys.None;
            }
        }

        private void WriteSaveFile()
        {
            if (Profils.Any(x=> x.name == ProfilSelector.Text))
            {
                Profil p = Profils.Where(x => x.name == ProfilSelector.Text).First();
                p.overlay = filePathTxt.Text;
                p.modifier = _modifier;
                p.key = _key;
                p.Opacite = (int)opacityNum.Value;
                p.application = textBox1.Text;
            }
            else
            {
                Profils.Add(new Profil(
                        ProfilSelector.Text,
                        filePathTxt.Text,
                        _modifier,
                        _key,
                        (int)opacityNum.Value,
                        textBox1.Text
                    ));
                ProfilSelector.Items.Clear();
                ProfilSelector.Items.AddRange(Profils.Select(x => x.name).ToArray());
                ProfilSelector.SelectedIndex = ProfilSelector.Items.Count - 1;
            }
            File.WriteAllText(SaveFilename, "");
            foreach (Profil p in Profils)
            {
                File.AppendAllText(SaveFilename, $"{p.name}?{p.overlay}|{p.modifier}|{p.key}|{p.Opacite}|{p.application}\n");
            }
            MessageBox.Show("Votre fichier de sauvegarde a bien été enregistré !");
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.bmp; *.jpg; *.gif; *.png)|*.bmp;*.jpg;*.gif;*.png";
            var result = dialog.ShowDialog();

            if(result == DialogResult.OK || result == DialogResult.Yes)
            {
                filePathTxt.Text = dialog.FileName;
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            desactived = false;
            StartOverlay();
        }

        private void StartOverlay()
        {
            if (string.IsNullOrWhiteSpace(filePathTxt.Text) || !File.Exists(filePathTxt.Text))
            {
                MessageBox.Show("Vous n'avez pas choisi d'image overlay correcte !");
                return;
            }

            if (_key == Keys.None)
            {
                _key = Keys.Escape;
                _modifier = KeyModifier.None;
            }


            _overlay = new OverlayForm(this, _key, _modifier, (int)opacityNum.Value);
            _overlay.BackgroundImage = Image.FromFile(filePathTxt.Text, true);

            _overlay.Show(this);

            this.Hide();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.Modifiers)
            {
                case Keys.LWin:
                    _modifier = KeyModifier.WinKey;
                    break;
                case Keys.Shift:
                    _modifier = KeyModifier.Shift;
                    break;
                case Keys.Control:
                    _modifier = KeyModifier.Control;
                    break;
                case Keys.Alt:
                    _modifier = KeyModifier.Alt;
                    break;
                default:
                    _modifier = KeyModifier.None;
                    break;
            }

            _key = e.KeyCode;
            if (!_modifers.Contains(e.KeyCode))
            {
                this.KeyPreview = false;
                UpdateKeystrokesInput(e.Modifiers, e.KeyCode);

                lblWaitingForKS.Visible = false;
            }
        }

        private void UpdateKeystrokesInput(Keys modifier, Keys keyCode)
        {
            string keyString = string.Empty;
            if (modifier != Keys.None)
                keyString = $"{modifier} + ";
            keyString += keyCode;

            this.keystrokeBtn.Text = keyString;
        }

        public bool IsModifierKey(Keys keycode)
        {
            return (keycode & ModifierKeys) == Keys.Control || (keycode & ModifierKeys) == Keys.Shift || (keycode | ModifierKeys) == Keys.LWin || (keycode & ModifierKeys) == Keys.Alt;
        }

        private void keystrokeBtn_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            lblWaitingForKS.Visible = true;
            this.keystrokeBtn.Text = "...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteSaveFile();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ProfilSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profil p = Profils.Where(x => x.name == ProfilSelector.Text).First();
            filePathTxt.Text = p.overlay;
            opacityNum.Value = p.Opacite;
            _modifier = p.modifier;
            _key = p.key;
            textBox1.Text = currentApp = p.application;

            UpdateKeystrokesInput(getmodifier(_modifier), _key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Exe Files (*exe)|*.exe";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void ProcessSpy()
        {
            Process tp = Process.GetCurrentProcess();
            while (!close && !tp.HasExited)
            {
                if ((_overlay == null || _overlay.IsDisposed || string.IsNullOrEmpty(Profils[ProfilSelector.SelectedIndex].application)) && !desactived)
                {
                    if (Profils.ToArray().Any(x => isPresent(x.application)))
                    {
                        if (_overlay != null && !_overlay.IsDisposed)
                        {
                            _overlay.Close();
                        }
                        Profil pr = Profils.ToArray().Where(x => isPresent(x.application)).First();
                        ProfilSelector.SelectedIndex = ProfilSelector.Items.IndexOf(pr.name);
                        this.BeginInvoke(new Action(()=> StartOverlay()));
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentApp) && !isPresent(currentApp))
                    {
                        _overlay.Close();
                        this.Show();
                        ProfilSelector.SelectedIndex = 0;
                        if (!string.IsNullOrEmpty(Profils[0].overlay))
                        {
                            this.BeginInvoke(new Action(() => StartOverlay()));
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }

        private bool isPresent(string app)
        {
            Process[] pc = Process.GetProcesses().Where(x => x.ProcessName != "svchost").ToArray();
            foreach (Process p in pc)
            {
                string pfile = "";
                try
                {
                    pfile = p.MainModule.FileName;
                }
                catch (Exception ex) { }
                if (!string.IsNullOrEmpty(pfile) && pfile == app)
                {
                    return true;
                }
            }
            return false;
        }

        private void SwitchLang(string l)
        {
            if (l == "ENG")
            {
                label1.Text = "Overlay file path";
                label2.Text = "Disable overlay combo key";
                lblWaitingForKS.Text = "Waiting a combo key";
                label3.Text = "Opacity";
                label4.Text = "Associed Profil";
                label5.Text = "Application path";

                findBtn.Text = button2.Text = "Search";
                applyBtn.Text = "Apply";
                button1.Text = "Save";
                label6.Text = "FR";
            }
            else
            {
                label1.Text = "Chemin vers l'overlay";
                label2.Text = "Combinaison de touche pour retirer l'overlay";
                lblWaitingForKS.Text = "En attente de la combinaison";
                label3.Text = "Opacité";
                label4.Text = "Profil Associé";
                label5.Text = "Chemin d'application";

                findBtn.Text = button2.Text = "Chercher";
                applyBtn.Text = "Appliquer";
                button1.Text = "Sauvegarder";
                label6.Text = "ENG";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SwitchLang(label6.Text);
        }
    }
}
