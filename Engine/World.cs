using System.Collections.Generic;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Enemy> Enemies = new List<Enemy>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Lootable> Lootables = new List<Lootable>();

        public const int ITEM_ID_FLIP_KNIFE = 1;
        public const int ITEM_ID_WORN_WALLET = 2;
        public const int ITEM_ID_WORN_CELLPHONE = 3;
        public const int ITEM_ID_KEY_CARD = 4;
        public const int ITEM_ID_POLICE_BATON = 5;
        public const int ITEM_ID_HATCHET = 6;
        public const int ITEM_ID_BASIC_MEDPACK = 7;
        public const int ITEM_ID_ADVANCED_MEDPACK = 8;
        public const int ITEM_ID_CAR_KEYS = 9;
        public const int ITEM_ID_BANDAGE = 10;
        public const int ITEM_ID_SHIP_KEYS = 11;
        public const int ITEM_ID_GAS = 12;
        public const int ITEM_ID_MAKESHIFT_SPEAR = 13;
        public const int ITEM_ID_RUSTY_CHAIN_WHIP = 14;
        public const int ITEM_ID_BASEBALL_BAT = 15;
        public const int ITEM_ID_BASEBALL_BAT_NAILS = 16;

        public const int LOOTABLE_ID_BACKPACK = 1;
        public const int LOOTABLE_ID_LUGGAGE = 2;
        public const int LOOTABLE_ID_BROKEN_CAR = 3;

        public const int ENEMY_ID_CRAZY_REDNECK = 1;
        public const int ENEMY_ID_RABID_DOG = 2;
        public const int ENEMY_ID_COYOTE = 3;
        public const int ENEMY_ID_SHIPHAND = 4;
        public const int ENEMY_ID_THE_ADMIRAL = 5;
        public const int ENEMY_ID_PARANOID_GAS_EMPLOYEE = 6;
        public const int ENEMY_ID_LOOTER = 7;

        public const int QUEST_ID_GET_OUT_OF_DODGE = 1;
        public const int QUEST_ID_FIND_A_CAR = 2;
        public const int QUEST_ID_TRAVEL_TO_WILMINGTON = 3;
        public const int QUEST_ID_DEFEAT_THE_ADMIRAL = 4;
        public const int QUEST_ID_GET_GAS = 5;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_NEIGHBORHOOD_STREET = 2;
        public const int LOCATION_ID_INTERSTATE_40_GAS_STATION = 3;
        public const int LOCATION_ID_WILMINGTON_CITY_LIMITS = 4;
        public const int LOCATION_ID_PORT_BRIDGE = 5;
        public const int LOCATION_ID_WILMINGTON_STORE = 6;
        public const int LOCATION_ID_DOWNTOWN_WILMINGTON = 7;
        public const int LOCATION_ID_WILMINGTON_PHARMACY = 8;
        public const int LOCATION_ID_PORT_SECURITY_PERIMITER = 9;
        public const int LOCATION_ID_PORT_SHIP = 10;
        public const int LOCATION_ID_INTERCOASTAL_WATERWAY = 11;
        public const int LOCATION_ID_TOWN_SQUARE = 12;
        public const int LOCATION_ID_PARK = 13;
        public const int LOCATION_ID_CHURCH_GROUNDS = 14;
        public const int LOCATION_ID_CHURCH_INTERIOR = 15;

        static World()
        {
            PopulateItems();
            PopulateEnemies();
            PopulateQuests();
            PopulateLootables();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_FLIP_KNIFE, "Rusty Flip Knife", "Rust Flip Knives", 1, 0, 4, 50));
            Items.Add(new Weapon(ITEM_ID_POLICE_BATON, "Police Baton", "Police Baton", 1, 2, 5, 50));
            Items.Add(new Weapon(ITEM_ID_HATCHET, "Old Hatchet", "Old Hatchets", 1, 5, 10, 50));
            Items.Add(new Weapon(ITEM_ID_BASEBALL_BAT, "Baseball Bat", "Baseball Bats", 1, 1, 6, 50));
            Items.Add(new Weapon(ITEM_ID_BASEBALL_BAT_NAILS, "Spiked Baseball Bat", "Spiked Baseball Bats", 1, 4, 9, 50));
            Items.Add(new Weapon(ITEM_ID_MAKESHIFT_SPEAR, "Makeshift Spear", "Makeshift Spears", 1, 5, 7, 50));
            Items.Add(new Weapon(ITEM_ID_RUSTY_CHAIN_WHIP, "Rusty chain Whip", "Rusty Chain Whips", 1, 6, 6, 50));
            Items.Add(new MedPack(ITEM_ID_BASIC_MEDPACK, "Basic MedPack", "Basic MedPacks", 1, 6, 50));
            Items.Add(new MedPack(ITEM_ID_ADVANCED_MEDPACK, "Advanced MedPack", "Advanced MedPacks", 1, 8, 50));
            Items.Add(new MedPack(ITEM_ID_BANDAGE, "Bandage", "Bandages", 1, 2, 50));
            Items.Add(new Item(ITEM_ID_CAR_KEYS, "Car Keys", "Car Keys", 1, 50));
            Items.Add(new Item(ITEM_ID_KEY_CARD, "Key Card", "Key Card", 1, 50));
            Items.Add(new Item(ITEM_ID_WORN_CELLPHONE, "Worn Cellphone", "Worn Cellphone", 1, 50));
            Items.Add(new Item(ITEM_ID_WORN_WALLET, "Worn Wallet", "Worn Wallet", 1, 50));
            Items.Add(new Item(ITEM_ID_SHIP_KEYS, "Ship Keys", "Ship Keys", 1, 50));
            Items.Add(new Item(ITEM_ID_GAS, "Gas container", "Gas containers", 1, 50));
        }

        private static void PopulateLootables()
        {
            Lootable backpack = new Lootable(LOOTABLE_ID_BACKPACK, "Backpack", "Backpacks", 2, false);
            backpack.addContent(Items[0]);
            backpack.addContent(Items[13]);
            backpack.addContent(Items[12]);
            backpack.addContent(Items[9]);
            backpack.addContent(Items[7]);
            Lootable brokenCar = new Lootable(LOOTABLE_ID_BROKEN_CAR, "Broken Car", "Broken Cars", 4, false);
            brokenCar.addContent(Items[3]);
            Lootable luggage = new Lootable(LOOTABLE_ID_LUGGAGE, "Luggage", "Luggage", 3, false);

            Lootables.Add(backpack);
            Lootables.Add(brokenCar);
            Lootables.Add(luggage);
        }


        private static void PopulateEnemies()
        {
            Enemy crazyRedneck = new Enemy(ENEMY_ID_CRAZY_REDNECK, "Crazy Redneck", 2, 7, 5, 7, 7);
            crazyRedneck.addLoot(Items[3]);
            crazyRedneck.addLoot(Items[9]);
            crazyRedneck.addLoot(Items[10]);
            crazyRedneck.addLoot(Items[11]);
            crazyRedneck.addLoot(Items[13]);
            Enemy rabidDog = new Enemy(ENEMY_ID_RABID_DOG, "Rabid Dog", 4, 8, 0, 8, 8);
            rabidDog.addLoot(Items[13]);
            Enemy coyote = new Enemy(ENEMY_ID_COYOTE, "Coyote", 3, 6, 0, 10, 10);
            Enemy gasEmployee = new Enemy(ENEMY_ID_PARANOID_GAS_EMPLOYEE, "Paranoid Gas Station Employee", 2, 6, 2, 12, 12);
            gasEmployee.addLoot(Items[15]);
            Enemy looter = new Enemy(ENEMY_ID_LOOTER, "Looter", 2, 5, 8, 6, 6);
            looter.addLoot(Items[7]);
            looter.addLoot(Items[9]);
            Enemy shiphand = new Enemy(ENEMY_ID_SHIPHAND, "Ship Hand", 6, 10, 10, 15, 15);
            shiphand.addLoot(Items[7]);
            shiphand.addLoot(Items[9]);
            Enemy theAdmiral = new Enemy(ENEMY_ID_THE_ADMIRAL, "The Admiral", 7, 14, 25, 20, 20);
            theAdmiral.addLoot(Items[12]);

            Enemies.Add(crazyRedneck);
            Enemies.Add(rabidDog);
            Enemies.Add(coyote);
            Enemies.Add(shiphand);
            Enemies.Add(theAdmiral);
            Enemies.Add(gasEmployee);
            Enemies.Add(looter);
        }

        private static void PopulateQuests()
        {
            //Quest getOut = new Quest(QUEST_ID_GET_OUT_OF_DODGE, "Get out of dodge", "You awoke to the sound of your window breaking. Looking through the broken window, you see corpses littering your neighborhood street. It appears you have slept through the apocalypse. Get the hell out of there!", 5, 2);
            Quest findCar = new Quest(QUEST_ID_FIND_A_CAR, "Find a car", "Find a car to be able to" +
                " travel longer distances.", 10, 5, Items[ITEM_ID_BASIC_MEDPACK]);
            findCar.addCompleteItem(new QuestCompleteItem(ItemByID(ITEM_ID_CAR_KEYS), 1));
            //Quest travelWilmington = new Quest(QUEST_ID_TRAVEL_TO_WILMINGTON, "Get to Wilmington", "You have a car. Make your way to the coast. Don't run out of gas.", 10, 0);
            Quest defeatAdmiral = new Quest(QUEST_ID_DEFEAT_THE_ADMIRAL, "Commeandeer the boat.",
                "There's only one seaworthy boat left at the port. It appears to be currently owned" +
                " by a ragtag militia ran by 'The Admiral', find a way to take it from them.",
                20, 30, Items[ITEM_ID_ADVANCED_MEDPACK]);
            defeatAdmiral.addCompleteItem(new QuestCompleteItem(ItemByID(ITEM_ID_SHIP_KEYS), 1));
            Quest getGas = new Quest(QUEST_ID_GET_GAS, "Find and get gas", "The engine is " +
                "remarkably weaker. The gas gauge is broken, but its safe to say it's time to" +
                " fill up", 5, 0, Items[ITEM_ID_ADVANCED_MEDPACK]);
            getGas.addCompleteItem(new QuestCompleteItem(ItemByID(ITEM_ID_GAS), 1));
            //Quests.Add(getOut);
            Quests.Add(findCar);
            //Quests.Add(travelWilmington);
            Quests.Add(defeatAdmiral);
            Quests.Add(getGas);
        }

        public static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your apartment. The door is barricaded. The window is broken. It's not safe here. You can see a car with some people outside it on the street outside.", 0);
            home.LootableHere = LootableByID(LOOTABLE_ID_BACKPACK);
            home.QuestHere = QuestByID(QUEST_ID_FIND_A_CAR);
            //home.QuestHere = QuestByID(QUEST_ID_GET_OUT_OF_DODGE);
            Location neighborhoodStreet = new Location(LOCATION_ID_NEIGHBORHOOD_STREET, "The street outside your apartment.", "Corpses litter the floor. There is one seemingly functional car surrounded by rednecks. The I-40 leads East.", 1);
            neighborhoodStreet.LootableHere = LootableByID(LOOTABLE_ID_BROKEN_CAR);
            neighborhoodStreet.QuestHere = QuestByID(QUEST_ID_TRAVEL_TO_WILMINGTON);
            neighborhoodStreet.EnemyHere = EnemyByID(ENEMY_ID_CRAZY_REDNECK);

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square", "The local town square. The roads are filled with broken down cars and a mixture of open and closed luggage. Perhaps you'll find something, once you deal with the looters.", 3);
            townSquare.EnemyHere = EnemyByID(ENEMY_ID_LOOTER);
            Location townPark = new Location(LOCATION_ID_PARK, "Town Park", "The local park. There are a number of broken down cars here, and some coyotes chewing on what appears to be human bones.", 4);
            townPark.EnemyHere = EnemyByID(ENEMY_ID_COYOTE);
            Location townChurchGrounds = new Location(LOCATION_ID_CHURCH_GROUNDS, "Church Grounds", "The grounds surrounding the local church. The signage is vandalized, but it appears that there was a medical camp set up here some time ago. You hear movement, and the distinct sound of weapons being sharped, inside.", 0);
            Location townChurchInterior = new Location(LOCATION_ID_CHURCH_INTERIOR, "Church Interior", "The inside of the Church is pitch black except for where it is lit by candles. You can make out a large cache of luggage behind the altar. As you approach this cache, you notice that a large group of shadowy individuals are waiting in ambush in the pews.", 7);
            townChurchInterior.EnemyHere = EnemyByID(ENEMY_ID_LOOTER);
            Location gasStation = new Location(LOCATION_ID_INTERSTATE_40_GAS_STATION, "A gas station on the I-40", "Looted, but maybe it still has some gas. Your neighborhood street is to the West. Wilmington lies south.", 3);
            gasStation.ItemRequiredEntry = ItemByID(ITEM_ID_CAR_KEYS);
            gasStation.QuestHere = QuestByID(QUEST_ID_GET_GAS);
            gasStation.EnemyHere = EnemyByID(ENEMY_ID_PARANOID_GAS_EMPLOYEE);
            Location cityLimits = new Location(LOCATION_ID_WILMINGTON_CITY_LIMITS, "Wilmington city limits", "The air smells different. Salty, with a hint of blood and death. A improvized roadblock made up of burning tires blocks the road further. The road back home is North. Downtown lies to the East. There's a store nearby that you can go inside.", 2);
            cityLimits.ItemRequiredEntry = ItemByID(ITEM_ID_GAS);
            cityLimits.EnemyHere = EnemyByID(ENEMY_ID_CRAZY_REDNECK);
            Location wilmStore = new Location(LOCATION_ID_WILMINGTON_STORE, "Hrrs Teet", "The sign looks a lot like a popular grocery store in the south-east US, but some letters are blown out. The cities limits are outside.", 2);
            wilmStore.EnemyHere = EnemyByID(ENEMY_ID_LOOTER);
            Location wilmPharm = new Location(LOCATION_ID_WILMINGTON_PHARMACY, "Weens", "The sign looks a lot like a popular pharmacy, but some of the letters are blown out. Downtown is outside.", 2);
            wilmStore.EnemyHere = EnemyByID(ENEMY_ID_SHIPHAND);
            Location downTown = new Location(LOCATION_ID_DOWNTOWN_WILMINGTON, "Downtown Wilmington", "There's a pharmacy you can go inside. The boardwalk leads to a bridge that leads to the port, to the South. You came from the West.", 2);
            downTown.EnemyHere = EnemyByID(ENEMY_ID_RABID_DOG);
            Location portBridge = new Location(LOCATION_ID_PORT_BRIDGE, "The bridge to Wilmington's Port", "You came from the North. The bridge crosses east-wards. There is a group of people on your end of the bridge, apparently blocking the way...", 3);
            portBridge.EnemyHere = EnemyByID(ENEMY_ID_SHIPHAND);
            Location portPerimiter = new Location(LOCATION_ID_PORT_SECURITY_PERIMITER, "Makeshift perimiter", "More burning tires form a perimiter, with a improvised wire gate acting as the only viable point of entry. The perimiter surrounds the dock with the last boat. You can board the inside of this boat.", 4);
            portBridge.EnemyHere = EnemyByID(ENEMY_ID_SHIPHAND);
            Location portShip = new Location(LOCATION_ID_PORT_SHIP, "Ship", "The last working ship at the port - or at least the only one you can find. A lone man is in the bridge of the tanker. He see's you, and approaches. Is this the Admiral you've heard the shiphands warn you of? Once you get control of the boat, you should sail east.", 1);
            portShip.QuestHere = QuestByID(QUEST_ID_DEFEAT_THE_ADMIRAL);
            portShip.EnemyHere = EnemyByID(ENEMY_ID_THE_ADMIRAL);
            Location interCoastal = new Location(LOCATION_ID_INTERCOASTAL_WATERWAY, "Intercoastal Waterway", "Finally, safety. You can sail on your cargo ship filled with the food the Admiral prepared for survival until this whole thing blows over. You could dock at the port West,", 0);
            interCoastal.ItemRequiredEntry = ItemByID(ITEM_ID_SHIP_KEYS);

            home.LocationOutside = neighborhoodStreet;

            neighborhoodStreet.LocationInside = home;
            neighborhoodStreet.LocationEast = gasStation;
            neighborhoodStreet.LocationSouth = townSquare;

            townSquare.LocationNorth = neighborhoodStreet;
            townSquare.LocationWest = townPark;
            townSquare.LocationEast = townChurchGrounds;

            townPark.LocationEast = townSquare;

            townChurchGrounds.LocationInside = townChurchInterior;
            townChurchGrounds.LocationWest = townSquare;

            townChurchInterior.LocationOutside = townChurchGrounds;

            gasStation.LocationEast = neighborhoodStreet;
            gasStation.LocationSouth = cityLimits;

            cityLimits.LocationEast = downTown;
            cityLimits.LocationInside = wilmStore;
            cityLimits.LocationNorth = gasStation;

            downTown.LocationInside = wilmPharm;
            downTown.LocationSouth = portBridge;
            downTown.LocationWest = cityLimits;

            wilmPharm.LocationOutside = downTown;
            wilmStore.LocationOutside = cityLimits;

            portBridge.LocationNorth = downTown;
            portBridge.LocationEast = portPerimiter;

            portPerimiter.LocationWest = portBridge;
            portPerimiter.LocationInside = portShip;

            portShip.LocationOutside = portPerimiter;
            portShip.LocationEast = interCoastal;

            Locations.Add(home);
            Locations.Add(neighborhoodStreet);
            Locations.Add(townSquare);
            Locations.Add(gasStation);
            Locations.Add(cityLimits);
            Locations.Add(wilmStore);
            Locations.Add(downTown);
            Locations.Add(wilmPharm);
            Locations.Add(portBridge);
            Locations.Add(portPerimiter);
            Locations.Add(portShip);
            Locations.Add(interCoastal);

        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Lootable LootableByID(int id)
        {
            foreach (Lootable lootable in Lootables)
            {
                if (lootable.ID == id)
                {
                    return lootable;
                }
            }
            return null;
        }

        public static Enemy EnemyByID(int id)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.ID == id)
                {
                    return enemy;
                }
            }
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }



    }
}
