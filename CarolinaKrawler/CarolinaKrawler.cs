// current version 0.30 updated 11/18/2019

using Engine;

using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace CarolinaKrawler
{
    public partial class CarolinaKrawler : Form
    {
        private Player _player;
        private Enemy _currentEnemy;
        private Lootable _currentLootable;

        public CarolinaKrawler()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_FLIP_KNIFE), 1));

            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
            UpdateInventoryListInUI();
        }

        /**
         * Moves the player to the room north of current location
         */
        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationWest);
        }

        private void btnInside_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationInside);
        }

        private void btnOutside_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationOutside);
        }

        private void MoveTo(Location newLocation)
        {
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemRequiredEntry.Name + " to enter this location." + Environment.NewLine;
                ScrollToBottomOfMessages();
                return;
            }

            _player.CurrentLocation = newLocation;

            btnNorth.Visible = (newLocation.LocationNorth != null);
            btnEast.Visible = (newLocation.LocationEast != null);
            btnSouth.Visible = (newLocation.LocationSouth != null);
            btnWest.Visible = (newLocation.LocationWest != null);
            btnInside.Visible = (newLocation.LocationInside != null);
            btnOutside.Visible = (newLocation.LocationOutside != null);

            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            UpdatePlayerStats();

            if (newLocation.LootableHere != null)
            {
                newLocation.LocationEnvironment.Clear();
                rtbMessages.Text += "You see a " + newLocation.LootableHere.Name + Environment.NewLine;

                newLocation.AddObjectToEnvironment(newLocation.LootableHere);

                Lootable standardLootable = World.LootableByID(newLocation.LootableHere.ID);
                _currentLootable = new Lootable(standardLootable.ID, standardLootable.Name, standardLootable.NamePlural, standardLootable.Capacity, standardLootable.IsLooted);

                foreach (Item lootItem in standardLootable.Contents)
                {
                    _currentLootable.Contents.Add(lootItem);
                }

                UpdateEnvironmentListInUI();
            }


            if (newLocation.QuestHere != null)
            {
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestHere);

                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompleteItems(newLocation.QuestHere);
                        bool playerAtQuestDestination = _player.AtQuestDestinationToCompleteQuest(newLocation.QuestHere);

                        if (playerHasAllItemsToCompleteQuest || playerAtQuestDestination)
                        {
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the " + newLocation.QuestHere.Name + " quest." + Environment.NewLine;
                            ScrollToBottomOfMessages();
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            ScrollToBottomOfMessages();
                            rtbMessages.Text += Environment.NewLine;

                            _player.AddItemToInventory(newLocation.QuestHere.RewardItem);

                            // Calling function to add experience points on completion of quest
                            _player.AddExperiencePoints(newLocation.QuestHere.RewardExperiencePoints);

                            // Calling function to add gold on completion of quest
                            _player.Gold += newLocation.QuestHere.RewardGold;

                            // Calling function to add quest reward item on completion of quest
                            _player.AddItemToInventory(newLocation.QuestHere.RewardItem);

                            // Calling function to mark quest as completed on completion of quest
                            _player.MarkQuestCompleted(newLocation.QuestHere);

                            // Calling function to remove quest items on completion of quest
                            _player.RemoveQuestCompleteItems(newLocation.QuestHere);

                            rtbMessages.Text += newLocation.QuestHere.RewardItem.Name.ToString() + Environment.NewLine;
                        }
                    }
                }

                else

                {
                    rtbMessages.Text += "You receive the " + newLocation.QuestHere.Name + " quest." + Environment.NewLine;
                    ScrollToBottomOfMessages();
                    rtbMessages.Text += newLocation.QuestHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, acquire:" + Environment.NewLine;
                    ScrollToBottomOfMessages();
                    foreach (QuestCompleteItem qci in newLocation.QuestHere.QuestCompleteItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;
                    _player.Quests.Add(newLocation.QuestHere);
                }

            }

            if (newLocation.NumberEnemy == 0)
            {
                newLocation.EnemyHere = null;
            }

            if (newLocation.EnemyHere != null)

            {
                rtbMessages.Text += "You see a " + newLocation.EnemyHere.Name + Environment.NewLine;
                ScrollToBottomOfMessages();

                Enemy standardEnemy = World.EnemyByID(newLocation.EnemyHere.ID);

                _currentEnemy = new Enemy(standardEnemy.ID, standardEnemy.Name, standardEnemy.MaximumDamage, standardEnemy.RewardExperiencePoints, standardEnemy.RewardGold, standardEnemy.CurrentHitPoints, standardEnemy.MaximumHitPoints);

                foreach (Item lootItem in standardEnemy.LootTable)
                {
                    _currentEnemy.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboMeds.Visible = true;
                btnUseMed.Visible = true;
                btnUseWeapon.Visible = true;
            }

            else

            {
                _currentEnemy = null;
                cboWeapons.Visible = false;
                UpdateMedListInUI();
                btnUseWeapon.Visible = false;

            }

            UpdateInventoryListInUI();
            UpdateQuestListInUI();
            UpdateMedListInUI();
            UpdateWeaponListInUI();
        }

        private void UpdateEnvironmentListInUI()
        {
            dgvEnvironment.RowHeadersVisible = false;
            dgvEnvironment.ColumnCount = 2;
            dgvEnvironment.Columns[0].Name = "Name";
            dgvEnvironment.Columns[0].Width = 114;
            dgvEnvironment.Columns[1].Name = "Quantity";
            dgvEnvironment.Columns[1].Width = 58;
            dgvEnvironment.Rows.Clear();


            List<Lootable> lootables = new List<Lootable>();
            foreach (EnvironmentalObject environmentalObject in _player.CurrentLocation.LocationEnvironment)
            {
                if (environmentalObject.Details is Lootable)
                {

                    if (environmentalObject.Quantity > 0)
                    {
                        lootables.Add((Lootable)environmentalObject.Details);
                        dgvEnvironment.Rows.Add(new[] { environmentalObject.Details.Name, environmentalObject.Quantity.ToString() });
                    }
                }
            }

            if (lootables.Count == 0)
            {
                cboInspect.Enabled = false;
                btnInspect.Enabled = false;
            }
            else
            {
                cboInspect.DataSource = lootables;
                cboInspect.DisplayMember = "Name";
                cboInspect.ValueMember = "ID";
                cboInspect.SelectedIndex = 0;
            }
        }

        private void UpdateInspectListInUI()
        {
            // Prime Inspect DGV for data
            dgvInspect.RowHeadersVisible = false;
            dgvInspect.ColumnCount = 1;
            dgvInspect.Columns[0].Name = "Name";
            dgvInspect.Columns[0].Width = 172;
            dgvInspect.Rows.Clear();

            // List for Contents
            List<Item> contents = new List<Item>();
            // Add items from current loot items contents to list
            foreach (Item lootItem in _currentLootable.Contents)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    contents.Add(lootItem);
                }
            }
            if (contents.Count == 0)
            {
                cboContents.Enabled = false;
                btnLoot.Enabled = false;
            }
            else
            {
                cboContents.Enabled = true;
                btnLoot.Enabled = true;
                cboContents.DisplayMember = "Name";
                cboContents.ValueMember = "ID";
                cboContents.DataSource = contents;
                cboContents.BindingContext = this.BindingContext;
            }
            foreach (Item objectContents in contents)
            {
                rtbMessages.Text += "You see " + objectContents.Name + " in the " + _currentLootable.Name + Environment.NewLine;
                dgvInspect.Rows.Add(new[] { objectContents.Name });
            }
            dgvInspect.Enabled = true;

        }


        private void LootInspectedItem()
        {
            Item inspected = (Item)cboContents.SelectedItem;
            _player.AddItemToInventory(inspected);
            int selectedIndex = cboContents.SelectedIndex;
            UpdateInventoryListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";
            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        /// <summary>
        /// Updates the Quest Log to reflect current quests and their status.
        /// </summary>
        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (Quest playerQuest in _player.Quests)
            {
                if (_player.HasAllQuestCompleteItems(playerQuest)){
                    playerQuest.setComplete();
                }
                dgvQuests.Rows.Add(new[] { playerQuest.Name, playerQuest.Status.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdateMedListInUI()
        {
            List<MedPack> medPacks = new List<MedPack>();
            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is MedPack)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        medPacks.Add((MedPack)inventoryItem.Details);
                    }
                }
            }

            if (medPacks.Count == 0)
            {
                cboMeds.Visible = false;
                btnUseMed.Visible = false;
            }
            else
            {
                cboMeds.DataSource = medPacks;
                cboMeds.DisplayMember = "Name";
                cboMeds.ValueMember = "ID";
                cboMeds.SelectedIndex = 0;
            }

            if (medPacks.Count > 0 && _player.CurrentHitPoints < _player.MaximumHitPoints)
            {
                cboMeds.Visible = true;
                btnUseMed.Visible = true;

                cboMeds.DataSource = medPacks;
                cboMeds.DisplayMember = "Name";
                cboMeds.ValueMember = "ID";
                cboMeds.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get weapon selected, calc damage, apply to enemy return message
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            int damageToEnemy = RandomNumberGenerator.NumberBetween(currentWeapon.MinmumDamage, currentWeapon.MaximumDamage);

            _currentEnemy.CurrentHitPoints -= damageToEnemy;

            rtbMessages.Text += "You hit the " + _currentEnemy.Name + " for " + damageToEnemy.ToString() + " points. " + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Check if enemy is dead
            if (_currentEnemy.CurrentHitPoints <= 0)
            {
                // Dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _currentEnemy.Name + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Remove 1 Enemy from numberEnemy

                _player.CurrentLocation.NumberEnemy--;

                // XP
                _player.AddExperiencePoints(_currentEnemy.RewardExperiencePoints);
                rtbMessages.Text += "You receive " + _currentEnemy.RewardExperiencePoints.ToString() + " experience points." + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Gold
                _player.Gold += _currentEnemy.RewardGold;
                rtbMessages.Text += "You find " + _currentEnemy.RewardGold.ToString() + " gold." + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Items
                // Random loot items
                List<InventoryItem> lootedItems = new List<InventoryItem>();
                // Add items from list, rng drop percentage
                foreach (Item lootItem in _currentEnemy.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem, 1));
                    }
                }

                // Add looted item to inventory

                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInventory(inventoryItem.Details);
                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }


                }

                // Refresh UI

                lblHitPoints.Text = _player.CurrentHitPoints.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.ExperiencePoints.ToString();
                lblLevel.Text = _player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateMedListInUI();
                UpdateWeaponListInUI();

                rtbMessages.Text += Environment.NewLine;

                MoveTo(_player.CurrentLocation);

            }
            else
            {
                // Enemy Alive
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentEnemy.MaximumDamage);
                rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage!" + Environment.NewLine;
                ScrollToBottomOfMessages();
                _player.CurrentHitPoints -= damageToPlayer;
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            }
            UpdatePlayerStats();
        }


        private void btnInspect_Click(object sender, EventArgs e)
        {
            Lootable selectedLootable = (Lootable)cboInspect.SelectedItem;
            if (selectedLootable.IsLooted == false)
            {
                UpdateInspectListInUI();
                selectedLootable.IsLooted = true;
            }

        }

        private void btnUseMed_Click(object sender, EventArgs e)
        {
            MedPack medpack = (MedPack)cboMeds.SelectedItem;
            _player.CurrentHitPoints = (_player.CurrentHitPoints + medpack.HealAmount);

            if (_player.CurrentHitPoints > _player.MaximumHitPoints)
            {
                _player.CurrentHitPoints = _player.CurrentHitPoints;
            }

            foreach (InventoryItem ii in _player.Inventory)
            {
                if (ii.Details.ID == medpack.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            rtbMessages.Text += "You use a " + medpack.Name + "." + Environment.NewLine;
            rtbMessages.Text += "It heals for " + medpack.HealAmount + " Health Points." + Environment.NewLine;
            ScrollToBottomOfMessages();
            if (_currentEnemy == null)
            {
                UpdatePlayerStats();
                UpdateInventoryListInUI();
                UpdateMedListInUI();
            }
            if (_currentEnemy != null)
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentEnemy.MaximumDamage);

                rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage!" + Environment.NewLine;
                ScrollToBottomOfMessages();
                _player.CurrentHitPoints -= damageToPlayer;
                lblHitPoints.Text = _player.CurrentHitPoints.ToString();
                UpdateMedListInUI();
                UpdateInventoryListInUI();
            }

        }

        private void UpdatePlayerStats()
        {
            // Refresh player info
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();

            if (_player.CurrentHitPoints <= 0)
            {
                rtbMessages.Clear();
                rtbMessages.Text += "You awaken from a foggy dream to the sound of your window being broken.";
                ScrollToBottomOfMessages();
                _player.Inventory.Clear();
                _player.Quests.Clear();
                _player = new Player(10, 10, 20, 0);
                UpdatePlayerStats();
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_FLIP_KNIFE), 1));
            }
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void BtnLoot_Click(object sender, EventArgs e)
        {
            LootInspectedItem();
        }
    }
}