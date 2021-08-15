using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SDG.Unturned;

namespace sf.Extra
{
   public class Menu : MonoBehaviour
    {
        #region vars
        public static bool MenuOpen = false;
        public static Rect windowrect = new Rect(20,20,500,400);
        public static KeyCode MenuKey = KeyCode.F1;
        public static int selectedtab;
        public static int selectedesptab;
        public static string[] menutabs = new string[] {"Aim", "Visuals", "Weapons", "Players", "Misc", "Settings"};
        public static string[] visualtabs = new string[] { "Player", "Zombie", "Vehicle", "Item", "Animal", "Storage", "Bed" };

        //aim (not done)
        public static bool Aimlock = false;
        public static bool AimHotkey = false;

        //esp
        public static bool PlayerESPEnabled = false;
        public static bool PlayerName = false;
        public static bool PlayerDistance = false;
        public static bool PlayerGlow = false;
        public static bool PlayerBox2D = false;
        public static bool InfPlayerESPDistance = false;
        public static float PlayerDistanceVal = 600f;

        public static bool ZombieESPEnabled = false;
        public static bool ZombieName = false;
        public static bool ZombieDistance = false;
        public static bool ZombieGlow = false;
        public static bool ZombieBox2D = false;
        public static bool InfZombieESPDistance = false;
        public static float ZombieDistanceVal = 600f;

        public static bool VehicleESPEnabled = false;
        public static bool VehicleName = false;
        public static bool VehicleDistance = false;
        public static bool VehicleGlow = false;
        public static bool VehicleBox2D = false;
        public static bool InfVehicleESPDistance = false;
        public static float VehicleDistanceVal = 600f;

        public static bool ItemESPEnabled = false;
        public static bool ItemName = false;
        public static bool ItemDistance = false;
        public static bool ItemGlow = false;
        public static bool ItemBox2D = false;
        public static bool InfItemESPDistance = false;
        public static float ItemDistanceVal = 600f;

        public static bool AnimalESPEnabled = false;
        public static bool AnimalName = false;
        public static bool AnimalDistance = false;
        public static bool AnimalGlow = false;
        public static bool AnimalBox2D = false;
        public static bool InfAnimalESPDistance = false;
        public static float AnimalDistanceVal = 600f;

        public static bool StorageESPEnabled = false;
        public static bool StorageName = false;
        public static bool StorageDistance = false;
        public static bool StorageGlow = false;
        public static bool StorageBox2D = false;
        public static bool InfStorageESPDistance = false;
        public static float StorageDistanceVal = 600f;

        public static bool BedESPEnabled = false;
        public static bool BedName = false;
        public static bool BedDistance = false;
        public static bool BedGlow = false;
        public static bool BedBox2D = false;
        public static bool InfBedESPDistance = false;
        public static float BedDistanceVal = 600f;


        //weapons
        public static bool NoRecoil = false;
        public static bool NoSpread = false;
        public static bool NoSway = false;
        public static bool WeaponInfo = false;

        //misc
        public static bool NoRain = false;
        public static bool NoSnow = false;
        public static bool ShowCompass = false;
        public static bool ForceThirdPerson = false;

        //players
        public static SteamPlayer player;

        #endregion

        public void Update()
        {
            if (Input.GetKeyDown(MenuKey))
            {
                if (MenuOpen == false)
                {
                    MenuOpen = true;
                }
                else
                {
                    MenuOpen = false;
                }
            }
        }

        public void OnGUI()
        {
            if (MenuOpen)
            {
                windowrect = GUI.Window(0, windowrect, MainWindow, "");
            }
        }

        public void MainWindow(int id)
        {
            selectedtab = GUILayout.Toolbar(selectedtab, menutabs);
            switch (selectedtab)
            {
                case 0:
                    AimTab();
                    break;
                case 1:
                    ESPTab();
                    break;
                case 2:
                    WeaponsTab();
                    break;
                case 3:
                    PlayersTab();
                    break;
                case 4:
                    MiscTab();
                    break;
                case 5:
                    SettingsTab();
                    break;
            }

            GUI.DragWindow();
        }

        public void AimTab()
        {
            Aimlock = GUILayout.Toggle(Aimlock, "Enable Aimlock");
            AimHotkey = GUILayout.Toggle(AimHotkey, "Use Hotkey");
        }

        public void WeaponsTab()
        {
            NoRecoil = GUILayout.Toggle(NoRecoil, "No Recoil");
            NoSpread = GUILayout.Toggle(NoSpread, "No Spread");
            NoSway = GUILayout.Toggle(NoSway, "No Sway");
            WeaponInfo = GUILayout.Toggle(WeaponInfo, "Weapon Information");
        }

        public void PlayersTab()
        {
            if (!Provider.isLoading && Provider.isConnected)
            {
                for (int i = 0; i < Provider.clients.Count; i++)
                {
                    SteamPlayer steamPlayer = Provider.clients[i];

                    

                    if (steamPlayer == null || steamPlayer.player == Utils.Utilities.mainPlayer)
                    {
                        continue;
                    }


                    if (GUILayout.Button(steamPlayer.player.name))
                    {
                        player = steamPlayer;
                    }

                    if (player == null)
                    { return; }


                    if (GUILayout.Button("Remove Friend"))
                    {
                        Utils.Utilities.RemoveFriend(player.player);
                    }

                    if (GUILayout.Button("Add Friend"))
                    {
                        Utils.Utilities.AddFriend(player.player);
                    }
                }
            }
        }
        public void MiscTab()
        {

        }

        public void SettingsTab()
        {


            if (GUILayout.Button("Disconnect"))
                Provider.disconnect();
        }

