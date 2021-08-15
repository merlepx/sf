using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using sf.Extra;
using SDG.Unturned;

namespace sf.Features
{
    public class Weapons : MonoBehaviour
    {
        public static Rect WeaponInfoWindow = new Rect(200,200, 150,150);


        public void Start()
        {
           
        }
        public void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                ItemGunAsset itemGunAsset = (ItemGunAsset)Player.player.equipment.asset;
                if (itemGunAsset != null)
                {
                    if (Menu.NoRecoil && Player.player.equipment.asset is ItemGunAsset)
                    {
                        itemGunAsset.recoilMax_x = 0f;
                        itemGunAsset.recoilMax_y = 0f;
                        itemGunAsset.recoilMin_x = 0f;
                        itemGunAsset.recoilMin_y = 0f;
                    }
                    if (Menu.NoSpread && Player.player.equipment.asset is ItemGunAsset)
                    {
                        itemGunAsset.spreadAim = 0f;
                        itemGunAsset.spreadHip = 0f;
                        PlayerUI.disableCrosshair();
                        PlayerUI.enableDot();
                    }
                    else
                    {
                        PlayerUI.disableDot();
                        PlayerUI.enableCrosshair();
                    }
                    if (Menu.NoSway && Player.player.equipment.asset is ItemGunAsset)
                    {
                        itemGunAsset.shakeMax_x = 0f;
                        itemGunAsset.shakeMax_y = 0f;
                        itemGunAsset.shakeMax_z = 0f;
                        itemGunAsset.shakeMin_x = 0f;
                        itemGunAsset.shakeMin_y = 0f;
                        itemGunAsset.shakeMin_z = 0f;
                        Player.player.animator.viewSway = Vector3.zero;
                    }
                }
            }
        }
        public void OnGUI()
        {
            if (Menu.WeaponInfo)
            {
                WeaponInfoWindow = GUI.Window(1, WeaponInfoWindow, Window, "Weapon Info");
            }
        }

        private void Window(int id)
        {
            ItemGunAsset itemGunAsset = (ItemGunAsset)Player.player.equipment.asset;

            if (Provider.isConnected && !Provider.isLoading)
            {
                if (Player.player.equipment.asset is ItemGunAsset)
                {
                    string range = itemGunAsset.range.ToString();
                    GUILayout.Label("Range: " + range);
                } 
            }
            GUI.DragWindow();
        }

    }
}
