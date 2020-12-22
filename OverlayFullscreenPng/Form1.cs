using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OverlayFullscreenPng.KeyHandler;

namespace OverlayFullscreenPng
{
    public partial class Form1 : Form
    {
        public const string SaveFilename = "save.txt";

        private List<Keys> _modifers = new List<Keys>() { Keys.ControlKey, Keys.Alt, Keys.Menu, Keys.LWin, Keys.ShiftKey, Keys.LShiftKey, Keys.RShiftKey, Keys.LControlKey, Keys.RControlKey };

        private KeyModifier _modifier;
        private Keys _key;

        private OverlayForm _overlay;
        public Form1()
        {
            InitializeComponent();

            if (File.Exists(SaveFilename))
            {
                var dataLines = File.ReadAllLines(SaveFilename);

                filePathTxt.Text = dataLines[0];

                Enum.TryParse(dataLines[1], out _modifier);
                var modifierKey = Keys.None;
                switch (_modifier)
                {
                    case KeyModifier.WinKey :
                        modifierKey = Keys.LWin;
                        break;
                    case KeyModifier.Shift:
                        modifierKey =  Keys.Shift;
                        break;
                    case KeyModifier.Control:
                        modifierKey =  Keys.Control;
                        break;
                    case KeyModifier.Alt:
                        modifierKey =  Keys.Alt;
                        break;
                    default:
                        modifierKey = Keys.None;
                        break;
                }

                Enum.TryParse(dataLines[2], out _key);
                opacityNum.Value = int.Parse(dataLines[3]);

                UpdateKeystrokesInput(modifierKey, _key);

                StartOverlay();
            }
        }

        private void WriteSaveFile()
        {
            File.WriteAllText(SaveFilename, $"{filePathTxt.Text}\n{_modifier}\n{_key}\n{opacityNum.Value}");
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
    }
}