        public void ESPTab()
        {
            selectedesptab = GUILayout.Toolbar(selectedesptab, visualtabs);

            switch(selectedesptab)
            {
                case 0: PlayerESPTab();
                    break;
                case 1: ZombieESPTab();
                    break;
                case 2: VehicleESPTab();
                    break;
                case 3: ItemESPTab();
                    break;
                case 4: AnimalESPTab();
                    break;
                case 5: StorageESPTab();
                    break;
                case 6: BedESPTab();
                    break;
            }
        }

        public void PlayerESPTab()
        {
            GUILayout.Label("Player ESP");
            PlayerESPEnabled = GUILayout.Toggle(PlayerESPEnabled, "Enable Player ESP");
            PlayerName = GUILayout.Toggle(PlayerName, "Enable Name");
            PlayerDistance = GUILayout.Toggle(PlayerDistance, "Enable Distance");
            PlayerGlow = GUILayout.Toggle(PlayerGlow, "Enable Glow");
            PlayerBox2D = GUILayout.Toggle(PlayerBox2D, "Enable 2D Box");
            InfPlayerESPDistance = GUILayout.Toggle(InfPlayerESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + PlayerDistanceVal.ToString());
            PlayerDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(PlayerDistanceVal, 5, 5000));
        }

        public void ZombieESPTab()
        {
            GUILayout.Label("Zombie ESP");
            ZombieESPEnabled = GUILayout.Toggle(ZombieESPEnabled, "Enable Zombie ESP");
            ZombieName = GUILayout.Toggle(ZombieName, "Enable Name");
            ZombieDistance = GUILayout.Toggle(ZombieDistance, "Enable Distance");
            ZombieGlow = GUILayout.Toggle(ZombieGlow, "Enable Glow");
            ZombieBox2D = GUILayout.Toggle(ZombieBox2D, "Enable 2D Box");
            InfZombieESPDistance = GUILayout.Toggle(InfZombieESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + ZombieDistanceVal.ToString());
            ZombieDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(ZombieDistanceVal, 5, 5000));
        }
        public void VehicleESPTab()
        {
            GUILayout.Label("Vehicle ESP");
            VehicleESPEnabled = GUILayout.Toggle(VehicleESPEnabled, "Enable Vehicle ESP");
            VehicleName = GUILayout.Toggle(VehicleName, "Enable Name");
            VehicleDistance = GUILayout.Toggle(VehicleDistance, "Enable Distance");
            VehicleGlow = GUILayout.Toggle(VehicleGlow, "Enable Glow");
            VehicleBox2D = GUILayout.Toggle(VehicleBox2D, "Enable 2D Box");
            InfVehicleESPDistance = GUILayout.Toggle(InfVehicleESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + VehicleDistanceVal.ToString());
            VehicleDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(VehicleDistanceVal, 5, 5000));

        }
        public void ItemESPTab()
        {
            GUILayout.Label("Item ESP");
            ItemESPEnabled = GUILayout.Toggle(ItemESPEnabled, "Enable Item ESP");
            ItemName = GUILayout.Toggle(ItemName, "Enable Name");
            ItemDistance = GUILayout.Toggle(ItemDistance, "Enable Distance");
            ItemGlow = GUILayout.Toggle(ItemGlow, "Enable Glow");
            ItemBox2D = GUILayout.Toggle(ItemBox2D, "Enable 2D Box");
            InfItemESPDistance = GUILayout.Toggle(InfItemESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + ItemDistanceVal.ToString());
            ItemDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(ItemDistanceVal, 5, 5000));
        }
        public void AnimalESPTab()
        {
            GUILayout.Label("Animal ESP");
            AnimalESPEnabled = GUILayout.Toggle(AnimalESPEnabled, "Enable Animal ESP");
            AnimalName = GUILayout.Toggle(AnimalName, "Enable Name");
            AnimalDistance = GUILayout.Toggle(AnimalDistance, "Enable Distance");
            AnimalGlow = GUILayout.Toggle(AnimalGlow, "Enable Glow");
            AnimalBox2D = GUILayout.Toggle(AnimalBox2D, "Enable 2D Box");
            InfAnimalESPDistance = GUILayout.Toggle(InfItemESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + AnimalDistanceVal.ToString());
            AnimalDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(AnimalDistanceVal, 5, 5000));
        }
        
        public void StorageESPTab()
        {
            GUILayout.Label("Storage ESP");
            StorageESPEnabled = GUILayout.Toggle(StorageESPEnabled, "Enable Storage ESP");
            StorageName = GUILayout.Toggle(StorageName, "Enable Name");
            StorageDistance = GUILayout.Toggle(StorageDistance, "Enable Distance");
            StorageGlow = GUILayout.Toggle(StorageGlow, "Enable Glow");
            StorageBox2D = GUILayout.Toggle(StorageBox2D, "Enable 2D Box");
            InfStorageESPDistance = GUILayout.Toggle(InfStorageESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + StorageDistanceVal.ToString());
            StorageDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(StorageDistanceVal, 5, 5000));
        }

        public void BedESPTab()
        {
            GUILayout.Label("Bed ESP");
            BedESPEnabled = GUILayout.Toggle(BedESPEnabled, "Enable Bed ESP");
            BedName = GUILayout.Toggle(BedName, "Enable Name");
            BedDistance = GUILayout.Toggle(BedDistance, "Enable Distance");
            BedGlow = GUILayout.Toggle(BedGlow, "Enable Glow");
            BedBox2D = GUILayout.Toggle(BedBox2D, "Enable 2D Box");
            InfBedESPDistance = GUILayout.Toggle(InfBedESPDistance, "Infinite Distance");
            GUILayout.Label("Distance: " + BedDistanceVal.ToString());
            BedDistanceVal = (float)System.Math.Round(GUILayout.HorizontalSlider(BedDistanceVal, 5, 5000));
        }


    }
}
