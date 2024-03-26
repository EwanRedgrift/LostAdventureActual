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
using System.Media;

namespace LostAdventure
{
    public partial class Form1 : Form
    {
        // Tracks current page and previous page
        int page;
        int prevPage = 0;

        int goldCoins;
        int numPotions;
        bool hasKnife;
        bool hasRock;

        //Random number generator
        Random randGen = new Random();

        SoundPlayer swordsSound = new SoundPlayer(Properties.Resources.Sound_Effect_Swords_Clashing);
        SoundPlayer magicSpellSound = new SoundPlayer(Properties.Resources.Magic_Sound_Effect_No_Copyright_Free_Download);
        SoundPlayer UIClick = new SoundPlayer(Properties.Resources.Menu_Game_Button_Click_Sound_Effect);
        SoundPlayer forestSound = new SoundPlayer(Properties.Resources.jungle);
        SoundPlayer crunchSound = new SoundPlayer(Properties.Resources.Apple_Crunch_);

        public Form1()
        {
            InitializeComponent();

            imageBox.Image = Properties.Resources.forest;
            outputLabel.Text = "You are walking in a forest...";

            goldCoins = randGen.Next(10, 31);
            UpdateGold();

            forestSound.Play();
            option1Button.Visible = true;
            option1Label.Enabled = true;
            option1Label.Text = "Continue";
        }

        private void UpdateGold()
        {
            goldOutput.Text = $"Gold: {goldCoins}";
        }
        private void option1Button_Click(object sender, EventArgs e)
        {
            /// Check what page we are currently on, and then flip
            /// to the page you need to go to if you selected option 1

            prevPage = page;

            if (page == 0)
            {
                page = randGen.Next(1, 3);
                DisplayPage();
            }
            else if (page == 1)
            {
                page = 3;
            }
            else if (page == 3)
            {
                page = 9;
            }
            else if (page == 4)
            {
                page = 2;
            }
            else if (page == 5)
            {
                page = 3;
            }
            else if (page == 6)
            {
                page = 0;
            }
            else if (page == 7)
            {
                page = 0;
            }
            else if (page == 8)
            {
                if (goldCoins >= 45)
                {
                    page = 12;
                }
                else
                {
                    page = 11;
                }
            }
            else if (page == 9)
            {
                page = 16;
            }
            else if (page == 10)
            {
                page = 0;
                prevPage = 10;
            }
            else if (page == 11)
            {
                page = 0;
            }
            else if (page == 12)
            {
                page = 0;
            }
            else if (page == 13)
            {
                page = 0;
            }
            else if (page == 14)
            {
                page = 0;
            }
            else if (page == 15)
            {
                page = 0;
            }
            else if (page == 16)
            {
                page = 18;
            }
            else if (page == 17)
            {
                page = 0;
            }
            else if (page == 18)
            {
                page = 0;
            }
            else if (page == 19)
            {
                page = 0;

            }

            // MAIN PATH 2

            else if (page == 2)
            {
                if (hasKnife == true)
                {
                    page = 5;
                }
                else if (randGen.Next(1, 11) != 1)
                {
                    page = 5;
                }
                else
                {
                    page = 6;
                }

                // random chance for page 5 or 6
            }

            DisplayPage();
            UIClick.Play();
        }

        private void option2Button_Click(object sender, EventArgs e)
        {
            ///check what page we are currently on, and then flip
            ///to the page you need to go to if you selected option 2
            /// Check what page we are currently on, and then flip
            /// to the page you need to go to if you selected option 1

            prevPage = page;

            if (page == 1)
            {
                page = 4;
            }
            else if (page == 3)
            {
                page = 10;
            }
            else if (page == 5)
            {
                page = 4;
            }
            else if (page == 8)
            {
                if (hasKnife == true)
                {
                    page = 14;
                }
                else
                {
                    page = 13;
                }
            }
            else if (page == 9)
            {
                page = 17;
            }
            else if (page == 16)
            {
                page = 19;
            }

            //MAIN PATH 2

            else if (page == 2)
            {

                if (hasKnife == true)
                {
                    page = 8;
                }
                else if (randGen.Next(1,5) != 1)
                {
                    page = 8;
                }
                else
                {
                    page = 7;
                }
                //Chance to go to either page 7 or 8
            }
            else if (page == 8)
            {
                page = 15;
            }

            DisplayPage();
            UIClick.Play();
        }

