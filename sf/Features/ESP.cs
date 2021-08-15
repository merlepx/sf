using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using HighlightingSystem;
using sf.Utils;
using SDG.Unturned;
using sf.Extra;

namespace sf.Features
{
    public class ESP : MonoBehaviour
    {
        public void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
             

                if (Utilities.mainCamera == null)
                {
                    Utilities.mainCamera = Camera.main;
                }
                if (Menu.PlayerGlow)
                {
                    for (int i = 0; i < Provider.clients.Count; i++)
                    {
                        SteamPlayer steamPlayer = Provider.clients[i];

                        Highlighter highlighter = steamPlayer.player.gameObject.GetComponent<Highlighter>();
                        if (steamPlayer.player.gameObject == null || steamPlayer.player.life.isDead || steamPlayer.player == Player.player)
                        {
                            if (highlighter == null)
                            {
                                steamPlayer.player.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.PlayerGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }

                    }
                }
                if (Menu.ZombieGlow)
                {
                    foreach (Zombie zombies in FindObjectsOfType<Zombie>())
                    {
                        Highlighter highlighter = zombies.gameObject.GetComponent<Highlighter>();
                        if (zombies != null)
                        {
                            if (highlighter == null)
                            {
                                zombies.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);

                        }
                        else if (!Menu.ZombieGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }

                    }
                }
                if (Menu.VehicleGlow)
                {
                    foreach (InteractableVehicle vehicle in FindObjectsOfType<InteractableVehicle>())
                    {
                        Highlighter highlighter = vehicle.gameObject.GetComponent<Highlighter>();
                        if (vehicle != null)
                        {
                            if (highlighter == null)
                            {
                                vehicle.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.VehicleGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }
                    }
                }

                if (Menu.ItemGlow)
                {
                    foreach (InteractableItem item in FindObjectsOfType<InteractableItem>())
                    {
                        Highlighter highlighter = item.gameObject.GetComponent<Highlighter>();
                        if (item != null)
                        {
                            if (highlighter == null)
                            {
                                item.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.ItemGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }
                    }
                }

                if (Menu.AnimalGlow)
                {
                    foreach (Animal animal in FindObjectsOfType<Animal>())
                    {
                        Highlighter highlighter = animal.gameObject.GetComponent<Highlighter>();
                        if (animal != null)
                        {
                            if (highlighter == null)
                            {
                                animal.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.AnimalGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }
                    }
                }

                if (Menu.StorageGlow)
                {
                    foreach (InteractableStorage storage in FindObjectsOfType<InteractableStorage>())
                    {
                        Highlighter highlighter = storage.gameObject.GetComponent<Highlighter>();
                        if (storage != null)
                        {
                            if (highlighter == null)
                            {
                                storage.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.StorageGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }
                    }
                }

                if (Menu.BedGlow)
                {
                    foreach (InteractableBed bed in FindObjectsOfType<InteractableBed>())
                    {
                        Highlighter highlighter = bed.gameObject.GetComponent<Highlighter>();
                        if (bed != null)
                        {
                            if (highlighter == null)
                            {
                                bed.gameObject.AddComponent<Highlighter>();
                            }
                            highlighter.occluder = true;
                            highlighter.overlay = true;
                            highlighter.ConstantOnImmediate(Color.red);
                        }
                        else if (!Menu.BedGlow)
                        {
                            highlighter.ConstantOffImmediate();
                        }
                    }
                }
            }
        }

        public void OnGUI()
        {
            if (!Provider.isLoading && Provider.isConnected)
            {
                if (Utilities.mainCamera == null)
                {
                    Utilities.mainCamera = Camera.main;
                }

                if (Menu.PlayerESPEnabled)
                {
                    for (int i = 0; i < Provider.clients.Count; i++)
                    {
                        SteamPlayer steamPlayer = Provider.clients[i];
                        float distance = Vector3.Distance(Player.player.transform.position, steamPlayer.player.transform.position);
                      
                        if (steamPlayer.player != null || !steamPlayer.player.life.isDead || steamPlayer.player != Player.player || distance <= Menu.PlayerDistanceVal)
                        {
                            Vector3 position = Utilities.mainCamera.WorldToScreenPoint(steamPlayer.player.transform.position);
                            position.y = Screen.height - position.y;
                            if (position.z >= 0)
                            {
                                string txt = "";

                                if (Menu.PlayerName)
                                {
                                    txt += $"{steamPlayer.player.name}";
                                }
                                if (Menu.PlayerDistance)
                                {
                                    txt += $"\n{Math.Round(distance)}m";
                                }

                                GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"{txt}");
                            }
                        }

                    }
                }


                if (Menu.ZombieESPEnabled)
                {
                    foreach (Zombie zombie in FindObjectsOfType<Zombie>())
                    {
                        float distance = Vector3.Distance(zombie.transform.position, Utilities.mainPlayer.transform.position);
                        if (zombie != null || distance <= Menu.ZombieDistanceVal)
                        {
                            Vector3 position = Utilities.mainCamera.WorldToScreenPoint(zombie.transform.position);
                            position.y = Screen.height - position.y;
                            if (position.z >= 0)
                            {
                                string txt = "";

                                if (Menu.ZombieName)
                                {
                                    txt += $"{zombie.name}";
                                }
                                if (Menu.ZombieDistance)
                                {
                                    txt += $"\n{Math.Round(distance)}m";
                                }

                                GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                            }
                        }
                    }

                }

                if (Menu.VehicleESPEnabled)
                {
                    foreach (InteractableVehicle vehicle in FindObjectsOfType<InteractableVehicle>())
                    {
                        float distance = Vector3.Distance(vehicle.transform.position, Utilities.mainPlayer.transform.position);
                        if (vehicle != null || distance <= Menu.VehicleDistanceVal)
                        {
                            Vector3 position = Utilities.mainCamera.WorldToScreenPoint(vehicle.transform.position);
                            position.y = Screen.height - position.y;
                            if (position.z >= 0)
                            {
                                string txt = "";

                                if (Menu.VehicleName)
                                {
                                    txt += $"{vehicle.asset.vehicleName}";
                                }
                                if (Menu.VehicleDistance)
                                {
                                    txt += $"\n{Math.Round(distance)}m";
                                }

                                GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                            }
                        }
                    }
                }

                if (Menu.ItemESPEnabled)
                {
                    foreach (InteractableItem item in FindObjectsOfType<InteractableItem>())
                    {
                        float distance = Vector3.Distance(item.transform.position, Utilities.mainPlayer.transform.position);
                        if (item != null || distance <= Menu.ItemDistanceVal)
                        {
                            Vector3 position = Utilities.mainCamera.WorldToScreenPoint(item.transform.position);
                            position.y = Screen.height - position.y;
                            if (position.z >= 0)
                            {
                                string txt = "";

                                if (Menu.ItemName)
                                {
                                    txt += $"{item.asset.itemName}";
                                }
                                if (Menu.ItemDistance)
                                {
                                    txt += $"\n{Math.Round(distance)}m";
                                }

                                GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                            }
                        }
                    }

                    if (Menu.AnimalESPEnabled)
                    {
                        foreach (Animal animal in FindObjectsOfType<Animal>())
                        {
                            float distance = Vector3.Distance(animal.transform.position, Utilities.mainPlayer.transform.position);
                            if (animal != null || distance <= Menu.AnimalDistanceVal)
                            {
                                Vector3 position = Utilities.mainCamera.WorldToScreenPoint(animal.transform.position);
                                position.y = Screen.height - position.y;
                                if (position.z >= 0)
                                {
                                    string txt = "";

                                    if (Menu.AnimalName)
                                    {
                                        txt += $"{animal.asset.animalName}";
                                    }
                                    if (Menu.AnimalDistance)
                                    {
                                        txt += $"\n{Math.Round(distance)}m";
                                    }

                                    GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                                }
                            }
                        }
                    }

                    if (Menu.StorageESPEnabled)
                    {
                        foreach (InteractableStorage storage in FindObjectsOfType<InteractableStorage>())
                        {
                            float distance = Vector3.Distance(storage.transform.position, Utilities.mainPlayer.transform.position);
                            if (storage != null || distance <= Menu.StorageDistanceVal)
                            {
                                Vector3 position = Utilities.mainCamera.WorldToScreenPoint(storage.transform.position);
                                position.y = Screen.height - position.y;
                                if (position.z >= 0)
                                {
                                    string txt = "";

                                    if (Menu.StorageName)
                                    {
                                        txt += $"Storage";
                                    }
                                    if (Menu.StorageDistance)
                                    {
                                        txt += $"\n{Math.Round(distance)}m";
                                    }

                                    GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                                }
                            }
                        }
                    }

                    if (Menu.BedESPEnabled)
                    {
                        foreach (InteractableBed bed in FindObjectsOfType<InteractableBed>())
                        {
                            float distance = Vector3.Distance(bed.transform.position, Utilities.mainPlayer.transform.position);
                            if (bed != null || distance <= Menu.BedDistanceVal)
                            {
                                Vector3 position = Utilities.mainCamera.WorldToScreenPoint(bed.transform.position);
                                position.y = Screen.height - position.y;
                                if (position.z >= 0)
                                {
                                    string txt = "";

                                    if (Menu.BedName)
                                    {
                                        txt += $"Bed";
                                    }
                                    if (Menu.BedDistance)
                                    {
                                        txt += $"\n{Math.Round(distance)}m";
                                    }

                                    GUI.Label(new Rect(position + new Vector3(0, 6f, 0), new Vector2(180, 70)), $"{txt}");
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}

