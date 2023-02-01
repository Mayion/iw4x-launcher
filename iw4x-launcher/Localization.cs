using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iw4x_launcher
{
    class Localization
    {
        private static Localization instance;
        public static Localization Languages
        {
            get
            {
                if (instance == null)
                    instance = new Localization();
                return instance;
            }
        }
        private Localization()
        {

        }

        public string Version = string.Empty;

        public string Main { get; set; }
        public string LabelVersion { get; set; }
        public string LabelVersion_Error { get; set; }
        public string LabelVersion_Error2 { get; set; }
        public string LabelVersion_ErrorSwitch { get; set; }
        public string LabelDLCFiles_Verified { get; set; }
        public string LabelRawFiles_Verified { get; set; }
        public string LabelDLCFiles_Checking { get; set; }
        public string LabelRawFiles_Checking { get; set; }
        public string LabelDLCFiles_Error { get; set; }
        public string LabelRawFiles_Error { get; set; }
        public string Labelc7 { get; set; }
        public string LabelDownload { get; set; }
        public string MenuFix { get; set; }
        public string cbGameVersion { get; set; }
        public string MessageVersionDownload { get; set; }
        public string cbComp { get; set; }
        public string cbSort { get; set; }
        public string LabelHeader1 { get; set; }
        public string LabelHeader2 { get; set; }
        public string LabelHeader3 { get; set; }
        public string LabelHeader4 { get; set; }

        public string ButtonLaunch { get; set; }
        public string ButtonSelect { get; set; }

        public string MsgDebug1 { get; set; }
        public string MsgDebug2 { get; set; }
        public string MsgDebug3 { get; set; }
        public string MsgDebug4 { get; set; }
        public string MsgDebug5 { get; set; }
        public string MsgDebug6 { get; set; }
        public string MsgDebug7 { get; set; }
        public string MsgDebug8 { get; set; }
        public string MsgDebug9 { get; set; }
        public string MsgDebug10 { get; set; }
        public string DLCPatch =
            "co_hunted_load.ff,favela_escape_load.ff,iw4x_code_post_gfx_mp.ff,iw4x_localized_english.ff,iw4x_localized_french.ff,iw4x_localized_russian.ff,iw4x_localized_spanish.ff,iw4x_patch_mp.ff,iw4x_team_militia.ff,iw4x_team_opforce_airborne.ff,iw4x_team_opforce_arctic.ff,iw4x_team_opforce_composite.ff,iw4x_team_seals_udt.ff,iw4x_team_socom_141_arctic.ff,iw4x_team_socom_141_desert.ff,iw4x_team_socom_141_forest.ff,iw4x_team_us_army.ff,iw4x_ui_mp.ff,iw4_credits_load.ff,mp_rust_long_load.ff,mp_shipment.ff,mp_shipment_load.ff,mp_shipment_long_load.ff,oilrig_load.ff,patch_co_hunted.ff,patch_mp_bloc.ff,patch_mp_bloc_sh.ff,patch_mp_bog_sh.ff,patch_mp_cargoship.ff,patch_mp_cargoship_sh.ff,patch_mp_crash_tropical.ff,patch_mp_cross_fire.ff,patch_mp_estate_tropical.ff,patch_mp_fav_tropical.ff,patch_mp_firingrange.ff,patch_mp_killhouse.ff,patch_mp_nuked.ff,patch_mp_rust_long.ff,patch_mp_shipment.ff,patch_mp_shipment_long.ff,patch_mp_storm_spring.ff,patch_oilrig.ff";

        public string DLCFiles = @"zone\dlc\mp_abandon.ff,zone\dlc\mp_abandon_load.ff,zone\dlc\mp_ambush_sh.ff,zone\dlc\mp_backlot.ff,zone\dlc\mp_backlot_load.ff,zone\dlc\mp_bloc.ff,zone\dlc\mp_bloc_load.ff,zone\dlc\mp_bloc_sh.ff,zone\dlc\mp_bloc_sh_load.ff,zone\dlc\mp_bog_sh.ff,zone\dlc\mp_bog_sh_load.ff,zone\dlc\mp_carentan.ff,zone\dlc\mp_carentan_load.ff,zone\dlc\mp_cargoship.ff,zone\dlc\mp_cargoship_load.ff,zone\dlc\mp_cargoship_sh.ff,zone\dlc\mp_cargoship_sh_load.ff,zone\dlc\mp_compact.ff,zone\dlc\mp_compact_load.ff,zone\dlc\mp_complex.ff,zone\dlc\mp_complex_load.ff,zone\dlc\mp_countdown.ff,zone\dlc\mp_countdown_load.ff,zone\dlc\mp_crash.ff,zone\dlc\mp_crash_load.ff,zone\dlc\mp_crash_snow.ff,zone\dlc\mp_crash_snow_load.ff,zone\dlc\mp_crash_tropical.ff,zone\dlc\mp_crash_tropical_load.ff,zone\dlc\mp_cross_fire.ff,zone\dlc\mp_cross_fire_load.ff,zone\dlc\mp_estate_tropical.ff,zone\dlc\mp_estate_tropical_load.ff,zone\dlc\mp_farm.ff,zone\dlc\mp_farm_load.ff,zone\dlc\mp_fav_tropical.ff,zone\dlc\mp_fav_tropical_load.ff,zone\dlc\mp_firingrange.ff,zone\dlc\mp_firingrange_load.ff,zone\dlc\mp_fuel2.ff,zone\dlc\mp_fuel2_load.ff,zone\dlc\mp_killhouse.ff,zone\dlc\mp_killhouse_load.ff,zone\dlc\mp_nuked.ff,zone\dlc\mp_nuked_load.ff,zone\dlc\mp_nuked_shaders.ff,zone\dlc\mp_overgrown.ff,zone\dlc\mp_overgrown_load.ff,zone\dlc\mp_pipeline.ff,zone\dlc\mp_pipeline_load.ff,zone\dlc\mp_rust_long.ff,zone\dlc\mp_rust_long_load.ff,zone\dlc\mp_shipment_long.ff,zone\dlc\mp_shipment_long_load.ff,zone\dlc\mp_storm.ff,zone\dlc\mp_storm_load.ff,zone\dlc\mp_storm_spring.ff,zone\dlc\mp_storm_spring_load.ff,zone\dlc\mp_strike.ff,zone\dlc\mp_strike_load.ff,zone\dlc\mp_trailerpark.ff,zone\dlc\mp_trailerpark_load.ff,zone\dlc\mp_vacant.ff,zone\dlc\mp_vacant_load.ff,zone\dlc\patch_code_post_gfx_mp.ff,zone\dlc\patch_code_pre_gfx_mp.ff,zone\dlc\patch_mp.ff,zone\dlc\team_opfor.ff,zone\dlc\team_opforce_airborne.ff,zone\dlc\team_opforce_composite.ff,zone\dlc\team_rangers.ff,zone\dlc\team_spetsnaz.ff,zone\dlc\team_tf141.ff,zone\dlc\team_us_army.ff,main\iw_dlc3_00.iwd,main\iw_dlc4_00.iwd,main\iw_dlc4_01.iwd,main\iw_dlc5_00.iwd,main\iw_dlc5_01.iwd,main\iw_dlc6_00.iwd,main\iw_dlc7_00.iwd,main\iw_dlc8_00.iwd,main\iw_dlc9_00.iwd";
        public string Godbless =
            @"zone\patch\co_hunted_load.ff:617,zone\patch\favela_escape_load.ff:621,zone\patch\iw4x_code_post_gfx_mp.ff:64131,zone\patch\iw4x_localized_english.ff:1693,zone\patch\iw4x_localized_french.ff:5233,zone\patch\iw4x_localized_russian.ff:4443,zone\patch\iw4x_localized_spanish.ff:5232,zone\patch\iw4x_patch_mp.ff:2897940,zone\patch\iw4x_team_militia.ff:2184621,zone\patch\iw4x_team_opforce_airborne.ff:2875377,zone\patch\iw4x_team_opforce_arctic.ff:2524516,zone\patch\iw4x_team_opforce_composite.ff:2407542,zone\patch\iw4x_team_seals_udt.ff:2856360,zone\patch\iw4x_team_socom_141_arctic.ff:3366362,zone\patch\iw4x_team_socom_141_desert.ff:3270555,zone\patch\iw4x_team_socom_141_forest.ff:3282389,zone\patch\iw4x_team_us_army.ff:3040038,zone\patch\iw4x_ui_mp.ff:1235,zone\patch\iw4_credits_load.ff:619,zone\patch\mp_rust_long_load.ff:622,zone\patch\mp_shipment.ff:68,zone\patch\mp_shipment_load.ff:620,zone\patch\mp_shipment_long_load.ff:624,zone\patch\oilrig_load.ff:617,zone\patch\patch_co_hunted.ff:35027,zone\patch\patch_mp_bloc.ff:1648,zone\patch\patch_mp_bloc_sh.ff:72762,zone\patch\patch_mp_bog_sh.ff:45329,zone\patch\patch_mp_cargoship.ff:405393,zone\patch\patch_mp_cargoship_sh.ff:95311,zone\patch\patch_mp_crash_tropical.ff:286373,zone\patch\patch_mp_cross_fire.ff:1282,zone\patch\patch_mp_estate_tropical.ff:855950,zone\patch\patch_mp_fav_tropical.ff:907362,zone\patch\patch_mp_firingrange.ff:148195,zone\patch\patch_mp_killhouse.ff:1284,zone\patch\patch_mp_nuked.ff:80835,zone\patch\patch_mp_rust_long.ff:22482,zone\patch\patch_mp_shipment.ff:87199,zone\patch\patch_mp_shipment_long.ff:87206,zone\patch\patch_mp_storm_spring.ff:121258,zone\patch\patch_oilrig.ff:36146,iw4x\iw4x_00.iwd:10271636,iw4x\iw4x_01.iwd:51500310,iw4x\iw4x_02.iwd:164";


        public void SetLanguage()
        {
            if (Functions.Methods.SelectedLanguage == Functions.Language.English)
            {
                Main = "IW4X Launcher";

                MessageVersionDownload = "Version {0} is not downloaded. Do you wish to download it right now?";

                LabelVersion = "Currently running version: {0}\r\nSelected Server: {1}";
                cbSort = "Sort by Player Count";
                LabelVersion_Error = "Could not find iw4x.dll!";
                LabelVersion_Error2 = "Could not find iw4x.exe!";
                LabelVersion_ErrorSwitch = "Error. Could not switch game versions!";

                LabelDLCFiles_Verified = "✓ DLC 9 Files Verified.";
                LabelDLCFiles_Checking = "⌛ Checking DLC 9 Files ..";
                LabelDLCFiles_Error = "🚫 Failed to Verify DLC 9 Files.";

                LabelRawFiles_Verified = "✓ v0.0.9 Rawfiles Verified.";
                LabelRawFiles_Checking = "⌛ Checking v0.0.9 Rawfiles ..";
                LabelRawFiles_Error = "🚫 Failed to Verify Rawfiles.";
                cbComp = "Show only Compatible Servers";
                MenuFix = "v0.7.5 Menu Fix";
                
                Labelc7 = "✓ You can run 0.7.x";
                cbGameVersion = "Only Local Game Versions";
                LabelHeader1 = "  Select Game Version  ";
                LabelHeader2 = "  Launcher Options ";
                LabelHeader3 = "Servers";
                LabelHeader4 = "  Select a Server  ";

                ButtonLaunch = "Launch IW4x";
                ButtonSelect = "Select Game Directory";
                LabelDownload = "🡇 Download and Patch";

                MsgDebug1 = "Download Progress: {0}";
                MsgDebug2 = "Error, could not download.";
                MsgDebug3 = "Error, could not retrieve IW4X versions.";
                MsgDebug4 = "Please select game directory.";
                MsgDebug5 = "Game is running.";
                MsgDebug6 = "This will download the v0.0.9 patch files and will make changes to your /zone/patch/ and /iw4x/ folders.\n\nYou are highly advised to backup those folders!\n\nContinue?";
                MsgDebug7 = "You will be redirected to download the official .torrent file containing all the game's DLCs. After which, place all the files in your game directory.\n\nContinue?";
                MsgDebug8 = "Missing DLC Files: ({0}) -> ";
                MsgDebug9 = "Missing Patch Files: ({0}) -> ";
                MsgDebug10 = "The launcher needs to detect the game, so make sure to place it in the game's directory, or to select it using the Select Game Directory button.";
            }
            else if(Functions.Methods.SelectedLanguage == Functions.Language.Russian)
            {
                MessageVersionDownload = "Версия {0} не загружена. Вы хотите загрузить ее прямо сейчас?";
                MsgDebug6 = "Это загрузит файлы патча v0.0.9 и внесет изменения в папки /zone/patch/ и /iw4x/.\n\nНастоятельно рекомендуется создать резервные копии этих папок!\n\nПродолжать?";
                ButtonLaunch = "Открыть IW4x";
                ButtonSelect = "Выберите каталог игр";
                LabelVersion = "Версия0 игры: {0}\r\nВыбранный сервер: {1}";

                cbSort = "Сортировать по количеству игроков";
                LabelVersion_Error = "Не удалось найти iw4x.dll!";
                LabelVersion_Error2 = "Не удалось найти iw4x.exe!";
                LabelVersion_ErrorSwitch = "Ошибка. Не удалось переключить версию игры!";
                MenuFix = "0.7.5 исправление";
                cbGameVersion = "Локальные версии игр";
                LabelDLCFiles_Verified = "✓ DLC 9 файлы Проверено";
                LabelDLCFiles_Checking = "⌛ Проверка DLC 9 Файлы ..";
                LabelDLCFiles_Error = "🚫 не могу проверить DLC 9 Файлы";
                cbComp = "Только совместимые серверы";
                LabelRawFiles_Verified = "✓ v0.0.9 Rawfiles Проверено";
                LabelRawFiles_Checking = "⌛ Проверка v0.0.9 Rawfiles ..";
                LabelRawFiles_Error = "🚫 не могу проверить Rawfiles";

                Labelc7 = "✓ Проверенная версия 0.7.x";
                LabelHeader1 = "  Выберите версию игры  ";
                LabelHeader2 = "  Опции  ";
                LabelHeader4 = "  Выберите сервер  ";
                LabelDownload = "🡇 Загрузка и исправление";
                LabelHeader3 = "Серверы";
                MsgDebug1 = "Скачать Прогресс: {0}";
                MsgDebug2 = "Ошибка, не удалось загрузить";
                MsgDebug3 = "Ошибка, не удалось получить версии IW4X.";
                MsgDebug4 = "Пожалуйста, выберите каталог игр.";
                MsgDebug5 = "Игра запущена.";
                MsgDebug7 = "Вы будете перенаправлены на скачивание официального .torrent-файла, содержащего все DLC игры. После этого поместите все файлы в каталог игры.\n\nПродолжать?";
                MsgDebug8 = "Отсутствующие файлы DLC: ({0}) -> ";
                MsgDebug9 = "Отсутствующие файлы патчей: ({0}) -> "; 
                MsgDebug10 =
                    "Программа запуска должна обнаружить игру, поэтому убедитесь, что она помещена в каталог игры, или выберите ее с помощью кнопки Выберите каталог игр.";
            }
        }
    }
}
