using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ChatSteer {
    public partial class Main : Form {

        ChromiumWebBrowser chrome;

        bool work = false;

        public List<int> keyListRemove = new List<int>();

        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            ToStatic.main = this;

            LoadHotKeys();

            Work(false);
            SetProcess.Refresh(ProcessList);

            CefSettings settings = new CefSettings();
            settings.Locale = "en-US";
            Cef.Initialize(settings);

            chrome = new ChromiumWebBrowser(Config.chatUrl());
            this.Chat.Controls.Add(chrome);
            chrome.Dock = DockStyle.Fill;
        }

        public bool GetWork() {
            return work;
        }

        void Work(bool w) {
            work = w;

            KeyList.Visible = w;
            KeyListTitle.Visible = w;
            Messages.Visible = w;
            MessagesTitle.Visible = w;
            SteeringAppText.Visible = w;

            ProcessList.Visible = !w;
            ProcessListTitle.Visible = !w;
            RefreshButton.Visible = !w;
            WelcomeText.Visible = !w;
            AuthorLabel.Visible = false;
            AuthorButton.Visible = !w;
        }

        void Timer0_Tick(object sender, EventArgs e) {
            if(work) {
                Dispatcher.CurrentDispatcher.BeginInvoke((Action)(async () => {
                    string source = await chrome.GetTextAsync();

                    if(source == "Live chat is not available" || source == "Czat na żywo jest niedostępny") {
                        work = false;

                        string title = "Czat";
                        string message = "Czat na żywo jest niedostępny!\nZmień adres czatu w pliku: " +
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer\\config.yml";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                        if(result == DialogResult.OK) {
                            Environment.Exit(0);
                        }
                    }

                    GetChat.Get(source, KeyList, Messages);
                }));
            }
        }

        private void Refresh_Click(object sender, EventArgs e) {
            if(!work)
                SetProcess.Refresh(ProcessList);
        }

        private void ProcessList_ItemCheck(object sender, ItemCheckEventArgs e) {
            if(!work) {
                if(e.NewValue == CheckState.Checked && ProcessList.CheckedItems.Count > 0) {
                    ProcessList.ItemCheck -= ProcessList_ItemCheck;
                    ProcessList.SetItemChecked(ProcessList.CheckedIndices[0], false);
                    ProcessList.ItemCheck += ProcessList_ItemCheck;
                }
            }
        }

        private void Start_Click(object sender, EventArgs e) {
            StartWork();
        }

        void StartWork() {
            if(ProcessList.CheckedItems.Count == 0) {
                string title = "Błąd celu";
                string message = "Nie wybrano programu do sterowania!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                return;
            }
            SteeringAppText.Text = "Sterowany program: " + ProcessList.CheckedItems[0];

            Work(true);
            Stop.BackColor = Color.Red;

            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/" + SafeName.Get(ProcessList.CheckedItems[0].ToString()) + ".xml")) {
                work = false;

                Pattern.Check();
                File.Copy(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/pattern.xml",
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer/" + SafeName.Get(ProcessList.CheckedItems[0].ToString()) + ".xml"
                );

                string title = "Brak konfiguracji";
                string message =
                    "Nie znaleziono konfiguracji dla danego programu!\n" +
                    "Domyślna konfiguracja została skopiowana do pliku: " +
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ChatSteer\\" +
                    SafeName.Get(ProcessList.CheckedItems[0].ToString()) +
                    ".xml\n" +
                    "Sprawdź czy jest ona spójna z aplikacją, a następnie przejdź dalej!"
                ;
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if(result == DialogResult.OK)
                    work = true;
            }

            KeyReader.LoadKeys(SafeName.Get(ProcessList.CheckedItems[0].ToString()));

            var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
            ahk.ExecRaw("WinActivate, " + ProcessList.CheckedItems[0]);

            KeyList.Items.Clear();

            KeyWorker.app = ProcessList.CheckedItems[0].ToString();
            KeyWorker.keyList = KeyList;
            Thread thr0 = new Thread(new ThreadStart(KeyWorker.Work));
            thr0.Start();
        }

        private void Stop_Click(object sender, EventArgs e) {
            StopWork();
        }

        void StopWork() {
            Work(false);
            Stop.BackColor = SystemColors.Control;
            KeyList.Items.Clear();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            for(int i = 0; i < keyListRemove.Count; i++) {
                if(KeyList.Items.Count > keyListRemove[i] && keyListRemove[i] >= 0)
                    KeyList.Items.RemoveAt(keyListRemove[i]);
            }
        }

        private void Timer2_Tick(object sender, EventArgs e) {
            if(work) {
                ActiveWarning.Check(ProcessList);
            } else {
                AuthorLabel.Visible = false;
                AuthorButton.Visible = true;
            }
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        void LoadHotKeys() {
            int hotKeyCode = (int)(Keys)Enum.Parse(typeof(Keys), Config.startShortcut(), true);
            RegisterHotKey(this.Handle, 0, 0x0000, hotKeyCode);

            hotKeyCode = (int)(Keys)Enum.Parse(typeof(Keys), Config.stopShortcut(), true);
            RegisterHotKey(this.Handle, 1, 0x0000, hotKeyCode);
        }

        protected override void WndProc(ref Message m) {
            if(m.Msg == 0x0312) {
                int id = m.WParam.ToInt32();

                switch(id) {
                    case 0:
                        StartWork();
                        break;
                    case 1:
                        StopWork();
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void AuthorButton_Click(object sender, EventArgs e) {
            if(!work) {
                AuthorLabel.Visible = true;
                AuthorButton.Visible = false;
            }
        }
    }
}
