using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PetVirtual
{
    public partial class Form1 : Form
    {
        private bool isHappy = false;
        private DateTime lastCheckInDate;
        private float petY;
        private float animationDirection = 1;
        private int baseY;
        
        
        private const float SLOW_SPEED = 0.5f;  
        private const float FAST_SPEED = 2.0f;  
        private const float ANIMATION_RANGE = 15f; 
        
        public Form1()
        {
            InitializeComponent();
            InitializePet();
            LoadPetState();
            CheckDayChange();
        }
        
        private void InitializePet()
        {
            
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "pet_apenas.png");
                if (File.Exists(imagePath))
                {
                    this.petPictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    
                    CreatePlaceholderImage();
                }
            }
            catch (Exception)
            {
                CreatePlaceholderImage();
            }
            
            
            baseY = petPictureBox.Location.Y;
            petY = baseY;
            
            
            animationTimer.Start();
        }
        
        private void CreatePlaceholderImage()
        {
            
            Bitmap placeholder = new Bitmap(150, 150);
            using (Graphics g = Graphics.FromImage(placeholder))
            {
                g.Clear(Color.White);
                g.FillEllipse(Brushes.Orange, 25, 25, 100, 100);
                g.FillEllipse(Brushes.Black, 40, 50, 15, 15);
                g.FillEllipse(Brushes.Black, 95, 50, 15, 15);
                g.FillEllipse(Brushes.Red, 65, 85, 20, 10);
            }
            this.petPictureBox.Image = placeholder;
        }
        
        private void LoadPetState()
        {
            try
            {
                string dataPath = Path.Combine(Application.StartupPath, "pet_data.txt");
                if (File.Exists(dataPath))
                {
                    string[] lines = File.ReadAllLines(dataPath);
                    if (lines.Length >= 2)
                    {
                        DateTime.TryParse(lines[0], out lastCheckInDate);
                        bool.TryParse(lines[1], out isHappy);
                    }
                }
            }
            catch (Exception)
            {
                
                lastCheckInDate = DateTime.MinValue;
                isHappy = false;
            }
        }
        
        private void SavePetState()
        {
            try
            {
                string dataPath = Path.Combine(Application.StartupPath, "pet_data.txt");
                string[] lines = new string[]
                {
                    lastCheckInDate.ToString("yyyy-MM-dd"),
                    isHappy.ToString()
                };
                File.WriteAllLines(dataPath, lines);
            }
            catch (Exception)
            {
                
            }
        }
        
        private void CheckDayChange()
        {
            DateTime today = DateTime.Today;
            
            
            if (lastCheckInDate.Date < today && isHappy)
            {
                isHappy = false;
                SavePetState();
            }
            
            UpdateUI();
        }
        
        private void UpdateUI()
        {
            DateTime today = DateTime.Today;
            this.dateLabel.Text = string.Format("Data: {0:dd/MM/yyyy}", today);
            
            if (isHappy)
            {
                this.statusLabel.Text = "Pet Feliz!";
                this.statusLabel.ForeColor = Color.Green;
                this.checkInButton.Enabled = false;
                this.checkInButton.Text = "Check-in Realizado";
                this.checkInButton.BackColor = Color.Gray;
            }
            else
            {
                this.statusLabel.Text = "Pet Triste...";
                this.statusLabel.ForeColor = Color.Red;
                this.checkInButton.Enabled = true;
                this.checkInButton.Text = "Check-in Diário";
                this.checkInButton.BackColor = Color.LightGreen;
            }
        }
        
        private void CheckInButton_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            
            
            if (lastCheckInDate.Date == today)
            {
                MessageBox.Show("Você já fez o check-in hoje!", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            
            isHappy = true;
            lastCheckInDate = today;
            SavePetState();
            UpdateUI();
            
            MessageBox.Show("Check-in realizado! Seu pet está feliz!", "Sucesso", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            
            float speed = isHappy ? FAST_SPEED : SLOW_SPEED;
            
            
            petY += animationDirection * speed;
            
            
            if (petY >= baseY + ANIMATION_RANGE)
            {
                petY = baseY + ANIMATION_RANGE;
                animationDirection = -1;
            }
            else if (petY <= baseY - ANIMATION_RANGE)
            {
                petY = baseY - ANIMATION_RANGE;
                animationDirection = 1;
            }
            
           
            petPictureBox.Location = new Point(petPictureBox.Location.X, (int)petY);
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (animationTimer != null)
            {
                animationTimer.Stop();
                animationTimer.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