        private void option3Button_Click(object sender, EventArgs e)
        {
            prevPage = page;

            if (page == 8) {
                page = 15;
            }

            DisplayPage();
            UIClick.Play();
        }

        private void DisplayPage()
        {
            /// Display text and game options to screen based on the 
            /// current page

            switch (page)
            {
                case 0:
                    imageBox.Image = Properties.Resources.forest;

                    swordsSound.Stop();
                    hasKnife = false;
                    hasRock = false;

                    outputLabel.Text = "You are walking in a forest...";

                    goldCoins = randGen.Next(10, 31);
                    UpdateGold();

                    forestSound.Play();
                    option1Button.Visible = true;
                    option1Label.Enabled = true;
                    option2Button.Visible = false;
                    option2Label.Enabled = false;
                    option3Button.Visible = false;
                    option3Label.Enabled = false;

                    option1Label.Text = "Continue";
                    break;
                case 1:
                    imageBox.Image = Properties.Resources.apple;

                    outputLabel.Text = "And a yummy apple falls on your head!";
                    outputLabel.Text += $"\nDo you eat the apple?";

                    option1Button.Visible = true;
                    option2Button.Visible = true;
                    option1Label.Enabled = true;
                    option2Label.Enabled = true;

                    option1Label.Text = "Eat the apple";
                    option2Label.Text = "Do not eat the apple";
                    break;
                case 2:
                    imageBox.Image = Properties.Resources.jumpingGoblin;

                    outputLabel.Text = "And a nasty goblin jumps at and attacks you!";
                    outputLabel.Text += $"\nDo you fight or run?";

                    option1Button.Visible = true;
                    option2Button.Visible = true;
                    option1Label.Enabled = true;
                    option2Label.Enabled = true;

                    option1Label.Text = "Fight!";
                    option2Label.Text = "Run!";
                    break;
                case 3:
                    imageBox.Image = Properties.Resources.goblinTransformation;

                    swordsSound.Stop();
                    goldCoins++;
                    UpdateGold();

                    crunchSound.Play();
                    outputLabel.Text = "Your skin turns green. Claws sprout from your finger tips. The apple has transformed into a goblin!";
                    outputLabel.Text += $"\nFreak out or go about your new life?";

                    option1Label.Text = "Go about your new life";
                    option2Label.Text = "Freak out!";
                    break;
                case 4:
                    imageBox.Image = Properties.Resources.forest;

                    swordsSound.Stop();
                    goldCoins++;
                    UpdateGold();

                    outputLabel.Text = "You kick the apple and continue walking...";
                    outputLabel.Text += $"\nRIGHT INTO ANOTHER UNIVERSE";

                    magicSpellSound.Play();
                    option1Label.Text = "Continue";

                    option2Button.Visible = false;
                    option2Label.Enabled = false;

                    break;
                case 5:
                    imageBox.Image = Properties.Resources.deadGoblin;

                    goldCoins += 5;
                    UpdateGold();

                    if (hasKnife == true)
                    {
                        outputLabel.Text = "You slice up the goblin with your knife! He drops 5 gold coins and an apple";
                    }
                    else
                    {
                        outputLabel.Text = "You kill the goblin! He drops 5 gold coins and an apple";
                    }

                    outputLabel.Text += $"\nDo you eat the apple?";

                    swordsSound.Play();

                    option1Label.Text = "Eat the apple";
                    option2Label.Text = "Kick the apple and continue walking";
                    break;
                case 6:
                    imageBox.Image = Properties.Resources.runningAway;

                    outputLabel.Text = "He killed you terribly!";
                    outputLabel.Text += $"\nPlay again?";

                    swordsSound.Play();
                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 7:
                    imageBox.Image = Properties.Resources.goblinFighting;

                    outputLabel.Text = "The goblin cought up to you! You must fight! Oh wait... ";
                    outputLabel.Text += $"\nHe already killed you... Play again?";

                    swordsSound.Play();
                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 8:
                    imageBox.Image = Properties.Resources.runningAway;

                    goldCoins += 25;
                    UpdateGold();

                    if (hasKnife == true)
                    {
                        outputLabel.Text = "The goblin catches up to you. You kill him with your knife and move into his goblin cave. Out of nowhere his wife apears!";
                        outputLabel.Text += $"\nWhat will you do?";
                    }
                    else
                    {
                        outputLabel.Text = "You escape the goblin by running into his own cave. You steal 25 of his gold. Out of nowhere his wife apears!";
                        outputLabel.Text += $"\nWhat will you do?";
                    }

                    option3Button.Visible = true;
                    option3Label.Enabled = true;

                    option1Label.Text = "Buy her love";
                    option2Label.Text = "Figher her";
                    option3Label.Text = "Pretend to be her husband";
                    break;
                case 9:
                    imageBox.Image = Properties.Resources.goblinLady;

                    goldCoins++;
                    UpdateGold();

                    outputLabel.Text = "After coming to your senses, you notice a cute goblin girl making eye contact with you.";
                    outputLabel.Text += $"\nRizz?";

                    option1Label.Text = "Approach her";
                    option2Label.Text = "Ignore her";
                    break;
                case 10:
                    imageBox.Image = Properties.Resources.forest;

                    outputLabel.Text = "You run off into the forest never to be seen again.";
                    outputLabel.Text += $"\nPlay again?";

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 11:
                    imageBox.Image = Properties.Resources.goblinCave;

                    outputLabel.Text = "She thinks you're broke and eats you alive!";
                    outputLabel.Text += $"\nPlay again?";

                    option3Label.Enabled = false;
                    option3Button.Visible = false;

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 12:
                    imageBox.Image = Properties.Resources.goblinCave;

                    outputLabel.Text = "You two fall in love and live happily ever after.";
                    outputLabel.Text += $"\nPlay again?";

                    option3Label.Enabled = false;
                    option3Button.Visible = false;

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 13:
                    imageBox.Image = Properties.Resources.goblinCave;

                    outputLabel.Text = "She chops you up into little peices.";
                    outputLabel.Text += $"\nPlay again?";

                    option3Label.Enabled = false;
                    option3Button.Visible = false;

                    swordsSound.Play();
                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 14:
                    imageBox.Image = Properties.Resources.goblinCave;

                    outputLabel.Text = "You chop her up with your knife and live in the stinky cave for the rest of your life.";
                    outputLabel.Text += $"\nPlay again?";

                    swordsSound.Play();
                    option3Label.Enabled = false;
                    option3Button.Visible = false;

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 15:
                    imageBox.Image = Properties.Resources.goblinCave;

                    outputLabel.Text = "She sees right past you...";
                    outputLabel.Text += $"\nAnd kills you... Play again?";

                    swordsSound.Play();
                    option3Label.Enabled = false;
                    option3Button.Visible = false;

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 16:
                    imageBox.Image = Properties.Resources.goblinLady;

                    goldCoins++;
                    UpdateGold();

                    outputLabel.Text = "She likes your confidance. She asks you to meet her parrents.";
                    outputLabel.Text += $"\nRizz the parents?";

                    option1Label.Text = "Accept";
                    option2Label.Text = "Decline";
                    break;
                case 17:
                    if (hasKnife == true)
                    {
                        imageBox.Image = Properties.Resources.deadGoblin;

                        outputLabel.Text = "She tries to cast a spell on you. You kill her first with your knife. You die of loneliness.";
                        outputLabel.Text += $"\nPlay again?";
                    }
                    else
                    {
                        imageBox.Image = Properties.Resources.timeTravel;

                        outputLabel.Text = "She casts a time travel spell on you and sends you back to the start";
                        outputLabel.Text += $"\nYou loose all gold";

                        magicSpellSound.Play();
                    }

                    option1Label.Text = "Continue";

                    option2Button.Visible = false;
                    option2Label.Enabled = false;
                    break;
                case 18:
                    imageBox.Image = Properties.Resources.romanticalGoblins;

                    outputLabel.Text = "Her parents love you! You two live happily ever after";
                    outputLabel.Text += $"\nPlay again?";

                    option1Label.Text = "Yes";
                    option2Label.Text = "No";
                    break;
                case 19:
                    if (hasKnife == true)
                    {
                        imageBox.Image = Properties.Resources.forest;

                        outputLabel.Text = "Your girlfriend tries to eat you. But you slice her with your knife! You die of loneliness.";
                        outputLabel.Text += $"\nPlay again?";
                    }
                    else
                    {
                        imageBox.Image = Properties.Resources.runningAway;

                        outputLabel.Text = "Your girlfriend eats you alive!";
                        outputLabel.Text += $"\nPlay again?";
                        crunchSound.Play();
                    }

                    swordsSound.Play();
                    option1Label.Text = "Yes";
                    option2Label.Text = "No";

                    break;
                case 99:
                    outputLabel.Text = "Thank you for playing";
                    option1Label.Text = "";
                    option2Label.Text = "";
                    Refresh();
                    Thread.Sleep(2000);
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            storeGroupBox.Enabled = true;
            storeGroupBox.Visible = true;
            UIClick.Play();
        }

        private void exitStoreButton_Click(object sender, EventArgs e)
        {
            storeGroupBox.Enabled = false;
            storeGroupBox.Visible = false;
            UIClick.Play();
        }

        private void PTTButton_Click(object sender, EventArgs e)
        {
            if (goldCoins >= 15)
            {
                goldCoins -= 15;
                numPotions++;
                
                storeOutputLable.ForeColor = Color.White;
                storeOutputLable.Text = $"You have {numPotions} Potions.";
                UpdateGold();

                usePotionButton.Enabled = true;
                usePotionButton.Visible = true;
                usePotionLabel.Enabled = true;
            }
            else
            {
                storeOutputLable.ForeColor = Color.Red;
                storeOutputLable.Text = $"Insufficient funds.";
            }
            UIClick.Play();
        }

        private void knifeButton_Click(object sender, EventArgs e)
        {
            if (goldCoins >= 25 && !hasKnife)
            {
                goldCoins -= 25;
                hasKnife = true;

                storeOutputLable.ForeColor = Color.White;
                storeOutputLable.Text = $"You have a bought a knife.";
                UpdateGold();
            }
            else if (hasKnife == true)
            {
                storeOutputLable.ForeColor = Color.Red;
                storeOutputLable.Text = $"You already have a knife.";
            }
            else
            {
                storeOutputLable.ForeColor = Color.Red;
                storeOutputLable.Text = $"Insufficient funds";
            }
            UIClick.Play();
        }

        private void fancyrockButton_Click(object sender, EventArgs e)
        {
            if (goldCoins >= 50 && !hasRock)
            {
                goldCoins -= 25;
                hasRock = true;

                storeOutputLable.ForeColor = Color.White;
                storeOutputLable.Text = $"You were scammed. :)";
                UpdateGold();
            }
            else if (hasRock == true)
            {
                storeOutputLable.ForeColor = Color.Red;
                storeOutputLable.Text = $"You already have a rock.";
            }
            else
            {
                storeOutputLable.ForeColor = Color.Red;
                storeOutputLable.Text = $"Insufficient funds";
            }
            UIClick.Play();
        }

        private void usePotionButton_Click(object sender, EventArgs e)
        {
            if (numPotions == 1)
            {
                usePotionButton.Enabled = false;
                usePotionButton.Visible = false;
                usePotionLabel.Enabled = false;
            }
            numPotions--;

            magicSpellSound.Play();

            page = prevPage;
            DisplayPage();
            UIClick.Play();
        }
    }

}
