using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HK_Roller_2021
{
    public partial class Form1 : Form
    {
        List<Dice> dices = new List<Dice>();
        Label[] diceDisplay = new Label[12];
        Label[] diceHighlight = new Label[12];
        Label[] diceNames = new Label[12];
        Button[] diceDelete = new Button[12];

        public Form1()
        {
            InitializeComponent();
            for(int i = 1; i <= 12; i++)
            {
                string str = "D" + i + "Display";
                Label current= (Label)Controls.Find(str, true)[0];
                diceDisplay[i - 1] = current;

                str = "D" + i + "Highlight";
                current = (Label)Controls.Find(str, true)[0];
                diceHighlight[i - 1] = current;

                str = "D" + i + "Name";
                current = (Label)Controls.Find(str, true)[0];
                diceNames[i - 1] = current;

                str = "D" + i + "Delete";
                Button currentButton = (Button)Controls.Find(str, true)[0];
                diceDelete[i - 1] = currentButton;
            }

        }

        private void rollButton_Click(object sender, EventArgs e)
        {
            int num = int.Parse(rollLabel.Text);
            num++;
            rollLabel.Text = num.ToString();
            for(int i=0; i < dices.Count; i++)
            {
                if (!dices[i].saved)
                {
                    diceDisplay[i].Text = dices[i].roll().ToString();
                }
            }
        }

        private void createDie_Click(object sender, EventArgs e)
        {
            if (dices.Count < 12)
            {
                try
                {
                    int dieValue = int.Parse(dieValueTextBox.Text);

                    string name = "";

                    name = nameTextBox.Text + " " + dieValue;
                    

                    guildEnum guild;
                    if (noGuildRB.Checked == true)
                    {
                        guild = guildEnum.none;
                    }
                    else if (rangerGuildRB.Checked == true)
                    {
                        guild = guildEnum.ranger;
                    }
                    else if (mageGuildRB.Checked == true)
                    {
                        guild = guildEnum.mage;
                    }
                    else
                    {
                        guild = guildEnum.knight;
                    }
                   

                    //create Die
                    Dice die = new Dice(dieValue, guild, name);
                    dices.Add(die);


                    //Add new die to dices
                    updateDice();

                    //clear text
                    nameTextBox.Text = "";
                }
                catch
                {
                    MessageBox.Show("Invalid number given");
                }
            }
            else
            {
                MessageBox.Show("Max number of dice reached");
            }
        }

        private void updateDice()
        {
            clearAll();

            for (int i=0; i < dices.Count; i++)
            {
                //Make visible
                diceDisplay[i].Visible = true;
                diceNames[i].Visible = true;
                diceDelete[i].Visible = true;
                if (dices[i].saved)
                {
                    diceHighlight[i].Visible = true;
                }
                else
                {
                    diceHighlight[i].Visible = false;
                }


                //Fix values
                diceDisplay[i].Text = dices[i].getCurrentRoll().ToString();
                
                guildEnum guild = dices[i].getGuild();
                if(guild == guildEnum.none)
                {
                    diceDisplay[i].BackColor = Color.White;
                    diceDisplay[i].ForeColor = Color.Black;
                } else if (guild == guildEnum.ranger)
                {
                    diceDisplay[i].BackColor = Color.Black;
                    diceDisplay[i].ForeColor = Color.White;
                } else if (guild == guildEnum.mage)
                {
                    diceDisplay[i].BackColor = Color.Blue;
                    diceDisplay[i].ForeColor = Color.White;
                }
                else
                {
                    diceDisplay[i].BackColor = Color.Red;
                    diceDisplay[i].ForeColor = Color.White;
                }
                
                diceNames[i].Text = dices[i].getName();

                
            }
        }

        private void clearAll()
        {
            for (int i = 0; i < diceDisplay.Length; i++)
            {
                diceDisplay[i].Visible = false;
                diceHighlight[i].Visible = false;
                diceNames[i].Visible = false;
                diceDelete[i].Visible = false;
            }
        }

        private void D1Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(0);
            updateDice();
        }

        private void D2Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(1);
            updateDice();
        }

        private void D3Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(2);
            updateDice();
        }

        private void D4Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(3);
            updateDice();
        }

        private void D5Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(4);
            updateDice();
        }

        private void D6Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(5);
            updateDice();
        }

        private void D7Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(6);
            updateDice();
        }

        private void D8Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(7);
            updateDice();
        }

        private void D9Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(8);
            updateDice();
        }

        private void D10Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(9);
            updateDice();
        }

        private void D11Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(10);
            updateDice();
        }

        private void D12Delete_Click(object sender, EventArgs e)
        {
            dices.RemoveAt(11);
            updateDice();
        }

        private void D1Display_Click(object sender, EventArgs e)
        {
            dices[0].toggleSave();
            updateDice();
        }

        private void D2Display_Click(object sender, EventArgs e)
        {
            dices[1].toggleSave();
            updateDice();
        }

        private void D3Display_Click(object sender, EventArgs e)
        {
            dices[2].toggleSave();
            updateDice();
        }

        private void D4Display_Click(object sender, EventArgs e)
        {
            dices[3].toggleSave();
            updateDice();
        }

        private void D5Display_Click(object sender, EventArgs e)
        {
            dices[4].toggleSave();
            updateDice();
        }

        private void D6Display_Click(object sender, EventArgs e)
        {
            dices[5].toggleSave();
            updateDice();
        }

        private void D7Display_Click(object sender, EventArgs e)
        {
            dices[6].toggleSave();
            updateDice();
        }

        private void D8Display_Click(object sender, EventArgs e)
        {
            dices[7].toggleSave();
            updateDice();
        }

        private void D9Display_Click(object sender, EventArgs e)
        {
            dices[8].toggleSave();
            updateDice();
        }

        private void D10Display_Click(object sender, EventArgs e)
        {
            dices[9].toggleSave();
            updateDice();
        }

        private void D11Display_Click(object sender, EventArgs e)
        {
            dices[10].toggleSave();
            updateDice();
        }

        private void D12Display_Click(object sender, EventArgs e)
        {
            dices[11].toggleSave();
            updateDice();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            rollLabel.Text = "0";
            for(int i = 0; i < dices.Count; i++)
            {
                dices[i].saved = false;
            }
            updateDice();
        }

        private void coinAddButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(coinTB.Text);
            val++;
            coinTB.Text = val.ToString();
        }

        private void coinSubtractButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(coinTB.Text);
            if(val > 0)
            {
                val--;
                coinTB.Text = val.ToString();
            }
        }

        private void honorAddButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(honorTB.Text);
            val++;
            honorTB.Text = val.ToString();
        }

        private void honorSubtractButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(honorTB.Text);
            if(val > 0)
            {
                val--;
                honorTB.Text = val.ToString();
            }
        }

        private void rShardAddButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(rangerShardTB.Text);
            val++;
            rangerShardTB.Text = val.ToString();
        }

        private void rShardSubtractButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(rangerShardTB.Text);
            if (val > 0)
            {
                val--;
                rangerShardTB.Text = val.ToString();
            }
        }

        private void mShardAddButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(mageShardTB.Text);
            val++;
            mageShardTB.Text = val.ToString();
        }

        private void mShardSubtractButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(mageShardTB.Text);
            if (val > 0)
            {
                val--;
                mageShardTB.Text = val.ToString();
            }
        }

        private void kShardAddButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(knightShardTB.Text);
            val++;
            knightShardTB.Text = val.ToString();
        }

        private void kShardSubtractButton_Click(object sender, EventArgs e)
        {
            int val = int.Parse(knightShardTB.Text);
            if (val > 0)
            {
                val--;
                knightShardTB.Text = val.ToString();
            }
        }
    }
}
